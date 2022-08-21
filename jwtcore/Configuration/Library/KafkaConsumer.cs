using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using jwtcore.Configuration.Library.Interface;
using Microsoft.Extensions.Logging;

namespace jwtcore.Configuration.Library
{

    public abstract class KafkaConsumer< TKey, TMessage, TKeyDeserializer, TMessageDeserializer>: IkafkaConsumer
    where TMessageDeserializer:IDeserializer<TMessage>
    where TKeyDeserializer:IDeserializer<TKey>
    
    {
        public readonly ILogger _logger;
        private readonly KafkaConfiguration _kafkaConfiguration;
        private readonly string _className;

        public static event EventHandler<KafkaConsumerMessageArgs<TKey,TMessage>> MessageReceivedEvent;
        protected KafkaConsumer(ILogger logger,KafkaConfiguration kafkaConfiguration)
        {
           _logger = logger;
           _kafkaConfiguration = kafkaConfiguration;
           _className = GetType().Name;
        }

        protected abstract TMessageDeserializer ValueDeserializer {get;}
        protected abstract TKeyDeserializer KeyDeserializer {get;}
        public abstract string ConsumerName {get;}

        private KafkaConsumerConfiguration ConsumerConfiguration => _kafkaConfiguration.Consumers[ConsumerName];

        public Task StartAsync(CancellationToken cancellationToken)
        {

            
            var (AutoCommit, consumer) = SetupConsumer();
            
  
            return Task.Run(()=>{
 
               using (consumer){

                   try {

                       if (consumer == null){
                           throw new OperationCanceledException("The consumer was not built successfully"); 
                       }


                       consumer.Subscribe(ConsumerConfiguration.TopicId);
                       while (!cancellationToken.IsCancellationRequested){

                           ConsumeResult<TKey,TMessage> consumeResult;
                           try {
                               consumeResult = consumer.Consume(cancellationToken);
                  
                           } catch (ConsumeException e){
                              _logger.LogError("Exception Reason: {reason}, " +
                                                         "topic: {topic}, " +
                                                         "partition: {partition} " +
                                                         "offset: {offset}",
                                                          e.Error.Reason,
                                                          e.ConsumerRecord.Topic,
                                                          e.ConsumerRecord.Partition,
                                                          e.ConsumerRecord.Offset);
                                continue;
                           }
                           string message = "received message from topic : {topic-partition-offset}";
                           if (consumeResult.Message == null){
                               _logger.LogError("No message found for topic {topic}", consumeResult.Topic);
                           }
                           var key = consumeResult.Message.Key;
                           var value = consumeResult.Message.Value;

                           _logger.LogInformation(message + " and has the key :{key}, and value: {value}", 
                                                              consumeResult.TopicPartition, key, value);

                           if (MessageReceivedEvent != null){
                                       
                                  MessageReceivedEvent(this, new KafkaConsumerMessageArgs<TKey, TMessage>{
                                      Key = key,
                                      Value = value
                                  });

                           }
                           if(!AutoCommit){

                               consumer.Commit(consumeResult);

                           }

                       }
                       
                   } catch (OperationCanceledException ex){
                        _logger.LogError("The consumer consumption has been cancelled ",_className, ex.Message);
                   }
               }
   

            }); 

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask; 
        }
        //bool, 
        protected virtual (bool, IConsumer<TKey,TMessage>) SetupConsumer(){

            

            var conf = new ConsumerConfig
            {

               BootstrapServers=_kafkaConfiguration.BootstrapServers,
               GroupId = ConsumerConfiguration.GroupId,
               EnableAutoCommit=ConsumerConfiguration.AutoCommit,
               AutoOffsetReset = AutoOffsetReset.Earliest

            };
            
            if (conf.BootstrapServers.Contains("localhost")){
                // conf.SaslMechanism = SaslMechanism.Plain;
                // conf.SecurityProtocol = SecurityProtocol.Plaintext;
            }

            var builder = new ConsumerBuilder<TKey,TMessage>(conf);
            if (KeyDeserializer != null){
                builder.SetKeyDeserializer(KeyDeserializer);
            }
            if (ValueDeserializer != null){
                builder.SetValueDeserializer(ValueDeserializer);
                _logger.LogInformation("set serializer"+ValueDeserializer);
            }
            IConsumer<TKey,TMessage> consumer = null;
            try {
              consumer = builder.Build();
            } catch (Exception e){
     
                _logger.LogError("Something went wrong building the consumer "+e.Message);

            }
            return (conf.EnableAutoCommit.Value && conf.EnableAutoCommit.HasValue, consumer);

        }

    } 

    
}
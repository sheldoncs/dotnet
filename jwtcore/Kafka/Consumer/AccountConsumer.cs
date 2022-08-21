using System;
using Confluent.Kafka;
using jwrcore.Kafka.Consumer.Deserialize;
using jwtcore.Configuration;
using jwtcore.Configuration.Library;
using jwtcore.Data.Entities.Dtos;
using Microsoft.Extensions.Logging;

namespace jwtcore.Kafka.Consumer {

    public class AccountConsumer : KafkaConsumer<string,  FacultyDto, IDeserializer<string>, IDeserializer<FacultyDto>>
    {
        
        public override string ConsumerName => "LawBrokerage";

        protected override  IDeserializer<string> KeyDeserializer => null;
        protected override IDeserializer<FacultyDto> ValueDeserializer => new AccountDeserializer(_logger);
        public AccountConsumer(ILogger<AccountConsumer> Logger,KafkaConfiguration KafkaConfiguration) : base(Logger,KafkaConfiguration)
        {
           MessageReceivedEvent += AccountConsumerMessageReceivedEvent;
        }

        

      
        private void AccountConsumerMessageReceivedEvent(object sender, KafkaConsumerMessageArgs<string, FacultyDto> e){
             _logger.LogInformation("Message Received: key: {key}, value:{value}",e.Key, e.Value);

             
        }


       
    }
}
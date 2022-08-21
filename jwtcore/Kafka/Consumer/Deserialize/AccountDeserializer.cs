using System;
using System.Text;
using System.Text.Json;
using Confluent.Kafka;
using jwtcore.Data.Entities.Dtos;
using Microsoft.Extensions.Logging;

namespace jwrcore.Kafka.Consumer.Deserialize {

    public class AccountDeserializer : IDeserializer<FacultyDto>
    {
        private readonly ILogger _logger;

        public AccountDeserializer (ILogger logger){
            _logger = logger;
        }
        public FacultyDto Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            string str = Encoding.UTF8.GetString(data);
             _logger.LogInformation(str);
            
            try {
                   var accountTopic = JsonSerializer.Deserialize<FacultyDto>(data);
                   if (accountTopic == null){
                       throw new InvalidOperationException($"Could not parse the received payload to {nameof(FacultyDto)}");
                   }
                   return accountTopic;
                   
            } catch (Exception exception){

                _logger.LogError(exception,"Error when parsing Account Topic");
                throw;
            }

           
           
            
        }
    }
}
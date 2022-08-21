

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace jwtcore.Configuration {

    public class KafkaConfiguration {

       private List<string> BootstrapServerList; 

       public virtual Dictionary<string, KafkaConsumerConfiguration> Consumers { get; } =
            new Dictionary<string, KafkaConsumerConfiguration>();
       public virtual string BootstrapServers
            => BootstrapServerList != null ? string.Join(",", BootstrapServerList) : "";

       public KafkaConfiguration (IConfiguration configuration){
          
           BootstrapServerList = configuration.GetSection("Confluent:Kafka:BootstrapServers").Get<List<string>>();
           configuration.GetSection("Confluent:Kafka:Consumers").Bind(Consumers);

       }
        
    }
}
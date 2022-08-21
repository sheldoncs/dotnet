namespace jwtcore.Configuration {

    public class KafkaConsumerConfiguration {

        public string TopicId {get; set;}
        public string GroupId {get; set;}
        public bool AutoCommit {get; set;}
       
    }
}
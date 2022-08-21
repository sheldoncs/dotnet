using Microsoft.Extensions.Hosting;

namespace jwtcore.Configuration.Library.Interface {

    public interface IkafkaConsumer: IHostedService {

       string ConsumerName {get;}

    }
}
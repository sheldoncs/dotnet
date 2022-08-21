using jwtcore.Configuration;
using jwtcore.Configuration.Library.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace jwtcore.CollectionFactory {

    public static class ServiceCollectionExtensions {

        public static IServiceCollection Addkafka(this IServiceCollection serviceCollection){

              serviceCollection.AddSingleton<KafkaConfiguration>();

              return serviceCollection;

        }

        public static IServiceCollection AddKafkaConsumer <T> (this IServiceCollection serviceCollection) where T : class, IkafkaConsumer
        {

           serviceCollection.AddSingleton<T>();
           serviceCollection.AddHostedService(service => service.GetRequiredService<T>());
        //    serviceCollection.AddHostedService(service => {
        //        return service.GetRequiredService<T>();
        //    });

           return serviceCollection;
        } 

    }
}
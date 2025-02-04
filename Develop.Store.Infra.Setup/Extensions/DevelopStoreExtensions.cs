using Develop.Store.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Develop.Store.Infra.Setup.Extensions
{
    public static class DevelopStoreExtensions
    {
        public static IServiceCollection AddDevelopStoreContext(this IServiceCollection services, IConfiguration config)
        {
            return services
                 .AddScoped(sp =>
                    new DevelopStoreContext(
                        sp.GetRequiredService<MongoClient>().GetDatabase(config.GetConnectionString("DevelopStoreDatabase"))
                    )
                );
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NFT.Domain.Services;
using NFT.Infrastructure.Services;

namespace NFT.BootStrapper
{
    public static class BootStrapper
    {
        public static ServiceProvider CreateServices()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json") 
                .Build();

            return new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .AddTransient<INFTServices, NFTServices>()
                .AddTransient<IAPIServices, APIServices>()
                .AddSingleton(configuration)
                .AddTransient<IDataServices,DataServices>()
                .BuildServiceProvider();
        }
  
    }
}

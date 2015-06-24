using System.Configuration;
using System.Reflection;
using DataSync.Common.AxisMessages.Contract;
using NServiceBus;

namespace DataSync.Store.StoreMessageDownloader
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.AssembliesToScan(Assembly.GetExecutingAssembly(), typeof(AxisMessage).Assembly,  typeof(AzureStorageQueueTransport).Assembly);
            
            string transportConnectionString = GetConnectionString();
            
            configuration.UseTransport<AzureStorageQueueTransport>().ConnectionString(transportConnectionString);
            configuration.UseTransport<AzureStorageQueueTransport>()
                .BatchSize(int.Parse(ConfigurationManager.AppSettings["AzureDownloadBatchSize"]));

            configuration.UseTransport<AzureStorageQueueTransport>()
                .PeekInterval(int.Parse(ConfigurationManager.AppSettings["AzureDownloadPeekInterval"]));
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EndpointName(ConfigurationManager.AppSettings["StoreKey"]);
        }


        protected string GetConnectionString()
        {
            return "DefaultEndpointsProtocol=https;AccountName=[Name];AccountKey=[Key]";
        }
    }
}
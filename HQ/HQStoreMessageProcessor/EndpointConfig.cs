
using System.Reflection;
using DataSync.Common.AxisMessages.Contract;
using Microsoft.WindowsAzure;
using NServiceBus;

namespace DataSync.HQ.HQStoreMessageProcessor
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.AssembliesToScan(Assembly.GetExecutingAssembly(), typeof(AxisMessage).Assembly, typeof(ReportStoreMessage).Assembly, typeof(AzureStorageQueueTransport).Assembly);
            configuration.UseTransport<AzureStorageQueueTransport>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EndpointName("50000");
            configuration.Transactions().DoNotWrapHandlersExecutionInATransactionScope();
            configuration.Transactions().Disable();
        }
    }
}
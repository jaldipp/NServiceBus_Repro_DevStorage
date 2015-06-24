using System;
using DataSync.Common.AxisMessages.Contract;
using NServiceBus;

namespace Repro.MessageSender
{
    class MessageSender
    {
        static void Main(string[] args)
        {
            var config = new BusConfiguration();
            config.UsePersistence<InMemoryPersistence>();
            config.UseTransport<AzureStorageQueueTransport>();
            ServiceBus = Bus.CreateSendOnly(config);

            ReportStoreMessage message = new ReportStoreMessage();

            message.CompanyID = 50000;
            message.CompanyStoreID = 1;
            message.Identifier = "999243463345888";
            message.Timestamp = DateTime.Now;


            ServiceBus.Send("50000", message);

            Console.WriteLine("Message sent");
            Console.ReadLine();
        }

        public static ISendOnlyBus ServiceBus { get; set; }
    }
}

using System;
using System.Data.SqlClient;
using DataSync.Common.AxisMessages.Contract;
using NServiceBus;

namespace DataSync.Store.StoreMessageDownloader
{
    public class StoreDownloadableMessageHandler : IHandleMessages<AxisMessage>
    {
        public IBus Bus { get; set; }

        private AxisMessage _message;

        public void Handle(AxisMessage message)
        {
            throw new Exception("fail");
        }
    }
}
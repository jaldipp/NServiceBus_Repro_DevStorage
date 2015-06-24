using DataSync.Common.AxisMessages.Contract;
using NServiceBus;
using NServiceBus.Logging;

namespace DataSync.HQ.HQStoreMessageProcessor
{
    public class StoreOutboundMessageHandler : IHandleMessages<AxisStoreOutboundMessage>
    {
        private ILog logger = LogManager.GetLogger<AxisStoreDistributableOutboundMessage>();
        public void Handle(AxisStoreOutboundMessage message)
        {
            logger.Info("Save data and perform business logic for the command at HQ " + message.Timestamp);
        }
    }
}
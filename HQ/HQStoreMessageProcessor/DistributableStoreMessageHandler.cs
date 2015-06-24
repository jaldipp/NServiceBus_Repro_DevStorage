using DataSync.Common.AxisMessages.Contract;
using NServiceBus;
using NServiceBus.Logging;

namespace DataSync.HQ.HQStoreMessageProcessor
{
    public class DistributableStoreMessageHandler : IHandleMessages<AxisStoreDistributableOutboundMessage>
    {
        public IBus Bus { get; set; }
        private ILog logger = LogManager.GetLogger<AxisStoreDistributableOutboundMessage>();

        public void Handle(AxisStoreDistributableOutboundMessage message)
        {
            logger.Info("Distribute message that was started at " + message.Timestamp);
            logger.Info("and throwing exception");
            Bus.Send("6E326F85-D7E6-4E1D-8E63-0920556548EA", message);
        }

    }
}
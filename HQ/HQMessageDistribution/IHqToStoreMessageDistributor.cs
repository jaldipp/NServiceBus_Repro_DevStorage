using DataSync.Common.AxisMessages.Contract;
using NServiceBus;

namespace DataSync.HQ.HQMessageDistribution
{
    public interface IHqToStoreMessageDistributor
    {
        void DistributeMessage(IBus bus, AxisMessage message);
    }
}
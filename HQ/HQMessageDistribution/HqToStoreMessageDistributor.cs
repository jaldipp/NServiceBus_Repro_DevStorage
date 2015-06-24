using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Axis.Enterprise.DIContainer;
using Axis.HQDataSync.BusinessService.Interface;
using DataSync.Common.AxisMessages.Contract;
using NServiceBus;

namespace DataSync.HQ.HQMessageDistribution
{
    internal class HqToStoreMessageDistributor : IHqToStoreMessageDistributor
    {
        private AxisMessage Message { get; set; }
        private IDictionary<int,string> DistributionList { get; set; }

        public HqToStoreMessageDistributor()
        {
            DistributionList = AxisServiceLocator.GetInstance<IRetrieveStoreList>().GetStoreIDWithKeyList();
        }

        public void DistributeMessage(IBus bus, AxisMessage message)
        {
            Message = message;
            foreach (var pair in DistributionList)
            {
                if (CanSendToStore(pair.Key))
                {
                    Console.WriteLine("Sending message from cloud to store " + pair.Key);
                    bus.Send(pair.Value, message);
                }
            }
        }

        private bool CanSendToStore(int companyStoreID)
        {
            AxisStoreMessage storeMessage = Message as AxisStoreMessage;
            if (storeMessage != null)
                return storeMessage.CompanyStoreID != companyStoreID;
            return true;
        }
    }
}
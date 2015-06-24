using Axis.Enterprise.DIContainer;

namespace DataSync.HQ.HQMessageDistribution
{
    public class HqMessageDistributionDiInitialize : BaseDiComponentInitialize
    {
        private static IDiComponentInitialization _instance;

        private HqMessageDistributionDiInitialize()
        {
        }

        public static IDiComponentInitialization Instance
        {
            get { return _instance ?? (_instance = new HqMessageDistributionDiInitialize()); }
        }

        protected override void RegisterTypes()
        {
            AxisServiceLocator.RegisterType<IHqToStoreMessageDistributor, HqToStoreMessageDistributor>();
        }
    }
}
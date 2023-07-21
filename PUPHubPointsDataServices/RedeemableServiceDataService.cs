using PUPHubPointsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsDataServices
{
    public class RedeemableServiceDataService
    {
        IRedeeemableServiceData _redeemableServiceData;

        public RedeemableServiceDataService(IRedeeemableServiceData redeemableServiceData)
        {
            _redeemableServiceData = redeemableServiceData;
        }

        public List<RedeemableService> GetServices()
        {
            return _redeemableServiceData.GetServices();
        }

        public RedeemableService GetService(string serviceName)
        {
            return _redeemableServiceData.GetService(serviceName);
        }

        public int GetServicePoints(string serviceName)
        {
            return _redeemableServiceData.GetServicePoints(serviceName);
        }
        
        public void AddService(RedeemableService redeemableService)
        {
            _redeemableServiceData.AddService(redeemableService);
        }

        public void UpdateService(RedeemableService redeemableService)
        {
            _redeemableServiceData.UpdateService(redeemableService);
        }

        public void DeleteService(RedeemableService redeemableService)
        {
            _redeemableServiceData.DeleteService(redeemableService);
        }
    }
}

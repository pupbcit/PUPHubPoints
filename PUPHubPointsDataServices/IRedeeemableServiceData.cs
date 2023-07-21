using PUPHubPointsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsDataServices
{
    public interface IRedeeemableServiceData
    {

        List<RedeemableService> GetServices();

        RedeemableService GetService(string serviceName);

        int GetServicePoints(string serviceName);

        int AddService(RedeemableService redeemableService);

        void UpdateService(RedeemableService redeemableService);

        void DeleteService(RedeemableService redeemableService);
    }
}

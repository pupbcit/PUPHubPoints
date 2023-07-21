using PUPHubPointsDataServices;
using PUPHubPointsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsBusinessRules
{
    public class RedeemableServicesRulesService
    {
        private RedeemableServiceDataService redeemableServiceDataService;

        public RedeemableServicesRulesService()
        {
            redeemableServiceDataService = new RedeemableServiceDataService(new SqlData());
        }

        public List<RedeemableService> GetServices()
        {
            return redeemableServiceDataService.GetServices();
        }

        public RedeemableService GetService(string serviceName)
        {
            return redeemableServiceDataService.GetService(serviceName);
        }

        public int GetServicePoints(string serviceName)
        {
            return redeemableServiceDataService.GetServicePoints(serviceName);
        }

        public int AddService(RedeemableService redeemableService)
        {
            int success = 0;
            if (IsRedeemableServiceValid(redeemableService))
            {
                redeemableServiceDataService.AddService(redeemableService);
                success = 1;
            }
            return success;
        }

        private bool IsRedeemableServiceValid(RedeemableService redeemableService)
        {
            var isNotExisting = GetService(redeemableService.ServiceName).ServiceName == null;

            var isValidPoints = redeemableService.RequiredPoints >= 0;

            return isNotExisting && isValidPoints;
        }

        public int UpdateService(RedeemableService redeemableService)
        {
            int success = 0;
            if (redeemableService.RequiredPoints >= 0)
            {
                redeemableServiceDataService.UpdateService(redeemableService);
                success = 1;
            }
            return success;
        }

        public void DeleteService(RedeemableService redeemableService)
        {
            redeemableServiceDataService.DeleteService(redeemableService);
        }
    }
}

using PUPHubPointsDataServices;
using PUPHubPointsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsBusinessRules
{
    public class RedeemableProductRulesService
    {
        private RedeemableProductDataService redeemableProductDataService;

        public RedeemableProductRulesService()
        {
            redeemableProductDataService = new RedeemableProductDataService(new SqlData());
        }

        public List<RedeemableProduct> GetProducts()
        {
            return redeemableProductDataService.GetProducts();
        }

        public RedeemableProduct GetProduct(string productName)
        {
            return redeemableProductDataService.GetProduct(productName);
        }

        public int GetProductPoints(string productName)
        {
            return redeemableProductDataService.GetProductPoints(productName);
        }

        public int AddProduct(RedeemableProduct redeemableProduct)
        {
            if (IsRedeemableProductValid(redeemableProduct))
            {
                redeemableProductDataService.AddProduct(redeemableProduct);
                return 1; //success
            }
            else
            {
                return 0;
            }
        }

        public int UpdateProduct(RedeemableProduct redeemableProduct)
        {
            if (redeemableProduct.RequiredPoints >= 0)
            {
                redeemableProductDataService.UpdateProduct(redeemableProduct);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void DeleteProduct(RedeemableProduct redeemableProduct)
        {
            redeemableProductDataService.DeleteProduct(redeemableProduct);
        }

        private bool IsRedeemableProductValid(RedeemableProduct redeemableProduct)
        {
            var isNotExisting = GetProduct(redeemableProduct.ProductName).ProductName == null;
            var isValidPoints = redeemableProduct.RequiredPoints >= 0;
            var isValidQty = redeemableProduct.RedeemableQty >= 0;

            return isNotExisting && isValidPoints && isValidQty;

        }

    }
}

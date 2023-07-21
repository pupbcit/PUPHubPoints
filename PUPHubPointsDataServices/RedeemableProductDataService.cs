using PUPHubPointsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsDataServices
{
    public class RedeemableProductDataService
    {
        IRedeemableProductData _redeemableProductData;

        public RedeemableProductDataService(IRedeemableProductData redeemableProductData)
        {
            _redeemableProductData = redeemableProductData;
        }

        public List<RedeemableProduct> GetProducts()
        {
            return _redeemableProductData.GetProducts();
        }

        public RedeemableProduct GetProduct(string productName)
        {
            return _redeemableProductData.GetProduct(productName);
        }

        public int GetProductPoints(string productName)
        {
            return _redeemableProductData.GetProductPoints(productName);
        }

        public void AddProduct(RedeemableProduct RedeemableProduct)
        {
            _redeemableProductData.AddProduct(RedeemableProduct);
        }

        public void UpdateProduct(RedeemableProduct RedeemableProduct)
        {
            _redeemableProductData.UpdateProduct(RedeemableProduct);
        }

        public void DeleteProduct(RedeemableProduct RedeemableProduct)
        {
            _redeemableProductData.DeleteProduct(RedeemableProduct);
        }
    }
}

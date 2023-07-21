using PUPHubPointsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsDataServices
{
    public interface IRedeemableProductData
    {
        List<RedeemableProduct> GetProducts();

        RedeemableProduct GetProduct(string productName);

        int GetProductPoints(string productName);

        int AddProduct(RedeemableProduct redeemableProduct);

        void UpdateProduct(RedeemableProduct redeemableProduct);

        void DeleteProduct(RedeemableProduct redeemableProduct);
    }
}

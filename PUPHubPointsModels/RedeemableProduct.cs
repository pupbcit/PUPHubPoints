using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsModels
{
    public class RedeemableProduct
    {
        public string ProductName { get; set; }
        public int RedeemableQty { get; set; }
        public int RequiredPoints { get; set; }
    }
}

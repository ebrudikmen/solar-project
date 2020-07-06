using System.Collections.Generic;

namespace SolarProject.Models
{
    public class BuyRequest
    {
        public List<CodeWithQuantity> codeWithQuantities { get; set; }

        public string paymentType { get; set; }

        public BuyRequest()
        {
            codeWithQuantities = new List<CodeWithQuantity>();
        }
    }
}

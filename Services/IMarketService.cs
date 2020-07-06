using System.Collections.Generic;
using SolarProject.Models;

namespace SolarProject.Services
{
    public interface IMarketService
    {
        public List<Product> GetProducts();

        public Product GetProduct(long id);

        public Product AddProduct(Product product);

        public Product UpdateProduct(long id, Product product);

        public Product DeleteProduct(long id);

        public Product UpdateStore(long id, int quantity);

        public List<Product> BuyProducts(List<CodeWithQuantity> codeWithQuantities);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using SolarProject.Models;

namespace SolarProject.Services
{
    public class MarketService : IMarketService
    {
        private readonly SolarContext _solarContext;

        public MarketService(SolarContext solarContext)
        {
            _solarContext = solarContext;
        }

        public List<Product> GetProducts()
        {
            return _solarContext.Products.ToList();
        }

        public Product GetProduct(long id)
        {
            var foundProduct =  _solarContext.Products.Find(id);

            if (foundProduct == null)
            {
                throw new Exception("Not found exception: " + id);
            }

            return foundProduct;
        }

        public Product AddProduct(Product product)
        {
            var addedProduct = _solarContext.Products.Add(product).Entity;

            _solarContext.SaveChanges();

            return addedProduct;
        }

        public Product UpdateProduct(long id, Product product)
        {
            var foundProduct = _solarContext.Products.Find(id);

            if (foundProduct == null)
            {
                throw new Exception("Not found exception: " + id);
            }

            foundProduct.Code = product.Code;
            foundProduct.Name = product.Name;
            foundProduct.Price = product.Price;
            foundProduct.Quantity = product.Quantity;

            var updatedProduct = _solarContext.Products.Update(foundProduct).Entity;
            
            _solarContext.SaveChanges();
            
            return updatedProduct;
        }

        public Product DeleteProduct(long id)
        {
            var foundProduct = _solarContext.Products.Find(id);

            if (foundProduct == null)
            {
                throw new Exception("Not found exception: " + id);
            }
            
            var deletedProduct = _solarContext.Products.Remove(foundProduct).Entity;

            _solarContext.SaveChanges();
            
            return deletedProduct;
        }

        public Product UpdateStore(long id, int quantity)
        {
            var foundProduct = _solarContext.Products.Find(id);

            if (foundProduct == null)
            {
                throw new Exception("Not found exception: " + id);
            }

            foundProduct.Quantity = quantity;

            var updatedProduct = _solarContext.Products.Update(foundProduct).Entity;

            _solarContext.SaveChanges();

            return updatedProduct;
        }

        public List<Product> BuyProducts(List<CodeWithQuantity> codeWithQuantities)
        {
            List<Product> boughtProducts = new List<Product>();

            foreach(CodeWithQuantity codeWithQuantity in codeWithQuantities)
            {
                var products = _solarContext.Products.Where(product => product.Code == codeWithQuantity.code).ToList();

                if(products.Count == 0)
                {
                    throw new Exception("Product does not exist: " + codeWithQuantity.code);
                }else if (products.Count > 1)
                {
                    throw new Exception("Technical problem: " + codeWithQuantity.code);
                }

                var foundProduct = products.First();

                if(foundProduct.Quantity < codeWithQuantity.quantity)
                {
                    throw new Exception("Product does not have enough quantity: " + codeWithQuantity.code);
                }

                foundProduct.Quantity = foundProduct.Quantity - codeWithQuantity.quantity;

                var updatedProduct = _solarContext.Products.Update(foundProduct).Entity;

                _solarContext.SaveChanges();

                var boughtProduct = updatedProduct;

                boughtProduct.Quantity = codeWithQuantity.quantity;

                boughtProducts.Add(boughtProduct);
            }  
            
            return boughtProducts; 
        }
    }
}
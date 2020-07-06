using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SolarProject.Models;
using SolarProject.Services;

namespace SolarProject.Controllers
{
    [ApiController]
    public class MarketMicroService : Controller
    {
        private readonly IMarketService _marketMicroService;

        public MarketMicroService(IMarketService marketMicroService)
        {
            _marketMicroService = marketMicroService;
        }

        [HttpGet("/api/products")]
        public ActionResult<List<Product>> GetProducts()
        {
            return Json(_marketMicroService.GetProducts());
        }

        [HttpGet("/api/products/{id}")]
        public ActionResult<Product> GetProduct(long id)
        {
            return Json(_marketMicroService.GetProduct(id));
        }

        [HttpPost("/api/products")]
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            return Json(_marketMicroService.AddProduct(product));
        }

        [HttpPut("/api/products/{id}")]
        public ActionResult<Product> UpdateProduct([FromRoute] long id, [FromBody] Product product)
        {
            return Json(_marketMicroService.UpdateProduct(id, product));
        }

        [HttpDelete("/api/products/{id}")]
        public ActionResult<Product> DeleteProduct([FromRoute] long id)
        {
            return Json(_marketMicroService.DeleteProduct(id));
        }

        [HttpPut("/api/products/{id}/store")]
        public ActionResult<bool> UpdateStore([FromRoute] long id, [FromQuery] int quantity)
        {
            return Json(_marketMicroService.UpdateStore(id, quantity));
        }
    }
}
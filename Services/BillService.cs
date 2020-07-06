using SolarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolarProject.Services
{
    public class BillMicroService : IBillService
    {
        private readonly IMarketService _marketMicroService;

        private readonly SolarContext _solarContext;

        public BillMicroService(SolarContext solarContext, IMarketService marketMicroService = null)
        {
            _solarContext = solarContext;
            _marketMicroService = marketMicroService;
        }

        public Bill AddBill(BuyRequest buyRequest)
        {
            List<Product> boughtProducts = _marketMicroService.BuyProducts(buyRequest.codeWithQuantities);

            double total = 0;
            foreach(Product boughtProduct in boughtProducts)
            {
                total += boughtProduct.Price * boughtProduct.Quantity;
            }

            var bill = new Bill();
            bill.Products = boughtProducts;
            bill.BillingDate = DateTime.Now;
            bill.PaymentType = buyRequest.paymentType;
            bill.Amount = total;

            var addedBill = _solarContext.Bills.Add(bill).Entity;

            _solarContext.SaveChanges();

            return addedBill;
        }

        public Bill DeleteBill(long id)
        {
            var foundBill = _solarContext.Bills.Find(id);

            if (foundBill == null)
            {
                throw new Exception("Not found exception: " + id);
            }

            var deletedBill = _solarContext.Bills.Remove(foundBill).Entity;

            _solarContext.SaveChanges();

            return deletedBill;
        }

        public Bill GetBill(long id)
        {
            var foundBill = _solarContext.Bills.Find(id);

            if (foundBill == null)
            {
                throw new Exception("Not found exception: " + id);
            }

            return foundBill;
        }

        public List<Bill> GetBills()
        {
            return _solarContext.Bills.ToList();
        }

        public Bill UpdateBill(long id, Bill bill)
        {

            var foundBill = _solarContext.Bills.Find(id);

            if (foundBill == null)
            {
                throw new Exception("Not found exception: " + id);
            }

            foundBill.BillingDate = bill.BillingDate;
            foundBill.Amount = bill.Amount;
            foundBill.PaymentType = bill.PaymentType;
            foundBill.Products = bill.Products;

            var updatedBill = _solarContext.Bills.Update(foundBill).Entity;

            _solarContext.SaveChanges();

            return updatedBill;
        }
    }
}
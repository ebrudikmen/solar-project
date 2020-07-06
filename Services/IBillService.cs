using SolarProject.Models;
using System.Collections.Generic;

namespace SolarProject.Services
{
    public interface IBillService
    {
        public Bill AddBill(BuyRequest buyRequest);

        public List<Bill> GetBills();

        public Bill GetBill(long id);

        public Bill UpdateBill(long id, Bill bill);

        public Bill DeleteBill(long id);
    }
}
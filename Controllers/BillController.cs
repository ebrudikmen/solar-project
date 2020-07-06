using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SolarProject.Models;
using SolarProject.Services;

namespace SolarProject.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost("/api/bills")]
        public ActionResult<Bill> AddBill([FromBody] BuyRequest buyRequest)
        {
            return Json(_billService.AddBill(buyRequest));
        }

        [HttpGet("/api/bills")]
        public ActionResult<List<Bill>> GetBills()
        {
            return Json(_billService.GetBills());
        }

        [HttpGet("/api/bills/{id}")]
        public ActionResult<Bill> GetBill([FromRoute] long id)
        {
            return Json(_billService.GetBill(id));
        }

        [HttpPut("/api/bills/{id}")]
        public ActionResult<Bill> UpdateBill([FromRoute] long id, [FromBody] Bill bill)
        {
            return Json(_billService.UpdateBill(id, bill));
        }

        [HttpDelete("/api/bills/{id}")]
        public ActionResult<Bill> DeleteBill([FromRoute] long id)
        {
            return Json(_billService.DeleteBill(id));
        }
    }
}

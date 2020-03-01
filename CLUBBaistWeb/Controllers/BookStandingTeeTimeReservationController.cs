using CLUBBaistWeb.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLUBBaistWeb.Controllers
{
    public class BookStandingTeeTimeReservationController : Controller
    {
        // GET: BookStandingTeeTimeReservation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddBooking(BookTeeTimeReservation objBoookstanding)
        {
            string message = string.Empty;
            bool status = false;
            try
            {

            }
            catch (Exception ex)
            {
                status = false; message = ex.Message.ToString();
                return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLUBBaistWeb.Controllers
{
    public class BookTeeTimeReservationController : Controller
    {
        // GET: BookTeeTimeReservation
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ReserverTime(string ReservationList)
        { 
            string Message = string.Empty;
            try
            {
                string SelectedItem = ReservationList;
                DateTime reservation = DateTime.Parse(SelectedItem);
                Reservations CBRD = new Reservations();
                Message= CBRD.CancelReservation(reservation, reservation, int.Parse(Session["MemberNumber"].ToString())).ToString();
                return Json(true, Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) 
            {
                return Json(false, ex.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
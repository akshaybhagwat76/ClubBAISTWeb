using CLUBBaistWeb.Helper;
using CLUBBaistWeb.Repositories;
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
            int MemberNumber = 0;
            try
            {
                MemberNumber = int.Parse(Session["MemberNumber"].ToString());
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "LogIn");
            }
            return View();
        }
        [HttpPost]
        public JsonResult AddStandingTeeTime(BookStandingTeeTimeReservationVM objBoookstanding)
        {
            string message = string.Empty;
            bool status = false;
            try
            {
                if (objBoookstanding != null)
                {
                    string[] reserve = objBoookstanding.RequestedTime.Split(',');
                    int hours = int.Parse(reserve[0]);
                    int minutes = int.Parse(reserve[1]);

                    if (reserve[2] == "PM" && hours != 12)
                        hours += 12;

                    var timeTee = hours.ToString() + ":" + minutes.ToString();
                    objBoookstanding.RequestedTime = timeTee;
                    var response = new ReservationRepository().AddStandingReservation(objBoookstanding);
                    if (response)
                    {
                        status = response;
                        message = "Successfully added";
                        return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
                    }
                }
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
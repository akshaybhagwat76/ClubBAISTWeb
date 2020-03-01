using CLUBBaistWeb.Helper;
using CLUBBaistWeb.Repositories;
using Newtonsoft.Json;
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

        [HttpGet]
        public JsonResult DisplayTeeRecords(string date)
        {
            List<TeeTime> Times = new List<TeeTime>();
            if (!string.IsNullOrEmpty(date))
            {
                Times = new Reservations().GetTeeTimes(DateTime.Parse(date));

                return Json(JsonConvert.SerializeObject(Times), JsonRequestBehavior.AllowGet);
            }
            return Json(JsonConvert.SerializeObject(Times), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveDataBookTeeTimeReservation(BookTeeTimeReservation objBoookstanding)
        {
            bool isStatus = false;
            string message = string.Empty;

            int hours = objBoookstanding.Hour;
            int minutes = objBoookstanding.Minute;

            if (objBoookstanding.AMorPM == "PM" && hours != 12)
                hours += 12;

            string datetime = objBoookstanding.Date;
            datetime += " " + hours.ToString() + ":" + minutes.ToString();
            TeeTime NewTeeTime = new TeeTime();
            DateTime DateT = DateTime.Parse(datetime);
            try
            {
                NewTeeTime = new TeeTime(DateT, DateT, Session["MemberName"].ToString(), objBoookstanding.MemberName2, objBoookstanding.MemberName3, objBoookstanding.MemberName4, Convert.ToInt32(Session["MemberNumber"]), objBoookstanding.NumberOfPlayers, objBoookstanding.PhoneNumber, Convert.ToInt32(objBoookstanding.NumberOfCarts), "N/A");




                ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();


                if (CBRD.ReserveTeeTime(NewTeeTime, Session["MembershipLevel"].ToString()))
                {
                    isStatus = true;
                    message = "Reservation was successfuly made.";
                }
                else
                {
                    message = "Reservation could not be made.";
                }

            }
            catch (Exception ex)
            {
                return Json(new { Status = isStatus, message = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { Status = isStatus, message = message }, JsonRequestBehavior.AllowGet);

        }
    }
}
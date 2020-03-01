using CLUBBaistWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLUBBaistWeb.Controllers
{
    public class CancelTeeTimeReservationController : Controller
    {
        // GET: CancelTeeTimeReservation
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
            var data = new Reservations().GetMemberReservations(Convert.ToInt32(Session["MemberNumber"].ToString()));
            List<SelectListItem> ddlitemlist = data.Select(c => new SelectListItem { Text = c.Key, Value = c.Value.ToString() }).ToList();

            ViewBag.ddlitemlist = ddlitemlist; //using ViewBag to bind DropDownList
            return View();
        }

        public JsonResult CancelTee(string cancellDate)
        {
            string message = string.Empty;
            if (!string.IsNullOrEmpty(cancellDate))
            {
                DateTime reservation = DateTime.Parse(cancellDate);
                ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
                message = new ReservationRepository().CancelReservation(reservation, reservation, int.Parse(Session["MemberNumber"].ToString())).ToString();
            }
            return Json(new { status = true, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}
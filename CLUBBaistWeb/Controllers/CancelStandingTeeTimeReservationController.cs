using CLUBBaistWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLUBBaistWeb.Controllers
{
    public class CancelStandingTeeTimeReservationController : Controller
    {
        // GET: CancelStandingTeeTimeReservation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cancel()
        {
            var Cancelled = new ReservationRepository().CancelStandingReservation(Convert.ToInt32(Session["MemberNumber"].ToString()));
            return RedirectToAction("Index", "Home");
        }
    }
}
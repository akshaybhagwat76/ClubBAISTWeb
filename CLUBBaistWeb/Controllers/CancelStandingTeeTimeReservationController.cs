using CLUBBaistWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLUBBaistWeb.Controllers
{
    /// <summary>
    /// Author : Akshay Bhagwat
    /// SKype Id : akshaybhagwat76@hotmail.com
    /// Gmail : akshaybhagwat76@gmail.com
    /// Freelancer : https://www.freelancer.com/u/akshaybhagwat76
    /// COntact : +91-7383328380
    /// </summary>
    public class CancelStandingTeeTimeReservationController : Controller
    {
        // GET: CancelStandingTeeTimeReservation
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
        public ActionResult Cancel()
        {
            var Cancelled = new ReservationRepository().CancelStandingReservation(Convert.ToInt32(Session["MemberNumber"].ToString()));
            return RedirectToAction("Index", "Home");
        }
    }
}
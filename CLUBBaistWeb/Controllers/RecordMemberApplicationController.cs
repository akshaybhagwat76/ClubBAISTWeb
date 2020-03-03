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
    public class RecordMemberApplicationController : Controller
    {
        // GET: RecordMemberApplication
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
        public JsonResult AddApplication(Application application)
        {
            string message = string.Empty;
            bool status = false;
            try
            {
                if (application!=null)
                {

                    var response = new ApplicationsRepository().AddApplication(application);
                    if (response)
                    {
                        status = response;
                        message = "Successfully added";
                        return Json(new { status=status,message=message},JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                status = false; message = ex.Message.ToString();
                return Json(new { status = status, message =message}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}
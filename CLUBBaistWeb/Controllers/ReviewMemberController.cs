using CLUBBaistWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLUBBaistWeb.Controllers
{
    public class ReviewMemberController : Controller
    {
        // GET: ReviewMember
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
            List<Application> Applications = new ApplicationsRepository().GetApplications();
            List<ApplicationVM> list = new List<ApplicationVM>();

            foreach (Application item in Applications)
            {
                ApplicationVM obj = new ApplicationVM();
                obj.ApplicationID = item.ApplicationID;
                obj.LastName = item.LastName;
                obj.FirstName = item.FirstName;
                obj.Address = item.Address;
                obj.PostalCode = item.PostalCode;
                obj.Phone = item.Phone;
                obj.AltPhone = item.AltPhone;
                obj.Email = item.Email;
                obj.BirthDate = item.BirthDate.ToShortDateString();
                obj.Occupation = item.Occupation;
                obj.CompanyName = item.CompanyName;
                obj.CompanyAddress = item.CompanyAddress;
                obj.CompanyPostalCode = item.CompanyPostalCode;
                obj.CompanyPhone = item.CompanyPhone;
                obj.SubmitDate = item.SubmitDate.ToShortDateString();
                obj.Sex = item.Sex.ToString();
                obj.WantsShare = item.WantsShare ? "Yes" : "No";
                obj.Waitlisted = item.Waitlisted ? "Yes" : "No";
                obj.Onhold = item.Onhold ? "Yes" : "No";
                obj.ShareholderName1 = item.ShareholderName1;
                obj.ShareholderDate1 = item.ShareholderDate1.ToShortDateString();
                obj.ShareholderName2 = item.ShareholderName2;
                obj.ShareholderDate2 = item.ShareholderDate2.ToShortDateString();
                list.Add(obj);
            }
            ViewBag.lstData = list;
            return View();
        }
        [HttpGet]
        public JsonResult FindApp(string findApplication)
        {
            string message = string.Empty; bool status = false;
            if (!string.IsNullOrEmpty(findApplication))
            {
                var ApplicationID = findApplication[1];
                string[] parameters = findApplication.Split(',');
                if (parameters[0] == "Accept")
                {
                    var memberId = new ApplicationsRepository().AcceptApplication(ApplicationID);
                    if (memberId != 0)
                    {
                        message = "Application was accepted successfully...... MemberID = " + memberId.ToString();
                        status = true;
                    }
                    else
                    {
                        message = "Application could not be accepted.";
                    }
                }
                else if (parameters[0] == "Deny")
                {
                    if (new ApplicationsRepository().DenyApplication(ApplicationID))
                    {
                        message = "Application was denied successfully."; status = true;
                    }
                    else
                    {
                        message = "Application could not be denied.";
                    }
                }
                else if (parameters[0] == "Waitlist")
                {
                    if (new ApplicationsRepository().WaitlistApplication(ApplicationID))
                    {
                        message = "Application was waitlisted successfully."; status = true;
                    }
                    else
                    {
                        message = "Application could not be waitlisted.";
                    }
                }
                else
                {
                    if (new ApplicationsRepository().HoldApplication(ApplicationID))
                    {
                        message = "Application was put on hold successfully."; status = true;
                    }
                    else
                    {
                        message = "Application could not be put on hold.";
                    }
                }
            }
            return Json(new { status = status, message = message });
        }
    }
}
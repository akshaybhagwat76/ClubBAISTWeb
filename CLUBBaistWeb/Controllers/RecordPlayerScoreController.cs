using CLUBBaistWeb.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CLUBBaistWeb.Controllers
{
    public class RecordPlayerScoreController : Controller
    {
        List<string> boxes;
        const double MENWHITERATING = 69.1;
        const double MENBLUERATING = 70.6;
        const int MENWHITESLOPE = 121;
        const int MENBLUESLOPE = 128;
        const double WOMENREDRATING = 73d;
        const double WOMENWHITERATING = 75.3;
        const int WOMENREDSLOPE = 127;
        const int WOMENWHITESLOPE = 131;
        public ActionResult Index()
        {
            boxes = new List<string>() { "S1", "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "S11", "S12", "S13", "S14", "S15", "S16", "S17", "S18" };

            List<SelectListItem> lst = new List<SelectListItem>();



            if (Session["Sex"].ToString() == "M")
            {
                lst.Add(new SelectListItem { Text = "Blue", Value = "Blue" });
                lst.Add(new SelectListItem { Text = "While", Value = "White", Selected = true });
            }
            else
            {
                lst.Add(new SelectListItem { Text = "Red", Value = "Red" });
                lst.Add(new SelectListItem { Text = "While", Value = "White", Selected = true });
            }
            ViewData["Tee"] = lst;
            return View();
        }

        [HttpGet]
        public JsonResult GetCurrentHandicap()
        {
            string message = string.Empty;
            bool status = false;
            try
            {
                int memberNumber = Convert.ToInt32(Session["MemberNumber"].ToString());
                var response = new ScoresRepository().GetCurrentHandicap(memberNumber);
                status = response >= 0 ? true : false;
                message = response.ToString();

            }
            catch (Exception ex)
            {
                status = false; message = ex.Message.ToString();
                return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CalculateResult()
        {
            string message = string.Empty;
            bool status = false;
            try
            {
                boxes = new List<string>() { "S1", "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "S11", "S12", "S13", "S14", "S15", "S16", "S17", "S18" };


                List<string> obj = new List<string>();
                int fronttotal = 0;
                for (int i = 0; i < 9; i++)
                {
                    fronttotal +=i;
                }
                obj.Add(fronttotal.ToString());

                int backtotal = 0;
                for (int i = 9; i < 18; i++)
                {
                    backtotal += i;
                }
                status = true; message = JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                status = false; message = ex.Message.ToString();
                return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RecordTee(string totalAndTee)
        {
            string message = string.Empty;
            bool status = false;
            try
            {
                var response = JsonConvert.SerializeObject(totalAndTee);
                
                boxes = new List<string>() { "S1", "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "S11", "S12", "S13", "S14", "S15", "S16", "S17", "S18" };
                //Score NewScore = new Score(TeeList.SelectedValue, total);
                for (int i = 0; i < boxes.Count; i++)
                {
                    //NewScore.scores.Add(int.Parse(item.Text));
                }
                //foreach (TextBox item in boxes)
                //{
                //    try
                //    {
                //        NewScore.scores.Add(int.Parse(item.Text));
                //    }
                //    catch (Exception)
                //    {
                //        Message.Text = "Your scores are not correct";
                //    }
                //}

                //if (NewScore.scores.Count == 18)
                //    NewScore.HandicapDifferential = Math.Round(((NewScore.Total - float.Parse(Rating.Text)) * 113) / float.Parse(Slope.Text), 1);


                //ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
                //if (CBRD.RecordScore((int)Session["MemberNumber"], NewScore))
                //    Message.Text = "Score was recorded successfully";
                //else
                //    Message.Text = "There seems to be an error in your score.";
                //int memberNumber = Convert.ToInt32(Session["MemberNumber"].ToString());
                //var response = new ScoresRepository().GetCurrentHandicap(memberNumber);
                //status = response >= 0 ? true : false;
                //message = response.ToString();

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
using ASPSnippets.SmsAPI;
using Model1;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Views.Home
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {

            return View();
        }


        public JsonResult SendOTP()
        {
            int otpValue = new Random().Next(100000, 999999);
            var status = "";
            try
            {
                string recipient = ConfigurationManager.AppSettings["RecipientNumber"].ToString();
                string APIKey = ConfigurationManager.AppSettings["APIKey"].ToString();

                string message = "Your OTP Number is " + otpValue + " ( Sent By : Thuan )";
                String encodedMessage = HttpUtility.UrlEncode(message);

                using (var webClient = new WebClient())
                {
                    byte[] response = webClient.UploadValues("https://api.textlocal.in/send/", new NameValueCollection(){
                                        { "apikey", APIKey},
                                        { "numbers", recipient},
                                        {"message" , encodedMessage},
                                        { "sender" , "TXTLCL"}});
                    //{ "TimeAlive", "15"},
                    //{ "SecretKey", "F99FEDEC24B80B4A505011AAE62BC9"},
                    //{ "CallbackUrl", "https://enaehgfhfyqxn.x.pipedream.net/"},
                    //{"TypeId", "1"},

                    string result = System.Text.Encoding.UTF8.GetString(response);

                    var jsonObject = JObject.Parse(result);

                    status = jsonObject["status"].ToString();

                    Session["CurrentOTP"] = otpValue;
                }


                return Json(status, JsonRequestBehavior.AllowGet);


            }
            catch (Exception e)
            {

                throw (e);

            }

        }

        public ActionResult EnterOTP()
        {
            return View();
        }

        [HttpPost]
        public JsonResult VerifyOTP(string otp)
        {
            bool result = false;

            string sessionOTP = Session["CurrentOTP"].ToString();

            if (otp == sessionOTP)
            {
                result = true;

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
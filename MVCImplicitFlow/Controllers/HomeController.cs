using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVCImplicitFlow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult AccessToken()
        {
            var user = User as ClaimsPrincipal;
            var token = user.FindFirst("access_token");

            if (token != null)
            {
                ViewData["access_token"] = token.Value;
            }

            return View();
        }

        [Authorize]
        public ActionResult CallApi()
        {
            var user = User as ClaimsPrincipal;
            var token = user.FindFirst("access_token").Value;
            string apiUrl = Constants.SitefinityNewsItemsApiUrl;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + token);

            string result = string.Empty;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            ViewBag.Json = result;
            return View();
        }

    }
}
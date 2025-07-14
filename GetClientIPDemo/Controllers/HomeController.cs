using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;

namespace YourAppNamespace.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string clientIp = GetClientIp();

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            ViewBag.Ip = clientIp;
            ViewBag.Elapsed = $"{elapsed.TotalMilliseconds} ms";

            return View();
        }

        private string GetClientIp()
        {
            var request = System.Web.HttpContext.Current?.Request;
            string ip = request?.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                return ip.Split(',')[0];
            }

            return request?.UserHostAddress ?? "IP Not Available";
        }
    }
}

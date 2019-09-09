using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;
using System.Web.Http.Cors;
using System.Net;

namespace MVCWebApp.Controllers
{
    [EnableCors(origins: "http://localhost:55578/Service1.svc", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        // async var
        public static string response = "Waiting for call back";
        // index controller
        public IActionResult Index()
        {
            return View();
        }
        //async method
        public string guessNumber(int guess, int number)
        {
            response = "Waiting for call back";
            string baseUrl = "http://localhost:55578/Service1.svc/guess";
            string fullUrl = $"{baseUrl}?x={guess}&y={number}";
            HttpWebRequest hwReq1 = (HttpWebRequest)HttpWebRequest.Create(new Uri(fullUrl));
            hwReq1.BeginGetResponse(new AsyncCallback(myCallbackFunc), hwReq1);
            do
            {
                //wait
            } while (response.Equals("Waiting for call back"));
            return response;
        }
        // async callback
        private static void myCallbackFunc(IAsyncResult requestObj)
        {
            HttpWebRequest hwReq2 = (HttpWebRequest) requestObj.AsyncState;
            HttpWebResponse hwResponse = (HttpWebResponse)hwReq2.EndGetResponse(requestObj);
            using (System.IO.StreamReader sReader = new System.IO.StreamReader(hwResponse.GetResponseStream()))
            {
                response = sReader.ReadToEnd().ToString();
            }
        }
    }
}

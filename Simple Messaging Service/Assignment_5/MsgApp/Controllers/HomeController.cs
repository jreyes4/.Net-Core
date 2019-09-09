using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MsgApp.Models;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace MsgApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult SendMsg()
        {
            return View();
        }

        [HttpPost]
        // Sends message
        public IActionResult SendMsg(Msg model)
        {
            // transfer from model to variables
            string receiverID = model.sendID;
            string senderID = model.userID;
            string message = model.msg;
            // build url
            string baseUrl = "http://localhost:50225/Service1.svc/send";
            string fullUrl = $"{baseUrl}/{senderID}/{receiverID}/{message}";
            HttpWebRequest hwReq1 = (HttpWebRequest)HttpWebRequest.Create(new Uri(fullUrl));
            // make request
            hwReq1.BeginGetResponse(null, hwReq1);
            // success
            model.sent = true;
            return View(model);
        }
        // normal view controller
        public IActionResult ReceiveMsg()
        {
            return View();
        }
        [HttpPost]
        // gets msgs
        public IActionResult ReceiveMsg(Msgs model)
        {
            // transfer from model
            string receiverID = model.userID;
            bool purge = model.purge;
            // build url
            string url = $"http://localhost:50225/Service1.svc/retrieve?x={receiverID}&y={purge}";

            using (WebClient client = new WebClient())
            {
                // try to download. 
                try
                {
                    // download information from url
                    var json = client.DownloadString(url);
                    // deserialize json
                    string[] result = JsonConvert.DeserializeObject<string[]>(json);
                    model.messages = new List<Msg>();
                    for (int i = 0; i < result.Length; i++)
                    {
                        Msg tmp = new Msg();
                        tmp.sendID = result[i];
                        tmp.timeStamp = result[++i];
                        tmp.msg = result[++i];
                        model.messages.Add(tmp);
                    }
                    model.success = true;
                }
                catch
                {
                    model.success = false;
                }
            }
            return View(model);
        }

    }


    public class Rootobject
    {
        public string Property1 { get; set; }
    }

}

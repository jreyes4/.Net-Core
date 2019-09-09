using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsgApp.Models
{
    public class Msg
    {
        public string sendID { get; set; }
        public string userID { get; set; }
        public string msg { get; set; }
        public string timeStamp { get; set; }
        public bool sent { get; set; }
    }
}

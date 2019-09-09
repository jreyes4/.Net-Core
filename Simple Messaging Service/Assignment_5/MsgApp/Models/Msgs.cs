using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsgApp.Models
{
    public class Msgs
    {
        public string userID { get; set; }
        public bool purge { get; set; }
        public bool success { get; set; }
        public List<Msg> messages { get; set; }
    }
}

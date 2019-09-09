using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Assignment_5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "send/{senderID}/{receiverID}/{Message}", ResponseFormat = WebMessageFormat.Json)]
        void SendMessage(string senderID, string receiverID, string Message);

        [OperationContract]
        [WebGet(UriTemplate = "retrieve?x={UserID}&y={purge}", ResponseFormat = WebMessageFormat.Json)]
        string[] ReceiveMessage(string UserID, bool purge);
    }
}

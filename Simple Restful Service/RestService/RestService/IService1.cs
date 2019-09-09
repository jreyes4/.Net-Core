using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestService
{
    // restful service
    [ServiceContract]
    public interface IService1
    {
        // hide method name
        [OperationContract]
        [WebGet(UriTemplate="numGen?x={lower}&y={upper}", ResponseFormat = WebMessageFormat.Json)]
        int SecretNumber(int lower, int upper);
        // hide method name
        [OperationContract]
        [WebGet(UriTemplate = "guess?x={userNum}&y={SecretNum}", ResponseFormat = WebMessageFormat.Json)]
        string checkNumber(int userNum, int SecretNum);
    }
}

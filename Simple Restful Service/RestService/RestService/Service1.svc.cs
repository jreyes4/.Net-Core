using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    public class Service1 : IService1
    {
        // implementation of secretNum
        public int SecretNumber(int lower, int upper)
        {
            // Generate random number from bounds given by client
            DateTime currentDate = DateTime.Now;
            int seed = (int)currentDate.Ticks;
            Random random = new Random(seed);
            int sNumber = random.Next(lower, upper);
            return sNumber;
        }
        //implementation of checkNumber
        public string checkNumber(int userNum, int SecretNum)
        {
            // if user guessed number
            if (userNum == SecretNum)
                return "correct";
            else
            // else hint user to go bigger or smaller
                if (userNum > SecretNum)
                return "too big";
            else return "too small";
        }
    }
}

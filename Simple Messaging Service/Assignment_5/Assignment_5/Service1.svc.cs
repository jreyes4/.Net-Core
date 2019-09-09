using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Assignment_5
{
    public class Service1 : IService1
    {
        // global path
        string XMLLocale = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Messages.xml");

        public void SendMessage(string senderID, string receiverID, string Message)
        {
            // declare new doc
            XDocument xmlDocMsgs = new XDocument();
            XNamespace nameSpace = "http://example.com/Messages";
            // try inserting element inside of root
            try
            {
                xmlDocMsgs = XDocument.Load(XMLLocale);
                XElement xmlElement = new XElement(nameSpace + "Message",
                    new XElement(nameSpace + "SenderID", senderID),
                    new XElement(nameSpace + "ReceiverID", receiverID),
                    new XElement(nameSpace + "TS", System.DateTime.Now.ToString()),
                    new XElement(nameSpace + "Read", false),
                    new XElement(nameSpace + "MessageContents", Message));
                xmlDocMsgs.Element(nameSpace + "Messages").Add(xmlElement);
                xmlDocMsgs.Save(XMLLocale);
            }
            // file was not found, create new file
            catch(FileNotFoundException ex)
            {
                    xmlDocMsgs = new XDocument(
                        new XDeclaration("1.0", "UTF-8", "yes"),
                        new XComment("CSE446 Messaging System Example"),
                        new XElement(nameSpace + "Messages",
                        new XElement(nameSpace + "Message",
                        new XElement(nameSpace + "SenderID", senderID),
                        new XElement(nameSpace + "ReceiverID", receiverID),
                        new XElement(nameSpace + "TS", System.DateTime.Now.ToString()),
                        new XElement(nameSpace + "Read", "false"),
                        new XElement(nameSpace + "MessageContents", Message))));
                    xmlDocMsgs.Save(XMLLocale);
            }
        }

        public string[] ReceiveMessage(string receiverID, bool purge)
        {
            // string to return
            string[] returnMsg;
            // load xml doc w/ namespace
            XDocument xmlDocMsgs = XDocument.Load(XMLLocale);
            XNamespace nameSpace = "http://example.com/Messages";
            // finds messages received by user that haven't already been read.
            IEnumerable<XElement> queryElementItems = from item in xmlDocMsgs.Root.Descendants(nameSpace + "Message")
                                                      where item.Element(nameSpace + "ReceiverID").Value == receiverID && item.Element(nameSpace + "Read").Value == "false"
                                                      orderby (DateTime)item.Element(nameSpace + "TS") ascending
                                                      select item;
            //create array of req'd size
            returnMsg = new string[queryElementItems.Count() * 3];
            int iter = 0;
            // fill returnMsg
            foreach(XElement item in queryElementItems)
            {
                returnMsg[iter++] = item.Element(nameSpace + "SenderID").Value;
                returnMsg[iter++] = item.Element(nameSpace + "TS").Value;
                returnMsg[iter++] = item.Element(nameSpace + "MessageContents").Value;
                // element has now been read and should have its read value updated
                item.Element(nameSpace + "Read").Value = "true";
            }

            // save updated xml
            xmlDocMsgs.Save(XMLLocale);
            // removes all msgs to user
            if (purge) { purgeID(receiverID); }
            


            return returnMsg;
        }

        private void purgeID(string ID)
        {
            XDocument xmlDocMsgs = XDocument.Load(XMLLocale);
            XNamespace nameSpace = "http://example.com/Messages";
            // finds messages received by user that haven't already been read.
            IEnumerable<XElement> queryElementItems = from item in xmlDocMsgs.Root.Descendants(nameSpace + "Message")
                                                      where item.Element(nameSpace + "ReceiverID").Value == ID
                                                      select item;
            queryElementItems.ToList().ForEach(x => x.Remove());
            xmlDocMsgs.Save(XMLLocale);
        }
    }
}

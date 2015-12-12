using System;
using System.Xml;

namespace Onero.Loader.Results
{
    public class FormResultParameters
    {
        public FormResultType ResultType { get; set; }
        
        public string Url { get; set; }
        public string Id { get; set; }
        public string Message { get; set; }

        public FormResultParameters(FormResultType type)
        {
            ResultType = type;
        }

        public FormResultParameters(XmlNode resultNodeList)
        {
            var type = resultNodeList.Attributes["type"].Value;
            switch (type.Trim().ToLower())
            {
                case "redirect":
                {
                    ResultType = FormResultType.Redirect;
                    Url = resultNodeList.SelectSingleNode("url").InnerText;
                    break;
                }
                case "message":
                {
                    ResultType = FormResultType.Message;
                    Id = resultNodeList.SelectSingleNode("id").InnerText;
                    Message = resultNodeList.SelectSingleNode("message") != null ? resultNodeList.SelectSingleNode("message").InnerText : String.Empty;
                    Url = resultNodeList.SelectSingleNode("url") != null ? resultNodeList.SelectSingleNode("url").InnerText : String.Empty;
                    break;
                }
            }
        }
    }
}

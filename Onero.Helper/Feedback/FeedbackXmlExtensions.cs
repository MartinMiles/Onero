using System;
using System.Globalization;
using System.Xml.Linq;

namespace Onero.Helper.Feedback
{
    public static class FeedbackXmlExtensions
    {
        public static XElement XmlNode(this Feedback license)
        {
            var node = new XElement("feedback", license.Message);
            node.SetAttributeValue("firstname", license.FirstName);
            node.SetAttributeValue("lastname", license.LastName);
            node.SetAttributeValue("email", license.Email);
            node.SetAttributeValue("created", license.Created.ToString("yyyy/MM/dd"));
            return node;
        }

        public static Feedback FromXmlFeedback(this XElement xml)
        {
            var feedback = new Feedback
            {
                FirstName = xml.Attribute("firstname")?.Value ?? String.Empty,
                LastName = xml.Attribute("lastname")?.Value ?? String.Empty,
                Email = xml.Attribute("email")?.Value ?? String.Empty,
                Message = xml.Value
            };

            if (xml.Attribute("created") != null)
            {
                feedback.Created = DateTime.ParseExact(xml.Attribute("created").Value, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }

            return feedback;
        }
    }
}

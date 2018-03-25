using System;
using System.Globalization;
using System.Xml.Linq;

namespace Onero.Helper.ErrorHandling
{
    public static class ReportableErrorXmlExtensions
    {
        public static XElement XmlNode(this ReportableError error)
        {
            var node = new XElement("error"/*, license.SerialNumber*/);

            node.SetAttributeValue("created", error.Created.ToString("yyyy/MM/dd"));
            node.SetAttributeValue("comment", error.Comment);

            node.SetAttributeValue("type", error.Type);
            node.SetAttributeValue("callStack", error.CallStack);
            node.SetAttributeValue("exceptionMessage", error.ExceptionMessage);
            node.SetAttributeValue("innerType", error.InnerType);
            node.SetAttributeValue("innerCallStack", error.InnerCallStack);
            node.SetAttributeValue("innerExceptionMessage", error.InnerExceptionMessage);

            node.SetAttributeValue("machineId", error.MachineId);
            node.SetAttributeValue("serialNumber", error.SerialNumber);
            node.SetAttributeValue("os", error.OS);

            return node;
        }

        public static ReportableError FromXmlError(this XElement lic)
        {
            var license = new ReportableError
            {
                Comment = lic.Attribute("comment")?.Value ?? String.Empty,

                Type = lic.Attribute("type")?.Value ?? String.Empty,
                CallStack = lic.Attribute("callStack")?.Value ?? String.Empty,
                ExceptionMessage = lic.Attribute("exceptionMessage")?.Value ?? String.Empty,

                InnerType = lic.Attribute("innerType")?.Value ?? String.Empty,
                InnerCallStack = lic.Attribute("innerCallStack")?.Value ?? String.Empty,
                InnerExceptionMessage = lic.Attribute("innerExceptionMessage")?.Value ?? String.Empty,

                MachineId = lic.Attribute("machineId")?.Value ?? String.Empty,
                SerialNumber = lic.Attribute("serialNumber")?.Value ?? String.Empty,
                OS = lic.Attribute("os")?.Value ?? String.Empty,
            };

            if (lic.Attribute("created") != null)
            {
                license.Created = DateTime.ParseExact(lic.Attribute("created").Value, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }

            return license;
        }
    }
}

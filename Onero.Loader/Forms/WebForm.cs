﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Onero.Loader.Results;

namespace Onero.Loader
{
    public class WebForm : RuleForm 
    {
        #region Contructors

        public WebForm()
        {
            ResultParameters = new FormResultParameters(FormResultType.Message);
        }

        public WebForm(XmlNode node) : base(node)
        {
        }

        #endregion

        #region Properties

        public IEnumerable<string> Urls { get; set; }

        public List<WebFormField> Fields { get; set; }

        public string SubmitId { get; set; }

        public FormResultParameters ResultParameters { get; set; }

        #endregion

        protected override void Parse()
        {
            bool enabled = true;
            if (node.Attributes["enabled"] != null)
            {
                Enabled = bool.TryParse(node.Attributes["enabled"].Value, out enabled);
            }
            Enabled = enabled;

            Name = node.Attributes["name"].Value;

            Urls = from XmlNode n in node.SelectNodes("url") select n.InnerText;

            var submit = from XmlNode n in node.SelectNodes("submit") select n.Attributes["id"].Value;
            SubmitId = submit.FirstOrDefault() ?? String.Empty;

            Fields = new List<WebFormField>();
            XmlNodeList xmlNodeList = node.SelectNodes("fields/field");
            foreach (XmlNode _node in xmlNodeList)
            {
                string id = _node.Attributes["id"].Value;
                string value = _node.InnerText;
                Fields.Add(new WebFormField(id, value));
            }

            XmlNode resultNodeList = node.SelectSingleNode("result");
            if (resultNodeList != null)
            {
                ResultParameters = new FormResultParameters(resultNodeList);
            }
        }

        public override XElement Save()
        {
            var node = new XElement("form");
            node.SetAttributeValue("name", Name);
            node.SetAttributeValue("enabled", Enabled);

            foreach (var url in Urls)
            {
                node.Add(new XElement("url", url));
            }

            var fields = new XElement("fields");
            foreach (var webFormField in Fields)
            {
                var field = new XElement("field", webFormField.Value);
                field.SetAttributeValue("id", webFormField.Id);
                fields.Add(field);
            }
            node.Add(fields);

            var submit = new XElement("submit");
            submit.SetAttributeValue("id", SubmitId);
            node.Add(submit);

            var result = new XElement("result");
            result.SetAttributeValue("type", ResultParameters.ResultType == FormResultType.Redirect ? "redirect" : "message");

            if (!string.IsNullOrWhiteSpace(ResultParameters.Url))
            {
                result.Add(new XElement("url", ResultParameters.Url));
            }
            if (!string.IsNullOrWhiteSpace(ResultParameters.Message))
            {
                result.Add(new XElement("message", ResultParameters.Message));
            }
            if (!string.IsNullOrWhiteSpace(ResultParameters.Id))
            {
                result.Add(new XElement("id", ResultParameters.Id));
            }
            node.Add(result);

            return node;
        }
    }
}
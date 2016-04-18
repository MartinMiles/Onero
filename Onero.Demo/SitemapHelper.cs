using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Onero.Demo
{
    public class SitemapHelper
    {
        private IReadOnlyCollection<SitemapNode> GetSitemapNodes(UrlHelper urlHelper)
        {
            List<SitemapNode> nodes = new List<SitemapNode>
            {
                new SitemapNode {Url = urlHelper.AbsoluteRouteUrl("Default", new {action = "Index"}), Priority = 1},
                new SitemapNode {Url = urlHelper.AbsoluteRouteUrl("Default", new {action = "About"}), Priority = 0.9},
                new SitemapNode { Url = urlHelper.AbsoluteRouteUrl("Default", new {action = "BrokenLinks"}), Priority = 0.9 },
                new SitemapNode { Url = urlHelper.AbsoluteRouteUrl("Default", new {action = "SupportedFields"}),Priority = 0.9 },
                new SitemapNode { Url = urlHelper.AbsoluteRouteUrl("Default", new {action = "DataExtract"}), Priority = 0.9 },
                new SitemapNode { Url = urlHelper.AbsoluteRouteUrl("Default", new {action = "ExtractData"}), Priority = 0.9 }
            };

            return nodes;
        }

        public string GetSitemapDocument(UrlHelper urlHelper)
        {
            IEnumerable<SitemapNode> sitemapNodes = GetSitemapNodes(urlHelper);

            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");
            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),

                    sitemapNode.LastModified == null ? null : new XElement(xmlns + "lastmod", sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(xmlns + "changefreq", sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(xmlns + "priority", sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }

    }
}
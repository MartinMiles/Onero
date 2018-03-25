using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Onero.Demo.Controllers
{
    public class SeoController : Controller
    {
        [Route("Sitemap")]
        public ActionResult SitemapXml()
        {
            string xml = new SitemapHelper().GetSitemapDocument(Url);
            return Content(xml, "text/xml", Encoding.UTF8);
        }

        [Route("Robots")]
        public ActionResult RobotsTxt()
        {
            var lines = new List<string>
            {
                "User - agent: *",
                "Disallow:",
                $"Sitemap: {Request.Url.AbsoluteUri.Replace("/robots.txt", "/Seo/sitemapxml")}"
            };

            return Content(string.Join(Environment.NewLine, lines), "text/plain", Encoding.UTF8);
        }
    }
}
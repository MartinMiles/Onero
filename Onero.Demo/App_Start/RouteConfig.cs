using System.Web.Mvc;
using System.Web.Routing;

namespace WebsiteTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Sitemap",
                url: "sitemap.xml",
                defaults: new { controller = "Seo", action = "SitemapXml", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Robots",
                url: "robots.txt",
                defaults: new { controller = "Seo", action = "RobotsTxt", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System.Web.Mvc;

namespace Onero.Demo
{
    public static class UrlHelperExtensions
    {
        public static string AbsoluteRouteUrl(this UrlHelper urlHelper, string routeName, object routeValues = null)
        {
            string scheme = urlHelper.RequestContext.HttpContext.Request.Url.Scheme;
            return urlHelper.RouteUrl(routeName, routeValues, scheme);
        }
    }
}
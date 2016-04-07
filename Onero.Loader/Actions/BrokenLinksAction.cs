using System;
using System.Collections.Generic;
using System.Linq;
using Onero.Loader.Results;
using OpenQA.Selenium;

namespace Onero.Loader.Actions
{
    public class BrokenLinksAction : BaseAction
    {
        const int TIMEOUT = 20; // seconds

        public BrokenLinksAction(IWebDriver driver, LoaderSettings settings) : base(driver, settings)
        {
        }

        public override dynamic Execute()
        {
            return new BrokenLinksResult
            {
                Links = GetValue(settings.Profile.FindAllBrokenLinks, settings.BrokenLinks, "a", "href"),
                Images = GetValue(settings.Profile.FindAllBrokenImages, settings.BrokenImages, "img", "src"),
                Scripts = GetValue(settings.Profile.FindAllBrokenScripts, settings.BrokenScripts, "script", "src"/*, "type", "text/javascript"*/),
                Styles = GetValue(settings.Profile.FindAllBrokenStyles, settings.BrokenStyles, "link", "href", "rel", "stylesheet")
            };
        }

        private IEnumerable<string> GetValue(bool findOnEveryPage, IEnumerable<Broken.Broken> items, string tag, string attr, string filterAttributeName = null, string filterAttributeValue = null)
        {
            if (findOnEveryPage)
            {
                return VerifyLinks(tag, attr, filterAttributeName, filterAttributeValue);
            }

            if (items != null && items.Any(r => r.ShouldRunOnThePage(driver.Url)))
            {
                return VerifyLinks(tag, attr, filterAttributeName, filterAttributeValue);
            }

            return new List<string>();
        }

        private IEnumerable<string> VerifyLinks(string tagName, string attributeName, string filterAttributeName = null, string filterAttributeValue = null)
        {
            var brokenLinks = new List<string>();

            var uris = driver
                .FindElements(By.TagName(tagName))
                .Where(e => FilterByAttribute(e, filterAttributeName, filterAttributeValue))
                .Select(l => l.GetAttribute(attributeName))
                .Where(i=>!string.IsNullOrWhiteSpace(i))
                .Distinct().Select(u => new Uri(u));

            HttpStatusCodeReader httpStatusCodeReader = new HttpStatusCodeReader(uris);
            var results = httpStatusCodeReader.GetHttpStatusCodes();

            foreach (var result in results)
            {
                if (!result.Value)
                {
                    brokenLinks.Add(result.Key.ToString());
                }
            }

            //foreach (var href in hrefs)
            //{
            //    if (href.StartsWith("javascript:"))
            //    {
            //        continue;
            //    }

            //    try
            //    {
            //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(href);
            //        //request.Method = WebRequestMethods.Http.Head;
            //        request.Timeout = TIMEOUT*1000;
            //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //        if (response.StatusCode != HttpStatusCode.OK)
            //        {
            //            brokenLinks.Add(href);
            //        }
            //    }
            //    catch (NotSupportedException e)
            //    {
            //        brokenLinks.Add(href);
            //    }
            //    catch (WebException e)
            //    {
            //        brokenLinks.Add(href);
            //    }
            //    catch (ArgumentNullException e)
            //    {
            //    }
            //}

            return brokenLinks;
        }

        private bool FilterByAttribute(IWebElement e, string name, string value)
        {
            return (name == null && value == null) ||
                   (!string.IsNullOrWhiteSpace(e.GetAttribute(name))
                    && e.GetAttribute(name).Equals(value, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Onero.Loader.Results;
using OpenQA.Selenium;

namespace Onero.Loader.Actions
{
    public class BrokenLinksAction : BaseAction
    {
        const int TIMEOUT = 20; // 10 seconds

        public BrokenLinksAction(IWebDriver driver, LoaderSettings settings) : base(driver, settings)
        {
        }

        public override dynamic Execute()
        {
            return new BrokenLinksResult
            {
                Links = GetValue(settings.Profile.FindAllBrokenLinks, settings.BrokenLinks, "a", "href"),
                Images = GetValue(settings.Profile.FindAllBrokenImages, settings.BrokenImages, "img", "src"),
                Scripts = GetValue(settings.Profile.FindAllBrokenScripts, settings.BrokenScripts, "script", "src", "type", "text/javascript"),
                Styles = GetValue(settings.Profile.FindAllBrokenStyles, settings.BrokenStyles, "link", "href", "rel", "stylesheet")
            };
        }

        private IEnumerable<string> GetValue(bool findAll, IEnumerable<Broken.Broken> items, string tag, string attr, string filterAttributeName = null, string filterAttributeValue = null)
        {
            if (findAll)
            {
                return VerifyLinks(tag, attr);
            }
            else
            {
                if (items.Any())
                {
                    foreach (var rule in items)
                    {
                        if (!rule.ShouldRunOnThePage(driver.Url))
                        {
                            continue;
                        }
                    }

                    return VerifyLinks(tag, attr, filterAttributeName, filterAttributeValue);
                }
            }

            return new List<string>();
        }

        private IEnumerable<string> VerifyLinks(string tagName, string attributeName, string filterAttributeName = null, string filterAttributeValue = null)
        {
            var brokenLinks = new List<string>();

            var hrefs = driver
                .FindElements(By.TagName(tagName))
                .Where(e => Filter(e, filterAttributeName, filterAttributeValue))
                .Select(l => l.GetAttribute(attributeName))
                .Where(i=>!string.IsNullOrWhiteSpace(i))
                .Distinct();

            foreach (var href in hrefs)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(href);
                    //request.Method = WebRequestMethods.Http.Head;
                    request.Timeout = TIMEOUT*1000;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        brokenLinks.Add(href);
                    }
                }
                catch (WebException e)
                {
                    brokenLinks.Add(href);
                }
                catch (ArgumentNullException e)
                {
                    int k = 0;
                    //brokenLinks.Add(href);
                }

                //using (WebClient client = new WebClient())
                //{
                //    try
                //    {
                //        string s = client.DownloadString(href);
                //    }
                //    catch (Exception)
                //    {
                //        brokenLinks.Add(href);
                //    }
                //}
            }

            return brokenLinks;
        }

        private bool Filter(IWebElement e, string filterAttributeName, string filterAttributeValue)
        {
            return (filterAttributeName == null && filterAttributeValue == null) ||
                   (!string.IsNullOrWhiteSpace(e.GetAttribute(filterAttributeName))
                    && e.GetAttribute(filterAttributeName).Equals(filterAttributeValue, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

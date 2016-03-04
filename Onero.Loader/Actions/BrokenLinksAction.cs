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
        const int TIMEOUT = 10; // 10 seconds

        public BrokenLinksAction(IWebDriver driver, LoaderSettings settings) : base(driver, settings)
        {
        }

        public override dynamic Execute()
        {
            var result = new BrokenLinksResult();

            //TODO: Refactor blocks below

            if (settings.Profile.FindAllBrokenLinks)
            {
                result.Links = VerifyLinks("a", "href");
            }
            else
            {
                foreach (var rule in settings.BrokenLinks)
                {
                    var resultCode = new ResultCode();

                    if (!rule.ShouldRunOnThePage(driver.Url))
                    {
                        continue;
                    }

                    result.Links = VerifyLinks("a", "href");
                }                
            }


            if (settings.Profile.FindAllBrokenImages)
            {
                result.Images = VerifyLinks("img", "src");
            }
            else
            {
                foreach (var rule in settings.BrokenImages)
                {
                    var resultCode = new ResultCode();

                    if (!rule.ShouldRunOnThePage(driver.Url))
                    {
                        continue;
                    }

                    result.Images = VerifyLinks("img", "src");
                }
            }

            return result;
        }

        private IEnumerable<string> VerifyLinks(string tagName, string attributeName)
        {
            var brokenLinks = new List<string>();

            var hrefs = driver
                .FindElements(By.TagName(tagName))
                .Select(l => l.GetAttribute(attributeName))
                .Where(i=>!string.IsNullOrWhiteSpace(i))
                .Distinct();

            foreach (var href in hrefs)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(href);
                    request.Method = WebRequestMethods.Http.Head;
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
    }
}

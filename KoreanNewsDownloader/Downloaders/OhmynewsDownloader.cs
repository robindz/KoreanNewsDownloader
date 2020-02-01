using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace KoreanNewsDownloader.Downloaders
{
    internal class OhmynewsDownloader : DownloaderBase
    {
        public OhmynewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "www.ohmynews.com", "star.ohmynews.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.AbsoluteUri.Contains("/View/"))
            {
                return Document.DocumentNode
                    .SelectNodes("//*[@class=\"gal-thumb cssAjaxLink\"]")
                    .Select(x => Regex.Match(x.GetAttributeValue("style", ""), @"^.+(http.+jpg)").Groups.Values.Last().Value
                    .Replace("CT_T_IMG", "ORG_IMG_FILE")
                    .Replace("PHT", "ORG")
                    .Replace("MT", "ORG"));
            }
            else
            {
                return Document.DocumentNode
                    .SelectNodes("//*[@class=\"image line\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", "").Replace("STD", "ORG"));
            }
        }
    }
}

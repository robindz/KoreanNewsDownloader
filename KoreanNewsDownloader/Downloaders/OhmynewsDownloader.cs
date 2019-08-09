using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class OhmynewsDownloader : DownloaderBase
    {
        public OhmynewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.ohmynews.com", "star.ohmynews.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            IList<string> images = new List<string>();
            HtmlDocument doc = await GetDocumentAsync(uri);

            if (uri.Host == HostUrls[0])
            {
                images = doc.DocumentNode
                    .SelectNodes("//*[@class=\"gal-thumb cssAjaxLink\"]")
                    .Select(x => Regex.Match(x.GetAttributeValue("style", ""), @"^.+(http.+jpg)").Groups.Last().Value.Replace("CT_T_IMG", "ORG_IMG_FILE").Replace("MT", "ORG"))
                    .ToList();
            }
            else if (uri.Host == HostUrls[1])
            {
                images = doc.DocumentNode
                    .SelectSingleNode("//*[@class=\"image line\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", "").Replace("STD", "ORG"))
                    .ToList();
            }

            return images;
        }
    }
}

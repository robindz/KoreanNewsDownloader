using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KookjeDownloader : DownloaderBase
    {
        public KookjeDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.kookje.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            if (uri.AbsoluteUri.Contains("newsbody"))
            {
                var images = doc.DocumentNode
                    .SelectSingleNode("//*[@class=\"news_article\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""))
                    .ToList();

                return images;
            }
            else
            {
                var images = doc.DocumentNode
                    .SelectSingleNode("//*[@id=\"thumbs\"]")
                    .Descendants("img")
                    .Select(x => Regex.Replace(x.GetAttributeValue("src", ""), "/S", "/L"))
                    .ToList();

                return images;
            }
        }
    }
}

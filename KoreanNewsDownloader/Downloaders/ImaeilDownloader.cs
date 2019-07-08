using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ImaeilDownloader : DownloaderBase
    {
        public ImaeilDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "news.imaeil.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectNodes("//*[@class=\"img_box img_center\"]")
                .Descendants("img")
                .Select(x => $"https://news.imaeil.com{x.GetAttributeValue("src", "")}")
                .ToList();

            return images;
        }
    }
}

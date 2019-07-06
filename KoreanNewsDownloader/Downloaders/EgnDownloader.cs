using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class EgnDownloader : DownloaderBase
    {
        public EgnDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "www.egn.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"article-view-content-div\"]")
                .Descendants("img")
                .Where(x => x.GetAttributeValue("src", "").Contains("photo"))
                .Select(x => $"http://www.egn.kr{x.GetAttributeValue("src", "")}")
                .ToList();

            return images;
        }
    }
}

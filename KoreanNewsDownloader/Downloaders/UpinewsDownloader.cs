using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class UpinewsDownloader : DownloaderBase
    {
        public UpinewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.upinews.kr", "upinews.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"viewConts\"]")
                .Descendants("img")
                .Select(x => $"http://www.upinews.kr/{x.GetAttributeValue("src", "")}")
                .ToList();

            return images;
        }
    }
}

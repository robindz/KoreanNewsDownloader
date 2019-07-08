using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MediasrDownloader : DownloaderBase
    {
        public MediasrDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.mediasr.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"article-view-content-div\"]")
                .Descendants("img")
                .Where(x => x.GetAttributeValue("src", "").Contains("/news/photo"))
                .Select(x => $"http://www.mediasr.co.kr{x.GetAttributeValue("src", "")}")
                .ToList();

            return images;
        }
    }
}

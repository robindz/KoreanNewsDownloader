using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class WikitreeDownloader : DownloaderBase
    {
        public WikitreeDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.wikitree.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"wikicon\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("data-src", ""))
                .ToList();

            return images;
        }
    }
}

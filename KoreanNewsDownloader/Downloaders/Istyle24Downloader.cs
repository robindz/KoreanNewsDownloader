using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class Istyle24Downloader : DownloaderBase
    {
        public Istyle24Downloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "zine.istyle24.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = doc.DocumentNode
                .SelectSingleNode("//*[@class=\"editor_area\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""))
                .ToList();

            return images;
        }
    }
}

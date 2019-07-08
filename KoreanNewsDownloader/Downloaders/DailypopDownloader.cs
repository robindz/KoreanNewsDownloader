using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DailypopDownloader : DownloaderBase
    {
        public DailypopDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.dailypop.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .Descendants()
                .Where(x => x.Name == "img" && x.HasClass("content"))
                .Select(x => x.GetAttributeValue("src", ""))
                .ToList();

            return images;
        }
    }
}

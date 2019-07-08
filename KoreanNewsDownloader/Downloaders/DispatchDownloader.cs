using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DispatchDownloader : DownloaderBase
    {
        public DispatchDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.dispatch.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .Descendants()
                .Where(x => x.Name == "img" && x.GetAttributeValue("src", "").Contains("uploads"))
                .Select(x => x.GetAttributeValue("src", ""))
                .ToList();

            return images;
        }
    }
}

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ImbcDownloader : DownloaderBase
    {
        public ImbcDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "enews.imbc.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                    .SelectSingleNode("//*[@class=\"ent-cont\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""))
                    .ToList();

            return images;
        }
    }
}

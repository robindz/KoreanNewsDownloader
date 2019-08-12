using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class XportsnewsDownloader : DownloaderBase
    {
        public XportsnewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.xportsnews.com", "xportsnews.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"articleView\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""))
                .ToList();

            return images;
        }
    }
}

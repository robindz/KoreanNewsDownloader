using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SegyeDownloader : DownloaderBase
    {
        public SegyeDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "segye.com", "www.segye.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"article_txt\"]")
                .Descendants("img")
                .Select(x => $"http:{x.GetAttributeValue("src", "")}")
                .ToList();

            return images;
        }
    }
}

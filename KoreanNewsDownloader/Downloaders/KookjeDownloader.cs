using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KookjeDownloader : DownloaderBase
    {
        public KookjeDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.kookje.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectSingleNode("//*[@class=\"news_article\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""))
                .ToList();

            return images;
        }
    }
}

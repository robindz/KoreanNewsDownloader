using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class OsenDownloader : DownloaderBase
    {
        public OsenDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.osen.co.kr", "osen.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = doc.DocumentNode
                    .SelectNodes("//*[@class=\"view_photo up\"]")
                    .Select(x => x.GetAttributeValue("src", "").Replace("article", "article/original").Replace("_1024x", ""))
                    .ToList();

            return images;
        }
    }
}

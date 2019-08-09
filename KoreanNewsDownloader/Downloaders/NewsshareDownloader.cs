using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewsshareDownloader : DownloaderBase
    {
        public NewsshareDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.newsshare.co.kr", "newsshare.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectNodes("//*[@class=\"body_img_table2\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""))
                .ToList();

            return images;
        }
    }
}

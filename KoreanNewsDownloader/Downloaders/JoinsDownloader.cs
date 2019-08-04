using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class JoinsDownloader : DownloaderBase
    {
        public JoinsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "isplus.live.joins.com", "dcnewsj.joins.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            if (uri.Host == HostUrls[0])
            {
                //return await GetOgImageAsync(uri);
            }

            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectNodes("//*[@class=\"image\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("data-src", ""))
                .ToList();

            return images;
        }
    }
}

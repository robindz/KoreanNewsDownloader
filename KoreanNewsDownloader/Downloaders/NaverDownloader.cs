using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NaverDownloader : DownloaderBase
    {
        public NaverDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "post.naver.com", "m.post.naver.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            string html = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"__clipContent\"]")
                .InnerText;

            doc.LoadHtml(html);

            var images = doc.DocumentNode
                .SelectNodes("//*[@class=\"se_mediaImage __se_img_el\"]")
                .Select(x => x.GetAttributeValue("data-src", "").Substring(0, x.GetAttributeValue("data-src", "").LastIndexOf("?type=")))
                .ToList();

            return images;
        }
    }
}

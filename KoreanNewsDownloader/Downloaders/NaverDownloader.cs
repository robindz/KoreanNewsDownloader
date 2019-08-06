using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

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

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            string html = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"__clipContent\"]")
                .InnerText;

            doc.LoadHtml(html);

            var images = doc.DocumentNode
                .SelectNodes("//*[@class=\"se_mediaImage __se_img_el\"]")
                .Select(x => Regex.Replace(x.GetAttributeValue("data-src", ""), @"\?type.*", ""))
                .ToList();

            return images;
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => HttpUtility.UrlDecode(x.Split('/').Last()));
        }
    }
}

using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NaverDownloader : DownloaderBase
    {
        public NaverDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "post.naver.com", "m.post.naver.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            string html = Document.DocumentNode
                .SelectSingleNode("//*[@id=\"__clipContent\"]")
                .InnerText;

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            return doc.DocumentNode
                .SelectNodes("//*[@class=\"se_mediaImage __se_img_el\"]")
                .Select(x => Regex.Replace(x.GetAttributeValue("data-src", ""), @"\?type.*", ""));
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => HttpUtility.UrlDecode(x.Split('/').Last()));
        }
    }
}

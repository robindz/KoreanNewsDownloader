using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MdprDownloader : DownloaderBase
    {
        public MdprDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "mdpr.jp", "www.mdpr.jp"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@class=\"outputthumb\"]")
                .Select(x => Regex.Replace(x.GetAttributeValue("src", ""), @"\?width.*", ""));
        }
    }
}

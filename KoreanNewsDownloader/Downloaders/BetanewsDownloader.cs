using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    public class BetanewsDownloader : DownloaderBase
    {
        public BetanewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.betanews.net", "betanews.net"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"articleBody\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("//") ? $"http:{x.GetAttributeValue("src", "")}"
                                                                                 : x.GetAttributeValue("src", ""));
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}

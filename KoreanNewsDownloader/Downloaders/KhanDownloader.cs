using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KhanDownloader : DownloaderBase
    {
        public KhanDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "sports.khan.co.kr", "news.khan.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"articleBody\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").Replace("l_", ""));
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}

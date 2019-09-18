using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class PulsenewsDownloader : DownloaderBase
    {
        public PulsenewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.pulsenews.co.kr", "pulsenews.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//div[@class=\"art_img\"]/div/img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("//") ? $"https:{x.GetAttributeValue("src", "")}"
                                                                             : x.GetAttributeValue("src", ""));
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}

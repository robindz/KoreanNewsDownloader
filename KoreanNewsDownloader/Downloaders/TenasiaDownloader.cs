using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    public class TenasiaDownloader : DownloaderBase
    {
        public TenasiaDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.tenasia.co.kr", "tenasia.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                    .Descendants()
                    .Where(x => x.Id.Contains("attachment_"))
                    .Select(x => x.FirstChild.GetAttributeValue("src", "").Substring(0, x.FirstChild.GetAttributeValue("src", "").LastIndexOf("-")) + ".jpg");
        }
    }
}

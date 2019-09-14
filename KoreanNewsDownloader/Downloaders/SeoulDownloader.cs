using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SeoulDownloader : DownloaderBase
    {
        public SeoulDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "www.seoul.co.kr", "seoul.co.kr", "en.seoul.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[2])
            {
                return Document.DocumentNode
                    .SelectSingleNode("//*[@id=\"CmAdContent\"]")
                    .Descendants("img")
                    .Select(x => $"https:{x.GetAttributeValue("src", "").Replace("_V", "")}");
            }

            return Document.DocumentNode
                .SelectNodes("//*[@class=\"v_photoarea\"]")
                .Descendants("img")
                .Where(x => x.GetAttributeValue("src", "").Contains("upload"))
                .Select(x => $"https:{x.GetAttributeValue("src", "").Replace("_V", "")}");
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}

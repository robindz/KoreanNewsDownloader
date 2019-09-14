using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MedicalworldnewsDownloader : DownloaderBase
    {
        public MedicalworldnewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.medicalworldnews.co.kr", "medicalworldnews.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"viewContent\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/data/") ? $"http://www.medicalworldnews.co.kr{x.GetAttributeValue("src", "")}"
                                                                                 : x.GetAttributeValue("src", ""));
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class YtnDownloader : DownloaderBase
    {
        public YtnDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.ytn.co.kr", "ytn.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            List<string> images = new List<string>();
            var imgNodes = Document.DocumentNode
                .SelectNodes("//*[@id=\"newsContent\"]")
                .Descendants("img").ToList();

            images.Add(imgNodes.FirstOrDefault().GetAttributeValue("src", ""));
            
            if (imgNodes.Count > 1)
            {
                images.AddRange(imgNodes.GetRange(1, imgNodes.Count - 1).Select(x => x.GetAttributeValue("data-src", "")).ToList());
            }

            return images.Distinct().Where(x => x != string.Empty);
        }
    }
}

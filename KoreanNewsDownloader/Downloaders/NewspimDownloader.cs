using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewspimDownloader : DownloaderBase
    {
        public NewspimDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "www.newspim.com", "newspim.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"news_contents\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").Replace("_w", ""));
        }
    }
}

using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NocutnewsDownloader : DownloaderBase
    {
        public NocutnewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "www.nocutnews.co.kr", "nocutnews.co.kr"
            };
        }
    }
}

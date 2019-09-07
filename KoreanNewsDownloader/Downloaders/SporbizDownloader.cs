using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SporbizDownloader : DownloaderBase
    {
        public SporbizDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "sporbiz.co.kr", "www.sporbiz.co.kr"
            };
        }
    }
}

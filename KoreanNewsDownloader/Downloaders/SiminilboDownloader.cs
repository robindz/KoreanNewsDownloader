using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SiminilboDownloader : DownloaderBase
    {
        public SiminilboDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "www.siminilbo.co.kr", "siminilbo.co.kr"
            };
        }
    }
}

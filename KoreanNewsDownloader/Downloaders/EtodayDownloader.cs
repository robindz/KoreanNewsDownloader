using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class EtodayDownloader : DownloaderBase
    {
        public EtodayDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "enter.etoday.co.kr", "www.etoday.co.kr"
            };
        }
    }
}

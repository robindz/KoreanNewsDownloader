using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KoreabiomedDownloader : DownloaderBase
    {
        public KoreabiomedDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.koreabiomed.com", "koreabiomed.com"
            };
        }
    }
}

using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class FnnewsDownloader : DownloaderBase
    {
        public FnnewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "star.fnnews.com", "hugs.fnnews.com", "www.fnnews.com"
            };
        }
    }
}

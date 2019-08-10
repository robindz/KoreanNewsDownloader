using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class PolinewsDownloader : DownloaderBase
    {
        public PolinewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.polinews.co.kr", "polinews.co.kr"
            };
            HttpClient = httpClient;
        }
    }
}

using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewsinsideDownloader : DownloaderBase
    {
        public NewsinsideDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.newsinside.kr", "newsinside.kr"
            };
            HttpClient = httpClient;
        }
    }
}

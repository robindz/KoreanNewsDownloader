using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class FnnewsDownloader : DownloaderBase
    {
        public FnnewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "star.fnnews.com", "hugs.fnnews.com", "www.fnnews.com"
            };
            HttpClient = httpClient;
        }
    }
}

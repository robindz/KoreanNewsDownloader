using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MkDownloader : DownloaderBase
    {
        public MkDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "sports.mk.co.kr", "star.mk.co.kr", "www.mk.co.kr", "mk.co.kr"
            };
            HttpClient = httpClient;
        }
    }
}

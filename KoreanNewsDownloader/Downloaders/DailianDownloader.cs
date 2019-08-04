using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DailianDownloader : DownloaderBase
    {
        public DailianDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.dailian.co.kr"
            };
            HttpClient = httpClient;
        }
    }
}

using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class EtodayDownloader : DownloaderBase
    {
        public EtodayDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "enter.etoday.co.kr", "www.etoday.co.kr"
            };
            HttpClient = httpClient;
        }
    }
}

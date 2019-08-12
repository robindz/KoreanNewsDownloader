using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KndailyDownloader : DownloaderBase
    {
        public KndailyDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.kndaily.co.kr", "kndaily.co.kr"
            };
            HttpClient = httpClient;
        }
    }
}

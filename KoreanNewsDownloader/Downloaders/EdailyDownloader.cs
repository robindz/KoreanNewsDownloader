using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class EdailyDownloader : DownloaderBase
    {
        public EdailyDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.edaily.co.kr"
            };
            HttpClient = httpClient;
        }
    }
}

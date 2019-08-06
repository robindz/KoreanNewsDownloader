using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KukinewsDownloader : DownloaderBase
    {
        public KukinewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.kukinews.com"
            };
            HttpClient = httpClient;
        }
    }
}

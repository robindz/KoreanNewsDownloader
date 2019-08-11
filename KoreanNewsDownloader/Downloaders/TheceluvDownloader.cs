using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class TheceluvDownloader : DownloaderBase
    {
        public TheceluvDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "theceluv.com", "www.theceluv.com"
            };
            HttpClient = httpClient;
        }
    }
}

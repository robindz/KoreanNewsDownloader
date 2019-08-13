using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class CbciDownloader : DownloaderBase
    {
        public CbciDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.cbci.co.kr", "cbci.co.kr"
            };
            HttpClient = httpClient;
        }
    }
}

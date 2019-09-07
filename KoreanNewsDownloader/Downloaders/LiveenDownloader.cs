using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class LiveenDownloader : DownloaderBase
    {
        public LiveenDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.liveen.co.kr"
            };
            HttpClient = httpClient;
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}

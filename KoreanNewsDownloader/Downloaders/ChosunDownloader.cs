using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ChosunDownloader : DownloaderBase
    {
        public ChosunDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "sports.chosun.com", "m.sportschosun.com"
            };
        }

        public override Encoding GetEncoding()
        {
            if (Uri.Host == HostUrls[0])
                return Encoding.GetEncoding("EUC-KR");

            return base.GetEncoding();
        }
    }
}

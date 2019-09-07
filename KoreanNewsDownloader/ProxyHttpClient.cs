using System.Net.Http;

namespace KoreanNewsDownloader
{
    public class ProxyHttpClient : HttpClient
    {
        public ProxyHttpClient(HttpClientHandler handler) : base(handler) { }
    }
}

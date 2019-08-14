using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class TvreportDownloader : DownloaderBase
    {
        public TvreportDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.tvreport.co.kr", "tvreport.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            var images = base.GetArticleImages();
            return images.Select(x => x.Replace("_1.jpg", "_0.jpg"));
        }
    }
}

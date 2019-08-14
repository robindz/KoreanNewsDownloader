using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class TvjDownloader : DownloaderBase
    {
        public TvjDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.tvj.co.kr", "tvj.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            var images = base.GetArticleImages();
            return images.Select(x => x.Replace("thumbnail", "photo").Replace("_v150", ""));
        }
    }
}

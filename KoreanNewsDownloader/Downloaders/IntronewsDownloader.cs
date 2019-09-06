using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class IntronewsDownloader : DownloaderBase
    {
        public IntronewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "intronews.net", "www.intronews.net"
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

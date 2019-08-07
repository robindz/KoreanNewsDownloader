using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MetroseoulDownloader : DownloaderBase
    {
        public MetroseoulDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.metroseoul.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            var images = await base.GetImageUrlsAsync(uri);
            return images.Select(x => $"http://cdn.emetro.co.kr/html/image_view_maxw.php?x=9999999999&ds=9999999999&f={x.Split('/').Last()}").ToList();
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => x.Substring(x.LastIndexOf("=") + 1));
        }
    }
}

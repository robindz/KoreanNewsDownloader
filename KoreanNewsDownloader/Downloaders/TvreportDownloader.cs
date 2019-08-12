using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            var images = await base.GetImageUrlsAsync(uri);
            return images.Select(x => x.Replace("_1.jpg", "_0.jpg")).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    internal class HeraldcorpDownloader : DownloaderBase
    {
        public HeraldcorpDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "biz.heraldcorp.com","pop.heraldcorp.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            IList<string> images = await GetOgImageAsync(uri);

            if (uri.Host == HostUrls[1])
            {
                images = images.Select(x => x.Replace("idx=42", "idx=999")).ToList();
            }

            return images;
        }
    }
}

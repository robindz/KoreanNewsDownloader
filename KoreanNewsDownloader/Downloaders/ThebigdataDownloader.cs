using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ThebigdataDownloader : DownloaderBase
    {
        public ThebigdataDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.thebigdata.co.kr", "cnews.thebigdata.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => x.Substring(x.LastIndexOf("=") + 1));
        }
    }
}

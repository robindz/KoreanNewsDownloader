﻿using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SpotvnewsDownloader : DownloaderBase
    {
        public SpotvnewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "spotvnews.co.kr", "www.spotvnews.co.kr"
            };
            HttpClient = httpClient;
        }
    }
}
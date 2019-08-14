﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewsinsideDownloader : DownloaderBase
    {
        public NewsinsideDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.newsinside.kr", "newsinside.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"articleBody\"]")
                .SelectNodes("//figure/img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/news/") ? $"http://cds.newsinside.kr{x.GetAttributeValue("src", "").Replace("thumbnail", "photo").Replace("_v150", "")}"
                                                                                 : x.GetAttributeValue("src", "").Replace("thumbnail", "photo").Replace("_v150", ""))
                .ToList();

            return images;
        }
    }
}

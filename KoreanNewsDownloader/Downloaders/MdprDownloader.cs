﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MdprDownloader : DownloaderBase
    {
        public MdprDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "mdpr.jp", "www.mdpr.jp"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectNodes("//*[@class=\"outputthumb\"]")
                .Select(x => x.GetAttributeValue("src", "").Substring(0, x.GetAttributeValue("src", "").LastIndexOf(".jpg") + 4))
                .ToList();

            return images;
        }
    }
}

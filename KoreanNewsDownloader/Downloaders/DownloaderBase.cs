using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    public abstract class DownloaderBase : IDownloader
    {
        public IList<string> HostUrls { get; set; }
        protected readonly int BufferSize = 65536;
        protected HttpClient HttpClient { get; set; }

        public async Task DownloadAsync(string url, string filePath, bool overwrite)
        {
            await DownloadAsync(new Uri(url), filePath, overwrite);
        }
        public async Task DownloadAsync(Uri uri, string filePath, bool overwrite)
        {
            IList<string> images = await GetImagesAsync(uri.AbsoluteUri);
            for (int i = 0; i < images.Count(); i++)
            {
                string fileName = CleanImageName($"{images[i].Split('/').Last()}");
                using (Stream imageStream = await HttpClient.GetStreamAsync(images[i]))
                {
                    FileMode fileMode = overwrite ? FileMode.Create : FileMode.CreateNew;

                    using (FileStream fileStream = new FileStream($"{filePath}/{fileName}", fileMode, FileAccess.Write, FileShare.None, BufferSize, true))
                    {
                        await imageStream.CopyToAsync(fileStream);
                    }
                }
            }
        }
        public async Task<IList<string>> GetOgImageAsync(string url)
        {
            HtmlDocument doc = await GetDocumentAsync(url);

            var images = doc.DocumentNode
                .Descendants()
                .Where(x => x.Name == "meta" && x.GetAttributeValue("property", "") == "og:image")
                .Select(x => x.GetAttributeValue("content", "").Replace("?1", ""))
                .ToList();

            return images;
        }
        public async Task<IList<string>> GetImagesAsync(string url)
        {
            return await GetImagesAsync(new Uri(url));
        }
        public abstract Task<IList<string>> GetImagesAsync(Uri uri);
        protected async Task<HtmlDocument> GetDocumentAsync(string url)
        {
            string html = await GetHtmlAsync(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }
        private async Task<string> GetHtmlAsync(string url)
        {
            return await HttpClient.GetStringAsync(url);
        }
        private string CleanImageName(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf("=") + 1);
        }
    }
}

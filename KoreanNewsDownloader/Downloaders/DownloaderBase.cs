using HtmlAgilityPack;
using KoreanNewsDownloader.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    public partial class DownloaderBase : IDownloader
    {
        public List<string> HostUrls { get; set; }

        protected readonly int BufferSize = (int)Math.Pow(2, 13);

        protected HtmlDocument Document { get; set; } = new HtmlDocument();
        protected Uri Uri { get; set; }
        protected HttpClient HttpClient { get; set; }
        protected ProxyHttpClient ProxyHttpClient { get; set; }

        public DownloaderBase(HttpClient httpClient, ProxyHttpClient proxyHttpClient)
        {
            HttpClient = httpClient;
            ProxyHttpClient = proxyHttpClient;
        }

        public async Task LoadArticleAsync(Uri uri)
        {
            Uri = ValidateUri(uri);
            string html = await GetHtmlAsync();
            Document.LoadHtml(html);
        }

        public async Task DownloadArticleImagesAsync(string path, bool overwrite)
        {
            List<string> images = GetArticleImages().ToList();
            images = images.Distinct().ToList();

            IList<string> fileNames = GetFilenames(images).ToList();

            for (int i = 0; i < images.Count(); i++)
            {
                await DownloadImageAsync(images[i], path, fileNames[i], overwrite ? FileMode.Create : FileMode.CreateNew);
            }
        }

        public virtual IEnumerable<string> GetArticleImages()
        {
            return GetOgArticleImage();
        }

        public virtual string GetArticleTitle()
        {
            return GetOgArticleTitle();
        }

        public virtual IEnumerable<string> GetFilenames(IEnumerable<string> images) => images.Select(x => x.Split('/').Last());

        public virtual Encoding GetEncoding() => Encoding.UTF8;

        public virtual bool UseProxy() => false;

        private IEnumerable<string> GetOgArticleImage()
        {
            return Document.DocumentNode
               .Descendants("meta")
               .First(x => x.GetAttributeValue("property", "") == "og:image")
               .GetAttributeValue("content", "")
               .Yield();
        }

        private string GetOgArticleTitle()
        {
            return HttpUtility.HtmlDecode(Document.DocumentNode
                .Descendants("title")
                .First()
                .InnerText).Trim();
        }

        private async Task DownloadImageAsync(string source, string path, string name, FileMode fileMode)
        {
            using (Stream imageStream = await HttpClient.GetStreamAsync(source))
            {
                using (FileStream fileStream = new FileStream($"{path}/{name}", fileMode, FileAccess.Write, FileShare.None, BufferSize, true))
                {
                    await imageStream.CopyToAsync(fileStream);
                }
            }
        }

        private async Task<string> GetHtmlAsync()
        {
            Encoding encoding = GetEncoding();
            if (UseProxy())
            {
                return encoding.GetString(await ProxyHttpClient.GetByteArrayAsync(Uri));
            }
            else
            {
                return encoding.GetString(await HttpClient.GetByteArrayAsync(Uri));
            }
        }

        private Uri ValidateUri(Uri uri)
        {
            if ((uri.Host == "www.news1.kr" || uri.Host == "news1.kr") && uri.AbsoluteUri.Contains("view"))
                return new Uri(uri.AbsoluteUri.Replace("view", "details").Replace("&80", ""));
            return uri;
        }
    }
}

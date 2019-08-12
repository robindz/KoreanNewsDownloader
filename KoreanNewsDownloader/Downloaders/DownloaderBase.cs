using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    public abstract class DownloaderBase : IDownloader
    {
        public IList<string> HostUrls { get; set; }
        protected readonly int BufferSize = (int)Math.Pow(2, 13);
        protected HttpClient HttpClient { get; set; }

        public async Task DownloadArticleImagesAsync(string url, string filePath, bool overwrite)
        {
            await DownloadArticleImagesAsync(new Uri(url), filePath, overwrite);
        }

        public async Task DownloadArticleImagesAsync(Uri uri, string filePath, bool overwrite)
        {
            IList<string> images = await GetImageUrlsAsync(uri);
            images = images.Distinct().ToList();

            IList<string> fileNames = GetFilenames(images).ToList();

            for (int i = 0; i < images.Count(); i++)
            {
                await DownloadImageAsync(images[i], filePath, fileNames[i], overwrite ? FileMode.Create : FileMode.CreateNew);
            }
        }

        public virtual async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
               .Descendants()
               .Where(x => x.Name == "meta" && x.GetAttributeValue("property", "") == "og:image")
               .Select(x => x.GetAttributeValue("content", ""))
               .ToList();

            return images;
        }

        public IList<string> GetOgImageUrl(HtmlDocument document)
        {
            var images = document.DocumentNode
               .Descendants()
               .Where(x => x.Name == "meta" && x.GetAttributeValue("property", "") == "og:image")
               .Select(x => x.GetAttributeValue("content", ""))
               .ToList();

            return images;
        }

        public virtual IEnumerable<string> GetFilenames(IEnumerable<string> images) => images.Select(x => x.Split('/').Last());

        protected async Task<HtmlDocument> GetDocumentAsync(Uri uri)
        {
            string html = await GetHtmlAsync(uri);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }

        private async Task DownloadImageAsync(string source, string filePath, string fileName, FileMode fileMode)
        {
            using (Stream imageStream = await HttpClient.GetStreamAsync(source))
            {
                using (FileStream fileStream = new FileStream($"{filePath}/{fileName}", fileMode, FileAccess.Write, FileShare.None, BufferSize, true))
                {
                    await imageStream.CopyToAsync(fileStream);
                }
            }
        }

        private async Task<string> GetHtmlAsync(Uri uri)
        {
            return Encoding.UTF8.GetString(await HttpClient.GetByteArrayAsync(uri));
        }

        private string CleanImageName(string fileName)
        {
            fileName = fileName.Substring(fileName.LastIndexOf("=") + 1);
            if (!(fileName.EndsWith(".png") || fileName.EndsWith(".jpg") || fileName.EndsWith(".jpeg") || fileName.EndsWith(".gif")))
            {
                fileName += ".jpg";
            }
            return HttpUtility.UrlDecode(fileName);
        }
    }
}

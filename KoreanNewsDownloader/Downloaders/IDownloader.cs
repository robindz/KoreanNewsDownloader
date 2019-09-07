using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    public interface IDownloader
    {
        List<string> HostUrls { get; set; }
        Task LoadArticleAsync(Uri uri);
        Task DownloadArticleImagesAsync(string filePath, bool overwrite);
        IEnumerable<string> GetArticleImages();
        string GetArticleTitle();
    }
}

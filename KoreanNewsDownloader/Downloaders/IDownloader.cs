using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    public interface IDownloader
    {
        IList<string> HostUrls { get; set; }
        Task DownloadArticleImagesAsync(Uri uri, string filePath, bool overwrite);
        Task<IList<string>> GetImageUrlsAsync(Uri uri);
    }
}

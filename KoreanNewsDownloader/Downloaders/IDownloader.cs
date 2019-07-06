using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    public interface IDownloader
    {
        IList<string> HostUrls { get; set; }
        Task DownloadAsync(Uri uri, string filePath, bool overwrite);
        Task<IList<string>> GetImagesAsync(Uri uri);
    }
}

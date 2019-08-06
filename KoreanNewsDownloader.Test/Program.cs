using System;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Test
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string folder = @"C:\Users\robin\Desktop\botlog";

            var downloader = new KDownloader();

            await downloader.DownloadArticleImagesAsync(new Uri("https://mdpr.jp/music/detail/1809786"), folder, true);
            await downloader.DownloadArticleImagesAsync(new Uri("https://mdpr.jp/photo/detail/6909306"), folder, true);
            await downloader.DownloadArticleImagesAsync(new Uri("https://mdpr.jp/k-enta/detail/1809977"), folder, true);

            Console.ReadKey();
        }
    }
}

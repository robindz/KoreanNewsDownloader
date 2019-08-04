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

            await downloader.DownloadArticleImagesAsync(new Uri("https://photo.insight.co.kr/news/239073"), folder, true);
            await downloader.DownloadArticleImagesAsync(new Uri("https://www.insight.co.kr/news/223957"), folder, true);

            Console.ReadKey();
        }
    }
}

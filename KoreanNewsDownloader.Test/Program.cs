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

            await downloader.DownloadArticleImagesAsync(new Uri("http://www.sporbiz.co.kr/news/articleView.html?idxno=299210"), folder, true);
            await downloader.DownloadArticleImagesAsync(new Uri("http://sporbiz.co.kr/news/articleView.html?idxno=299210"), folder, true);

            Console.ReadKey();
        }
    }
}

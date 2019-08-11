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

            await downloader.DownloadArticleImagesAsync(new Uri("http://theviewers.co.kr/news/articleView.html?idxno=41767"), folder, true);
            await downloader.DownloadArticleImagesAsync(new Uri("http://www.theviewers.co.kr/news/articleView.html?idxno=41767"), folder, true);
            await downloader.DownloadArticleImagesAsync(new Uri("http://viewers.heraldcorp.com/news/articleView.html?idxno=27556"), folder, true);

            Console.ReadKey();
        }
    }
}

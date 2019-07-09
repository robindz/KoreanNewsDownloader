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

            await downloader.DownloadAsync("http://www.newsinside.kr/news/articleView.html?idxno=652740", folder);
            await downloader.DownloadAsync("http://newsinside.kr/news/articleView.html?idxno=652740", folder, true);

            Console.ReadKey();
        }
    }
}

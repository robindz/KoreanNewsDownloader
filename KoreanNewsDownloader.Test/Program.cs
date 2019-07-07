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

            await downloader.DownloadAsync("http://www.ilyoseoul.co.kr/news/articleView.html?idxno=304669", folder);
            await downloader.DownloadAsync("http://www.ilyoseoul.co.kr/news/articleView.html?idxno=279446", folder);

            Console.ReadKey();
        }
    }
}

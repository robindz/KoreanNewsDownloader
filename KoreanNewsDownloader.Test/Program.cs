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

            await downloader.DownloadAsync("https://www.insight.co.kr/news/223957", folder);
            await downloader.DownloadAsync("https://photo.insight.co.kr/news/196409", folder);

            Console.ReadKey();
        }
    }
}

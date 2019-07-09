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

            await downloader.DownloadAsync("http://www.newsshare.co.kr/sub_read.html?uid=96026", folder);
            await downloader.DownloadAsync("http://newsshare.co.kr/sub_read.html?uid=96026", folder, true);

            Console.ReadKey();
        }
    }
}

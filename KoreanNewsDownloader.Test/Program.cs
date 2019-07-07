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

            await downloader.DownloadAsync("https://gall.dcinside.com/board/view/?id=issuezoom&no=4025", folder);
            await downloader.DownloadAsync("https://gall.dcinside.com/board/view/?id=twice&no=9362256&exception_mode=recommend&page=1", folder);
            await downloader.DownloadAsync("https://gall.dcinside.com/board/view/?id=twice&no=9334076&exception_mode=recommend", folder);

            Console.ReadKey();
        }
    }
}

using KoreanNewsDownloader.Downloaders;
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

            await downloader.DownloadAsync("http://cnews.thebigdata.co.kr/view.php?ud=201811281430301567482b2d7606_23", folder);
            await downloader.DownloadAsync("http://www.thebigdata.co.kr/view.php?ud=201905200956044318482b2d7606_23", folder);

            Console.ReadKey();
        }
    }
}

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

            await downloader.DownloadAsync("http://www.newspim.com/news/view/20181206000799", folder);
            await downloader.DownloadAsync("http://newspim.com/news/view/20181206000799", folder, true);

            Console.ReadKey();
        }
    }
}

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

            await downloader.DownloadAsync("http://m.sportschosun.com/news.htm?id=201904220100178910012180&ServiceDate=20190422&f_url=Fire#_enliple", folder);
            await downloader.DownloadAsync("http://sports.chosun.com/news/utype.htm?id=201906260100198980013567&ServiceDate=20190626", folder);

            Console.ReadKey();
        }
    }
}

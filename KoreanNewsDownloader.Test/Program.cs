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

            await downloader.DownloadAsync("http://star.ohmynews.com/NWS_Web/OhmyStar/at_pg.aspx?CNTN_CD=A0002501468", folder);
            await downloader.DownloadAsync("http://www.ohmynews.com/NWS_Web/View/img_pg.aspx?CNTN_CD=IE002416385", folder);

            Console.ReadKey();
        }
    }
}

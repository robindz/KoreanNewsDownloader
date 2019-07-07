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

            await downloader.DownloadAsync("http://isplus.live.joins.com/news/article/article.asp?total_id=23152505&cloc=isplus%7Csport%7Cisplus_art_mustclick", folder);
            await downloader.DownloadAsync("http://isplus.live.joins.com/news/article/article.asp?total_id=22456266", folder);
            await downloader.DownloadAsync("https://dcnewsj.joins.com/article/23518080?cloc=dcnewsj|list", folder);

            Console.ReadKey();
        }
    }
}

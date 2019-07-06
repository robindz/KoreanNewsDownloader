using KoreanNewsDownloader.Downloaders;
using System;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Test
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("KoreanNewsDownloader v0.1 by GodsWithin");

            var downloader = new KDownloader();

            await downloader.DownloadAsync("https://www.ajunews.com/view/20190704072752092", @"C:\Users\robin\Desktop\botlog", false);
            await downloader.DownloadAsync("http://www.asiatoday.co.kr/view.php?key=20190705010003683", @"C:\Users\robin\Desktop\botlog", false);
            await downloader.DownloadAsync("http://pop.heraldcorp.com/view.php?ud=201907021700105694458_1", @"C:\Users\robin\Desktop\botlog", false);
            await downloader.DownloadAsync("http://biz.heraldcorp.com/culture/view.php?ud=201901151754080859875_1", @"C:\Users\robin\Desktop\botlog", false);
            await downloader.DownloadAsync("http://bntnews.hankyung.com/apps/news?popup=0&nid=04&c1=04&c2=04&c3=00&nkey=201812110834233&mode=sub_view", @"C:\Users\robin\Desktop\botlog", false);
            await downloader.DownloadAsync("https://www.hankyung.com/entertainment/article/201904221513H", @"C:\Users\robin\Desktop\botlog", false);

            Console.ReadKey();
        }
    }
}

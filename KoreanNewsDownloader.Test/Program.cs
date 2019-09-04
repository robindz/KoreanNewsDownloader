using System;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Test
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string folder = @"C:\Users\robin\Desktop\";

            var downloader = new KDownloader();

            await downloader.LoadArticleAsync("https://www.ajunews.com/view/20190704072752092");
            Console.WriteLine(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            await downloader.LoadArticleAsync("http://www.asiatoday.co.kr/view.php?key=20190705010003683");
            Console.WriteLine(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            await downloader.LoadArticleAsync("http://biz.heraldcorp.com/culture/view.php?ud=201901151754080859875_1");
            Console.WriteLine(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            await downloader.LoadArticleAsync("http://pop.heraldcorp.com/view.php?ud=201907021700105694458_1");
            Console.WriteLine(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            await downloader.LoadArticleAsync("http://bntnews.hankyung.com/apps/news?popup=0&nid=04&c1=04&c2=04&c3=00&nkey=201812110834233&mode=sub_view");
            Console.WriteLine(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            await downloader.LoadArticleAsync("https://www.hankyung.com/entertainment/article/201904221513H");
            Console.WriteLine(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            await downloader.LoadArticleAsync("http://news.hankyung.com/article/201811053473H");
            Console.WriteLine(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            await downloader.LoadArticleAsync("http://tenasia.hankyung.com/archives/1607731");
            Console.WriteLine(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Test
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string folder = @"C:\Users\robin\Desktop\";
            List<string> titles = new List<string>();

            var downloader = new KDownloader();
            
            await downloader.LoadArticleAsync("https://www.ajunews.com/view/20190704072752092");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.asiatoday.co.kr/view.php?key=20190705010003683");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://biz.heraldcorp.com/culture/view.php?ud=201901151754080859875_1");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://pop.heraldcorp.com/view.php?ud=201907021700105694458_1");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://bntnews.hankyung.com/apps/news?popup=0&nid=04&c1=04&c2=04&c3=00&nkey=201812110834233&mode=sub_view");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.hankyung.com/entertainment/article/201904221513H");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://news.hankyung.com/article/201811053473H");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://tenasia.hankyung.com/archives/1607731");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.breaknews.com/sub_read.html?uid=665014");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.getnews.co.kr/view.php?ud=20190519193930687580ed35aa76_16");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://cnews.getnews.co.kr/view.php?ud=20181129102859399280ed35aa76_16");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://cnews.thebigdata.co.kr/view.php?ud=201811281430301567482b2d7606_23");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.thebigdata.co.kr/view.php?ud=201905200956044318482b2d7606_23");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.dailian.co.kr/news/view/789623");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.dailypop.kr/news/articleView.html?idxno=39563");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.dispatch.co.kr/1566345");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.dt.co.kr/contents.html?article_no=2019042202109965035019&ref=daum");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.edaily.co.kr/news/read?newsId=01315286619442128&mediaCodeNo=258");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.egn.kr/news/articleView.html?idxno=118150");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://enews.imbc.com/News/RetrieveNewsInfo/242123");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://enews24.tving.com/news/article?nsID=1318559");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.etoday.co.kr/news/section/newsview.php?idxno=1648199");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://enter.etoday.co.kr/view/news_view.php?varAtcId=158112");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://hugs.fnnews.com/article/201908041615131181");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://star.fnnews.com/archives/754837");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.fnnews.com/news/201908041108002346");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://gall.dcinside.com/board/view/?id=twice&no=9362256&exception_mode=recommend&page=1");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.getitk.com/%ED%8F%AC%ED%86%A0-%ED%8A%B8%EC%99%80%EC%9D%B4%EC%8A%A4-%EB%AF%B8%EB%AA%A8%EC%9D%98-%EC%8B%9C%EB%84%88%EC%A7%80-%ED%9A%A8%EA%B3%BC%EB%A5%BC-%EC%B2%B4%EA%B0%90%ED%95%98%EA%B3%A0-%EC%9E%88/");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            
            await downloader.LoadArticleAsync("http://ilyoseoul.co.kr/news/articleView.html?idxno=304669");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            
            await downloader.LoadArticleAsync("http://www.inews24.com/view/1138814");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.insight.co.kr/news/223957");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://photo.insight.co.kr/news/239073");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            
            await downloader.LoadArticleAsync("http://www.intronews.net/news/articleView.html?idxno=146726");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://isplus.live.joins.com/news/article/article.asp?total_id=22456266");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://dcnewsj.joins.com/article/23518080?cloc=dcnewsj%7Clist");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.issuedaily.com/news/news_view.php?ns_idx=219988");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            

            Console.ReadKey();

        }
    }
}

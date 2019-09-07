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

            /*
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
            

            await downloader.LoadArticleAsync("http://www.joynews24.com/view/1142298");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.kookje.co.kr/news2011/asp/newsbody.asp?code=0500&key=20190617.99099007501");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.kookje.co.kr/news2011/asp/photo.asp?code=0900&pkey=719");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.kukinews.com/news/article.html?no=616048&mode=orig&rvw_no=");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.liveen.co.kr/news/articleView.html?idxno=243468");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://m.post.naver.com/viewer/postView.nhn?volumeNo=19894147&memberNo=22171331");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://post.naver.com/viewer/postView.nhn?volumeNo=18717990&memberNo=29747755");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            
            await downloader.LoadArticleAsync("http://sports.chosun.com/news/utype.htm?id=201906260100198980013567&ServiceDate=20190626");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            
            await downloader.LoadArticleAsync("http://m.sportschosun.com/news.htm?id=201904220100178910012180&ServiceDate=20190422&f_url=Fire#_enliple");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            
            await downloader.LoadArticleAsync("https://mdpr.jp/music/detail/1809786");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://mdpr.jp/photo/detail/6909306");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://mdpr.jp/k-enta/detail/1809977");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.mediasr.co.kr/news/articleView.html?idxno=50932");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.metroseoul.co.kr/news/newsview?newscd=2018101600195");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://moneys.mt.co.kr/news/mwView.php?no=2019021210028052916&outlink=1");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://star.mt.co.kr/stview.php?no=2019042215133513159&outlink=1&ref=https%3A%2F%2Fsearch.daum.net");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://osen.mt.co.kr/article/G1110961803");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.mydaily.co.kr/new_yk/html/read.php?newsid=201811281442305523&ext=da");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.nbnnews.co.kr/news/articleView.html?idxno=226960");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            */
            await downloader.LoadArticleAsync("http://nc.asiae.co.kr/view.htm?idxno=2019021215491181796");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://stoo.asiae.co.kr/article.php?aid=52011665816");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://tvdaily.asiae.co.kr/read.php3?aid=15433825051417865017");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.newdaily.co.kr/site/data/html/2018/12/28/2018122800157.html");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.news-report.co.kr/69/?idx=1430120&bmode=view");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://news.imaeil.com/Entertainments/2018122520110023242");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://news.kstyle.com/article.ksn?articleNo=2106872");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://news.tf.co.kr/read/photomovie/1741282.htm");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.news1.kr/photos/details/?3402915");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.newsinside.kr/news/articleView.html?idxno=977287");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://newspim.com/news/view/20181206000799");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.newsshare.co.kr/sub_read.html?uid=96026");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.newstomato.com/ReadNews.aspx?no=890702");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.nocutnews.co.kr/news/5139037");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://star.ohmynews.com/NWS_Web/OhmyStar/at_pg.aspx?CNTN_CD=A0002501468");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.ohmynews.com/NWS_Web/View/img_pg.aspx?CNTN_CD=IE002416385");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.oricon.co.jp/news/2125266/photo/1/");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.osen.co.kr/article/G1111212743");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://polinews.co.kr/news/article.html?no=400970");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.sedaily.com/NewsView/1S7ATY29FF");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://segye.com/newsView/20190115002414");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.seoul.co.kr/news/newsView.php?id=20181206500185&wlog_tag3=daum");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.sisajournal.com/news/articleView.html?idxno=184393");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.sporbiz.co.kr/news/articleView.html?idxno=299210");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://sports.donga.com/3/all/20181228/93482736/1");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://sports.hankooki.com/lpage/entv/201908/sp20190801201547136730.htm");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://sports.khan.co.kr/entertainment/sk_index.html?art_id=201904221718003&sec_id=540101&pt=nv");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));


            Console.ReadKey();

        }
    }
}

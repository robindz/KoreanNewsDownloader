using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Test
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            List<string> titles = new List<string>();

            var downloader = new KDownloader(new WebProxy("1.1.1.1", 0));

            await downloader.LoadArticleAsync("http://www.joynews24.com/view/1210320");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://www.xportsnews.com/?ac=article_view&entry_id=1171884");
            HttpResponseMessage response = await client.SendAsync(request);
            foreach (string s in response.Content.Headers.ContentEncoding) { Console.WriteLine(s); }
            byte[] bytes = await response.Content.ReadAsByteArrayAsync();

            downloader.LoadArticle(bytes, "http://www.xportsnews.com/?ac=article_view&entry_id=1171884");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.xportsnews.com/?ac=article_view&entry_id=1171884");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.ksilbo.co.kr/news/articleView.html?idxno=724979");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.dispatch.co.kr/2042291");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.upinews.kr/news/newsview.php?ncode=1065605968763168");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://news.mt.co.kr/mtview.php?no=2019081411000963342");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.newswave.kr/sub_read.html?uid=412651");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://businesskorea.co.kr/news/articleView.html?idxno=36090");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://mbnmoney.mbn.co.kr/news/view?news_no=MM1003720813");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://m-i.kr/news/articleView.html?idxno=638920");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.snmnews.com/news/articleView.html?idxno=452565");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://kookminnews.com/news/view.php?idx=23783");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://news.chosun.com/site/data/html_dir/2019/09/18/2019091800408.html");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://fintechpost.co.kr/news/articleView.html?idxno=71353");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://pulsenews.co.kr/view.php?year=2019&no=736518");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.obsnews.co.kr/news/articleView.html?idxno=1177956");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://pluskorea.net/sub_read.html?uid=146994");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://iminju.net/news/articleView.html?idxno=48942");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.horsebiz.co.kr/news/articleView.html?idxno=47536");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));    

            await downloader.LoadArticleAsync("http://seoulwire.com/news/articleView.html?idxno=220487");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://rpm9.com/news/article.html?id=20190918090021");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.famtimes.co.kr/news/view/401439");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://leaders.asiae.co.kr/news/articleView.html?idxno=121334");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.insightkorea.co.kr//news/articleView.html?idxno=58299");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://kookbang.dema.mil.kr/newsWeb/20190918/13/BBSMSTR_000000010060/view.do");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.sportsworldi.com/newsView/20190918507431");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://news.jtbc.joins.com/article/article.aspx?news_id=NB11880808");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://iworldtoday.com/news/articleView.html?idxno=230999");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.ppnews.kr/news/articleView.html?idxno=30007");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://starin.edaily.co.kr/news/newspath.asp?newsId=01154566622621104");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://thetravelnews.co.kr/09/178645/");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.thetravelnews.co.kr/07/168532/");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://coinreaders.com/sub_read.html?uid=5435");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://ccreview.co.kr/news/articleView.html?idxno=203724");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://kidstvnews.co.kr/view.php?ud=2019091217260399288322dbb067_29");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.asiae.co.kr/article/entertainment-star/2019091415183013928");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.interview365.com/news/articleView.html?idxno=88814");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://kyeongin.com/main/view.php?key=20190912001530133");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.starjn.com/sub_read.html?uid=96398");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://sisafocus.co.kr/news/articleView.html?idxno=220463");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.seoul.co.kr/news/newsView.php?id=20181206500185&wlog_tag3=daum");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://en.seoul.co.kr/news/newsView.php?id=20190912500043&wlog_tag3=daum");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
        
            await downloader.LoadArticleAsync("http://joongdo.co.kr/main/view.php?key=20190912001136002");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://smlounge.co.kr/woman/article/42783");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://weekly.cnbnews.com/news/article.html?no=130099");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://digitalchosun.dizzo.com/site/data/html_dir/2019/09/11/2019091180172.html");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://yna.co.kr/view/AKR20190909045900005?input=1179m");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://beyondpost.co.kr/view.php?ud=20190912080301638TJ20554_30");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://kado.net/?mod=news&act=articleView&idxno=987087");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://gooddailynews.co.kr/news/articleView.html?idxno=118128");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://jjan.kr/news/articleView.html?idxno=2060249&sc_section_code=S1N36&sc_sub_section_code=S2N71");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://nanumnews.com/sub_read.html?uid=75967");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.ytn.co.kr/_sn/0117_201909131621129389");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.ytn.co.kr/_sn/0117_201909131000086279");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://news.kmib.co.kr/article/view.asp?arcid=0924097339&code=13180000&cp=du");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://purpress.com/bbs/board.php?bo_table=star&wr_id=12847");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://koreatimes.co.kr/www/opinion/2019/09/197_275452.html");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.mbn.co.kr/pages/news/newsView.php?news_seq_no=3935420");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://star.mbn.co.kr/view.php?sc=71600017&year=2019&no=726199");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://starnnews.com/news/index.html?no=527183");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://etnews.com/20190911000096");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.koreabiomed.com/news/articleView.html?idxno=6427");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://imnews.imbc.com/news/2019/politic/article/5401183_24691.html");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://ksdaily.co.kr/news/articleView.html?idxno=76072");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://medicalworldnews.co.kr/news/view.php?idx=1475665857");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://christiantoday.co.kr/news/325264");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://hsinews.com/sub_read.html?uid=18385");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://gwbiz.kr/sub_read.html?uid=70213");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.dailysecu.com/news/articleView.html?idxno=69074");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://businesspost.co.kr/BP?command=article_view&num=125059");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://nspna.com/news/?mode=view&newsid=382556");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.asiatime.co.kr/news/articleView.html?idxno=269222");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.straightnews.co.kr/news/articleView.html?idxno=55132");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.sentv.co.kr/news/view/551939");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.seohaenews.net/news/article.html?no=57953");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.idjnews.kr/news/articleView.html?idxno=93555");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.gokorea.kr/news/articleView.html?idxno=82930");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.kjdaily.com/article.php?aid=1568018785482838078");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.daejeontoday.com/news/articleView.html?idxno=567705");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.goodnews1.com/news/news_view.asp?seq=90308");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.incheonilbo.com/news/articleView.html?idxno=981503");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://news.mtn.co.kr/newscenter/news_viewer.mtn?gidx=2019091113405189770");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.joygm.com/news/articleView.html?idxno=62965");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://star.hankookilbo.com/News/Read/201811062091080318");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.newsworks.co.kr/news/articleView.html?idxno=393932");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.gpkorea.com/news/articleView.html?idxno=56248");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.fntoday.co.kr/news/articleView.html?idxno=203418");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://sbsfune.sbs.co.kr/news/news_content.jsp?article_id=E10009648148");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://news.wowtv.co.kr/NewsCenter/News/Read?articleId=A201909110031");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.edaily.co.kr/news/read?newsId=02056566622619136&mediaCodeNo=257");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.egn.kr/news/articleView.html?idxno=118150");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.futurekorea.co.kr/news/articleView.html?idxno=120715");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.kwangju.co.kr/read.php3?aid=1568145000676667010");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://news.v.daum.net/v/20190911052407025?f=o");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.betanews.net/article/1048292");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.sisamagazine.co.kr/news/articleView.html?idxno=140314");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.slist.kr/news/articleView.html?idxno=101736");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://koreajoongangdaily.joins.com/news/article/article.aspx?aid=3067809");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://news.khan.co.kr/kh_news/khan_art_view.html?artid=201909102201015&code=960801");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.seconomy.kr/view.php?ud=201909021349032000798818e98b_2");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.newscj.com/news/articleView.html?idxno=652829");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://daily.hankooki.com/lpage/entv/201909/dh20190910200210139020.htm");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.whitepaper.co.kr/news/articleView.html?idxno=172239");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://ksilbo.co.kr/news/articleView.html?idxno=722138");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.economytalk.kr/news/articleView.html?idxno=197061");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://hei.hankyung.com/hub01/201909088202I");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.jejutwn.com/news/article.html?no=50296");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.ccdn.co.kr/news/articleView.html?idxno=601129");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.newskr.kr/news/articleView.html?idxno=31476");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.ajunews.com/view/20190704072752092");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.newsen.com/news_view.php?uid=201909070827353510");
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

            await downloader.LoadArticleAsync("http://www.dt.co.kr/contents.html?article_no=2019042202109965035019&ref=daum");
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
            
            await downloader.LoadArticleAsync("https://www.mk.co.kr/star/photos/view/2018/12/771603/");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://star.mk.co.kr/new/view.php?mc=ST&year=2018&no=771603");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://sports.mk.co.kr/view.php?year=2018&no=744521");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.sportsq.co.kr/news/articleView.html?idxno=312470");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            
            await downloader.LoadArticleAsync("http://www.sportsseoul.com/news/read/803439");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.spotvnews.co.kr/?mod=news&act=articleView&idxno=246655&sc_code=&page=3&total=448");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.stardailynews.co.kr/news/articleView.html?idxno=223243");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.theceluv.com/article.php?aid=1545723443228418009");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://theviewers.co.kr/news/articleView.html?idxno=41767");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.topstarnews.net/news/articleView.html?idxno=653891");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.tvj.co.kr/news/articleView.html?idxno=51159");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.tvreport.co.kr/1091393");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            
            await downloader.LoadArticleAsync("http://viva100.com/main/view.php?key=20181106010002278");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.vop.co.kr/A00001360142.html");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.webdaily.co.kr/view.php?ud=201811151726536425ccf1619543_7");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("https://www.wikitree.co.kr/main/news_view.php?id=403181");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://zine.istyle24.com/Star/StarView.aspx?Idx=41168&Menu=3&_C_=23069");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.kndaily.co.kr/news/articleView.html?idxno=89339");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.busan.com/view/busan/view.php?code=2019071911285593000");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.g-enews.com/view.php?ud=201904041751078093e8b8a793f7_1&ssk=search");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.mediapen.com/news/view/447602");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.siminilbo.co.kr/news/newsview.php?ncode=179524305975223");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.cbci.co.kr/news/articleView.html?idxno=326582");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.fashionn.com/board/read_new.php?table=1024&number=29799");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));

            await downloader.LoadArticleAsync("http://www.biztribune.co.kr/news/articleView.html?idxno=220259");
            titles.Add(downloader.GetArticleTitle());
            Console.WriteLine(string.Join("\n", downloader.GetArticleImages()));
            
            Console.ReadKey();
        }
    }
}

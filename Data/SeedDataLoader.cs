using System;
using AngleSharp.Parser.Html;
using System.Net;
using AngleSharp.Dom.Html;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace FanficSite.Data
{
    public class SeedDataLoader
    {
        readonly Uri mainPageUri = new Uri("https://www.quotev.com/fanfic");
        ConcurrentQueue<Uri> uriQueue = new ConcurrentQueue<Uri>();

        public void LoadData()
        {
            var mainPage = LoadMainPage();
            
        }

        private IHtmlDocument LoadMainPage()
        {
            IHtmlDocument mainPage = null;
            do
            {
                mainPage = TryLoadMainPage();
            } while (mainPage == null);

            return mainPage;
        }

        private IHtmlDocument TryLoadMainPage()
        {
            try
            {
                return GetHtmlPageDocument(mainPageUri);
            }
            catch (WebException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private IHtmlDocument GetHtmlPageDocument(Uri uri)
        {
            using (WebClient webClient = new WebClient())
            {
                HtmlParser htmlParser = new HtmlParser();
                return htmlParser.Parse(webClient.DownloadString(uri));
            }
        }
    }
    
    
}
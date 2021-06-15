using MyWebServer.Http;
using MyWebServer.HTTP;

namespace MyWebServer.Results
{
    public class HtmlResult : ContentResult
    {
        public HtmlResult(HTTPResponse response, string html)
           : base(response, html, HttpContentType.Html)
        {


        }


    }
}

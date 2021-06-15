using MyWebServer.Http;
using MyWebServer.HTTP;

namespace MyWebServer.Results
{
    public class TextResult : ContentResult
    {
        public TextResult(HTTPResponse response, string text)
            : base(response, text, HttpContentType.PlainText)
        {
        }
    }
}

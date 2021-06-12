using MyWebServer.Common;
using MyWebServer.Http;
using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

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

using MyWebServer.Common;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Results
{
    public class TextResult : ContentResult
    {
        public TextResult(string text)
            : base(text, HttpContentType.PlainText)
        {
        }
    }
}

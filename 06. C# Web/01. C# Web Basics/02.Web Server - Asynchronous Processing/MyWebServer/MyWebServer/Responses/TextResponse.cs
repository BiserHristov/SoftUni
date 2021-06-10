using MyWebServer.Common;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
            : base(text, HttpContentType.PlainText)
        {
        }
    }
}

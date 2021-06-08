using MyWebServer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
            : base(text, "text/plain; charset=UTF-8")
        {
        }
    }
}

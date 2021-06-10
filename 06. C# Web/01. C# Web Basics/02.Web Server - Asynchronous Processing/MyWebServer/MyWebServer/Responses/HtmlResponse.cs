using MyWebServer.Common;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string html)
           : base(html, HttpContentType.Html)
        {
            

        }

       
    }
}

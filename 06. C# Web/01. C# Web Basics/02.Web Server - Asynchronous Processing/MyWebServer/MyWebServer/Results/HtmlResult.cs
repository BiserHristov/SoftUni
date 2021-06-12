using MyWebServer.Common;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Results
{
    public class HtmlResult : ContentResult
    {
        public HtmlResult(string html)
           : base(html, HttpContentType.Html)
        {
            

        }

       
    }
}

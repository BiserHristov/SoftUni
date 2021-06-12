using MyWebServer.Common;
using MyWebServer.Http;
using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

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

using MyWebServer.Server.Common;
using SIS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Server.Responses
{
    public class HtmlResponse : HTTPResponse
    {
        public HtmlResponse(HttpStatusCode statusCode, string text)
           : base(statusCode, "text/html; charset=UTF-8", text)
        {
            

        }

        public HtmlResponse(string text)
          : this(HttpStatusCode.OK, text)
        {
        }
    }
}

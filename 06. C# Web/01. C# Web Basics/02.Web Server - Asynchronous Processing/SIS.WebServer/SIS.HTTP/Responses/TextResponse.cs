using MyWebServer.Server.Common;
using SIS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Server.Responses
{
    public class TextResponse : HTTPResponse
    {
        public TextResponse(string text)
            : base(HttpStatusCode.OK, "text/plain; charset=UTF-8", text)
        {
        }
    }
}

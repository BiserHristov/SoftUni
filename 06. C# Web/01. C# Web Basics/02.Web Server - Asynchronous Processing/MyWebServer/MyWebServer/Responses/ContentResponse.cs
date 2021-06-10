using MyWebServer.Common;
using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Responses
{
    public class ContentResponse : HTTPResponse
    {
        public ContentResponse(string content, string contentType)
            : base(HttpStatusCode.OK)
        {
            
            this.PrepareContent(content, contentType);

        }

    }
}

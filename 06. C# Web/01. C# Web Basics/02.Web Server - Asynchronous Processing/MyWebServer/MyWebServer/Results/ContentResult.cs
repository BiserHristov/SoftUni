using MyWebServer.Common;
using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Results
{
    public class ContentResult : HTTPResponse
    {
        public ContentResult(string content, string contentType)
            : base(HttpStatusCode.OK)
        {
            
            this.PrepareContent(content, contentType);

        }

    }
}

using MyWebServer.Server.Common;
using SIS.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Responses
{
    public class ContentResponse : HTTPResponse
    {
        public ContentResponse(string text, string contentType)
            : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text);
            Guard.AgainstNull(contentType);


            this.Headers.Add(new Header("Content-Type", contentType));
            this.Headers.Add(new Header("Content-Length", Encoding.UTF8.GetByteCount(text).ToString()));

            this.Content = text;

        }

    }
}

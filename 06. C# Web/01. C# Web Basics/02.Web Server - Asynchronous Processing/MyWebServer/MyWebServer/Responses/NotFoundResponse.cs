using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Responses
{
    public class NotFoundResponse : HTTPResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound)
        {
        }
    }
}

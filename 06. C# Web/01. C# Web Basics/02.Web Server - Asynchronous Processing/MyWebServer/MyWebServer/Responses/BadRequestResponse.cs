
using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Responses
{
    public class BadRequestResponse : HTTPResponse
    {
        public BadRequestResponse()
            : base(HttpStatusCode.BadRequest)
        {
        }
    }
}

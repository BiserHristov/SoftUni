using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Responses
{
    public class RedirectResponse : HTTPResponse
    {

        public RedirectResponse(string location) :
            base(HttpStatusCode.Found)
        {
            AddHeader("Location", location);
        }

    }
}

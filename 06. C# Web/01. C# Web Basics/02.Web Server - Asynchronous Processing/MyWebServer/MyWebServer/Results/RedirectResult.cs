using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Results
{
    public class RedirectResult : HTTPResponse
    {

        public RedirectResult(string location) :
            base(HttpStatusCode.Found)
        {
            this.Headers.Add(new Header(Header.Location, location));
        }

    }
}

using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Results
{
    public class RedirectResult : ActionResult
    {

        public RedirectResult(HTTPResponse response, string location) :
            base(response)
        {
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader(Header.Location, location);
        }

    }
}

using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Results
{
    public class NotFoundResult : ActionResult
    {
        public NotFoundResult(HTTPResponse response)
            : base(response)
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}

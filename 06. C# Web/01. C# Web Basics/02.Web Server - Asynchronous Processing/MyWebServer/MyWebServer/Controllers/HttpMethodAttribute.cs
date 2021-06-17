using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Controllers
{
    public abstract class HttpMethodAttribute : Attribute
    {
        public HttpMethodAttribute(HttpMethod httpMethod)
       => this.HttpMethod = httpMethod;

        public HttpMethod HttpMethod { get; }
    }
}

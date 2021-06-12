using MyWebServer.Controllers;
using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.App.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HTTPRequest request) 
            : base(request)
        {
        }

        //public HTTPResponse ActionWithCookies()
        //{

        //}
    }
}

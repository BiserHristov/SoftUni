﻿using MyWebServer.Controllers;
using MyWebServer.HTTP;
using MyWebServer.Results;
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

        public ActionResult ActionWithCookies()
        {
            const string cookieName = "My-Cookie";
            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];
                return Text($"Cookies already exist - {cookie}");

            }

            this.Response.AddCookie(cookieName, "My-value");
            this.Response.AddCookie("My-second-cookie", "My-second-value");
            return Text("Hello");
        }
    }
}

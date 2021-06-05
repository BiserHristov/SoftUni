using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP
{
    public enum HttpStatusCode
    {
        OK = 200,
        MovedPErmanently = 301,
        Found = 302,
        TemporaryRedirect = 307,
        BadRequest=400,
        NotFound = 404,
        ServerError = 500,
    }
}

using MyWebServer.Server.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP
{
    public abstract class HTTPResponse
    {
        //private readonly ICollection<Header> headers;
        public HTTPResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Headers = new List<Header>
            {
                { new Header("Date",$"{DateTime.UtcNow:r}")},
                { new Header("Server","My Web Server")},
            };
            this.Cookies = new List<Cookie>();
       
        }

        public HttpStatusCode StatusCode { get; private set; }
        public ICollection<Header> Headers { get; set; }
        public ICollection<Cookie> Cookies { get; set; }
        public string Content { get; protected set; }

        public override string ToString()
        {
            var responseBuilder = new StringBuilder();

            responseBuilder.Append($"HTTP/1.1 {(int)HttpStatusCode.OK} {HttpStatusCode.OK}" + HttpConstants.NewLine);

            foreach (var header in this.Headers)
            {
                responseBuilder.Append($"{header}" + HttpConstants.NewLine);
            }

            if (this.Cookies.Count > 0)
            {
                foreach (var cookie in this.Cookies)
                {
                    responseBuilder.Append($"Set-Cookie: " + cookie.ToString() + HttpConstants.NewLine);
                }
            }

            if (!string.IsNullOrEmpty(this.Content))
            {
                responseBuilder.Append(HttpConstants.NewLine);
                responseBuilder.Append(this.Content + HttpConstants.NewLine);

            }

            responseBuilder.Append(HttpConstants.NewLine);
            return responseBuilder.ToString();
        }

        //public HTTPResponse(byte[] body, string contentType, HttpStatusCode statusCode = HttpStatusCode.OK)
        //{
        //    this.StatusCode = statusCode;
        //    this.Body = body;
        //    this.Headers = new List<Header>
        //    {
        //        { new Header("Content-Type",contentType)},
        //        { new Header("Content-Length",body.Length.ToString())},
        //    };
        //    this.Cookies = new List<Cookie>();
        //}

        //public HttpStatusCode StatusCode { get; set; }
        //public ICollection<Header> Headers { get; set; }
        //public ICollection<Cookie> Cookies { get; set; }
        //public byte[] Body { get; set; }

        //public override string ToString()
        //{
        //    var responseBuilder = new StringBuilder();

        //    responseBuilder.Append($"HTTP/1.1 {(int)HttpStatusCode.OK} {HttpStatusCode.OK}" + HttpConstants.NewLine);

        //    foreach (var header in this.Headers)
        //    {
        //        responseBuilder.Append($"{header}" + HttpConstants.NewLine);
        //    }

        //    if (this.Cookies.Count > 0)
        //    {
        //        foreach (var cookie in this.Cookies)
        //        {
        //            responseBuilder.Append($"Set-Cookie: " + cookie.ToString() + HttpConstants.NewLine);
        //        }
        //    }

        //    responseBuilder.Append(HttpConstants.NewLine);
        //    return responseBuilder.ToString();
        //}

    }
}

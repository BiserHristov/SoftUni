using MyWebServer.Common;
using SISMyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebServer.HTTP
{
    public  class HTTPResponse
    {
        //private readonly ICollection<Header> headers;
        public HTTPResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Headers = new List<Header>
            {
                { new Header(Header.Date,$"{DateTime.UtcNow:r}")},
                { new Header(Header.Server,"My Web Server")},
            };
            this.Cookies = new Dictionary<string, Cookie>();

        }

        public HttpStatusCode StatusCode { get; protected set; }
        public IList<Header> Headers { get; set; }
        public IDictionary<string, Cookie> Cookies { get; private set; }
        public string Content { get; protected set; }
        public void AddHeader(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));
            var header = this.Headers.FirstOrDefault(h => h.Name == name);
            if (header!=null)
            {
                header.Value = value;
            }
            else
            {
                this.Headers.Add(new Header(name, value));
            }
            
        }

        public void AddCookie(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Cookies[name] = new Cookie(name, value);
        }
        public override string ToString()
        {
            var responseBuilder = new StringBuilder();

            responseBuilder.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}" + HttpConstants.NewLine);

            foreach (var header in this.Headers)
            {
                responseBuilder.Append($"{header}" + HttpConstants.NewLine);
            }

            if (this.Cookies.Count > 0)
            {
                foreach (var cookie in this.Cookies.Values)
                {
                    responseBuilder.Append($"{Header.SetCookie}: " + cookie.ToString() + HttpConstants.NewLine);
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

        protected void PrepareContent(string content, string contentType)
        {
            Guard.AgainstNull(content, nameof(content));
            Guard.AgainstNull(contentType, nameof(contentType));

            this.AddHeader(Header.ContentType, contentType);
            this.AddHeader(Header.ContentLength, Encoding.UTF8.GetByteCount(content).ToString());
            this.Content = content;
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

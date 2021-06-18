using MyWebServer.HTTP;
using System.Collections.Generic;

namespace MyWebServer.Results
{
    public abstract class ActionResult : HTTPResponse
    {
        public ActionResult(HTTPResponse response) :
             base(response.StatusCode)
        {
            this.Content = response.Content;
            this.PrepareHeaders(response.Headers);
            this.PrepareCookies(response.Cookies);

        }

        protected HTTPResponse Response { get; private init; }

        private void PrepareHeaders(IList<Header> headers)
        {
            foreach (var header in headers)
            {
                this.AddHeader(header.Name, header.Value);
            }
        }

        private void PrepareCookies(IDictionary<string, Cookie> cookies)
        {
            foreach (var cookie in cookies.Values)
            {
                this.AddCookie(cookie.Name, cookie.Value);
            }
        }
    }
}

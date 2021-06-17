using MyWebServer.Http;
using SISMyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebServer.HTTP
{
    public class HTTPRequest
    {
        private static Dictionary<string, Session> Sessions = new();
        public HTTPRequest()
        {
            this.Headers = new List<Header>();
            this.Cookies = new Dictionary<string, Cookie>();
            this.Query = new Dictionary<string, string>();

        }

        public string Path { get; private set; }
        public HttpMethod Method { get; private set; }
        public IReadOnlyCollection<Header> Headers { get; private set; }
        public IReadOnlyDictionary<string, Cookie> Cookies { get; private set; }
        public IReadOnlyDictionary<string, string> Query { get; private set; }
        public IReadOnlyDictionary<string, string> Form { get; private set; }
        public Session Session { get; private set; }

        public string Body { get; private set; }

        public static HTTPRequest Parse(string requestString)
        {
            var input = requestString.Split(HttpConstants.NewLine, StringSplitOptions.None);
            var headerLine = input[0].Split(" ").ToList();
            var method = Enum.Parse<HttpMethod>(headerLine[0]);
            var url = headerLine[1];

            var (path, query) = ParseUrl(url);

            var headers = new List<Header>();
            var cookies = new Dictionary<string, Cookie>();

            bool isInHeaders = true;
            var bodyBuilder = new StringBuilder();

            for (int i = 1; i < input.Length; i++)
            {
                var line = input[i];

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;
                    continue;
                }

                if (isInHeaders)
                {
                    var header = new Header(line);
                    headers.Add(header);

                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }

            }

            if (headers.Any(h => h.Name == "Cookie"))
            {
                var cookieValueAsString = headers.FirstOrDefault(h => h.Name == Header.Cookie).Value;

                var cookiesAsStringArr = cookieValueAsString.Split(";");
                for (int i = 0; i < cookiesAsStringArr.Length; i++)
                {
                    var cookie = new Cookie(cookiesAsStringArr[i]);
                    cookies[cookie.Name] = cookie;
                }
            }

            var session = GetSession(cookies);

            var body = bodyBuilder.ToString();

            var form = ParseForm(headers, body);

            return new HTTPRequest
            {
                Method = method,
                Path = path,
                Query = query,
                Headers = headers,
                Cookies = cookies,
                Session = session,
                Body = body,
                Form = form
            };
        }

        private static Session GetSession(Dictionary<string, Cookie> cookies)
        {
            var sessionId = cookies.ContainsKey(Session.SessionCookieName)
                ? cookies[Session.SessionCookieName].Value
                : Guid.NewGuid().ToString();


            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions.Add(sessionId, new Session(sessionId) { IsNew=true});
            }

            return Sessions[sessionId];


        }

        private static (string path, Dictionary<string, string> query) ParseUrl(string url)
        {
            var urlParts = url.Split('?', 2);
            var path = urlParts[0];

            if (urlParts.Length == 1)
            {
                return (path, new Dictionary<string, string>());
            }

            var query = ParseQuery(urlParts[1]);

            return (path, query);

        }

        private static Dictionary<string, string> ParseQuery(string urlParts)
        {
            return urlParts
                .Split('&')
                .Select(part => part.Split('='))
                .Where(part => part.Length == 2)
                .ToDictionary(part => part[0], part => part[1].Trim());
        }

        private static Dictionary<string, string> ParseForm(List<Header> headers, string body)
        {
            var result = new Dictionary<string, string>();
            var header = headers.Where(h => h.Name == Header.ContentType && h.Value == HttpContentType.FormUrlEncoded);

            if (header != null)
            {
                result = ParseQuery(body);
            }

            return result;
        }

       
    }
}

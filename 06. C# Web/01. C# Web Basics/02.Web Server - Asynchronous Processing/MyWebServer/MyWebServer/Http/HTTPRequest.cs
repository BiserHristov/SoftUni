using SISMyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebServer.HTTP
{
    public class HTTPRequest
    {
        public HTTPRequest()
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();
            this.Query = new ();

        }

        public string Path { get; private set; }
        public HttpMethod Method { get; private set; }
        public ICollection<Header> Headers { get; private set; }
        public ICollection<Cookie> Cookies { get; private set; }
        public Dictionary<string, string> Query { get; private set; }

        public string Body { get; private set; }

        public static HTTPRequest Parse(string requestString)
        {
            var input = requestString.Split(HttpConstants.NewLine, StringSplitOptions.None);
            var headerLine = input[0].Split(" ").ToList();
            var method = Enum.Parse<HttpMethod>(headerLine[0]);
            var url = headerLine[1];
            
            var (path, query) = ParseUrl(url);

            var headers = new List<Header>();
            var cookies = new List<Cookie>();

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
                var cookieValueAsString = headers.FirstOrDefault(h => h.Name == "Cookie").Value;

                var cookiesAsStringArr = cookieValueAsString.Split(" ");
                for (int i = 0; i < cookiesAsStringArr.Length; i++)
                {
                    var cookie = new Cookie(cookiesAsStringArr[i]);
                    cookies.Add(cookie);
                }
            }

            var body = bodyBuilder.ToString();

            return new HTTPRequest
            {
                Method = method,
                Path = path,
                Query = query,
                Headers = headers,
                Cookies = cookies,
                Body = body,
            };
        }

        private static (string path, Dictionary<string, string> query) ParseUrl(string url)
        {
            var urlParts = url.Split('?', 2);
            var path = urlParts[0];

            if (urlParts.Length==1)
            {
                return (path, new Dictionary<string, string>());
            }

            var query = urlParts[1]
                .Split('&')
                .Select(part => part.Split('='))
                .Where(part => part.Length == 2)
                .ToDictionary(part => part[0], part => part[1]);


            return (path, query);

        }
    }
}

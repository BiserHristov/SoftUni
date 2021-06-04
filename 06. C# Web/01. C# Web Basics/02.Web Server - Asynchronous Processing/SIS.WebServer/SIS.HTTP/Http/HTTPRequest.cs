using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP
{
    public class HTTPRequest
    {
        public HTTPRequest(string requestString)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();

            var input = requestString.Split(HttpConstants.NewLine, StringSplitOptions.None);
            var headerLine = input[0].Split(" ").ToList();
            this.Method = Enum.Parse<HttpMethod>(headerLine[0]);
            this.Path = headerLine[1];
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
                    this.Headers.Add(header);

                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }

            }

            if (this.Headers.Any(h => h.Name == "Cookie"))
            {
                var cookieValueAsString = this.Headers.FirstOrDefault(h => h.Name == "Cookie").Value;

                var cookiesAsStringArr = cookieValueAsString.Split(" ");
                for (int i = 0; i < cookiesAsStringArr.Length; i++)
                {
                    var cookie = new Cookie(cookiesAsStringArr[i]);
                    this.Cookies.Add(cookie);
                }
            }

            this.Body = bodyBuilder.ToString();
        }

        public string Path { get; private set; }
        public HttpMethod Method { get; private set; }
        public ICollection<Header> Headers { get; }
        public ICollection<Cookie> Cookies { get; }

        public string Body { get; private set; }
    }
}

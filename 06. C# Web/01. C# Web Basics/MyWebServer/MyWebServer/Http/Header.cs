using MyWebServer.Common;

namespace MyWebServer.HTTP
{
    public class Header
    {
        public const string ContentType = "Content-Type";
        public const string ContentLength = "Content-Length";
        public const string Server = "Server";
        public const string Date = "Date";
        public const string Location = "Location";
        public const string SetCookie = "Set-Cookie";
        public const string Cookie = "Cookie";



        public Header(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Name = name;
            this.Value = value;

        }
        public Header(string headerString)
        {
            var headerParts = headerString.Split(":", 2);
            this.Name = headerParts[0];
            this.Value = headerParts[1].Trim();

        }
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}
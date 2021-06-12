using MyWebServer.Common;

namespace MyWebServer.HTTP
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Name = name;
            this.Value = value;

        }
        public Cookie(string cookieString)
        {
            var cookieParts = cookieString.Split('=', 2);
            this.Name = cookieParts[0];
            this.Value = cookieParts[1];

        }
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}={this.Value}";
        }
    }
}
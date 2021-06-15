using System.Text;

namespace MyWebServer.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value)
            : base(name, value)
        {
            this.Path = "/";
        }

        public int MaxAge { get; set; }
        public bool HttpOnly { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            var cookieBuilder = new StringBuilder();

            cookieBuilder.Append($"{base.ToString()}; Path={this.Path};");
            if (this.MaxAge!=0)
            {
                cookieBuilder.Append($" Max-Age={this.MaxAge};");

            }
            if (this.HttpOnly)
            {
                cookieBuilder.Append($" HttpOnly;");

            }

            return cookieBuilder.ToString();
        }

    }
}

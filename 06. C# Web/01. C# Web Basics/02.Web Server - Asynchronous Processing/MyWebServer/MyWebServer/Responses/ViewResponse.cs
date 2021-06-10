using MyWebServer.Http;
using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Responses
{
    public class ViewResponse : HTTPResponse
    {


        public ViewResponse(string viewPath)
            : base(HttpStatusCode.OK)
        {
            this.GetHtml(viewPath);
        }

        private void GetHtml(string viewPath)
        {
            //var directory = Directory.GetCurrentDirectory();
            viewPath = Path.GetFullPath("." + viewPath);

            if (!File.Exists(viewPath))
            {
                this.StatusCode = HttpStatusCode.NotFound;
                return;
            }

            var viewContent = File.ReadAllText(viewPath);
            this.PrepareContent(viewContent, HttpContentType.Html);


        }
    }
}

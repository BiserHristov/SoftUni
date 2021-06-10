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


        public ViewResponse(string viewPath, string controllerName)
            : base(HttpStatusCode.OK)
        {
            this.GetHtml(viewPath, controllerName);
        }

        private void GetHtml(string viewName, string controllerName)
        {

            if (!viewName.Contains('/'))
            {
                viewName = controllerName + '/' + viewName;
            }
            var viewPath = Path.GetFullPath("./Views/" + viewName.TrimStart('/') + ".cshtml");

            if (!File.Exists(viewPath))
            {
               
                this.PrepareMissingViewError(viewPath);
                return;
            }

            var viewContent = File.ReadAllText(viewPath);
            this.PrepareContent(viewContent, HttpContentType.Html);


        }

        private void PrepareMissingViewError(string viewPath)
        {
            this.StatusCode = HttpStatusCode.NotFound;
            var errorMessage = $"View '{viewPath}' was not found!";
            this.PrepareContent(errorMessage, HttpContentType.PlainText);
        }
    }
}

﻿using MyWebServer.Http;
using MyWebServer.HTTP;
using System.IO;
using System.Linq;

namespace MyWebServer.Results
{
    public class ViewResult : ActionResult
    {


        public ViewResult(HTTPResponse response,string viewPath, string controllerName, object model)
            : base(response)
        {
            //this.StatusCode = HttpStatusCode.OK;
            this.GetHtml(viewPath, controllerName, model);
        }

        private void GetHtml(string viewName, string controllerName, object model)
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

            if (model != null)
            {
                viewContent = this.PopulateModel(viewContent, model);
            }
            this.SetContent(viewContent, HttpContentType.Html);


        }

        private void PrepareMissingViewError(string viewPath)
        {
            this.StatusCode = HttpStatusCode.NotFound;
            var errorMessage = $"View '{viewPath}' was not found!";
            this.SetContent(errorMessage, HttpContentType.PlainText);
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(pr => new
                {
                    pr.Name,
                    Value = pr.GetValue(model)
                });

            foreach (var entry in data)
            {
                viewContent = viewContent.Replace($"{{{{{entry.Name}}}}}", entry.Value.ToString());
            }

            return viewContent;
        }
    }
}
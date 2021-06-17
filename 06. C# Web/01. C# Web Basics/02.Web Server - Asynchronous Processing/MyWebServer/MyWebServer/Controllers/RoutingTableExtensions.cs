using MyWebServer.HTTP;
using MyWebServer.Routing;
using System;
using System.Linq;
using System.Reflection;

namespace MyWebServer.Controllers
{
    public static class RoutingTableExtensions
    {
        private static Type httpResponseType = typeof(HTTPResponse);
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path, Func<TController,
            HTTPResponse> controllerFunction)
                where TController : Controller
        {
            return routingTable.MapGet(path, request =>
            {
                var controller = CreateController<TController>(request);
                return controllerFunction(controller);
            });

        }

        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, HTTPResponse> controllerFunction)
                where TController : Controller
        {
            return routingTable.MapPost(path, request =>
            {
                var controller = CreateController<TController>(request);
                return controllerFunction(controller);
            });
        }

        public static IRoutingTable MapControllers(this IRoutingTable routingTable)
        {

            var controllerActions = Assembly
                .GetEntryAssembly()
                .GetExportedTypes()
                .Where(t => !t.IsAbstract
                    && t.IsAssignableTo(typeof(Controller))
                    && t.Name.EndsWith(nameof(Controller)))
                .SelectMany(t => t
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Where(m=>m.ReturnType.IsAssignableTo(httpResponseType)))
                .ToList();

            foreach (var controllerAction in controllerActions)
            {
                var controllerType = controllerAction.DeclaringType;
                var controllerName = controllerType.GetControllerName();
                var actionName = controllerAction.Name;
                var path = $"/{ controllerName}/{ actionName}";

                Func<HTTPRequest, HTTPResponse> responseFunction = request =>
                 {
                     var controllerInstance = CreateController(controllerType, request);
                     if (controllerAction.ReturnType != httpResponseType)
                     {
                         throw new InvalidOperationException($"Controller action '{path}' does not return a HttpResponse object");
                     }

                     return (HTTPResponse)controllerAction.Invoke(controllerInstance, Array.Empty<object>());
                 };

                var httpMethod = HttpMethod.GET;
                var httpMethodAttribute = controllerAction.GetCustomAttribute<HttpMethodAttribute>();

                if (httpMethodAttribute!=null)
                {
                    httpMethod = httpMethodAttribute.HttpMethod;
                }

                routingTable.Map(httpMethod,path, responseFunction);

                const string defaultActionName = "Index";
                const string defaultControllerName = "Home";

                if (actionName == defaultActionName)
                {
                    routingTable.Map(httpMethod,$"/{controllerName}", responseFunction);

                    if (controllerName == defaultControllerName)
                    {
                        routingTable.Map(httpMethod,"/", responseFunction);
                    }
                }

            }
            return routingTable;

        }

        private static Controller CreateController(Type controller, HTTPRequest request)
        => (Controller)Activator.CreateInstance(controller, new[] { request });

        private static TController CreateController<TController>(HTTPRequest request)
            where TController : Controller
        => (TController)CreateController(typeof(TController), request);
    }
}
using MyWebServer.HTTP;
using MyWebServer.Routing;
using System;

namespace MyWebServer.Controllers
{
    public static class RoutingTableExtensions
    {
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

        private static TController CreateController<TController>(HTTPRequest request)
        {
            var controller = (TController)Activator.CreateInstance(typeof(TController), new[] { request });

            return controller;
        }
    }
}

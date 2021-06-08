using MyWebServer.Common;
using MyWebServer.HTTP;
using MyWebServer.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, Func<HTTPRequest, HTTPResponse>>> routes;

        public RoutingTable()
        {
            this.routes = new()
            {
                [HttpMethod.GET] = new(),
                [HttpMethod.POST] = new(),
                [HttpMethod.PUT] = new(),
                [HttpMethod.DELETE] = new(),

            };
        }
        public IRoutingTable Map(HttpMethod method, string path, HTTPResponse response)
        {

            Guard.AgainstNull(response, nameof(response));



            return this.Map(method, path, request => response);
        }

        public IRoutingTable Map(HttpMethod method, string path, Func<HTTPRequest, HTTPResponse> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, HTTPResponse response)
        {
            return this.MapGet(path, request => response);
        }

        public IRoutingTable MapGet(string path, Func<HTTPRequest, HTTPResponse> responseFunction)
        {
            return this.Map(HttpMethod.GET, path, responseFunction);
        }


        public IRoutingTable MapPost(string path, HTTPResponse response)
        {
            return this.MapPost(path, request => response);
        }

        public IRoutingTable MapPost(string path, Func<HTTPRequest, HTTPResponse> responseFunction)
        {
            return this.Map(HttpMethod.POST, path, responseFunction);
        }

        public HTTPResponse ExecuteRequest(HTTPRequest request)
        {
            if (!this.routes.ContainsKey(request.Method) ||
                !this.routes[request.Method].ContainsKey(request.Path))
            {
                return new NotFoundResponse();
            }

            var responseFunction= this.routes[request.Method][request.Path];

            return responseFunction(request);
        }


    }
}

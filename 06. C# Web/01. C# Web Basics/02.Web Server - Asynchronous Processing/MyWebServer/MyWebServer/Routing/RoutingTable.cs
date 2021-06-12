using MyWebServer.Common;
using MyWebServer.HTTP;
using MyWebServer.Results;
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

            this.routes[method][path.ToLower()] = responseFunction;

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
            var requestMethod = request.Method;
            var requestPath = request.Path.ToLower();

            if (!this.routes.ContainsKey(requestMethod) ||
                !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new HTTPResponse(HttpStatusCode.NotFound);
            }

            var responseFunction= this.routes[requestMethod][requestPath];

            return responseFunction(request);
        }


    }
}

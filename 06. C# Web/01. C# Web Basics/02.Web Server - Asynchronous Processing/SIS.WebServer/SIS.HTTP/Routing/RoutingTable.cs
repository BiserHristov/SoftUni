using MyWebServer.Server.Common;
using MyWebServer.Server.Responses;
using SIS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, HTTPResponse>> routes;

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
        public IRoutingTable Map(string url, HttpMethod method, HTTPResponse response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(url, nameof(response));

            this.routes[method][url] = response;

            return this;
        }

        public IRoutingTable MapGet(string url, HTTPResponse response)
        {
            return this.Map(url, HttpMethod.GET, response);
        }

        public HTTPResponse MatchRequest(HTTPRequest request)
        {
            if (!this.routes.ContainsKey(request.Method) ||
                !this.routes[request.Method].ContainsKey(request.Path))
            {
                return new NotFoundResponse();
            }

            return this.routes[request.Method][request.Path];
        }


    }
}

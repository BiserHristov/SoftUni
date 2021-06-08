using MyWebServer.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Routing
{
    public interface IRoutingTable
    {
        //    void Map(string url, HTTPResponse response);
        IRoutingTable Map(HttpMethod method, string path, HTTPResponse response);
        IRoutingTable Map(HttpMethod method, string path, Func<HTTPRequest, HTTPResponse> responseFunction);

        IRoutingTable MapGet(string path, HTTPResponse response);
        IRoutingTable MapGet(string path, Func<HTTPRequest, HTTPResponse> responseFunction);
    
        IRoutingTable MapPost(string url, HTTPResponse response);
        IRoutingTable MapPost(string path, Func<HTTPRequest, HTTPResponse> responseFunction);
        

    }
}

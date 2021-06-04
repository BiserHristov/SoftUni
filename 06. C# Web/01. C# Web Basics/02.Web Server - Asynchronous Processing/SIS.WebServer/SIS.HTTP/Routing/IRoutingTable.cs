using SIS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Server.Routing
{
    public interface IRoutingTable
    {
        //    void Map(string url, HTTPResponse response);
        IRoutingTable Map(string url, HttpMethod method, HTTPResponse response);
        IRoutingTable MapGet(string url, HTTPResponse response);
        //void MapPost(string url, HTTPResponse response);
    }
}

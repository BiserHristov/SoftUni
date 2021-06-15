using MyWebServer.Common;
using MyWebServer.HTTP;
using System;

namespace MyWebServer.Routing
{
    public interface IRoutingTable
    {
        //    void Map(string url, HTTPResponse response);
        IRoutingTable MapStaticFiles(string folderName=Settings.StaticFilesRootFolder);

        IRoutingTable Map(HttpMethod method, string path, HTTPResponse response);
        IRoutingTable Map(HttpMethod method, string path, Func<HTTPRequest, HTTPResponse> responseFunction);

        IRoutingTable MapGet(string path, HTTPResponse response);
        IRoutingTable MapGet(string path, Func<HTTPRequest, HTTPResponse> responseFunction);
    
        IRoutingTable MapPost(string url, HTTPResponse response);
        IRoutingTable MapPost(string path, Func<HTTPRequest, HTTPResponse> responseFunction);
        

    }
}

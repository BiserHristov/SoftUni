using System;
using System.Threading.Tasks;

namespace MyWebServer.HTTP
{
    public interface IHTTPServer
    {
        //void AddRoute(string path, Func<HTTPRequest, HTTPResponse> action);
        Task Start();
    }
}

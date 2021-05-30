using System;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public interface IHTTPServer
    {
        void AddRoute(string path, Func<HTTPRequest, HTTPResponse> action);
        Task Start();
    }
}

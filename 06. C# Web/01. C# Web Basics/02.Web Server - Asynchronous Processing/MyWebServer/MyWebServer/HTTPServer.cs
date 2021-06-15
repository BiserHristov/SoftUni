using MyWebServer.Http;
using MyWebServer.HTTP;
using MyWebServer.Routing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class HTTPServer : IHTTPServer
    {
        
        //private IDictionary<string, Func<HTTPRequest, HTTPResponse>> routeTable;
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;
        private readonly RoutingTable routingTable;

        public HTTPServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.listener = new TcpListener(this.ipAddress, port);
            this.routingTable = new RoutingTable();
            routingTableConfiguration(this.routingTable);

        }

        public HTTPServer(int port, Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {

        }

        public HTTPServer(Action<IRoutingTable> routingTable)
            :this(5050, routingTable)
        {

        }
        //public void AddRoute(string path, Func<HTTPRequest, HTTPResponse> action)
        //{
        //    if (this.routeTable.ContainsKey(path))
        //    {
        //        this.routeTable[path] = action;
        //    }
        //    else
        //    {
        //        this.routeTable.Add(path, action);
        //    }
        //}

        public async Task Start()
        {
            this.listener.Start();

            Console.WriteLine($"Server started on port {port}...");
            Console.WriteLine("Listening for requests...");
            Console.WriteLine();

            while (true)
            {
                TcpClient client = await this.listener.AcceptTcpClientAsync();
                ProcessClientAsync(client);
            }
        }

        private async Task ProcessClientAsync(TcpClient client)
        {
            List<byte> dataBuffer = new List<byte>();
            using NetworkStream stream = client.GetStream();

            while (true)
            {
                var buffer = new byte[4098];
                int position = 0;

                int count = await stream.ReadAsync(buffer, position, buffer.Length);
                position += count;

                if (count == 0)
                {
                    break;
                }

                if (count < buffer.Length)
                {
                    var realBuffer = new byte[count];
                    Array.Copy(buffer, realBuffer, count);
                    dataBuffer.AddRange(realBuffer);
                    break;
                }

                dataBuffer.AddRange(buffer);
            }

            string requestAsString = Encoding.UTF8.GetString(dataBuffer.ToArray());
            Console.WriteLine(requestAsString);

            try
            {
                var request = HTTPRequest.Parse(requestAsString);

                HTTPResponse response = this.routingTable.ExecuteRequest(request);

                this.PrepareSession(request, response);

                await stream.WriteAsync(Encoding.UTF8.GetBytes(response.ToString()));
            }
            catch (Exception ex)
            {
                var errorResponse = HTTPResponse.ForError($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
                await stream.WriteAsync(Encoding.UTF8.GetBytes(errorResponse.ToString()));
            }

            client.Close();
        }

        private void PrepareSession(HTTPRequest request ,HTTPResponse response)
        {
            if (request.Session.IsNew)
            {
                response.AddCookie(Session.SessionCookieName, request.Session.Id);
                request.Session.IsNew = false;
            }
        }

        private async Task WriteResponse(NetworkStream stream, HTTPResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await stream.WriteAsync(responseBytes);

        }

    }
}

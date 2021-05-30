﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public class HTTPServer : IHTTPServer
    {
        private IDictionary<string, Func<HTTPRequest, HTTPResponse>> routeTable;
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;

        public HTTPServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.listener = new TcpListener(this.ipAddress, port);
            this.routeTable = new Dictionary<string, Func<HTTPRequest, HTTPResponse>>();


        }
        public void AddRoute(string path, Func<HTTPRequest, HTTPResponse> action)
        {
            if (this.routeTable.ContainsKey(path))
            {
                this.routeTable[path] = action;
            }
            else
            {
                this.routeTable.Add(path, action);
            }
        }

        public async Task Start()
        {
            this.listener.Start();

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

            var request = new HTTPRequest(requestAsString);

            HTTPResponse response;

            if (routeTable.ContainsKey(request.Path))
            {
                var action = routeTable[request.Path];
                response = action(request);

            }
            else
            {
                response = new HTTPResponse(new byte[0], "text/html", HttpStatusCode.NotFound);

            }


            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
            await stream.WriteAsync(response.Body, 0, response.Body.Length);


            client.Close();
        }

    }
}

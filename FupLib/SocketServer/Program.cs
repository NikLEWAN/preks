using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(ip, 6789);

            //TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();


            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated now");
                EchoService service = new EchoService(connectionSocket);
                //Use Task and delegates

                //Task solution with delegates
                Task.Factory.StartNew(() => service.DoIt());

            }

            serverSocket.Stop();
        }
    }
}

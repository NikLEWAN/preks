using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using FupLib;

namespace SocketServer
{
    class EchoService
    {
        private TcpClient connectionSocket;

        public EchoService(TcpClient connectionSocket)
        {
            // TODO: Complete member initialization
            this.connectionSocket = connectionSocket;
        }
        internal void DoIt()
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message = sr.ReadLine();
            string answer;

            //Abort while if message is empty
            while (message != null && message != "")
            {
                if (message.Contains(","))
                {
                    //Server input
                    string[] seperation = message.Split(",");
                    Console.WriteLine("Client inputs: " + seperation[0] + " - " + seperation[1] + " Average: " + TransportCalc.Average(int.Parse(seperation[0]), int.Parse(seperation[1])) );

                    //Server output
                    sw.WriteLine("Average: " + TransportCalc.Average(int.Parse(seperation[0]), int.Parse(seperation[1])) );
                }
                else
                {
                    //Server input
                    Console.WriteLine("Client input: " + message + " Total: " + TransportCalc.Total(message));

                    //Server output
                    sw.WriteLine("Total: " + TransportCalc.Total(message));
                }
                //Server wait for input
                message = sr.ReadLine();
            }

            ns.Close();
            connectionSocket.Close();
        }
    }
}

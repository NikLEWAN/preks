using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    class Program
    {
        static void Info() 
        {
            Console.WriteLine("Get Average (2 ints with comma sep.)");
            Console.WriteLine("Get Total (unlimited ints seperated by space)");
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {

            TcpClient clientSocket = new TcpClient("localhost", 6789);

            Stream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            Info();

            while (true)
            {
                Console.WriteLine("");
                string message = Console.ReadLine();
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
                Info();
            }
            ns.Close();
            clientSocket.Close();

        }
    }
}

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerwerNetCore
{
    class Program
    {


        static void Main(string[] args)
        {
			Server server = new Server();

			server.Start();

			
			
			while (true)
			{
				foreach(Connection conn in server.SessionList)
				{
					conn.SendAsyncFunction(Encoding.ASCII.GetBytes("HelloWorld"));
				}
				Thread.Sleep(500);
			}
        }
    }
}

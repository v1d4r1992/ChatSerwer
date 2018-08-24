using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerwerNetCore
{
    class Server
    {
		private TcpListener listener;

		public Server()
		{
			listener = new TcpListener(System.Net.IPAddress.Any,8088);
			listener.Start();
		}


		public void Start()
		{
			Task t = Task.Run(() => {
				while (true)
				{
					AcceptAsyncSockets();
					Thread.Sleep(500);
				}
			});
		}


		private void AcceptAsyncSockets()
		{
				listener.BeginAcceptSocket(new AsyncCallback(AcceptSocketCallback), listener);
		}

		private void AcceptSocketCallback(IAsyncResult ar)
		{
			TcpListener listener = (TcpListener)ar.AsyncState;

			Socket ConnectedSocket = listener.EndAcceptSocket(ar);
			UserList.SessionList.Add(new Connection(ConnectedSocket));
		}
	}
}

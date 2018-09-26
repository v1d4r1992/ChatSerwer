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
        private ManualResetEvent _acceptConnectionEvent = new ManualResetEvent(false);

		public Server()
		{
			listener = new TcpListener(System.Net.IPAddress.Any,8088);
			listener.Start();
		}


		public void Start()
		{
			AcceptConnectionService();
			ReciveService();
		}


		public void AcceptConnectionService()
		{
			Task t = Task.Run(() => {
				while (true)
				{

					AcceptAsyncSockets();
				}
			});
		}

        public void ReciveService()
        {
            new Thread(new ThreadStart(delegate ()
            {
                while (true)
                {
                        foreach (PlayerSession users in Sessions.SessionsInstance.sessionList.ToArray())
                        {
                           users.Connection.ReciveAsyncFunction();
                           users.PacketExecute();
                        }
                }
            })).Start();
        }

		private void AcceptAsyncSockets()
		{
            _acceptConnectionEvent.Reset();
                 listener.BeginAcceptSocket(new AsyncCallback(AcceptSocketCallback), listener);
            _acceptConnectionEvent.WaitOne();
        }

		private void AcceptSocketCallback(IAsyncResult ar)
		{
            _acceptConnectionEvent.Set();
            TcpListener listener = (TcpListener)ar.AsyncState;

			Socket ConnectedSocket = listener.EndAcceptSocket(ar);
            Sessions.SessionsInstance.sessionList.Add(new PlayerSession(new Connection(ConnectedSocket)));
		}
	}
}

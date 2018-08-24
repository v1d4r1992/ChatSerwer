using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SerwerNetCore
{


    class Connection
    {
		private Socket socket;
		private ManualResetEvent reciveDone = new ManualResetEvent(false);

		public Connection(Socket socket)
		{
			this.socket = socket;
		}


		public void ReciveAsyncFunction()
		{
			Packet packet = new Packet(socket);

			socket.BeginReceive(packet.buffer, 0, Packet.BUFFER_SIZE, 0,
			new AsyncCallback(ReciveCallBack) ,packet);
		}


		public void ReciveCallBack(IAsyncResult ar)
		{
			Packet state = (Packet)ar.AsyncState;

			Socket handler = state.workSocket;
			int bytesReadLength = handler.EndReceive(ar);

			if(bytesReadLength>0)
			{
				Console.WriteLine(Encoding.ASCII.GetString(
				state.buffer, 0, bytesReadLength));
			}
		}

		public void SendAsyncFunction(byte[] data)
		{
			Packet state = new Packet(socket);

			socket.BeginSend(data,0, data.Length,0, new AsyncCallback(SendCallBack), state);

		}



		public void SendCallBack(IAsyncResult ar)
		{
			Packet state = (Packet)ar.AsyncState;

			Socket handler = state.workSocket;
			int bytesReadLength = handler.EndSend(ar);
		}
	}
}

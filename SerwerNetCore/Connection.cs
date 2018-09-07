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
        private Boolean readyToRecive = false;
		private SocketError ErrorCode;

		public Queue<PacketData> PacketQueue { get; private set; } = new Queue<PacketData>();
		

		public Connection(Socket socket)
		{
			this.socket = socket;
		}


		public void ReciveAsyncFunction()
		{
            PacketData packet = new PacketData(socket);


            if (readyToRecive == false)
            {
                readyToRecive = true;
                socket.BeginReceive(packet.buffer, 0, PacketData.BUFFER_SIZE, 0,out ErrorCode,
				new AsyncCallback(ReciveCallBack), packet);
            }
         }

		public bool ConnectionIsAlive
		{
			get
			{
				return !(ErrorCode == System.Net.Sockets.SocketError.ConnectionReset);
			}
		}


		public void ReciveCallBack(IAsyncResult ar)
		{
            readyToRecive = false;
            PacketData state = (PacketData)ar.AsyncState;

            Socket handler = state.workSocket;
			
			int bytesReadLength = handler.EndReceive(ar,out ErrorCode);

			if (ErrorCode == SocketError.Success)
			{
				if (bytesReadLength > 0)
				{
					state.PacketLength = bytesReadLength;
					PacketQueue.Enqueue(state);
				}
			}
		}

		public void SendAsyncFunction(byte[] data)
		{
            PacketData state = new PacketData(socket);

            socket.BeginSend(data,0, data.Length,0, new AsyncCallback(SendCallBack), state);
        }

		public void SendCallBack(IAsyncResult ar)
		{
            
            PacketData state = (PacketData)ar.AsyncState;

			Socket handler = state.workSocket;
			int bytesReadLength = handler.EndSend(ar);
        }
	}
}

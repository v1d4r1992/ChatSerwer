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
		public static ManualResetEvent reciveDone = new ManualResetEvent(false);
        public Queue<PacketData> packetQueue { get; private set; } = new Queue<PacketData>();
        private Boolean readyToRecive = false;


        public Connection(Socket socket)
		{
			this.socket = socket;
		}


		public void ReciveAsyncFunction()
		{
            PacketData packet = new PacketData(socket);
            //  Connection.reciveDone.Reset();


            if (readyToRecive == false)
            {
                readyToRecive = true;
                socket.BeginReceive(packet.buffer, 0, PacketData.BUFFER_SIZE, 0,
                new AsyncCallback(ReciveCallBack), packet);
            }
                // Connection.reciveDone.WaitOne();
         }


		public void ReciveCallBack(IAsyncResult ar)
		{
            readyToRecive = false;
            //Connection.reciveDone.Set();
            PacketData state = (PacketData)ar.AsyncState;

            Socket handler = state.workSocket;
			int bytesReadLength = handler.EndReceive(ar);

			if(bytesReadLength>0)
			{
                state.PacketLength = bytesReadLength;
                packetQueue.Enqueue(state);
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


        public void PacketParser(byte[] data)
        {
        }
	}
}

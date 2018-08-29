using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SerwerNetCore
{
    class PacketData
    {
		public Socket workSocket = null;
		public const int BUFFER_SIZE = 1024;
		public byte[] buffer = new byte[BUFFER_SIZE];
        public int PacketLength = 0;


        public PacketData(Socket socket)
		{
			workSocket = socket;
		}
	}
}

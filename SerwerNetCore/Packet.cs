using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SerwerNetCore
{
    class Packet
    {
		public Socket workSocket = null;
		public const int BUFFER_SIZE = 1024;
		public byte[] buffer = new byte[BUFFER_SIZE];

		public Packet(Socket socket)
		{
			workSocket = socket;
		}
	}
}

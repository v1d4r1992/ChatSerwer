using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SerwerNetCore.Packet
{
	class ChatPacket : IPacket
	{
		public PacketData Packet { get; set; }

		public void Execute(Player user)
		{
			switch (Packet.buffer[1])
			{
				case 0x1: //do wszystkich
					{
						string message = user.NickName + ": " + ASCIIEncoding.ASCII.GetString(Packet.buffer, 2, Packet.PacketLength - 2);
						byte[] outpacket = new byte[] { 0x32 };
						outpacket = outpacket.Concat(Encoding.ASCII.GetBytes(message)).ToArray();

						UserList.Sessions.SendPacketToAllUsers(outpacket);
						break;
					}
			}
		}
	}
}

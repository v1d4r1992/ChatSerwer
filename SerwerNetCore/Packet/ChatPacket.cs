using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SerwerNetCore.Packet
{
	class ChatPacket : IPacket
	{
		public byte[] Packet { get; set; }

		public void Execute(Player user)
		{
			switch (Packet[1])
			{
				case 0x1: //do wszystkich
					{
						string message = user.NickName + ": " + ASCIIEncoding.ASCII.GetString(Packet, 1, Packet.Length - 1);
						byte[] outpacket = new byte[] { 0x32 };
						outpacket = outpacket.Concat(Encoding.ASCII.GetBytes(message)).ToArray();

						UserList.Sessions.SendPacketToAllUsers(outpacket);
						break;
					}
			}
		}
	}
}

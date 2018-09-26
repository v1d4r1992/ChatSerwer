using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SerwerNetCore.Packet
{
	class GlobalChatPacket : IPacket
	{
		public PacketData Packet { get; set; }

		public void Execute(User user)
		{
			string message = user.NickName + ": " + ASCIIEncoding.ASCII.GetString(Packet.buffer, 0, Packet.PacketLength);
			byte[] outpacket = new byte[] { 0x32 };
			outpacket = outpacket.Concat(Encoding.ASCII.GetBytes(message)).ToArray();

			Sessions.SessionsInstance.SendPacketToAllUsers(outpacket);
		}
	}
}

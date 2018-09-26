using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SerwerNetCore.Packet
{
	class PrivateMessage : IPacket
	{
		public PacketData Packet { get; set; }

		public void Execute(User user)
		{
			int senderNameLenght = (int)Packet.buffer[1];
			string senderName = ASCIIEncoding.ASCII.GetString(Packet.buffer, 2, senderNameLenght);

			string message = ASCIIEncoding.ASCII.GetString(Packet.buffer, senderNameLenght+2, Packet.PacketLength - 1);
			byte[] outpacket = new byte[] { 0x33, (byte)user.NickName.Length };
			outpacket = outpacket.Concat(Encoding.ASCII.GetBytes(user.NickName)).ToArray();
			outpacket = outpacket.Concat(Encoding.ASCII.GetBytes(message)).ToArray();

			Sessions.SessionsInstance.SendPacketToUser(senderName, outpacket);
		}
	}
}

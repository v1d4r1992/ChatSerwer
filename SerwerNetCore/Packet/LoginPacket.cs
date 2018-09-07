using System;
using System.Collections.Generic;
using System.Text;

namespace SerwerNetCore.Packet
{
	class LoginPacket : IPacket
	{
		public PacketData Packet { get; set; }

		public void Execute(Player user)
		{
			string nick = ASCIIEncoding.ASCII.GetString(Packet.buffer, 1, Packet.PacketLength - 1);
			Console.WriteLine($"User {user.NickName} zmienił nick na {nick} ");
			user.NickName = nick;
		}
	}
}

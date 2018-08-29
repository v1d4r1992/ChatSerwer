using System;
using System.Collections.Generic;
using System.Text;

namespace SerwerNetCore.Packet
{
	class LoginPacket : IPacket
	{
		public byte[] Packet { get; set; }

		public void Execute(Player user)
		{
			string nick = ASCIIEncoding.ASCII.GetString(Packet, 1, Packet.Length - 1);
			Console.Write($"User {user.NickName} zmienił nick na {nick} ");
			user.NickName = nick;
		}
	}
}

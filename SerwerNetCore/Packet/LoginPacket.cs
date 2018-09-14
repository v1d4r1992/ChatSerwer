using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SerwerNetCore.Packet
{
	class LoginPacket : IPacket
	{
		public PacketData Packet { get; set; }

		public void Execute(User user)
		{
			string nick = ASCIIEncoding.ASCII.GetString(Packet.buffer, 1, Packet.PacketLength - 1);

			if (UserList.Sessions.sessionList.Exists(x => x.User.NickName == nick))
			{
				UserList.Sessions.sessionList.Where(x => x.User == user).FirstOrDefault().Connection.SendAsyncFunction(new byte[] { 0x90, 0x01 });
			}
			else
			{
				user.NickName = nick;
			}
		}
	}
}

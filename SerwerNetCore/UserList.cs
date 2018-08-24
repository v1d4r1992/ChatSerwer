using System;
using System.Collections.Generic;
using System.Text;

namespace SerwerNetCore
{
    class UserList
    {
		private readonly static UserList instance = new UserList();

		private List<Connection> sessionList = new List<Connection>();


		public static List<Connection> SessionList
		{
			get
			{
				return instance.sessionList;
			}
		}

		public void SendPacketToAllUsers(byte[] data)
		{
			foreach(Connection user in SessionList)
			{
				user.SendAsyncFunction(data);
			}
		} 
	}
}

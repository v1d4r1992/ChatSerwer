using System;
using System.Collections.Generic;
using System.Text;

namespace SerwerNetCore
{
    class UserList
    {
		private readonly static UserList instance = new UserList();

		public List<PlayerSession> sessionList = new List<PlayerSession>();


		public static UserList Sessions
		{
			get
			{
				return instance;
			}
		}

		public void SendPacketToAllUsers(byte[] data)
		{
			foreach(PlayerSession user in sessionList)
			{
				user.Connection.SendAsyncFunction(data);
			}
		}


        public void SendPacketToUser(string name, byte[] data)
        {
            Connection user = sessionList.Find(x => x.User.NickName == name).Connection;

        }
	}
}

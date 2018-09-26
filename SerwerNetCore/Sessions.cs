using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SerwerNetCore
{
    class Sessions
    {
		private readonly static Sessions instance = new Sessions();

		public List<PlayerSession> sessionList = new List<PlayerSession>();


		public static Sessions SessionsInstance
		{
			get
			{
				return instance;
			}
		}

		public void TestSessionStatus()
		{
			List<PlayerSession> SessionsToKillCollection = new List<PlayerSession>();
			foreach (PlayerSession user in sessionList)
			{
				if (!user.Connection.ConnectionIsAlive)
				{
					SessionsToKillCollection.Add(user);
				}
			}

			sessionList.RemoveAll(x=> SessionsToKillCollection.Contains(x));
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
			if (sessionList.Exists(x => x.User.NickName == name))
			{
				Connection user = sessionList.Find(x => x.User.NickName == name).Connection;
				user.SendAsyncFunction(data);
			}
		}
	}
}

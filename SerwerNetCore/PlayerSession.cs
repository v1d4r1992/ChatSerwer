using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SerwerNetCore
{
    class PlayerSession
    {
		private Connection connection;

		public Player User;


		public PlayerSession(Connection connection)
		{
			this.connection = connection;
		}
	}
}

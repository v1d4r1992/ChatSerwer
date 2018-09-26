using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using SerwerNetCore.Packet;

namespace SerwerNetCore
{
    class PlayerSession
    {
		public Connection Connection { get; private set; }
        public User User { get; set; } = new User();
		public int ID { get; set; }

		public PlayerSession(Connection connection)
		{
			Connection = connection;
			ID = (int)(DateTime.Now.Ticks >> 10);
		}

 
        public void PacketExecute()
        {
			PacketParser parser = new PacketParser();

			while (Connection.PacketQueue.Count>0)
            {
				parser.ParsePacket(Connection.PacketQueue.Dequeue()).Execute(User);
			}
        }
	}
}

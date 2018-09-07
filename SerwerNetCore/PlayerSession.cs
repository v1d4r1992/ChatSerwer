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
        public Player User { get; set; } = new Player();

		public PlayerSession(Connection connection)
		{
			Connection = connection;
		}

        //stworzyc interfejs IPacket do przetwarzania pakietów i może zrobić te metode asynchroniczną
        public void PacketExecute()
        {
			PacketParser parser = new PacketParser();

			while (Connection.packetQueue.Count>0)
            {
				parser.ParsePacket(Connection.packetQueue.Dequeue()).Execute(User);
			}
        }
	}
}

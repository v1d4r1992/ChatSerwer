using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Linq;

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
        public void ParsePackets()
        {
            while (Connection.packetQueue.Count>0)
            {
                PacketData packet = Connection.packetQueue.Dequeue();

                switch (packet.buffer[0])
                {
                    case 0x71: //ustawianie nazwy użytkownika
                        {
                            string nick = ASCIIEncoding.ASCII.GetString(packet.buffer, 1, packet.PacketLength - 1);
                            Console.Write($"User {User.NickName} zmienił nick na {nick} ");
                            User.NickName = nick;
                            break;
                        }

                    case 0x72: //wysyłanie wiadomości
                        {
                            switch (packet.buffer[1])
                            {
                                case 0x1: //do wszystkich
                                    {
                                        string message = User.NickName+": " + ASCIIEncoding.ASCII.GetString(packet.buffer, 1, packet.PacketLength - 1);
                                        byte[] outpacket = new byte[] { 0x32 }; //opcode message recive
                                        outpacket = outpacket.Concat(Encoding.ASCII.GetBytes(message)).ToArray();

                                        UserList.Sessions.SendPacketToAllUsers(outpacket);
                                        break;
                                    }
                            }

                            break;
                        }
                }
            }
        }
	}
}

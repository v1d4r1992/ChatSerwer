using System;
using System.Collections.Generic;
using System.Text;

namespace SerwerNetCore.Packet
{
    class PacketParser
    {
		public IPacket ParsePacket(PacketData data)
		{

			switch (data.buffer[0])
			{
				case 0x71: //ustawianie nazwy użytkownika
					{
						LoginPacket packet = new LoginPacket();
						packet.Packet = data.buffer;
						return packet;
					}

				case 0x72: //wysyłanie wiadomości
					{
						ChatPacket packet = new ChatPacket();
						packet.Packet = data.buffer;
						return packet;
					}
			}
			return null;
		}
    }
}

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
						LoginPacket packet = new LoginPacket{ Packet = data };
						return packet;
					}

				case 0x72: //wysyłanie wiadomości
					{
						GlobalChatPacket packet = new GlobalChatPacket { Packet = data };
						return packet;
					}

				case 0x73:
					{
						PrivateMessage packet = new PrivateMessage { Packet = data };
						return packet;
					}
			}
			return null;
		}
    }
}

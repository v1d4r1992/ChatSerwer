using System;
using System.Collections.Generic;
using System.Text;

namespace SerwerNetCore.Packet
{
    interface IPacket
    {
		PacketData Packet { get; set; }

		void Execute(User user);
    }
}

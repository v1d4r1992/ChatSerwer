using System;
using System.Collections.Generic;
using System.Text;

namespace SerwerNetCore.Packet
{
    interface IPacket
    {
		byte[] Packet { get; set; }

		void Execute(Player user);
    }
}

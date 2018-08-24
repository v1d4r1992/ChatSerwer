using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SerwerNetCore
{
    class Player
    {
		public string NickName { get; set; }

		public Vector2 Position { get; set; }

		public Player()
		{
			Position = new Vector2(0,0);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SerwerNetCore.Hibernate
{
	class Users
	{
		public virtual int ID { get; set; }
		public virtual string Login { get; set; }
		public virtual string PasswordHash { get; set; }
	}
}

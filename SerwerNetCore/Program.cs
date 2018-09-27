using SerwerNetCore.Hibernate;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerwerNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
			

			using (var session = DataBase.Open())
			{

				using (var tx = session.BeginTransaction())
				{
					var students = session.CreateCriteria<Users>().List<Users>();

					foreach (var student in students)
					{
						Users usrr = new Users {
							ID = 2,
							Login="login1",
						PasswordHash ="HasH"};
						session.Save(usrr);

					}

					tx.Commit();
				}

				Console.ReadLine();
			}

			Server server = new Server();

			server.Start();


        }
    }
}

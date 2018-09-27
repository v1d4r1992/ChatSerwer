using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Linq;
using System.Reflection;
using NHibernate;
using System.Data.SqlClient;

namespace SerwerNetCore.Hibernate
{
	class DataBase
	{
		static readonly string DataSource =	@".\";
		static readonly string InitialCatalog = "CharServer";
		static readonly string IntegratedSecurity = "True";

		//Data Source=.\;Initial Catalog=CharServer;Integrated Security=True
		public static ISession Open()
		{
			var cfg = new Configuration();

			cfg.DataBaseIntegration(x=>{x.ConnectionString = $"Data Source={DataSource};Initial Catalog={InitialCatalog};Integrated Security={IntegratedSecurity};";
			x.Driver<SqlClientDriver>();
				x.Dialect<MsSql2012Dialect>();
			});

			cfg.AddAssembly(Assembly.GetExecutingAssembly());

			return cfg.BuildSessionFactory().OpenSession();
		}
	}
}

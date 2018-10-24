using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using RestaurantManagement_DAO.Entity_and_Mapping;
using Environment = NHibernate.Cfg.Environment;

namespace Test.Unit
{
    // Create In Memory DB for testing, so that it won't touch the real DB
    public class InMemoryDatabaseForXmlMapping : IDisposable
    {
        protected Configuration config;
        protected ISessionFactory SessionFactory;
        public ISession Session { get; set; }
        public InMemoryDatabaseForXmlMapping()
        {
            config = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof(MsSql2008Dialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof(SqlClientDriver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, @"Data Source=(localdb)\mssqllocaldb; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True")
                .AddAssembly(typeof(GuestTable).Assembly);    // To assembly all hbm.xml file
           
            SessionFactory = config.BuildSessionFactory();
            Session = SessionFactory.OpenSession();

            new SchemaExport(config).Execute(true, true, false, Session.Connection, Console.Out);
        }
        public void Dispose()
        {
            Session.Dispose();
            SessionFactory.Dispose();
        }
    }
}
using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace RestaurantManagement_DAO.DAO
{
    /// <summary>
    /// REASON TO LIVE: Create connection to Database using NHibernate
    /// IMPLEMENTATION 
    /// NHibernate Config with Code
    /// Connection String in App.Config
    /// Set as Singleton, therefore no 2 sessionfactory in the sametime
    /// </summary>
    public class DataProvider
    {
        private static readonly Configuration Cfg = ConfigureNHibernate();
        private static ISessionFactory _sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    _sessionFactory = Cfg.BuildSessionFactory();
                return _sessionFactory;
            }
        }    
        private DataProvider() { }
        /// <summary>
        /// NHibernate Config with code
        /// </summary>
        /// <returns></returns>
        public static Configuration ConfigureNHibernate()
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionStringName = "db";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
                x.IsolationLevel = IsolationLevel.RepeatableRead;
                x.Timeout = 10; x.BatchSize = 10;

            });
            //cfg.SessionFactory().GenerateStatistics();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }
    }
}

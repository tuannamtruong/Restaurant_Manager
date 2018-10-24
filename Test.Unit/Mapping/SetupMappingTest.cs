using NHibernate;
using NUnit.Framework;

namespace Test.Unit.Mapping
{
    class SetupMappingTest
    {
        protected InMemoryDatabaseForXmlMapping Database;
        protected ISession Session;
        /*
        * Set up the Database for testing
        */
        [SetUp]
        public void Setup()
        {
            Database = new InMemoryDatabaseForXmlMapping();
            Session = Database.Session;
        }
    }
}

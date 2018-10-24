using System;
using NUnit.Framework;
using RestaurantManagement_DAO.Entity_and_Mapping;

namespace Test.Unit.Mapping
{
    [TestFixture]
    class MappingTest : SetupMappingTest
    {
        [Test]
        public void MappingTest_Account()
        {
            // Create new Data to be saved in DB
            object id;
            using (var transaction = Session.BeginTransaction())
            {
                id = Session.Save(new Account
                {
                    Id = 1,
                    DisplayName = "TestAcoount",
                    Password = "TestPassword",
                    Type = true,
                    UserName = "TestUserName"
                });
                transaction.Commit();
            }
            // session is cleared in order to remove any traces of class instance from
            // previous database operation
            Session.Clear();
            // Test if the input data is right
            using (var transaction = Session.BeginTransaction())
            {
                var accountInstance = Session.Get<Account>(id);
                // Testing cases
                Assert.That(accountInstance.Id, Is.EqualTo(1));
                Assert.That(accountInstance.DisplayName, Is.EqualTo("TestAcoount"));
                Assert.That(accountInstance.Password, Is.EqualTo("TestPassword"));
                Assert.That(accountInstance.Type, Is.EqualTo(true));
                Assert.That(accountInstance.UserName, Is.EqualTo("TestUserName"));

            }
        }
        [Test]
        public void MappingTest_Bill()
        {
            // Create new Data to be saved in DB
            object id;
            using (var transaction = Session.BeginTransaction())
            {
                id = Session.Save(new Bill
                {
                    Id = 1,
                    Status = true,
                    DateCheckIn = new DateTime(1980, 2, 2),
                    DateCheckOut = new DateTime(2000, 1, 1),
                    Discount = 50,
                });
                transaction.Commit();
            }
            // session is cleared in order to remove any traces of class instance from
            // previous database operation
            Session.Clear();
            // Test if the input data is right
            using (var transaction = Session.BeginTransaction())
            {
                var accountInstance = Session.Get<Bill>(id);
                // Testing cases
                Assert.That(accountInstance.Id, Is.EqualTo(1));
                Assert.That(accountInstance.Status, Is.EqualTo(true));
                Assert.That(accountInstance.DateCheckIn, Is.EqualTo(new DateTime(1980, 2, 2)));
                Assert.That(accountInstance.DateCheckOut, Is.EqualTo(new DateTime(2000, 1, 1)));
                Assert.That(accountInstance.Discount, Is.EqualTo(50));

            }
        }

        [Test]
        public void MappingTest_BillInfo()
        {
            // Create new Data to be saved in DB
            object id;
            using (var transaction = Session.BeginTransaction())
            {
                id = Session.Save(new BillInfo
                {
                    Id = 1,
                    Count = 2
                });
                transaction.Commit();
            }
            // session is cleared in order to remove any traces of class instance from
            // previous database operation
            Session.Clear();
            // Test if the input data is right
            using (var transaction = Session.BeginTransaction())
            {
                var accountInstance = Session.Get<BillInfo>(id);
                // Testing cases
                Assert.That(accountInstance.Id, Is.EqualTo(1));
                Assert.That(accountInstance.Count, Is.EqualTo(2));

            }
        }

        [Test]
        public void MappingTest_Food()
        {
            // Create new Data to be saved in DB
            object id;
            using (var transaction = Session.BeginTransaction())
            {
                id = Session.Save(new Food
                {
                    Id = 1,
                    Name = "TestFood",
                    Price = 5.50M
                });
                transaction.Commit();
            }
            // session is cleared in order to remove any traces of class instance from
            // previous database operation
            Session.Clear();
            // Test if the input data is right
            using (var transaction = Session.BeginTransaction())
            {
                var accountInstance = Session.Get<Food>(id);
                // Testing cases
                Assert.That(accountInstance.Id, Is.EqualTo(1));
                Assert.That(accountInstance.Name, Is.EqualTo("TestFood"));
                Assert.That(accountInstance.Price, Is.EqualTo(5.50M));

            }
        }
        [Test]
        public void MappingTest_FoodCategory()
        {
            // Create new Data to be saved in DB
            object id;
            using (var transaction = Session.BeginTransaction())
            {
                id = Session.Save(new FoodCategory
                {
                    Id = 1,
                    Name = "TestCategory"
                });
                transaction.Commit();
            }
            // session is cleared in order to remove any traces of class instance from
            // previous database operation
            Session.Clear();
            // Test if the input data is right
            using (var transaction = Session.BeginTransaction())
            {
                var accountInstance = Session.Get<FoodCategory>(id);
                // Testing cases
                Assert.That(accountInstance.Id, Is.EqualTo(1));
                Assert.That(accountInstance.Name, Is.EqualTo("TestCategory"));
            }
        }
        [Test]
        public void MappingTest_GuestTable()
        {
            // Create new Data to be saved in DB
            object id;
            using (var transaction = Session.BeginTransaction())
            {
                id = Session.Save(new GuestTable
                {
                    Id = 1,
                    Name = "TestGuestTable",
                    Status = "Busy"

                });
                transaction.Commit();
            }
            // session is cleared in order to remove any traces of class instance from
            // previous database operation
            Session.Clear();
            // Test if the input data is right
            using (var transaction = Session.BeginTransaction())
            {
                var accountInstance = Session.Get<GuestTable>(id);
                // Testing cases
                Assert.That(accountInstance.Id, Is.EqualTo(1));
                Assert.That(accountInstance.Name, Is.EqualTo("TestGuestTable"));
                Assert.That(accountInstance.Status, Is.EqualTo("Busy"));
            }
        }
    }
}

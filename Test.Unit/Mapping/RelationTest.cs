using System;
using System.Linq;
using NUnit.Framework;
using RestaurantManagement_DAO.Entity_and_Mapping;

namespace Test.Unit.Mapping
{
    [TestFixture]
    class RelationTest : SetupMappingTest
    {
        [Test]
        public void MappingTest_Relation_Bill_BillInfo()
        {
            object billId;
            object billInfoId;
            using ( var transaction = Session.BeginTransaction())
            {
                var bill = new Bill()
                {
                    Status = true,
                    DateCheckIn = new DateTime(1981, 2, 2),
                    DateCheckOut = new DateTime(2001, 1, 1),
                    Discount = 55,
                };
                var billInfo = new BillInfo()
                {
                    Count = 3
                };
                bill.AddBillInfo(billInfo);
                billId = Session.Save(bill);
                billInfoId = Session.Save(billInfo);
                transaction.Commit();
            }
            Session.Clear();

            var testBill = Session.Get<Bill>(billId);
            var testBillInfo = Session.Get<BillInfo>(billInfoId);
            // One to many relation
            Assert.That(testBill.BillInfoCollection.First().Count, Is.EqualTo(3));
            // Many to one relation
            Assert.That(testBillInfo.Bill.Status, Is.EqualTo(true));
            Assert.That(testBillInfo.Bill.DateCheckIn, Is.EqualTo(new DateTime(1981, 2, 2)));
            Assert.That(testBillInfo.Bill.DateCheckOut, Is.EqualTo(new DateTime(2001, 1, 1)));
            Assert.That(testBillInfo.Bill.Discount, Is.EqualTo(55));
        }
        [Test]
        public void MappingTest_Relation_Bill_GuestTable()
        {
            object billId;
            object guestTableId;
            using (var transaction = Session.BeginTransaction())
            {
                var bill = new Bill()
                {
                    Status = true,
                    DateCheckIn = new DateTime(1981, 2, 2),
                    DateCheckOut = new DateTime(2001, 1, 1),
                    Discount = 55,
                };
                var guestTable = new GuestTable()
                {
                    Status = "TestStatus",
                    Name = "TestTable"
                };
               
                guestTable.AddBill(bill);
                billId = Session.Save(bill);
                guestTableId = Session.Save(guestTable);
                transaction.Commit();
            }
            Session.Clear();

            var testBill = Session.Get<Bill>(billId);
            var testGuestTable = Session.Get<GuestTable>(guestTableId);
            
            // Many to one relation
            Assert.That(testBill.GuestTable.Status, Is.EqualTo("TestStatus"));
            Assert.That(testBill.GuestTable.Name, Is.EqualTo("TestTable"));
            
            // One to many relation
            Assert.That(testGuestTable.BillCollection.First().Status, Is.EqualTo(true));
            Assert.That(testGuestTable.BillCollection.First().DateCheckIn, Is.EqualTo(new DateTime(1981, 2, 2)));
            Assert.That(testGuestTable.BillCollection.First().DateCheckOut, Is.EqualTo(new DateTime(2001, 1, 1)));
            Assert.That(testGuestTable.BillCollection.First().Discount, Is.EqualTo(55));
        }

        [Test]
        public void MappingTest_Relation_BillInfo_Food()
        {
            object billInfoId;
            object foodId;
            using (var transaction = Session.BeginTransaction())
            {
                var billInfo = new BillInfo()
                {
                    Count = 8
                };
                var food = new Food()
                {
                    Name = "TestFoody",
                    Price = 5.57M
                };

                food.AddBillInfo(billInfo);
                billInfoId = Session.Save(billInfo);
                foodId = Session.Save(food);
                transaction.Commit();
            }
            Session.Clear();

            var testBillInfo = Session.Get<BillInfo>(billInfoId);
            var testFood = Session.Get<Food>(foodId);

            // Many to one relation
            Assert.That(testBillInfo.Food.Name, Is.EqualTo("TestFoody"));
            Assert.That(testBillInfo.Food.Price, Is.EqualTo(5.57M));

            // One to many relation
            Assert.That(testFood.BillInfoCollection.First().Count, Is.EqualTo(8));
        }

        [Test]
        public void MappingTest_Relation_FoodCategory_Food()
        {
            object foodCategoryId;
            object foodId;
            using (var transaction = Session.BeginTransaction())
            {
                var foodCategory = new FoodCategory()
                {
                    Name = "Test Category"
                };
                var food = new Food()
                {
                    Name = "Testy Food",
                    Price = 5.59M
                };

                foodCategory.AddFood(food);
                foodId = Session.Save(food);
                foodCategoryId = Session.Save(foodCategory);
                transaction.Commit();
            }
            Session.Clear();

            var testFood = Session.Get<Food>(foodId);
            var testFoodCategory = Session.Get<FoodCategory>(foodCategoryId);
            //
            // Many to one relation
            Assert.That(testFoodCategory.FoodCollection.First().Name, Is.EqualTo("Testy Food"));
            Assert.That(testFoodCategory.FoodCollection.First().Price, Is.EqualTo(5.59M));

            // One to many relation
            Assert.That(testFood.FoodCategory.Name, Is.EqualTo("Test Category"));
        }
    }
}

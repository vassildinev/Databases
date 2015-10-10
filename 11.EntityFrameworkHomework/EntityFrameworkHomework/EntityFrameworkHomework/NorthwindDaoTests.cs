namespace EntityFrameworkHomework
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    using Telerik.JustMock;

    [TestClass]
    public class NorthwindDaoTests
    {

        private readonly IList<Customer> db = new List<Customer>()
        {
            new Customer()
                {
                    CustomerID = "PEN",
                    ContactName = "John Johnson"
                },

                new Customer()
                {
                    CustomerID = "PENCIL",
                    ContactName = "Georgi Stamatski"
                }
        };

        [TestMethod]
        public void UpdateCustomerShouldChangeDbRecord()
        {
            var northwindDbMock = new NorthwindEntities();
            Mock.Arrange(() => northwindDbMock.Customers).ReturnsCollection(this.db);

            var expected = "Ivan Borimechkata";
            NorthwindDao.ModifyCustomer(northwindDbMock, "pen",
                                        c => c.ContactName = expected);

            var actual = this.db.Where(x => x.CustomerID == "PEN")
                                .FirstOrDefault()
                                .ContactName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddCustomerShouldAddDbRecord()
        {
            var customer = new Customer()
            {
                CustomerID = "ZXC",
                ContactName = "Asd Qwerty"
            };

            var northwindDbMock = new NorthwindEntities();
            Mock.Arrange(() => northwindDbMock.Customers).ReturnsCollection(this.db);
            Mock.Arrange(() =>
                northwindDbMock.Customers
                               .Add(customer))
                                    .DoInstead((Customer c) => { this.db.Add(c); });

            NorthwindDao.InsertCustomer(northwindDbMock, customer);

            Assert.AreEqual(expected: 3, actual: this.db.Count);
        }
    }
}

namespace EntityFrameworkHomework
{
    using System;
    using System.Linq;

    public class EntryPoint
    {
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                // MODIFY CUSTOMER
                //NorthwindDao.ModifyCustomer(db: db, customerId: "alfki", operation: (customer => customer.City = "Sofia"));

                // INSERT CUSTOMER
                //NorthwindDao.InsertCustomer(new Customer
                //{
                //    CustomerID = "PESHO",
                //    CompanyName = "Pesho Inc.",
                //    ContactName = "Goshko",
                //    ContactTitle = "CEO",
                //    Address = "Studentski grad",
                //    City = "Sofia",
                //    PostalCode = "1000",
                //    Country = "Bulgaria"
                //});

                // DELETE CUSTOMER
                //NorthwindDao.DeleteCustomer(db: db, customerId: "alfki");

                // GET ALL CUSTOMERS WITH ORDERS IN 1997 TO CANADA
                //var customers = NorthwindDao.GetAllCustomersWithOrdersIn1997ToCanada(db);

                // GET ALL CUSTOMERS WITH ORDERS IN 1997 TO CANADA USING NATIVE QUERY
                //var customers = NorthwindDao.GetAllCustomersWithOrdersIn1997ToCanadaWithQuery(db);
                //foreach (var item in customers)
                //{
                //    Console.WriteLine("{0} - {1}", item.CustomerID, item.ContactName);
                //}

                //db.SaveChanges();

                // GET ALL ORDERS FROM A REGION AND IN A TIME SPAN
                var orders = NorthwindDao.GetAllSalesBySpecifiedRegionAndPeriod(db, "RJ", new DateTime(1995, 01, 01), new DateTime(2000, 01, 01));

                foreach (var item in orders)
                {
                    Console.WriteLine("{0} - {1}", item.OrderID, item.CustomerID);
                }

                // USE THE NEW EMPLOYEE PROPERTY
                //var territories = db.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault().TerritoriesEntities.ToList();
                //foreach (var item in territories)
                //{
                //    Console.WriteLine(item.TerritoryDescription);
                //}
            }
        }
    }
}

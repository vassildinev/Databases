namespace EntityFrameworkHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class NorthwindDao
    {
        public static void InsertCustomer(NorthwindEntities db, Customer customer)
        {
            Console.WriteLine("INSERTING CUSTOMER...");
            var allCustomers = db.Customers;
            foreach (var item in allCustomers)
            {
                if (item.CustomerID.ToLower() == customer.CustomerID.ToLower())
                {
                    return;
                }
            }

            db.Customers.Add(customer);
            db.SaveChanges();
            Console.WriteLine("DONE");
        }

        public static void DeleteCustomer(NorthwindEntities db, string customerId)
        {
            Console.WriteLine("DELETING CUSTOMER...");
            var customer = db.Customers.FirstOrDefault(x => x.CustomerID.ToLower() == customerId.ToLower());
            if (customer != null)
            {
                var orders = db.Orders.Where(x => x.CustomerID.ToLower() == customerId.ToLower()).ToList();
                foreach (var order in orders)
                {
                    order.CustomerID = null;
                }

                db.SaveChanges();

                db.Customers.Remove(customer);
                db.SaveChanges();
            }

            Console.WriteLine("DONE");
        }

        public static void ModifyCustomer(NorthwindEntities db, string customerId, Action<Customer> operation)
        {
            Console.WriteLine("MODIFYING CUSTOMER...");
            Customer customer = db.Customers.FirstOrDefault(x => x.CustomerID.ToLower() == customerId.ToLower());
            if (customer != null)
            {
                operation.Invoke(customer);
                db.SaveChanges();
            }

            Console.WriteLine("DONE");
        }

        public static IEnumerable<Order> GetAllSalesBySpecifiedRegionAndPeriod(NorthwindEntities db, string region, DateTime start, DateTime end)
        {
            var result = db.Orders.Where(o => o.OrderDate <= end && o.OrderDate >= start && o.ShipRegion == region).ToList();

            return result;
        }

        public static IEnumerable<Customer> GetAllCustomersWithOrdersIn1997ToCanada(NorthwindEntities db)
        {
            // Shows only distinct rows!
            var customers = from c in db.Customers
                            where (from o in c.Orders
                                   where o.ShipCountry == "Canada"
                                   select o).Count() != 0
                            select c;

            return customers.ToList();
        }

        public static IEnumerable<Customer> GetAllCustomersWithOrdersIn1997ToCanadaWithQuery(NorthwindEntities db)
        {
            // Does not show distinct rows!
            string query = "select * from Customers c, Orders o " +
                           "where o.CustomerID = c.CustomerID and datediff(year, o.OrderDate, '1997-01-01') = 0 and o.ShipCountry = 'Canada' ";

            var customers = db.Database.SqlQuery<Customer>(query);

            return customers.ToList();
        }
    }
}

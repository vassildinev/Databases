namespace NortwindSubstrContainedInProducts
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("String to search: ");
            var str = Console.ReadLine();
            Console.WriteLine("\nResults:" + new string('=', 20));
            var products = GetProductNames();
            foreach (var item in products)
            {
                if (item.Contains(str))
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static ICollection<string> GetProductNames()
        {
            var products = new List<string>();
            
            var connectionString = "Server=(local); Database=Northwind; Integrated Security=true;";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(cmdText: "select ProductName from Products", connection: connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var product = (string)reader["ProductName"];
                products.Add(product);
            }
            connection.Close();

            return products;
        }
    }
}

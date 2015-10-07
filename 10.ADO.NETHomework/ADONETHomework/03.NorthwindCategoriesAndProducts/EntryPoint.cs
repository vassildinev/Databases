namespace NorthwindCategoriesAndProducts
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class EntryPoint
    {
        public static void Main()
        {
            var connection = new SqlConnection(connectionString: "Server=(local); Database=Northwind; Integrated Security=true;");
            connection.Open();
            var command = new SqlCommand(cmdText: "select c.CategoryName, p.ProductName from Products p inner join Categories c on c.CategoryId = p.CategoryId;", connection: connection);

            var categoriesAndProducts = new Dictionary<string, List<string>>();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var category = (string)reader["CategoryName"];
                var product = (string)reader["ProductName"];
                if(categoriesAndProducts.ContainsKey(category))
                {
                    categoriesAndProducts[category].Add(product);
                }
                else
                {
                    categoriesAndProducts.Add(category, new List<string>());
                }
            }

            connection.Close();

            foreach (var kvp in categoriesAndProducts)
            {
                Console.WriteLine(new string(c: '=', count: 20) + "\n" + kvp.Key + "\n" + new string(c: '=', count: 20));

                foreach (var product in kvp.Value)
                {
                    Console.WriteLine("-- " + product);
                }
            }
        }
    }
}

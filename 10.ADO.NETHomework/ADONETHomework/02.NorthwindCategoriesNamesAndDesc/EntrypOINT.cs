namespace NorthwindCategoriesNamesAndDesc
{
    using System;
    using System.Data.SqlClient;

    public class EntryPoint
    {
        public static void Main()
        {
            var connection = new SqlConnection(connectionString: "Server=(local); Database=Northwind; Integrated Security=true;");
            connection.Open();
            var command = new SqlCommand(cmdText: "select CategoryName, Description from Categories;", connection: connection);

            Console.WriteLine(value: "Northwind categories\n=======================================================");
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["CategoryName"]} - {reader["Description"]}");
            }

            connection.Close();
        }
    }
}

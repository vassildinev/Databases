namespace RowsInNorthwind
{
    using System;
    using System.Data.SqlClient;

    public class EntryPoint
    {
        public static void Main()
        {
            var connection = new SqlConnection(connectionString: "Server=(local); Database=Northwind; Integrated Security=true;");
            connection.Open();
            var command = new SqlCommand(cmdText: "select count(*) from Categories;", connection: connection);
            var result = (int)command.ExecuteScalar();
            Console.WriteLine($"Number of rows in Northwind.Categories: {result}");
            connection.Close();
        }
    }
}

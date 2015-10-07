namespace AddEntryToNorthwindProducts
{
    using System;
    using System.Data.SqlClient;

    public class EntryPoint
    {
        public static void Main()
        {
            var connection = new SqlConnection(connectionString: "Server=(local); Database=Northwind; Integrated Security=true;");
            connection.Open();
            var command = new SqlCommand(cmdText: "insert into Products(ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)" +
                "values (@name, @suppId, @catId,@qpu, @unitPrice, @unitsInStock, @unitsInOrder, @reorderLvl, @disc)", connection: connection);
            command.Parameters.AddWithValue(parameterName: "@name", value: "Stamat");
            command.Parameters.AddWithValue(parameterName: "@suppId", value: 5);
            command.Parameters.AddWithValue(parameterName: "@catId", value: 5);
            command.Parameters.AddWithValue(parameterName: "@qpu", value: "6 boxes");
            command.Parameters.AddWithValue(parameterName: "@unitPrice", value: 14);
            command.Parameters.AddWithValue(parameterName: "@unitsInStock", value: 54);
            command.Parameters.AddWithValue(parameterName: "@unitsInOrder", value: 10);
            command.Parameters.AddWithValue(parameterName: "@reorderLvl", value: 8);
            command.Parameters.AddWithValue(parameterName: "@disc", value: "true");

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine($"({rowsAffected}) row(s) affected");
        }
    }
}

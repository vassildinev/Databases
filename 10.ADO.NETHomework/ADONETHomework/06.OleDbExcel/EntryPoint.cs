namespace OleDbExcel
{
    using System;
    using System.Data.OleDb;

    public class EntryPoint
    {
        public static void Main()
        {
            string connectionString = @"Provider=Microsoft.Jet.OleDB.4.0;" +
                @"Data Source=../../results.xls; Persist Security Info=false;Extended Properties=Excel 8.0";
            var connection = new OleDbConnection(connectionString);
            connection.Open();
            var command = new OleDbCommand(cmdText: "select * from [Results$]", connection: connection);

            Console.WriteLine("Name - Score\n" + new string(c: '=', count: 25));
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}.| {reader["Name"]} - {reader["Score"]}");
            }

            connection.Close();
        }
    }
}

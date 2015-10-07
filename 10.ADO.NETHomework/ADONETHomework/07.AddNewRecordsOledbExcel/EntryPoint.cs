namespace AddNewRecordsOledbExcel
{
    using System;
    using System.Data.OleDb;

    public class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine(value: "Adding results...");
            AddResultToDb(name: "Vankata", score: 2050);
            Console.WriteLine(value: "Results added.");
        }

        public static void AddResultToDb(string name, int score)
        {
            string connectionString = @"Provider = Microsoft.Jet.OleDB.4.0; " +
                @"Data Source=..\\..\\results.xls; Persist Security Info=false;Extended Properties=Excel 8.0";
            var connection = new OleDbConnection(connectionString);
            connection.Open();
            var command = new OleDbCommand("insert into [Results$](Id, Name, Score)" +
                "values (@id, @name, @score)", connection: connection);
            command.Parameters.AddWithValue(parameterName: "@id", value: GetNextId(connection));
            command.Parameters.AddWithValue(parameterName: "@name", value: name);
            command.Parameters.AddWithValue(parameterName: "@score", value: score);
            var rows = command.ExecuteNonQuery();
            Console.WriteLine($"({rows}) row(s) affected");
            connection.Close();
        }

        private static double GetNextId(OleDbConnection connection)
        {
            var command = new OleDbCommand(cmdText: "select top 1 Id from [Results$] order by Id desc", connection: connection);
            double id = 0;

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = (double)reader["Id"];
            }

            return id + 1;
        }
    }
}

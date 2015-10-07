namespace NorthwindBinaryToJpg
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("Retrieving data...");
            var connectionString = "Server=(local); Database=Northwind; Integrated Security=true;";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(cmdText: "select CategoryName, Picture from Categories", connection: connection);
            var converter = new ImageConverter();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var bitmap = (byte[])reader["Picture"];
                string name = ((string)reader["CategoryName"]).Split('/')[0].ToLower();
                var image = (Image)converter.ConvertFrom(bitmap);
                image.Save($"../../Images/{name}.jpeg", ImageFormat.Jpeg);
            }

            connection.Close();

            Console.WriteLine("Data saved to disk.");
        }
    }
}

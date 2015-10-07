namespace MySqlBooksDatabase
{
    using System;
    using System.Collections.Generic;

    using MySql.Data.MySqlClient;
    using System.Linq;

    public class EntryPoint
    {
        public static void Main()
        {
            //PrintBooksToConsole();

            //var book = GetBookByName("pod igoto");
            //Console.WriteLine($"{book.Title} - {book.Author}");

            var book = new Book(title: "Stamat", author: "Mariika");
            AddBook(book);
        }

        public static void PrintBooksToConsole()
        {
            var books = GetAllBooks();
            Console.WriteLine("Books:\n" + new string('=', 20));
            foreach (var item in books)
            {
                Console.WriteLine($"{item.Title} - {item.Author}");
            }
        }

        public static Book GetBookByName(string title)
        {
            var books = GetAllBooks();
            return books.Where(b => b.Title.ToLower() == title.ToLower()).FirstOrDefault();
        }

        public static void AddBook(Book book)
        {
            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();
            Console.Clear();

            var connectionString = "Server=localhost;Database=Books;Uid=root;Pwd=" + pass + ";";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = new MySqlCommand(cmdText: "insert into books(Title, Author, PublishDate, ISBN)" + 
                " values(@title, @author, @date, @isbn)", connection: connection);
            command.Parameters.AddWithValue(parameterName: "@title", value: book.Title);
            command.Parameters.AddWithValue(parameterName: "@author", value: book.Author);
            command.Parameters.AddWithValue(parameterName: "@date", value: book.PublishDate);
            command.Parameters.AddWithValue(parameterName: "@isbn", value: book.Isbn);
            var result = command.ExecuteNonQuery();
            Console.WriteLine($"({result}) row(s) affected");
            connection.Close();
        }

        private static ICollection<Book> GetAllBooks()
        {
            var list = new List<Book>();

            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();
            Console.Clear();

            var connectionString = "Server=localhost;Database=Books;Uid=root;Pwd=" + pass + ";";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = new MySqlCommand("select * from books", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Book((string)reader["Title"], (string)reader["Author"]));
            }
            
            connection.Close();

            return list;
        }
    }
}

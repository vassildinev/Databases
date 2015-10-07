namespace SQLiteBooksDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;

    public class EntryPoint
    {
        public static void Main()
        {
            //PrintBooksToConsole();

            //var book = GetBookByName(title: "pod igoto");
            //Console.WriteLine($"{book.Title} - {book.Author}");

            var book = new Book(title: "Stamat", author: "Mariika");
            AddBook(book);
        }

        public static void AddBook(Book book)
        {
            var connectionString = "Data Source=../../SQLite/Books.db;Version=3;";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var command = new SQLiteCommand(commandText: "insert into books(Title, Author, PublishDate, ISBN)" +
                " values(@title, @author, @date, @isbn)", connection: connection);
            command.Parameters.AddWithValue(parameterName: "@title", value: book.Title);
            command.Parameters.AddWithValue(parameterName: "@author", value: book.Author);
            command.Parameters.AddWithValue(parameterName: "@date", value: book.PublishDate);
            command.Parameters.AddWithValue(parameterName: "@isbn", value: book.Isbn);
            var result = command.ExecuteNonQuery();
            Console.WriteLine($"({result}) row(s) affected");
            connection.Close();
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

        private static ICollection<Book> GetAllBooks()
        {
            var list = new List<Book>();

            var connectionString = "Data Source=../../SQLite/Books.db;Version=3;";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var command = new SQLiteCommand(commandText: "select * from Books", connection: connection);
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

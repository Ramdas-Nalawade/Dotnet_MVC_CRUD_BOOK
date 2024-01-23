using Book_CRUD.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Book_CRUD.Repository
{
    public class BookRepo
    {
        public static List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = @"server=localhost; port=3306; user=root; 
                                    password=root123;  database=mytables";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from book";

            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    int id = int.Parse(dr["id"].ToString());
                    string? title = dr["title"].ToString();
                    string? author = dr["author"].ToString();
                    double price = double.Parse(dr["price"].ToString());
                    int quantity = int.Parse(dr["quantity"].ToString());

                    Book book = new Book();
                    book.Id = id;
                    book.Title = title;
                    book.Author = author;
                    book.Price = price;
                    book.Quantity = quantity;
                    list.Add(book);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static Book GetById(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = @"server=localhost; port=3306; user=root;
                                            password=root123; database=mytables";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from book where id = " + id;
            Book book = null;

            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int bid = int.Parse(dr["id"].ToString());
                    string? title = dr["title"].ToString();
                    string? author = dr["author"].ToString();
                    double price = double.Parse(dr["price"].ToString());
                    int quantity = int.Parse(dr["quantity"].ToString());
                    book = new(bid, title, author, price, quantity);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return book;
        }
        public static void Insert(Book book)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = @"server=localhost; port=3306; user=root;
                                            password=root123; database=mytables";
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"insert into book value({book.Id}, '{book.Title}','{book.
                                     Author}', {book.Price}, {book.Quantity})";
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = @"server=localhost; port=3306; user=root;
                                            password=root123; database=mytables";
            connection.Open ();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from book where id = "+id;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void Update(Book book)
        {
            int id = book.Id;
            string title = book.Title;
            string author = book.Author;
            double price = book.Price;
            int quantity = book.Quantity;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = @"server=localhost; port=3306; user=root;
                                                password=root123; database=mytables;";
            connection.Open ();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book set title='"+title+"', author='"+author+"', price='"+price+"',quantity='"+quantity+"' where id = "+id;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

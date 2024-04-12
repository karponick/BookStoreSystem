using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Threading.Tasks;
using static BookStoreSystem.User;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BookStoreSystem
{
    public class DatabaseController
    {
        const string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = ../../BookStoreDB.accdb";

        public static User GetUser(string userName, string password, AccountType accountType)
        {
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection(connectionString);
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("Select * From User where Username=@Username and [Password]=@Password and Account_Type=@AccountType", conn);
                cmd.Parameters.Add("@Username", OleDbType.VarChar).Value = userName;
                cmd.Parameters.Add("@Password", OleDbType.VarChar).Value = password;
                cmd.Parameters.Add("@AccountType", OleDbType.VarChar).Value = accountType;
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User(
                        int.Parse(reader["User_ID"].ToString()),
                        reader["Username"].ToString(),
                        reader["Password"].ToString(),
                        (AccountType)Enum.Parse(typeof(AccountType), reader["Account_Type"].ToString())
                        );
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public static bool AddUser(User user)
        {
            OleDbCommand
        }
        /*************************** Fields ***************************/
        readonly OleDbConnection myConnection;
        readonly OleDbCommand myCommand;
        readonly OleDbDataAdapter myAdapter;
        DataSet dataSet;


        /************************ Constructors ************************/
        public DatabaseController()
        {
            // Initialize Database connection stuff
            string strConnection = "provider=Microsoft.ACE.OLEDB.12.0;" +
                        "Data Source=BookStoreDB.accdb;";
            myConnection = new OleDbConnection(strConnection);
            myCommand = new OleDbCommand(string.Empty, myConnection);
            myAdapter = new OleDbDataAdapter(myCommand);
        }


        /*************************** Methods ***************************/
        private void PrintColHeaders(DataTable table)
        {
            foreach (DataColumn col in table.Columns)
            {
                Console.WriteLine(col.ColumnName + ": " + col.DataType.ToString());
            }
        }

        public List<Book> GetBookList()
        {
            // Gets all Books from Book table
            List<Book> bookList = new List<Book>();
            myCommand.CommandText = "SELECT * FROM Book";
            dataSet = new DataSet();
            try
            {
                myConnection.Open();
                myAdapter.Fill(dataSet, "Book");
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            // Handle data from database
            DataTable tableBooks = dataSet.Tables["Book"];

            foreach (DataRow row in tableBooks.Rows)
            {
                // Create book and add to list
                Book newBook = new Book(row["Book_ID"].ToString(), row["Pages"].ToString(), row["Price"].ToString())
                {
                    Title = row["Title"].ToString(),
                    Author = row["Author"].ToString(),
                    Genre = row["Genre"].ToString(),
                    Description = row["Description"].ToString(),
                    Publication = row["Publication"].ToString(),
                    CoverUrl = row["Cover_Url"].ToString()
                };
                bookList.Add(newBook);
            }
            return bookList;
        }

        public void AddBook(Book book)
        {
            List<Book> bookList = GetBookList();
            int latestId = bookList[bookList.Count - 1].Id;
            book.Id = latestId + 1;
            try
            {
                myConnection.Open();
                myCommand.CommandText = "INSERT INTO Book VALUES ('" + string.Join("','", book.ToArray()) + "')";
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }
        public void ModifyBook(Book book)
        {
            try
            {
                myConnection.Open();
                myCommand.CommandText = string.Format("Update Book SET Title = '{1}', Author = '{2}', Genre = '{3}', " +
                    "Description = '{4}', Pages = {5}, Price = {6}, Publication = '{7}', Cover_Url = '{8}' WHERE Book_ID = {0}",
                    book.Id, book.Title, book.Author, book.Genre, book.Description, book.Pages, book.Price, book.Publication, book.CoverUrl);
                Console.WriteLine(myCommand.CommandText);
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }
        public void DeleteBook(int bookId)
        {
            Console.WriteLine(bookId.ToString());
            try
            {
                myConnection.Open();
                myCommand.CommandText = "DELETE FROM Book WHERE Book_ID = " + bookId;
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }
    }
}
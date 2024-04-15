using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using static BookStoreSystem.User;

namespace BookStoreSystem
{
    public class DatabaseController
    {
        /*************************** Fields ***************************/
        const string connectionString = "provider=Microsoft.ACE.OLEDB.12.0; Data Source=BookStoreDB.accdb;";
        static OleDbConnection myConnection = new OleDbConnection(connectionString);
        static OleDbCommand myCommand = new OleDbCommand(string.Empty, myConnection);
        static OleDbDataAdapter myAdapter = new OleDbDataAdapter(myCommand);

        /*************************** Book Methods ***************************/
        private void PrintColHeaders(DataTable table)
        {
            // Used for testing purposes - will be deleted, eventually....
            foreach (DataColumn col in table.Columns)
            {
                Console.WriteLine(col.ColumnName + ": " + col.DataType.ToString());
            }
        }

        public static List<Book> GetBookList()
        {
            // Gets all Books from Book table
            List<Book> bookList = new List<Book>();
            myCommand.CommandText = "SELECT * FROM Book";
            DataSet dataSet = new DataSet();
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

        public static void AddBook(Book book)
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
        public static void ModifyBook(Book book)
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
        public static void DeleteBook(int bookId)
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
        public static string GetBookTitle(int id)
        {
            // Gets Book Title from Database by ID
            myCommand.CommandText = "SELECT Title FROM Book WHERE Book_ID = " + id.ToString();
            DataSet dataSet = new DataSet();
            try
            {
                myConnection.Open();
                myAdapter.Fill(dataSet, "Book");
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            DataTable table = dataSet.Tables["Book"];
            DataRow row = table.Rows[0];
            return row["Title"].ToString();
        }

        /**************************** Review Methods *****************************************/
        public static List<Review> GetReviewList(int bookId)
        {
            // Gets all Books from Book table
            List<Review> reviewList = new List<Review>();
            myCommand.CommandText = "SELECT * FROM Review WHERE Book_ID = " + bookId.ToString();
            DataSet dataSet = new DataSet();
            try
            {
                myConnection.Open();
                myAdapter.Fill(dataSet, "Review");
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            // Handle data from database
            DataTable table = dataSet.Tables["Review"];

            foreach (DataRow row in table.Rows)
            {
                // Create book and add to list
                Review newReview = new Review(row["Review_ID"].ToString(), row["User_ID"].ToString(), row["Book_ID"].ToString())
                {
                    Description = row["Description"].ToString()
                };
                newReview.SetRatings(row["Style_Rating"].ToString(), row["Plot_Rating"].ToString(), row["Character_Rating"].ToString());
                reviewList.Add(newReview);
            }
            return reviewList;
        }

        /**************************** User Methods *******************************************/

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
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connectionString;

            OleDbCommand cmd = new OleDbCommand(@"Insert into User
                                            (Username, Password, Account_Type)
                                            values(@Username, @Password, @Account_Type)");

            conn.Open();
            cmd.Connection = conn;

            if(conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Username", OleDbType.VarChar).Value = user.UserName;
                cmd.Parameters.Add("@Password", OleDbType.VarChar).Value = user.Password;
                cmd.Parameters.Add("@Account_Type", OleDbType.VarChar).Value = user.AccountType1;

                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
    }
}
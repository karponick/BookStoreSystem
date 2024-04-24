using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using static BookStoreSystem.User;
using static BookStoreSystem.Transaction;

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

                OleDbCommand cmd = new OleDbCommand("Select * From [User] where [Username]=@Username and [Password]=@Password and Account_Type=@AccountType", conn);
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

            OleDbCommand cmd = new OleDbCommand(@"Insert into [User]
                                            ([Username], [Password], [Account_Type])
                                            values (@Username, @Password, @Account_Type)");

            conn.Open();
            cmd.Connection = conn;

            if(conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Username", OleDbType.VarChar).Value = user.UserName;
                cmd.Parameters.Add("@Password", OleDbType.VarChar).Value = user.Password;
                cmd.Parameters.Add("@Account_Type", OleDbType.VarChar).Value = user.AccountType1.ToString();

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

        /**************************** Transaction Methods *****************************************/


        public static void CreateTransaction(Transaction transaction)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand(@"INSERT into [Transaction] ( User_ID, PurchaseDate, TotalCost, CardNumber, CardType,
                                            ExpirationDate, SecurityCode, BillingAddress, ZIP, State)
                                            values(@User_ID, @PurchaseDate, @TotalCost, @CardNumber, @CardType,
                                            @ExpirationDate, @SecurityCode, @BillingAddress, @ZIP, @State)", connection);
                
                oleDbCommand.Parameters.Add("@User_ID", OleDbType.Integer).Value = transaction.UserID;
                oleDbCommand.Parameters.Add("@PurchaseDate", OleDbType.Date).Value = transaction.PurchaseDate;
                oleDbCommand.Parameters.Add("@TotalCost", OleDbType.Double).Value = transaction.TotalCost;
                oleDbCommand.Parameters.Add("@CardNumber", OleDbType.VarChar).Value = transaction.CardNumber;
                oleDbCommand.Parameters.Add("@CardType", OleDbType.VarChar).Value = transaction.CardType1;
                oleDbCommand.Parameters.Add("@ExpirationDate", OleDbType.Date).Value = transaction.ExpDate;
                oleDbCommand.Parameters.Add("@SecurityCode", OleDbType.Integer).Value = transaction.SecurityCode;
                oleDbCommand.Parameters.Add("@BillingAddress", OleDbType.VarChar).Value = transaction.BillingAddress;
                oleDbCommand.Parameters.Add("@ZIP", OleDbType.VarChar).Value = transaction.ZIP;
                oleDbCommand.Parameters.Add("@State", OleDbType.VarChar).Value = transaction.State;
                oleDbCommand.ExecuteNonQuery();

                var cmd1 = new OleDbCommand("SELECT @@IDENTITY", connection);
                int transactionId = (int)cmd1.ExecuteScalar();

              
               //insert into booktransaction table
               foreach (var item in transaction.Books)
               {
                   OleDbCommand cmd2 = new OleDbCommand(@"INSERT into BookTransaction
                               (Book_ID, Transaction_ID)
                               values(@Book_ID, @Transaction_ID)", connection);

                   cmd2.Parameters.Add("@Book_ID", OleDbType.Integer).Value = item.Id;
                   cmd2.Parameters.Add("@Transaction_ID", OleDbType.Integer).Value = transactionId;
                   try
                   {
                       cmd2.ExecuteNonQuery();
                   }
                   catch (OleDbException ex)
                   {
                       Debug.WriteLine(ex.Message);
                       connection.Close();
                   }
               }
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
            finally
            {
                connection.Close();
            }
        }


        public static List<Transaction> GetTransactions()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                connection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand("select * from [Transaction]", connection);
                OleDbDataReader reader = oleDbCommand.ExecuteReader();

                while (reader.Read())
                {
                    Transaction transaction = BindTransaction(reader);
                    transactions.Add(transaction);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Transaction>();
            }
            finally
            {
                connection.Close();
            }
            return transactions;
        }

        public static List<Book> GetBooksByTransaction(int transactionID)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            List<Book> books = new List<Book>();

            try
            {
                connection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand(@"select * from Book inner join BookTransaction on 
                    BookTransaction.Book_ID = Book.Book_ID where BookTransaction.Transaction_ID=@transaction_ID ", connection);
                oleDbCommand.Parameters.Add("@transaction_ID", OleDbType.Integer).Value = transactionID;
                OleDbDataReader reader = oleDbCommand.ExecuteReader();

                while (reader.Read())
                {
                    Book book = BindBook(reader);
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Book>();
            }
            finally
            {
                connection.Close();
            }

            return books;
        }

        private static Book BindBook(OleDbDataReader reader)
        {
            Book book = new Book()
            {
                Title = reader["Title"].ToString(),
                Author = reader["Author"].ToString(),
                Price = Convert.ToDouble(reader["Price"])
            };

            return book;
        }

        private static Transaction BindTransaction(OleDbDataReader reader)
        {
           
           Transaction transaction = new Transaction(
              Convert.ToInt32(reader["Transaction_ID"]),
              Convert.ToInt32(reader["User_ID"]),
              DateTime.Parse(reader["PurchaseDate"].ToString()),
              Convert.ToDouble(reader["TotalCost"]),
              reader["CardNumber"].ToString(),
              (CardType)Enum.Parse(typeof(CardType), reader["CardType"].ToString()),
              DateTime.Parse(reader["ExpirationDate"].ToString()),
              Convert.ToInt32(reader["SecurityCode"]),
              reader["BillingAddress"].ToString(),
              reader["ZIP"].ToString(),
              reader["State"].ToString());
           return transaction;

        }
    }
}
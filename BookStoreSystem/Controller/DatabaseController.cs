using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using static BookStoreSystem.User;
using static BookStoreSystem.Transaction;
using System.Net;
using System.Collections;
using Google.Apis.Books.v1.Data;

namespace BookStoreSystem
{
    public class DatabaseController
    {
        /*************************** Fields ***************************/
        const string connectionString = "provider=Microsoft.ACE.OLEDB.12.0; Data Source=BookStoreDB.accdb;";
        static OleDbConnection myConnection = new OleDbConnection(connectionString);
        static OleDbCommand myCommand = new OleDbCommand(string.Empty, myConnection);
        static OleDbDataAdapter myAdapter = new OleDbDataAdapter(myCommand);

        /************** Overhead Template Methods **********************/
        private static DataSet FillDataSet(string query, string table)
        {
            // Template for filling DataSet with given database table
            myCommand.CommandText = query;
            DataSet dataSet = new DataSet();
            try
            {
                myConnection.Open();
                myAdapter.Fill(dataSet, table);
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
            return dataSet;
        }

        public static void ExecuteCommand(string query)
        {
            // Template for ExecuteNonQuery commands (mostly Add/Modify/Delete functions)
            try
            {
                if (myConnection.State == ConnectionState.Closed) { myConnection.Open(); }
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }

        private static void SetBookParameters(Book book)
        {
            // non-specific book parameters (no ids)
            myCommand.Parameters.Clear();
            myCommand.Parameters.Add("@BookTitle", OleDbType.VarChar).Value = book.Title;
            myCommand.Parameters.Add("@BookAuthor", OleDbType.VarChar).Value = book.Author;
            myCommand.Parameters.Add("@BookGenre", OleDbType.VarChar).Value = book.Genre;
            myCommand.Parameters.Add("@BookDescription", OleDbType.LongVarChar).Value = book.Description;
            myCommand.Parameters.Add("@BookPages", OleDbType.Integer).Value = book.Pages;
            myCommand.Parameters.Add("@BookPrice", OleDbType.Currency).Value = (decimal)book.Price;
            myCommand.Parameters.Add("@BookPublication", OleDbType.VarChar).Value = book.Publication;
            myCommand.Parameters.Add("@BookCoverUrl", OleDbType.VarChar).Value = book.CoverUrl;
        }

        /*************************** Book Methods ***************************/
        public static List<Book> GetBookList()
        {
            // List to hold all Books from Book table
            List<Book> bookList = new List<Book>();

            // Handle data from database
            string query = "SELECT * FROM Book";
            string table = "Book";
            DataSet dataSet = FillDataSet(query, table);
            DataTable tableBooks = dataSet.Tables[table];

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
            /* Add given book to database */
            string query = "INSERT INTO Book (Title, Author, Genre, Description, Pages, Price, Publication, Cover_Url) " +
                "VALUES (@BookTitle, @BookAuthor, @BookGenre, @BookDescription, @BookPages, @BookPrice, @BookPublication, @BookCoverUrl)";
            SetBookParameters(book);
            ExecuteCommand(query);
        }
        public static void ModifyBook(Book book)
        {
            /* Modify given book in database */
            string query = "UPDATE Book SET Title = @BookTitle, Author = @BookAuthor, Genre = @BookGenre, Description = @BookDescription, " +
                "Pages = @BookPages, Price = @BookPrice, Publication = @BookPublication, Cover_Url = @BookCoverUrl WHERE Book_ID = @BookId";
            SetBookParameters(book);
            // NOTE: Order in which OleDB Parameters are added to the Command MATTERS
            // If @BookId is added before the ones in SetBookParameters, errors are thrown
            myCommand.Parameters.Add("@BookId", OleDbType.Integer).Value = book.Id;
            ExecuteCommand(query);   
        }
        public static void DeleteBook(int bookId)
        {
            /* Delete book given by book id from database */
            string query = "DELETE FROM Book WHERE Book_ID = @BookId";
            myCommand.Parameters.Clear();
            myCommand.Parameters.Add("@BookId", OleDbType.Integer).Value = bookId;
            ExecuteCommand(query);
        }
        public static string GetBookTitle(int bookId)
        {
            // Gets Book Title from Database by ID
            string query = "SELECT Title FROM Book WHERE Book_ID = @BookId";
            string tableString = "Book";

            myCommand.Parameters.Clear();
            myCommand.Parameters.Add("@BookId", OleDbType.Integer).Value = bookId;

            DataSet dataSet = FillDataSet(query, tableString);

            DataTable table = dataSet.Tables[tableString];
            DataRow row = table.Rows[0];
            return row["Title"].ToString();
        }

        /**************************** Review Methods *****************************************/
        public static List<Review> GetReviewList(int bookId)
        {
            /* Gets all Books from Book table in database */
            List<Review> reviewList = new List<Review>();
            string query = "SELECT * FROM Review WHERE Book_ID = @BookId";
            string tableString = "Review";
            myCommand.Parameters.Clear();
            myCommand.Parameters.Add("@BookId", OleDbType.Integer).Value = bookId;

            DataSet dataSet = FillDataSet(query, tableString);

            // Handle data from database
            DataTable table = dataSet.Tables[tableString];
            foreach (DataRow row in table.Rows)
            {
                // Create review and add to list
                int.TryParse(row["Review_ID"].ToString(), out int reviewId);
                Review newReview = new Review(row["User_ID"].ToString(), row["Book_ID"].ToString())
                {
                    Id = reviewId,
                    Description = row["Description"].ToString(),
                    SubmissionDateTime = row["Submission_DateTime"].ToString(),
                    LastEditDateTime = row["LastEdit_DateTime"].ToString(),
                };
                newReview.SetRatings(row["Style_Rating"].ToString(), row["Plot_Rating"].ToString(), row["Character_Rating"].ToString());
                reviewList.Add(newReview);
            }
            return reviewList;
        }
        public static void AddReview(Review review)
        {
            /* Add given Review to database */
            string query = "INSERT INTO Review (User_ID, Book_ID, Description, Style_Rating, Plot_Rating, Character_Rating, Submission_DateTime) " +
                "VALUES (@UserId, @BookId, @ReviewDescription, @ReviewStyle, @ReviewPlot, @ReviewCharacter, @ReviewSubmission)";
            myCommand.Parameters.Clear();
            myCommand.Parameters.Add("@UserId", OleDbType.Integer).Value = review.UserId;
            myCommand.Parameters.Add("@BookId", OleDbType.Integer).Value = review.BookId;
            myCommand.Parameters.Add("@ReviewDescription", OleDbType.LongVarChar).Value = review.Description;
            myCommand.Parameters.Add("@ReviewStyle", OleDbType.Integer).Value = review.StyleRating;
            myCommand.Parameters.Add("@ReviewPlot", OleDbType.Integer).Value = review.PlotRating;
            myCommand.Parameters.Add("@ReviewCharacter", OleDbType.Integer).Value = review.CharacterRating;
            myCommand.Parameters.Add("@ReviewSubmission", OleDbType.VarChar).Value = review.SubmissionDateTime;
            ExecuteCommand(query);
        }
        public static void ModifyReview(Review review)
        {
            /* Modify given Review in database */
            string query = "UPDATE Review SET Description = @ReviewDescription, Style_Rating = @ReviewStyle, " +
                "Plot_Rating = @ReviewPlot, Character_Rating = @ReviewCharacter, LastEdit_DateTime = @ReviewLastEdit " +
                "WHERE Review_ID = @ReviewId";
            myCommand.Parameters.Clear();
            myCommand.Parameters.Add("@ReviewDescription", OleDbType.LongVarChar).Value = review.Description;
            myCommand.Parameters.Add("@ReviewStyle", OleDbType.Integer).Value = review.StyleRating;
            myCommand.Parameters.Add("@ReviewPlot", OleDbType.Integer).Value = review.PlotRating;
            myCommand.Parameters.Add("@ReviewCharacter", OleDbType.Integer).Value = review.CharacterRating;
            myCommand.Parameters.Add("@ReviewLastEdit", OleDbType.VarChar).Value = review.LastEditDateTime;
            myCommand.Parameters.Add("@ReviewId", OleDbType.Integer).Value = review.Id;
            ExecuteCommand(query);
        }
        public static void DeleteReview(int reviewId)
        {
            /* Delete review given by review id from database */
            string query = "DELETE FROM Review WHERE Review_ID = @ReviewId";
            myCommand.Parameters.Clear();
            myCommand.Parameters.Add("@ReviewId", OleDbType.Integer).Value = reviewId;
            ExecuteCommand(query);
        }

        public static Review GetReview(int reviewId)
        {
            /* Get Review using review Id */
            string query = "SELECT * FROM Review WHERE Review_ID = @ReviewId";
            string tableString = "Review";
            myCommand.Parameters.Clear();
            myCommand.Parameters.Add("@ReviewId", OleDbType.Integer).Value = reviewId;
            DataSet dataSet = FillDataSet(query, tableString);
            

            // Handle data from database
            DataTable table = dataSet.Tables[tableString];
            DataRow row = table.Rows[0];
            // Create review
            Review newReview = new Review(row["User_ID"].ToString(), row["Book_ID"].ToString())
            {
                Id = reviewId,
                Description = row["Description"].ToString(),
                SubmissionDateTime = row["Submission_DateTime"].ToString(),
                LastEditDateTime = row["LastEdit_DateTime"].ToString(),
            };
            newReview.SetRatings(row["Style_Rating"].ToString(), row["Plot_Rating"].ToString(), row["Character_Rating"].ToString());
            return newReview;
        }

        public static double[] AverageRatings(int bookId)
        {
            /* Returns an array of average ratings for a given book id
               [0] = Style, [1] = Plot, [2] = Character */
            string query = "SELECT AVG(Style_Rating), AVG(Plot_Rating), AVG(Character_Rating) FROM Review WHERE Book_ID = @BookId";
            string tableString = "Review";
            myCommand.Parameters.Clear();
            myCommand.Parameters.Add("@BookId", OleDbType.Integer).Value = bookId;
            DataSet dataSet = FillDataSet(query, tableString);

            // Handle data from database
            DataRow row = dataSet.Tables[tableString].Rows[0];
            double[] averages = new double[3] { 0, 0, 0 };
            double.TryParse(row[0].ToString(), out averages[0]);
            double.TryParse(row[1].ToString(), out averages[1]);
            double.TryParse(row[2].ToString(), out averages[2]);

            return averages;
        }

        /**************************** User Methods *******************************************/

        public static bool UpdateUser(User selectedUser)
        {
            OleDbConnection conn = new OleDbConnection(connectionString);

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(@"update [User] set
                                                [Username] = @Username, [Password] = @Password, Account_Type = @AccountType
                                                where User_ID=@UserID", conn);
                cmd.Parameters.Add("@Username", OleDbType.VarChar).Value = selectedUser.UserName;
                cmd.Parameters.Add("@Password", OleDbType.VarChar).Value = selectedUser.Password;
                cmd.Parameters.Add("@AccountType", OleDbType.VarChar).Value = selectedUser.AccountType1;
                cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = selectedUser.UserID;
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public static bool DeleteUser(int userID)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connectionString;

            OleDbCommand cmd = new OleDbCommand(@"Delete from [User] where User_ID=@UserID");

            conn.Open();
            cmd.Connection = conn;

            if(conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add(@"UserID", OleDbType.Integer).Value = userID;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return true;
        }


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
                    User user = BindUser(reader);
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

        private static User BindUser(OleDbDataReader reader)
        {
            return new User(
                int.Parse(reader["User_ID"].ToString()),
                reader["Username"].ToString(),
                reader["Password"].ToString(),
                (AccountType)Enum.Parse(typeof(AccountType), reader["Account_Type"].ToString())
                );
        }

        public static List<User> GetAllUsers()
        {
            OleDbConnection conn = null;
            List<User> users = new List<User>();
            try
            {
                conn = new OleDbConnection(connectionString);
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("Select * From [User] ", conn);
              
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = BindUser(reader);
                    users.Add(user);
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
            return users;
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

        public static string GetUsername(int userId)
        {
            // Gets Username from Database by user id
            string query = "SELECT [Username] FROM [User] WHERE [User_ID] = " + userId.ToString();
            string tableString = "User";
            DataSet dataSet = FillDataSet(query, tableString);

            DataTable table = dataSet.Tables[tableString];
            if (table.Rows.Count > 0) 
            { 
                DataRow row = table.Rows[0];
                return row["Username"].ToString();
            }
            else { return string.Empty; }
        }

        /**************************** Transaction Methods *****************************************/


        public static bool CreateTransaction(Transaction transaction)
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
                        return false;
                   }
               }
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
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
                Price = Convert.ToDouble(reader["Price"]),
                CoverUrl = reader["Cover_URL"].ToString()
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
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using static BookStoreSystem.User;
using System.Net;
using System.Collections;

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
            try
            {
                myConnection.Open();
                myCommand.CommandText = string.Format("INSERT INTO Book (Title, Author, Genre, Description, Pages, " +
                    "Price, Publication, Cover_Url) VALUES ('{0}', '{1}', '{2}', '{3}', {4}, {5}, '{6}', '{7}')",
                    book.Title, book.Author, book.Genre, book.Description, book.Pages, book.Price, book.Publication, book.CoverUrl);
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
                myCommand.CommandText = string.Format("UPDATE Book SET Title = '{1}', Author = '{2}', Genre = '{3}', " +
                    "Description = '{4}', Pages = {5}, Price = {6}, Publication = '{7}', Cover_Url = '{8}' WHERE Book_ID = {0}",
                    book.Id, book.Title, book.Author, book.Genre, book.Description, book.Pages, book.Price, book.Publication, book.CoverUrl);
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
            try
            {
                myConnection.Open();
                myCommand.CommandText = string.Format("INSERT INTO Review (User_ID, Book_ID, Description, Style_Rating, " +
                    "Plot_Rating, Character_Rating, Submission_DateTime) " +
                    "VALUES ({0}, {1}, '{2}', {3}, {4}, {5}, '{6}')",
                    review.UserId, review.BookId, review.Description, review.StyleRating, review.PlotRating, review.CharacterRating,
                    review.SubmissionDateTime);
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }
        public static void ModifyReview(Review review)
        {
            try
            {
                myConnection.Open();
                myCommand.CommandText = string.Format("UPDATE Review SET Description = '{1}', " +
                    "Style_Rating = {2}, Plot_Rating = {3}, Character_Rating = {4}, LastEdit_DateTime = '{5}' WHERE Review_ID = {0}",
                    review.Id, review.Description, review.StyleRating, review.PlotRating, review.CharacterRating, review.LastEditDateTime);
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }
        public static void DeleteReview(int reviewId)
        {
            try
            {
                myConnection.Open();
                myCommand.CommandText = "DELETE FROM Review WHERE Review_ID = " + reviewId;
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }

        public static Review GetReview(int reviewId)
        {
            DataSet dataSet = new DataSet();
            myCommand.CommandText = "SELECT * FROM Review WHERE Review_ID = " + reviewId.ToString();
            try
            {
                myConnection.Open();
                myAdapter.Fill(dataSet, "Review");
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            // Handle data from database
            DataTable table = dataSet.Tables["Review"];
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
            // Returns an array of average ratings
            // [0] = Style, [1] = Plot, [2] = Character
            DataSet dataSet = new DataSet();
            myCommand.CommandText = "SELECT AVG(Style_Rating), AVG(Plot_Rating), AVG(Character_Rating) FROM Review WHERE Book_ID = " + bookId.ToString();
            try
            {
                myConnection.Open();
                myAdapter.Fill(dataSet, "Review");
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            // Handle data from database
            DataRow row = dataSet.Tables["Review"].Rows[0];
            double[] averages = new double[3] { 0, 0, 0 };
            double.TryParse(row[0].ToString(), out averages[0]);
            double.TryParse(row[1].ToString(), out averages[1]);
            double.TryParse(row[2].ToString(), out averages[2]);

            return averages;
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

        public static string GetUsername(int id)
        {
            // Gets Username from Database by ID
            myCommand.CommandText = "SELECT [Username] FROM [User] WHERE [User_ID] = " + id.ToString();
            DataSet dataSet = new DataSet();
            try
            {
                myConnection.Open();
                myAdapter.Fill(dataSet, "User");
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            DataTable table = dataSet.Tables["User"];
            DataRow row = table.Rows[0];
            return row["Username"].ToString();
        }
    }
}
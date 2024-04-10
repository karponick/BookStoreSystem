using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreSystem
{
    public class DatabaseController
    {
        // fields
        readonly OleDbConnection myConnection;
        readonly OleDbCommand myCommand;
        readonly OleDbDataAdapter myAdapter;
        DataSet dataSet;

        // constructor
        public DatabaseController()
        {
            // Initialize Database connection stuff
            string strConnection = "provider=Microsoft.ACE.OLEDB.12.0;" +
                        "Data Source=BookStoreDB.accdb;";
            myConnection = new OleDbConnection(strConnection);
            myCommand = new OleDbCommand(string.Empty, myConnection);
            myAdapter = new OleDbDataAdapter(myCommand);
        }

        //Methods
        public void PrintColHeaders(DataTable table)
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
                    Publication = DateTime.Parse(row["Publication"].ToString())
                };
                bookList.Add(newBook);
            }
            return bookList;
        }

        public void AddBook(Book book)
        {
            try
            {
                myConnection.Open();
                // Append changes to SQL string
                List<string> changes = new List<string>();
                myCommand.CommandText = "INSERT INTO Book VALUES ('" + string.Join("','", book.ToArray()) + "')";
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
                // Append changes to SQL string
                List<string> changes = new List<string>();
                myCommand.CommandText = "DELETE FROM Book WHERE Book_ID = " + bookId;
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }
    }
}

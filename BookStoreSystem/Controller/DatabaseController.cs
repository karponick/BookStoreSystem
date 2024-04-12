using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStoreSystem.User;

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
    }
}
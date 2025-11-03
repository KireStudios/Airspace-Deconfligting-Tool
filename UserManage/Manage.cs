using System;
using System.Collections.Generic;
using System.Data;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace UserManage
{
    public class Manage
    {
        private SQLiteConnection cnx;

        public void Iniciar()
        {
            string relativePath = Path.Combine("..", "..", "..", "users.db");
            string dbPath = Path.GetFullPath(relativePath);
            string dataSource = $"Data Source={dbPath}";
            cnx = new SQLiteConnection(dataSource);
            cnx.Open();
        }
        public void Cerrar()
        {
            cnx.Close();
        }
        public DataTable GetUsers()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM users";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;
        }
        public string GetHashedPassword(string username)
        {
            string sql = "SELECT password FROM users WHERE username = @user";
            using (SQLiteCommand command = new SQLiteCommand(sql, cnx))
            {
                command.Parameters.AddWithValue("@user", username);
                object result = command.ExecuteScalar();
                return result?.ToString();
            }
        }
        public bool CreateUser(string username, string password)
        {
            try
            {
                string sql = "INSERT INTO users (username, password) VALUES (@user, @pass)";

                using (SQLiteCommand command = new SQLiteCommand(sql, cnx))
                {
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@pass", password);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SQLiteException ex)
            {
                if (ex.ErrorCode == SQLiteErrorCode.Constraint) // Usuario tiene que ser único
                {
                    return false;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

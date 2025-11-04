using System;
using System.Data;
using System.Data.SQLite;
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

            CreateTableIfNotExists();

            EnsureAdminUser("admin", "1234");
        }

        private void CreateTableIfNotExists()
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS users (
                    id INTEGER PRIMARY KEY,
                    username TEXT NOT NULL UNIQUE,
                    password TEXT NOT NULL
                );";

            using (SQLiteCommand command = new SQLiteCommand(sql, cnx))
            {
                command.ExecuteNonQuery();
            }
        }

        private void EnsureAdminUser(string username, string password)
        {
            // Primero, comprueba si el usuario 'admin' ya existe
            string checkSql = "SELECT COUNT(*) FROM users WHERE username = @user";
            using (SQLiteCommand checkCommand = new SQLiteCommand(checkSql, cnx))
            {
                checkCommand.Parameters.AddWithValue("@user", username);
                long count = (long)checkCommand.ExecuteScalar();

                if (count == 0)
                {
                    CreateUser(username, password);
                }
            }
        }

        public void Cerrar()
        {
            if (cnx != null && cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
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
                if (ex.ErrorCode == SQLiteErrorCode.Constraint)
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
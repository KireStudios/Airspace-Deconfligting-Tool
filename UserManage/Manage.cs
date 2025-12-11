using System;
using System.Data;
using System.Data.Sql;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace UserManage
{
    public class Manage
    {
        private SQLiteConnection cnx;

        public void Iniciar()
        {
            // Ho canvio al appdata, aixi esta "amagat" (i mes segur?, pq no estan encriptats, no?) i no es pujen ni comparteixen els usuaris
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbFolder = Path.Combine(appData, "AirspaceDeconflictingTool");
            Directory.CreateDirectory(dbFolder);
            string dbPath = Path.Combine(dbFolder, "database.db");
            string dataSource = $"Data Source={dbPath}";
            cnx = new SQLiteConnection(dataSource);
            cnx.Open();

            CreateTableIfNotExists();

            EnsureAdminUser("admin", "1234", "alex.sanz.rautiainen@estudiantat.upc.edu");
        }

        private void CreateTableIfNotExists()
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS users (
                    id INTEGER PRIMARY KEY,
                    username TEXT NOT NULL UNIQUE,
                    password TEXT NOT NULL,
                    mail TEXT NOT NULL
                );";

            using (SQLiteCommand command = new SQLiteCommand(sql, cnx))
            {
                command.ExecuteNonQuery();
            }
            
            sql = @"
                CREATE TABLE IF NOT EXISTS companies (
                    name TEXT NOT NULL UNIQUE PRIMARY KEY,
                    telephone TEXT NOT NULL,
                    mail TEXT NOT NULL
                );";

            using (SQLiteCommand command = new SQLiteCommand(sql, cnx))
            {
                command.ExecuteNonQuery();
            }
        }

        private void EnsureAdminUser(string username, string password, string mail)
        {
            // Primero, comprueba si el usuario 'admin' ya existe
            string checkSql = "SELECT COUNT(*) FROM users WHERE username = @user";
            using (SQLiteCommand checkCommand = new SQLiteCommand(checkSql, cnx))
            {
                checkCommand.Parameters.AddWithValue("@user", username);
                long count = (long)checkCommand.ExecuteScalar();

                if (count == 0)
                {
                    CreateUser(username, password, mail);
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
        public string GetEmail(string username)
        {
            string sql = "SELECT mail FROM users WHERE username = @user";
            using (SQLiteCommand command = new SQLiteCommand(sql, cnx))
            {
                command.Parameters.AddWithValue("@user", username);
                object result = command.ExecuteScalar();
                return result?.ToString();
            }
        }

        public bool CreateUser(string username, string password, string mail)
        {
            try
            {
                string sql = "INSERT INTO users (username, password, mail) VALUES (@user, @pass, @mail)";

                using (SQLiteCommand command = new SQLiteCommand(sql, cnx))
                {
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@pass", password);
                    command.Parameters.AddWithValue("@mail", mail);

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

        public static void SendRecoverEmail(Manage manageInstance, string username)
        {
            string smtpServer = "smtp.gmail.com";
            int port = 587;
            string fromEmail = "fracs3cuenta@gmail.com";
            string password = "noymackvcprnuidf";

            try
            {
                string toEmail = manageInstance.GetEmail(username);
                string body = "Password of " + username + " is " + manageInstance.GetHashedPassword(username);
                using (MailMessage mail = new MailMessage(fromEmail, toEmail, "Recover Password", body))
                using (SmtpClient client = new SmtpClient(smtpServer, port))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(fromEmail, password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Timeout = 10000; // ms

                    client.Send(mail);
                    Console.WriteLine("Correo enviado exitosamente a: " + toEmail);
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"Error de SMTP al enviar correo: {ex.StatusCode} - {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al enviar el correo: " + ex.Message);
                throw;
            }
        }
        
        public void GetContactInfo(string companyName, out string telephone, out string email)
        {
            string sql = "SELECT telephone, mail FROM companies WHERE name = @name";
            using (SQLiteCommand command = new SQLiteCommand(sql, cnx))
            {
                command.Parameters.AddWithValue("@name", companyName);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        telephone = reader["telephone"].ToString();
                        email = reader["mail"].ToString();
                    }
                    else
                    {
                        telephone = null;
                        email = null;
                    }
                }
            }
        }
    }
}
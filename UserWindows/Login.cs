using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManage;
using WindowsPrincipal;

namespace UserWindows
{
    public partial class Login : Form
    {
        Manage user_base = new Manage();
        
        // Per arrosegar el formulari
        //[DllImport("user32.dll")]
        //public static extern bool ReleaseCapture();

        //[DllImport("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        
        public Login()
        {
            InitializeComponent();
            
            // Per arrosegar el formulari
            this.MouseDown += Form1_MouseDown;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            user_base.Iniciar();
        }
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            CreateAccount create = new CreateAccount(user_base);
            create.ShowDialog();
            if (create.IsCreated())
            {
                MessageBox.Show("Ahora inicia sesión");
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string user = userBox.Text.Trim();
                string enteredPassword = keyBox.Text;

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(enteredPassword))
                {
                    MessageBox.Show("Por favor, ingrese un usuario y contraseña.");
                    return;
                }

                string storedHash = user_base.GetHashedPassword(user);

                if (storedHash != null)
                {
                    if (enteredPassword == storedHash)
                    {
                        MessageBox.Show("¡Login exitoso! Bienvenido/a.");
                        Hide();
                        new Main().ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error de formato en la entrada de datos.");
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        // Perque es pugui arrosegar el formulari
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }
}
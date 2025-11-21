using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManage;
using WindowsPrincipal;

namespace UserWindows
{
    public partial class CreateAccount : Form
    {
        Manage user_base = new Manage();
        bool created = false;
        public CreateAccount(Manage user_base)
        {
            this.user_base = user_base;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = userBox.Text.Trim();
            string pass1 = keyBox1.Text;
            string pass2 = keyBox2.Text;
            string mail = mailBox.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass1) || string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("El usuario y la contraseña no pueden estar vacíos.");
                return;
            }
            else if (pass1 != pass2)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                keyBox1.Clear();
                keyBox2.Clear();
            }
            else
            {
                bool success = user_base.CreateUser(user, pass1, mail);

                if (success)
                {
                    MessageBox.Show($"Usuario '{user}' creado exitosamente.");
                    created = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al crear la cuenta. El usuario puede ya existir.");
                    keyBox1.Clear();
                    keyBox2.Clear();
                    userBox.Clear();
                }
            }
        }
        public bool IsCreated() { return created; }
    }
}

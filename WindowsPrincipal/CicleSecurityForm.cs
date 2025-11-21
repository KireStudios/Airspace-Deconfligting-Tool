using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using FlightLib;
namespace WindowsPrincipal
{
    // Formulari per a afegir cicles i distància de seguretat
    public partial class CicleSecurityForm : Form
    {
        //Variables per a guardar els valors dels TextBox
        int cicles;
        double securityDistance;
        Random generator = new Random();
        
        // Per arrosegar el formulari
        //[DllImport("user32.dll")]
        //public static extern bool ReleaseCapture();

        //[DllImport("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        // Constructor del formulari
        public CicleSecurityForm(int cicles, double securityDistance)
        {
            InitializeComponent();
            
            this.cicles = cicles;
            this.securityDistance = securityDistance;
            
            // Per arrosegar el formulari
            this.MouseDown += Form1_MouseDown;
            
            // Perquè estigui sempre a dalt (es pot posar una opció a les opcions o algo així)
            //this.TopMost = true;
        }

        //Agafar els valors dels TextBox i guardar-los a les variables
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CicleTextBox.Text != "")
                {
                    cicles = Convert.ToInt32(CicleTextBox.Text);
                }

                if (SecurityTextBox.Text != "")
                {
                    securityDistance = Convert.ToDouble(SecurityTextBox.Text);
                }

                CicleTextBox.Text = null;
                SecurityTextBox.Text = null;
                MessageBox.Show("Cicle and security distance added correctly!!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Format error! Check what you wrote.");
            }
        }

        //Tancar el formulari
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Per traspassar les dades de Cicle i SecurityDistance al Main
        public int GetCicles()
        {
            return cicles;
        }
        public double GetSecurityDistance()
        {
            return securityDistance;
        }

        //Carregar el formulari
        private void CicleSecurityForm_Load(object sender, EventArgs e)
        {

        }

        //Omplir automàticament els camps amb valors aleatoris
        private void fillAuto_Click(object sender, EventArgs e)
        {
            cicles = generator.Next(10, 100);
            securityDistance = generator.Next(15, 30);
            CicleTextBox.Text = Convert.ToString(cicles);
            SecurityTextBox.Text = Convert.ToString(securityDistance);
        }

        // Per arrosegar el formulari
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }
}

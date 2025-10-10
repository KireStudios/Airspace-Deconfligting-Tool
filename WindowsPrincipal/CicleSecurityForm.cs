using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FlightLib;
namespace WindowsPrincipal
{
    public partial class CicleSecurityForm : Form
    {
        //Variables per a guardar els valors dels TextBox
        int cicles;
        double securityDistance;
        Random generator = new Random();
        public CicleSecurityForm()
        {
            InitializeComponent();
        }

        //Agafar els valors dels TextBox i guardar-los a les variables
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                cicles = Convert.ToInt32(CicleTextBox.Text);
                securityDistance = Convert.ToDouble(SecurityTextBox.Text);
                CicleTextBox.Text = null;
                SecurityTextBox.Text = null;
                MessageBox.Show("Cicle and security distance added correctly!!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Format error! Check what you wrote.");
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Per a traspassar les dades de Cicle i SecurityDistance al Main
        public int GetCicles()
        {
            return cicles;
        }
        public double GetSecurityDistance()
        {
            return securityDistance;
        }

        private void CicleSecurityForm_Load(object sender, EventArgs e)
        {

        }
        private void fillAuto_Click(object sender, EventArgs e)
        {
            cicles = generator.Next(10, 100);
            securityDistance = generator.Next(5, 30);
            CicleTextBox.Text = Convert.ToString(cicles);
            SecurityTextBox.Text = Convert.ToString(securityDistance);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FlightLib;

namespace WindowsPrincipal
{
    public partial class PlaneDataForm : Form
    {
        FlightPlanList FlightsList = new FlightPlanList();
        public PlaneDataForm()
        {
            InitializeComponent();
        }

        public void PlaneDataForm_Load(object sender, EventArgs e)
        {
           
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddFlightPlanButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = IdentificationTextBox.Text;
                double speed = Convert.ToDouble(SpeedTextBox.Text);
                string[] initialPosition = InitialPositionTextBox.Text.Split(' ');
                string[] finalPosition = FinalPositionTextBox.Text.Split(' ');
                double initialX = Convert.ToDouble(initialPosition[0]);
                double initialY = Convert.ToDouble(initialPosition[1]);
                double finalX = Convert.ToDouble(finalPosition[0]);
                double finalY = Convert.ToDouble(finalPosition[1]);
                FlightPlan plan = new FlightPlan(id, initialX, initialY, finalX, finalY, speed);
                FlightsList.AddFlightPlan(plan);
                
                IdentificationTextBox.Text = null;
                SpeedTextBox.Text = null;  
                InitialPositionTextBox.Text = null;
                FinalPositionTextBox.Text = null;
            }
            catch (FormatException)
            {
                MessageBox.Show("Format error! Check what you wrote.");
            }
        }
        public FlightPlanList GetFlightPlanList()
        {
            return FlightsList;
        }
    }
}

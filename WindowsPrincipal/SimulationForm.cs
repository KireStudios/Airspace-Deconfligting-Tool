using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsPrincipal
{
    public partial class SimulationForm : Form
    {
        // Variables per a guardar que venen del principal
        FlightPlanList FlightsList = new FlightPlanList();
        int OriginalCicles;
        int cicles;
        double securityDistance;
        public SimulationForm()
        {
            InitializeComponent();
        }

        // Recuperem les dades del Main
        public void GetFlightPlanListSimulation(FlightPlanList list)
        {
            FlightsList = list;
        }
        public void GetCiclesSimulation(int c)
        {
            OriginalCicles = c;
            cicles = OriginalCicles;
        }
        public void GetSecurityDistanceSimulation(double d)
        {
            securityDistance = d;
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < FlightsList.GetNumeroFlightPlans(); i++)
            {
                PictureBox plane = new PictureBox();
                string path = Path.Combine(Application.StartupPath, "avion.jpg");
                Bitmap image = new Bitmap(path);
                plane.Tag = FlightsList.GetFlightPlan(i).GetId();
                plane.Image = (Image)image;
                plane.SizeMode = PictureBoxSizeMode.StretchImage;
                plane.Location = new Point(Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetX()), Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetY()));
                SimulationPanel.Controls.Add(plane);
                plane.Click += new System.EventHandler(SeePlaneData);
            }
        }

        private void SeePlaneData(object sender, EventArgs e)
        {
            PictureBox plane = (PictureBox)sender;
            FlightPlan selectedFlightPlan = null;

            for (int i = 0; i < FlightsList.GetNumeroFlightPlans(); i++)
            {
                if (FlightsList.GetFlightPlan(i).GetId() == Convert.ToString(plane.Tag))
                {
                    selectedFlightPlan = FlightsList.GetFlightPlan(i);
                    break;
                }
            }
            SeePlaneDataOnClickForm SeePlaneDataForm = new SeePlaneDataOnClickForm();
            SeePlaneDataForm.GetFlightPlan(selectedFlightPlan);
            SeePlaneDataForm.ShowDialog();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cicles > 0)
            {
                FlightsList.Moure(10);
                for (int i = 0; i < FlightsList.GetNumeroFlightPlans(); i++)
                {
                    SimulationPanel.Controls[i].Location = new Point(Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetX()), Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetY()));
                }
                cicles--;
            }
            else
            {
                MessageBox.Show("No more cycles left!");
            }
        }

        // Reinicia totes les posicions actuals dels avions a les seves posicions inicials
        private void RestartButton_Click(object sender, EventArgs e)
        {
            cicles = OriginalCicles;
            FlightsList.RestartAll();
            for (int i = 0; i < FlightsList.GetNumeroFlightPlans(); i++)
            {
                SimulationPanel.Controls[i].Location = new Point(Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetX()), Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetY()));
            }
        }
    }
}

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
    public partial class Main : Form
    {
        // Variables per a guardar les dades que venen dels altres formularis
        FlightPlanList FlightsList;
        int cicles;
        double securityDistance;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //CloseButton.Location = new Point(this.ClientSize.Width - CloseButton.Width - 20, this.ClientSize.Height - CloseButton.Height - 20);
            //BienvenidaLabel.Location = new Point((this.ClientSize.Width - BienvenidaLabel.Width) / 2, (this.ClientSize.Height - 2*BienvenidaLabel.Height));
        }

        private void addDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaneDataForm planeForm = new PlaneDataForm();
            planeForm.ShowDialog();
            FlightsList = planeForm.GetFlightPlanList();
        }

        private void addCiclesAndSecurityDistanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CicleSecurityForm CSForm = new CicleSecurityForm();
            CSForm.ShowDialog();
            cicles = CSForm.GetCicles();
            securityDistance = CSForm.GetSecurityDistance();
        }

        private void initializeSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimulationForm SimForm = new SimulationForm();
            SimForm.GetFlightPlanListSimulation(FlightsList);
            SimForm.GetCiclesSimulation(cicles);
            SimForm.GetSecurityDistanceSimulation(securityDistance);
            SimForm.ShowDialog();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFileForm loadForm = new LoadFileForm();
            loadForm.ShowDialog();
            FlightsList = loadForm.GetFlightPlanList();
        }
    }
}

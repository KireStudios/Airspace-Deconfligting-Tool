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

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void initializeSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimulationForm SimForm = new SimulationForm();
            SimForm.GetFlightPlanList(FlightsList);
            SimForm.GetCicles(cicles);
            SimForm.GetSecurityDistance(securityDistance);
            SimForm.ShowDialog();
        }
    }
}

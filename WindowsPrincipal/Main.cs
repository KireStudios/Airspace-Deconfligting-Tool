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
        
        // ---
        // private PlaneDataForm AddPlaneForm;
        // ---
        
        public Main()
        {
            InitializeComponent();
            
            FlightsList = new FlightPlanList();
            cicles = 0;
            securityDistance = 0.0;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //CloseButton.Location = new Point(this.ClientSize.Width - CloseButton.Width - 20, this.ClientSize.Height - CloseButton.Height - 20);
            //BienvenidaLabel.Location = new Point((this.ClientSize.Width - BienvenidaLabel.Width) / 2, (this.ClientSize.Height - 2*BienvenidaLabel.Height));
        }

        private void addDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (AddPlaneForm != null)
            {
                AddPlaneForm.Close();
            }*/

            PlaneDataForm AddPlaneForm = new PlaneDataForm();
            AddPlaneForm.ShowDialog(); //Show(); //Dialog();
            
            /*AddPlaneForm.PlansUpdated += (s, flightPlans) =>
            {
                FlightsList = flightPlans;
            };*/
            FlightsList.AddFlightPlans(AddPlaneForm.GetFlightPlanList());
        }

        private void addCiclesAndSecurityDistanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CicleSecurityForm CSForm = new CicleSecurityForm(cicles, securityDistance);
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

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFileForm loadForm = new LoadFileForm();
            loadForm.ShowDialog();
            FlightsList = loadForm.GetFlightPlanList();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlightsList = new FlightPlanList();
            MessageBox.Show("New simulation created successfully!", "New Simulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            //saveDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveDialog.Title = "Save simulation";
            saveDialog.DefaultExt = "txt";
            saveDialog.FileName = "simulation_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FlightsList.SaveToFile(saveDialog.FileName);
                    MessageBox.Show("Estado de la simulación guardado correctamente en:\n" + saveDialog.FileName,
                        "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }          
        }
    }
}

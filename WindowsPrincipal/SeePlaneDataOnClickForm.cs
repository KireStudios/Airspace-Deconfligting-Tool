using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsPrincipal
{
    public partial class SeePlaneDataOnClickForm : Form
    {
        FlightPlan SelectedFlightPlan;
        
        private double velocitatModificada;

        // Constructor que rep el FlightPlan seleccionat
        public SeePlaneDataOnClickForm(FlightPlan selectedFlightPlan)
        {
            InitializeComponent();
            
            SelectedFlightPlan = selectedFlightPlan;
        }

        // Carregar les dades del FlightPlan seleccionat al DataGridView
        private void SeePlaneDataOnClickForm_Load(object sender, EventArgs e)
        {
            PlaneDataGridView.RowCount = 5;
            PlaneDataGridView.ColumnCount = 2;
            PlaneDataGridView.Rows[0].Cells[0].Value = "Identification";
            PlaneDataGridView.Rows[1].Cells[0].Value = "Companyia";
            PlaneDataGridView.Rows[2].Cells[0].Value = "Speed";
            PlaneDataGridView.Rows[3].Cells[0].Value = "Initial Position";
            PlaneDataGridView.Rows[4].Cells[0].Value = "Final Position";
            PlaneDataGridView.Rows[0].Cells[1].Value = SelectedFlightPlan.GetId();
            PlaneDataGridView.Rows[1].Cells[1].Value = SelectedFlightPlan.GetCompany();
            PlaneDataGridView.Rows[2].Cells[1].Value = SelectedFlightPlan.GetSpeed();
            PlaneDataGridView.Rows[3].Cells[1].Value = "(" + SelectedFlightPlan.GetPosition().GetX().ToString("F3") + ", " + SelectedFlightPlan.GetPosition().GetY().ToString("F3") + ")";
            PlaneDataGridView.Rows[4].Cells[1].Value = "(" + SelectedFlightPlan.GetFinalPosition().GetX() + ", " + SelectedFlightPlan.GetFinalPosition().GetY() + ")";

            // Sol es pot modificar la velocitat (no es pot fer aixi)
            PlaneDataGridView.ReadOnly = false;//true;
            // PlaneDataGridView.Rows[2].Cells[1].ReadOnly = false;
            
            // ja es mira al tancar i sol es canvia la velocitat
        }
              
        public double GetVelocitatModificada()
        {
            return velocitatModificada;
        }

        //Per si es vol canviar la velocitat directament al DataGridView
        private void PlaneDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 2 && e.ColumnIndex == 1)
            {
                //SelectedFlightPlan.SetSpeed(Convert.ToDouble(PlaneDataGridView.Rows[2].Cells[1].Value));
                velocitatModificada = PlaneDataGridView.Rows[2].Cells[1].Value != null
                    ? Convert.ToDouble(PlaneDataGridView.Rows[2].Cells[1].Value)
                    : SelectedFlightPlan.GetSpeed();
            }
        }
    }
}

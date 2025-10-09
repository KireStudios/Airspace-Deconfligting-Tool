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

        public SeePlaneDataOnClickForm()
        {
            InitializeComponent();
        }

        private void SeePlaneDataOnClickForm_Load(object sender, EventArgs e)
        {
            PlaneDataGridView.RowCount = 4;
            //PlaneDataGridView.RowTemplate.Height = 200;
            PlaneDataGridView.ColumnCount = 2;
            PlaneDataGridView.Rows[0].Cells[0].Value = "Identification";
            PlaneDataGridView.Rows[1].Cells[0].Value = "Speed";
            PlaneDataGridView.Rows[2].Cells[0].Value = "Initial Position";
            PlaneDataGridView.Rows[3].Cells[0].Value = "Final Position";
            PlaneDataGridView.Rows[0].Cells[1].Value = SelectedFlightPlan.GetId();
            PlaneDataGridView.Rows[1].Cells[1].Value = SelectedFlightPlan.GetSpeed();
            PlaneDataGridView.Rows[2].Cells[1].Value = "(" + SelectedFlightPlan.GetPosition().GetX().ToString("F3") + ", " + SelectedFlightPlan.GetPosition().GetY().ToString("F3") + ")";
            PlaneDataGridView.Rows[3].Cells[1].Value = "(" + SelectedFlightPlan.GetFinalPosition().GetX() + ", " + SelectedFlightPlan.GetFinalPosition().GetY() + ")";
        }

        public void GetFlightPlan(FlightPlan SelectedFlightPlan)
        {
            this.SelectedFlightPlan = SelectedFlightPlan;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

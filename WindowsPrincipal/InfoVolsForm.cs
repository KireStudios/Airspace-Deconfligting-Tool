using FlightLib;
using System;
using System.Windows.Forms;

namespace WindowsPrincipal
{
    public partial class InfoVolsForm : Form
    {
        private FlightPlanList llistaVols;
        
        public InfoVolsForm(FlightPlanList llistaVols)
        {
            InitializeComponent();
            this.llistaVols = llistaVols;
        }
        
        private void InfoVolsForm_Load(object sender, EventArgs e)
        {
            VolsDataGridView.RowCount = llistaVols.GetNumeroFlightPlans();
            VolsDataGridView.ColumnCount = 5;
            VolsDataGridView.Columns[0].Name = "ID";
            VolsDataGridView.Columns[1].Name = "Velocitat";
            VolsDataGridView.Columns[2].Name = "Posició inicial";
            VolsDataGridView.Columns[3].Name = "Posició actual";
            VolsDataGridView.Columns[4].Name = "Posició final";
            
            for (int i = 0; i < llistaVols.GetNumeroFlightPlans(); i++)
            {
                FlightPlan fp = llistaVols.GetFlightPlan(i);
                VolsDataGridView.Rows[i].Cells[0].Value = fp.id;
                VolsDataGridView.Rows[i].Cells[1].Value = fp.GetSpeed().ToString("F2");
                VolsDataGridView.Rows[i].Cells[2].Value = $"{fp.GetInitialPosition().GetX().ToString()}, {fp.GetInitialPosition().GetY().ToString()}";
                VolsDataGridView.Rows[i].Cells[3].Value = $"{fp.GetPosition().GetX().ToString()}, {fp.GetPosition().GetY().ToString()}";
                VolsDataGridView.Rows[i].Cells[4].Value = $"{fp.GetFinalPosition().GetX().ToString()}, {fp.GetFinalPosition().GetY().ToString()}";
            }
            
            VolsDataGridView.ReadOnly = true;
            VolsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            VolsDataGridView.CellClick += VolsDataGridView_CellClick;
        }

        private void VolsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < llistaVols.GetNumeroFlightPlans())
            {
                FlightPlan pv = llistaVols.GetFlightPlan(e.RowIndex);
                // Distancia amb un altre vol (per exemple, el seguent vol de la llista)
                if (llistaVols.GetNumeroFlightPlans() > 1)
                {
                    FlightPlan seguentPv =
                        llistaVols.GetFlightPlan((e.RowIndex + 1) % llistaVols.GetNumeroFlightPlans());
                    double distancia = pv.Distancia(seguentPv);
                    MessageBox.Show($"Distància mínima al vol {seguentPv.id}: {distancia:F2} unitats", 
                        "Distància entre vols", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
using FlightLib;
using System;
using System.Windows.Forms;

namespace WindowsPrincipal
{
    // Formulari per a mostrar la informació dels vols
    public partial class InfoVolsForm : Form
    {
        private FlightPlanList llistaVols;

        private FlightPlan p1;
        private FlightPlan p2;
        bool Selecting1 = false;
        bool Selecting2 = false;
        private bool actiu = false; // Indica si hi ha vols carregats i es pot seleccionar

        // Constructor del formulari
        public InfoVolsForm(FlightPlanList llistaVols)
        {
            InitializeComponent();
            this.llistaVols = llistaVols;
        }

        // Carregar la informació dels vols al DataGridView
        private void InfoVolsForm_Load(object sender, EventArgs e)
        {
            // Comprova si hi ha vols disponibles
            if (llistaVols.GetNumeroFlightPlans() == 0)
            {
                VolsDataGridView.RowCount = 1;
            }
            else
            {
                VolsDataGridView.RowCount = llistaVols.GetNumeroFlightPlans();
                actiu = true;
            }

            // Definició de les columnes
            VolsDataGridView.ColumnCount = 6;
            VolsDataGridView.Columns[0].Name = "ID";
            VolsDataGridView.Columns[1].Name = "Company";
            VolsDataGridView.Columns[2].Name = "Velocity";
            VolsDataGridView.Columns[3].Name = "Initial position";
            VolsDataGridView.Columns[4].Name = "Actual position";
            VolsDataGridView.Columns[5].Name = "Final position";
            
            VolsDataGridView.RowHeadersVisible = false;

            // Omplir el DataGridView amb les dades reals
            for (int i = 0; i < llistaVols.GetNumeroFlightPlans(); i++)
            {
                FlightPlan fp = llistaVols.GetFlightPlan(i);
                VolsDataGridView.Rows[i].Cells[0].Value = fp.GetId();
                VolsDataGridView.Rows[i].Cells[1].Value = fp.GetCompany();
                VolsDataGridView.Rows[i].Cells[2].Value = fp.GetSpeed().ToString("F2");
                VolsDataGridView.Rows[i].Cells[3].Value = $"{fp.GetInitialPosition().GetX().ToString()}, {fp.GetInitialPosition().GetY().ToString()}";
                VolsDataGridView.Rows[i].Cells[4].Value = $"{fp.GetPosition().GetX().ToString()}, {fp.GetPosition().GetY().ToString()}";
                VolsDataGridView.Rows[i].Cells[5].Value = $"{fp.GetFinalPosition().GetX().ToString()}, {fp.GetFinalPosition().GetY().ToString()}";
            }

            // Configuració visual
            VolsDataGridView.ReadOnly = true;
            VolsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            VolsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Gestionar els clics a les cel·les
            VolsDataGridView.CellClick += VolsDataGridView_CellClick;
        }

        // Selecciona els vols quan l’usuari fa clic i calcula la distància mínima
        private void VolsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < llistaVols.GetNumeroFlightPlans())
            {
                // Seleccionar el primer vol
                if (Selecting1)
                {
                    p1 = llistaVols.GetFlightPlan(e.RowIndex);
                    Pla1Button.Text = $"Pla 1: {p1.GetId()}";
                    Selecting1 = false;
                }
                // Seleccionar el segon vol
                else if (Selecting2)
                {
                    p2 = llistaVols.GetFlightPlan(e.RowIndex);
                    Pla2Button.Text = $"Pla 2: {p2.GetId()}";
                    Selecting2 = false;
                }

                // Si els dos vols són seleccionats, mostra la distància
                if (p1 != null && p2 != null)
                {
                    double distancia = p1.Distancia(p2);
                    DistanciaLabel.Text =
                        $"Distància mínima entre el vol {p1.GetId()} i el vol {p2.GetId()}: {distancia:F2} unitats";
                }
                else
                {
                    DistanciaLabel.Text = "";
                }
            }
        }

        // Activa la selecció del primer vol quan l’usuari vol assignar Pla 1
        private void Pla1Button_Click(object sender, EventArgs e)
        {
            if (actiu)
            {
                Selecting2 = false;
                Selecting1 = true;
                Pla1Button.Text = "Select plan in the grid";
            }
        }

        // Activa la selecció del segon vol quan l’usuari vol assignar Pla 2
        private void Pla2Button_Click(object sender, EventArgs e)
        {
            if (actiu)
            {
                Selecting1 = false;
                Selecting2 = true;
                Pla2Button.Text = "Select plan in the grid";
            }
        }
    }
}
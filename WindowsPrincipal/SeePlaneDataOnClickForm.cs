using FlightLib;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManage;

namespace WindowsPrincipal
{
    public partial class SeePlaneDataOnClickForm : Form
    {
        FlightPlan SelectedFlightPlan;
        
        private double velocitatModificada;
        
        Manage manage = new Manage();

        // Constructor que rep el FlightPlan seleccionat
        public SeePlaneDataOnClickForm(FlightPlan selectedFlightPlan)
        {
            InitializeComponent();
            
            SelectedFlightPlan = selectedFlightPlan;
        }

        private void CargarLogoCompania(string nombreCompania)
        {
            if (string.IsNullOrWhiteSpace(nombreCompania))
                return;

            // Normalizar el nombre: eliminar espacios y convertir a minúsculas
            string companiaNormalizada = nombreCompania.Replace(" ", "").ToLower();

            // Directorio base de recursos
            string directorioBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources");
            string directorioResources = Path.GetFullPath(directorioBase);

            // Diccionario de compañías válidas con sus nombres de archivo
            Dictionary<string, string> companiasValidas = new Dictionary<string, string>
            {
                { "vueling", "vueling.png" },
                { "iberia", "iberia.png" },
                { "airfrance", "airfrance.png" },
                { "airnostrum", "airnostrum.png" },
                { "aireuropa", "aireuropa.png" },
                { "alitalia", "alitalia.png" },
                { "americanairlines", "americanairlines.png" },
                { "delta", "delta.png" },
                { "aerosur", "aerosur.png" },
                { "spanair", "spanair.png" },
                { "avianca", "avianca.png" },
                { "aircanada", "aircanada.png" },
                { "britishairways", "britishairways.png" },
                { "lufthansa", "lufthansa.png" },
                { "canaryfly", "canaryfly.png" },
                { "airchina", "airchina.png" },
                { "qatarairways", "qatarairways.png" },
                { "singaporeairlines", "singaporeairlines.png" },
                { "emirates", "emirates.png" },
                { "turkishairlines", "turkishairlines.png" },
                { "koreanair", "koreanair.png" },
                { "japanairlines", "japanairlines.png" },
                { "hainanairlines", "hainanairlines.png" },
                { "easyjet", "easyjet.png" },
                { "allegiantair", "allegiantair.png" },
                { "hawaiianairlines", "hawaiianairlines.png" },
                { "airarabia", "airarabia.png" },
                { "finnair", "finnair.png" },
                { "usairways", "usairways.png" },
                { "airnewzealand", "airnewzealand.png" },
                { "etihadairways", "etihadairways.png" },
                { "southwest", "southwest.png" },
                { "jetblue", "jetblue.png" },
                { "evaair", "evaair.png" }
            };

            // Buscar si existe la compañía
            if (companiasValidas.TryGetValue(companiaNormalizada, out string nombreArchivo))
            {
                string rutaLogo = Path.Combine(directorioResources, nombreArchivo);
        
                if (File.Exists(rutaLogo))
                {
                    try
                    {
                        LogoCompaniaPictureBox.Image = Image.FromFile(rutaLogo);
                        LogoCompaniaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        LogoCompaniaPictureBox.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        LogoCompaniaPictureBox.Visible = false;
                    }
                }
                else
                {
                    LogoCompaniaPictureBox.Visible = false;
                }
            }
            else
            {
                LogoCompaniaPictureBox.Visible = false;
            }
        }


        // Carregar les dades del FlightPlan seleccionat al DataGridView
        private void SeePlaneDataOnClickForm_Load(object sender, EventArgs e)
        {
            PlaneDataGridView.RowCount = 5;
            PlaneDataGridView.ColumnCount = 2;
            
            // Deshabilitar ordenación de columnas
            foreach (DataGridViewColumn column in PlaneDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
            PlaneDataGridView.Rows[0].Cells[0].Value = "Identification";
            PlaneDataGridView.Rows[1].Cells[0].Value = "Companyia";
            PlaneDataGridView.Rows[2].Cells[0].Value = "Speed";
            PlaneDataGridView.Rows[3].Cells[0].Value = "Initial Position";
            PlaneDataGridView.Rows[4].Cells[0].Value = "Final Position";
            PlaneDataGridView.Rows[5].Cells[0].Value = "Company Telephone";
            PlaneDataGridView.Rows[6].Cells[0].Value = "Company Email";
            PlaneDataGridView.Rows[0].Cells[1].Value = SelectedFlightPlan.GetId();
            PlaneDataGridView.Rows[1].Cells[1].Value = SelectedFlightPlan.GetCompany();
            PlaneDataGridView.Rows[2].Cells[1].Value = SelectedFlightPlan.GetSpeed().ToString("F2");
            PlaneDataGridView.Rows[3].Cells[1].Value = "(" + SelectedFlightPlan.GetPosition().GetX().ToString("F3") + ", " + SelectedFlightPlan.GetPosition().GetY().ToString("F3") + ")";
            PlaneDataGridView.Rows[4].Cells[1].Value = "(" + SelectedFlightPlan.GetFinalPosition().GetX() + ", " + SelectedFlightPlan.GetFinalPosition().GetY() + ")";
            
            manage.GetContactInfo(SelectedFlightPlan.GetCompany(), out string tel, out string mail);
            PlaneDataGridView.Rows[5].Cells[1].Value = tel;
            PlaneDataGridView.Rows[6].Cells[1].Value = mail;
            
            PlaneDataGridView.ReadOnly = false;
        
            string nombreCompania = SelectedFlightPlan.GetCompany();
            CargarLogoCompania(nombreCompania);
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
                try
                {
                    //SelectedFlightPlan.SetSpeed(Convert.ToDouble(PlaneDataGridView.Rows[2].Cells[1].Value));
                    velocitatModificada = PlaneDataGridView.Rows[2].Cells[1].Value != null
                        ? Convert.ToDouble(PlaneDataGridView.Rows[2].Cells[1].Value)
                        : SelectedFlightPlan.GetSpeed();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid speed format. Please enter a numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
    }
}

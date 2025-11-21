using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using FlightLib;

namespace WindowsPrincipal
{
    public partial class PlaneDataForm : Form
    {
        FlightPlanList FlightsList = new FlightPlanList();
        
        // Per actualitzar sense tancar (si no es fa servir ShowDialog)
        //public event EventHandler<FlightPlanList> PlansUpdated;

        // Per arrosegar el formulari
        //[DllImport("user32.dll")]
        //public static extern bool ReleaseCapture();

        //[DllImport("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        
        
        public PlaneDataForm()
        {
            InitializeComponent();
            
            // Per arrosegar el formulari
            this.MouseDown += Form1_MouseDown;
            
            // perque estigui sempre a dalt (es pot posar una opcio a les opcions o algo aixi)
            //this.TopMost = true;
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
                string company = CompanyTextBox.Text;
                double speed = Convert.ToDouble(SpeedTextBox.Text);
                string[] initialPosition = InitialPositionTextBox.Text.Split(' ');
                string[] finalPosition = FinalPositionTextBox.Text.Split(' ');
                double initialX = Convert.ToDouble(initialPosition[0]);
                double initialY = Convert.ToDouble(initialPosition[1]);
                double finalX = Convert.ToDouble(finalPosition[0]);
                double finalY = Convert.ToDouble(finalPosition[1]);
                FlightPlan plan = new FlightPlan(id, company, initialX, initialY, finalX, finalY, speed);
                FlightsList.AddFlightPlan(plan);
                
                IdentificationTextBox.Text = null;
                CompanyTextBox.Text = null;
                SpeedTextBox.Text = null;  
                InitialPositionTextBox.Text = null;
                FinalPositionTextBox.Text = null;
                
                //PlansUpdated?.Invoke(this, FlightsList);
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

        private void DeveloperTestFlightsButton_Click(object sender, EventArgs e)
        {
            FlightPlan FP1 = new FlightPlan("FP1", "StandBy Airlines", 400, 400, 0, 0, 100);
            FlightPlan FP2 = new FlightPlan("FP2", "EasyFall",0, 400, 400, 0, 100);
            FlightPlan FP3 = new FlightPlan("FP3", "StandBy Airlines",800, 0, 700, 800, 150);
            FlightsList.AddFlightPlan(FP1);
            FlightsList.AddFlightPlan(FP2);
            FlightsList.AddFlightPlan(FP3);
            //PlansUpdated?.Invoke(this, FlightsList);
            MessageBox.Show("3 test flights added correctly!!\n(FP1, StandBy Airlines,400, 400, 0, 0, 100)\n(FP2, EasyFall, 0, 400, 400, 0, 100)\n(FP3, StandBy Airlines,800, 0, 700, 800, 150)");
        }

        // Perque es pugui arrosegar el formulari
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }
}

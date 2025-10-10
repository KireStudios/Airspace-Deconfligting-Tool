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
        private System.Windows.Forms.Timer autoTimer;
        
        public SimulationForm()
        {
            InitializeComponent();
            
            // Habilitar doble buffer en el panel usando reflexión para evitar parpadeo
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, SimulationPanel, new object[] { true });
            
            autoTimer = new System.Windows.Forms.Timer();
            autoTimer.Interval = 1000;
            autoTimer.Tick += AutoTimer_Tick;
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
            // Suscribirse al evento Paint para dibujar las trayectorias y elipses
            SimulationPanel.Paint += new PaintEventHandler(SimulationPanel_Paint);
            
            for (int i = 0; i < FlightsList.GetNumeroFlightPlans(); i++)
            {
                PictureBox plane = new PictureBox();
                
                // Crear un punto (círculo pequeño) para representar el avión
                Bitmap point = new Bitmap(10, 10);
                using (Graphics g = Graphics.FromImage(point))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(Color.Transparent);
                    g.FillEllipse(Brushes.Black, 0, 0, 10, 10);
                }
                plane.Image = point;
                plane.BackColor = Color.Transparent;
                
                plane.Tag = FlightsList.GetFlightPlan(i).GetId();
                plane.SizeMode = PictureBoxSizeMode.StretchImage;
                plane.Size = new Size(10, 10);
                plane.Location = new Point(
                    Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetX()) - 5, 
                    Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetY()) - 5
                );
                SimulationPanel.Controls.Add(plane);
                plane.Click += new System.EventHandler(SeePlaneData);
            }
        }

        // Fase 6 y 7: Dibujar trayectorias y elipses de seguridad
        private void SimulationPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < FlightsList.GetNumeroFlightPlans(); i++)
            {
                FlightPlan plan = FlightsList.GetFlightPlan(i);
                
                // Fase 6: Dibujar línea de trayectoria desde posición inicial a final
                Point initialPoint = new Point(
                    Convert.ToInt32(plan.GetInitialPosition().GetX()),
                    Convert.ToInt32(plan.GetInitialPosition().GetY())
                );
                Point finalPoint = new Point(
                    Convert.ToInt32(plan.GetFinalPosition().GetX()),
                    Convert.ToInt32(plan.GetFinalPosition().GetY())
                );
                
                Pen trajectoryPen = new Pen(Color.Blue, 2);
                g.DrawLine(trajectoryPen, initialPoint, finalPoint);
                
                // Fase 7: Dibujar elipse de distancia de seguridad alrededor de la posición actual
                Point currentPoint = new Point(
                    Convert.ToInt32(plan.GetPosition().GetX()),
                    Convert.ToInt32(plan.GetPosition().GetY())
                );
                
                // La elipse tiene como radio la distancia de seguridad
                int diameter = Convert.ToInt32(securityDistance * 2);
                Rectangle ellipseRect = new Rectangle(
                    currentPoint.X - Convert.ToInt32(securityDistance),
                    currentPoint.Y - Convert.ToInt32(securityDistance),
                    diameter,
                    diameter
                );
                
                Pen securityPen = new Pen(Color.Red, 1);
                securityPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawEllipse(securityPen, ellipseRect);
                
                trajectoryPen.Dispose();
                securityPen.Dispose();
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
                    SimulationPanel.Controls[i].Location = new Point(
                        Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetX()) - 5, 
                        Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetY()) - 5
                    );
                }
                cicles--;
                
                // Refrescar el panel para redibujar las elipses de seguridad en las nuevas posiciones
                SimulationPanel.Invalidate();
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
                SimulationPanel.Controls[i].Location = new Point(
                    Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetX()) - 5, 
                    Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetY()) - 5
                );
            }
            
            SimulationPanel.Invalidate();
        }

        // Fase 8: Simulación automática
        private void AutoSimulateButton_Click(object sender, EventArgs e)
        {
            autoTimer.Start();
        }

        private void StopSimulationButton_Click(object sender, EventArgs e)
        {
            autoTimer.Stop();
        }

        private void AutoTimer_Tick(object sender, EventArgs e)
        {
            if (cicles > 0)
            {
                FlightsList.Moure(10);
                for (int i = 0; i < FlightsList.GetNumeroFlightPlans(); i++)
                {
                    SimulationPanel.Controls[i].Location = new Point(
                        Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetX()) - 5, 
                        Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetY()) - 5
                    );
                }
                cicles--;
                SimulationPanel.Invalidate();
                
                // Fase 10: Verificar conflictos durante la simulación solo si ambos aviones no han llegado
                if (!FlightsList.GetFlightPlan(0).EstaAlFinal() && !FlightsList.GetFlightPlan(1).EstaAlFinal())
                {
                    if (FlightsList.GetFlightPlan(0).Conflicte(FlightsList.GetFlightPlan(1), securityDistance))
                    {
                        MessageBox.Show("¡ALERTA! Los vuelos están en conflicto (distancia menor a " + securityDistance + ")");
                    }
                }
            }
            else
            {
                autoTimer.Stop();
                MessageBox.Show("Simulación completada");
            }
        }

        // Fase 9: Mostrar datos de los vuelos
        private void ShowDataButton_Click(object sender, EventArgs e)
        {
            FlightPlan plan0 = FlightsList.GetFlightPlan(0);
            FlightPlan plan1 = FlightsList.GetFlightPlan(1);
            
            string info = "DATOS DE LOS VUELOS:\n\n";
            info += "Vuelo 1:\n";
            info += "ID: " + plan0.GetId() + "\n";
            info += "Velocidad: " + plan0.GetSpeed() + "\n";
            info += "Posición actual: (" + plan0.GetPosition().GetX().ToString("F2") + ", " + plan0.GetPosition().GetY().ToString("F2") + ")\n";
            info += "Posición inicial: (" + plan0.GetInitialPosition().GetX().ToString("F2") + ", " + plan0.GetInitialPosition().GetY().ToString("F2") + ")\n";
            info += "Posición final: (" + plan0.GetFinalPosition().GetX().ToString("F2") + ", " + plan0.GetFinalPosition().GetY().ToString("F2") + ")\n\n";
            
            info += "Vuelo 2:\n";
            info += "ID: " + plan1.GetId() + "\n";
            info += "Velocidad: " + plan1.GetSpeed() + "\n";
            info += "Posición actual: (" + plan1.GetPosition().GetX().ToString("F2") + ", " + plan1.GetPosition().GetY().ToString("F2") + ")\n";
            info += "Posición inicial: (" + plan1.GetInitialPosition().GetX().ToString("F2") + ", " + plan1.GetInitialPosition().GetY().ToString("F2") + ")\n";
            info += "Posición final: (" + plan1.GetFinalPosition().GetX().ToString("F2") + ", " + plan1.GetFinalPosition().GetY().ToString("F2") + ")\n\n";
            
            double distancia = plan0.GetPosition().Distancia(plan1.GetPosition());
            info += "Distancia entre vuelos: " + distancia.ToString("F2");
            
            MessageBox.Show(info, "Datos de los Vuelos");
        }

        // Fase 10: Verificar si hay conflicto
        private void CheckConflictButton_Click(object sender, EventArgs e)
        {
            FlightPlan plan0 = FlightsList.GetFlightPlan(0);
            FlightPlan plan1 = FlightsList.GetFlightPlan(1);
            
            double distancia = plan0.GetPosition().Distancia(plan1.GetPosition());
            
            if (distancia < securityDistance)
            {
                MessageBox.Show("SÍ - Los vuelos entrarán en conflicto.\nDistancia actual: " + distancia.ToString("F2") + "\nDistancia de seguridad: " + securityDistance, "Conflicto Detectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("NO - Los vuelos no están en conflicto.\nDistancia actual: " + distancia.ToString("F2") + "\nDistancia de seguridad: " + securityDistance, "Sin Conflicto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

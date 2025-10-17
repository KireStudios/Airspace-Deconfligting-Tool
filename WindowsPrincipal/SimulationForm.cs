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
        const int MAX_CONFLICTS = 100;
        
        // Variables per a guardar que venen del principal
        private FlightPlanList FlightsList = new FlightPlanList();
        private int OriginalCicles;
        private int cicles;
        private double securityDistance;
        private System.Windows.Forms.Timer autoTimer;
        
        // Fase 10: Conjunto para rastrear conflictos ya notificados
        private HashSet<string> conflictosNotificados = new HashSet<string>();
        int[,] MatriuConflictes = new int[MAX_CONFLICTS, 2];
        int NumConflictes = 0;
        
        public SimulationForm()
        {
            InitializeComponent();
            
            // Habilitar doble buffer en el panel usando reflexión para evitar parpadeo
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, SimulationPanel, new object[] { true });
            
            autoTimer = new System.Windows.Forms.Timer();
            autoTimer.Interval = 500;
            autoTimer.Tick += AutoTimer_Tick;
            
            // Suscribirse al evento Shown para verificar conflictos después de que la ventana sea visible
            this.Shown += SimulationForm_Shown;
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
                plane.Click += SeePlaneData;
            }
        }

        private void SimulationForm_Shown(object sender, EventArgs e)
        {
            // Verificar conflictos después de que la ventana sea completamente visible
            VerificarYNotificarConflictos();
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
                
                using (Pen trajectoryPen = new Pen(Color.Blue, 2))
                {
                    g.DrawLine(trajectoryPen, initialPoint, finalPoint);
                }
                
                // Fase 7: Dibujar elipse de distancia de seguridad alrededor de la posición actual
                Point currentPoint = new Point(
                    Convert.ToInt32(plan.GetPosition().GetX()),
                    Convert.ToInt32(plan.GetPosition().GetY())
                );
                
                int diameter = Convert.ToInt32(securityDistance); // Diámetro = 2 * radio, y el radio es securityDistance / 2
                Rectangle ellipseRect = new Rectangle(
                    currentPoint.X - Convert.ToInt32(securityDistance/2),
                    currentPoint.Y - Convert.ToInt32(securityDistance/2),
                    diameter,
                    diameter
                );
                
                using (Pen securityPen = new Pen(Color.Red, 1))
                {
                    securityPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawEllipse(securityPen, ellipseRect);
                }
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
            
            if (selectedFlightPlan != null)
            {
                SeePlaneDataOnClickForm SeePlaneDataForm = new SeePlaneDataOnClickForm();
                SeePlaneDataForm.GetFlightPlan(selectedFlightPlan);
                SeePlaneDataForm.ShowDialog();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MoveButton_Click(object sender, EventArgs e)
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
                
                // Verificar conflictos después del movimiento manual
                VerificarYNotificarConflictos();
            }
            else
            {
                MessageBox.Show("No more cycles left!");
            }
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            cicles = OriginalCicles;
            FlightsList.RestartAll();
            
            // Limpiar conflictos notificados al reiniciar
            conflictosNotificados.Clear();
            
            for (int i = 0; i < FlightsList.GetNumeroFlightPlans(); i++)
            {
                SimulationPanel.Controls[i].Location = new Point(
                    Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetX()) - 5, 
                    Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetY()) - 5
                );
            }
            autoTimer.Stop();
            SimulationPanel.Invalidate();
            
            // Verificar conflictos después de reiniciar
            VerificarYNotificarConflictos();
        }

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
                
                // Fase 10: Verificar y notificar conflictos durante la simulación automática
                VerificarYNotificarConflictos();
            }
            else
            {
                autoTimer.Stop();
                MessageBox.Show("Simulación completada");
            }
        }

        /// <summary>
        /// Fase 10: Verifica conflictos y muestra notificación solo una vez por cada conflicto
        /// </summary>
        private void VerificarYNotificarConflictos()
        {
            int numAviones = FlightsList.GetNumeroFlightPlans();
            HashSet<string> conflictosActuales = new HashSet<string>();
            
            // Verificar todos los pares de aviones
            for (int i = 0; i < numAviones; i++)
            {
                if (FlightsList.GetFlightPlan(i).EstaAlFinal())
                    continue;
                
                for (int j = i + 1; j < numAviones; j++)
                {
                    if (FlightsList.GetFlightPlan(j).EstaAlFinal())
                        continue;
                    
                    double distancia = FlightsList.GetFlightPlan(i).Distancia(FlightsList.GetFlightPlan(j));
                    double distanciaMinima = securityDistance;
                    
                    if (distancia < distanciaMinima)
                    {
                        // Crear clave única para este par (ordenada alfabéticamente para evitar duplicados)
                        string id1 = FlightsList.GetFlightPlan(i).GetId();
                        string id2 = FlightsList.GetFlightPlan(j).GetId();
                        string claveConflicto = string.Compare(id1, id2) < 0 ? id1 + "-" + id2 : id2 + "-" + id1;
                        
                        conflictosActuales.Add(claveConflicto);
                        
                        // Solo notificar si es un conflicto nuevo
                        if (!conflictosNotificados.Contains(claveConflicto))
                        {                            
                            conflictosNotificados.Add(claveConflicto);
                            autoTimer.Stop();
                            // Mostrar notificación
                            MessageBox.Show(
                                "⚠️ NUEVO CONFLICTO DETECTADO\n\n" +
                                "Aviones: " + id1 + " y " + id2 + "\n" +
                                "Distancia actual: " + distancia.ToString("F2") + "\n" +
                                "Distancia de seguridad: " + distanciaMinima.ToString("F2") + "\n\n" +
                                "Los círculos de seguridad se están solapando.",
                                "Alerta de Conflicto",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                    }
                }
            }
            
            // Limpiar conflictos que ya no están activos (los aviones se alejaron)
            conflictosNotificados.RemoveWhere(c => !conflictosActuales.Contains(c));
        }

        private void ShowDataButton_Click(object sender, EventArgs e)
        {
            InfoVolsForm infoForm = new InfoVolsForm(FlightsList);
            infoForm.ShowDialog();
            
            /* S'ha canviat per fer servir un datagridview en un altre formulari (Fase 9)
            int numAviones = FlightsList.GetNumeroFlightPlans();
            
            if (numAviones == 0)
            {
                MessageBox.Show("No hay vuelos", "Sin Datos");
                return;
            }
            
            string info = "DATOS DE LOS VUELOS:\n\n";
            
            for (int i = 0; i < numAviones; i++)
            {
                FlightPlan plan = FlightsList.GetFlightPlan(i);
                info += "Vuelo " + (i + 1) + ":\n";
                info += "ID: " + plan.GetId() + "\n";
                info += "Velocidad: " + plan.GetSpeed() + "\n";
                info += "Posición actual: (" + plan.GetPosition().GetX().ToString("F2") + ", " + plan.GetPosition().GetY().ToString("F2") + ")\n";
                info += "Posición inicial: (" + plan.GetInitialPosition().GetX().ToString("F2") + ", " + plan.GetInitialPosition().GetY().ToString("F2") + ")\n";
                info += "Posición final: (" + plan.GetFinalPosition().GetX().ToString("F2") + ", " + plan.GetFinalPosition().GetY().ToString("F2") + ")\n\n";
            }
            
            if (numAviones >= 2)
            {
                info += "DISTANCIAS:\n";
                for (int i = 0; i < numAviones; i++)
                {
                    for (int j = i + 1; j < numAviones; j++)
                    {
                        double dist = FlightsList.GetFlightPlan(i).GetPosition().Distancia(FlightsList.GetFlightPlan(j).GetPosition());
                        info += FlightsList.GetFlightPlan(i).GetId() + " - " + FlightsList.GetFlightPlan(j).GetId() + ": " + dist.ToString("F2") + "\n";
                    }
                }
            }
            
            info += "\nDistancia de seguridad configurada: " + securityDistance;
            MessageBox.Show(info, "Datos de los Vuelos");
            */
        }

        // Fase 10: Verificar si habrá conflicto a lo largo de la simulación (predicción futura)
        private void CheckConflictButton_Click(object sender, EventArgs e)
        {
            int numAviones = FlightsList.GetNumeroFlightPlans();
            
            if (numAviones < 2)
            {
                MessageBox.Show("Se necesitan al menos 2 vuelos", "Información");
                return;
            }
            
            string resultado = "PREDICCIÓN DE CONFLICTOS A LO LARGO DE LA SIMULACIÓN:\n\n";
            bool hayConflictosFuturos = false;
            
            for (int i = 0; i < numAviones; i++)
            {
                if (FlightsList.GetFlightPlan(i).EstaAlFinal())
                    continue;
                
                for (int j = i + 1; j < numAviones; j++)
                {
                    if (FlightsList.GetFlightPlan(j).EstaAlFinal())
                        continue;
                    
                    double distanciaActual = FlightsList.GetFlightPlan(i).GetPosition().Distancia(FlightsList.GetFlightPlan(j).GetPosition());
                    double distanciaMinima = FlightsList.GetFlightPlan(i).CalcularDistanciaMinimaFutura(FlightsList.GetFlightPlan(j));
                    double distanciaSeguridad = securityDistance;
                    
                    resultado += "Par: " + FlightsList.GetFlightPlan(i).GetId() + " - " + FlightsList.GetFlightPlan(j).GetId() + "\n";
                    resultado += "  Distancia actual: " + distanciaActual.ToString("F2") + "\n";
                    resultado += "  Distancia mínima prevista: " + distanciaMinima.ToString("F2") + "\n";
                    resultado += "  Distancia de seguridad requerida: " + distanciaSeguridad.ToString("F2") + "\n";
                    
                    if (distanciaMinima < distanciaSeguridad)
                    {
                        resultado += "  ⚠️ SÍ - HABRÁ CONFLICTO durante la simulación\n";
                        resultado += "  Los círculos de seguridad se solaparán en el futuro\n\n";
                        hayConflictosFuturos = true;
                    }
                    else
                    {
                        resultado += "  ✓ NO - Sin conflicto previsto\n";
                        resultado += "  Los vuelos mantendrán distancia segura\n\n";
                    }
                }
            }
            // Al clicar el No, no se resuelven los conflictos, pero al volver a abrir
            // el messageBox y clicar Yes, siguen sin resolverse. Hay que cerrar y abrir la simulación.
            // Lo cual no mola.
            if (hayConflictosFuturos)
            {
                resultado += "\n⚠️ CONCLUSIÓN: HAY CONFLICTOS FUTUROS PREVISTOS\n";
                resultado += "Los vuelos entrarán en conflicto durante la simulación.";
                if (MessageBox.Show(resultado, "Conflictos Futuros Detectados", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ResoldreConflictes();
                }
            }
            else
            {
                resultado += "\n✓ CONCLUSIÓN: NO HAY CONFLICTOS PREVISTOS\n";
                resultado += "Los vuelos completarán sus trayectorias sin conflictos.";
                MessageBox.Show(resultado, "Sin Conflictos Futuros", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private bool BuscarConflictes()
        {
            int numAvions = FlightsList.GetNumeroFlightPlans();

            if (numAvions < 2)
            { return false; }
            
            NumConflictes = 0;
            MatriuConflictes = new int[MAX_CONFLICTS, 2];

            
            for (int i = 0; i < numAvions; i++)
            {
                if (FlightsList.GetFlightPlan(i).EstaAlFinal())// || FlightsList.GetFlightPlan(i).GetInitialPosition() == FlightsList.GetFlightPlan(i).GetPosition())
                    continue;
                
                for (int j = i + 1; j < numAvions; j++)
                {
                    if (FlightsList.GetFlightPlan(j).EstaAlFinal())// || FlightsList.GetFlightPlan(j).GetInitialPosition() == FlightsList.GetFlightPlan(j).GetPosition())
                        continue;

                    double distanciaActual = FlightsList.GetFlightPlan(i).GetPosition().Distancia(FlightsList.GetFlightPlan(j).GetPosition());
                    double distanciaMinima = FlightsList.GetFlightPlan(i).CalcularDistanciaMinimaFutura(FlightsList.GetFlightPlan(j));
                    double distanciaSeguretat = securityDistance;
                    
                    if (distanciaMinima < distanciaSeguretat)
                    {
                        if ((FlightsList.GetFlightPlan(i).GetInitialPosition() == FlightsList.GetFlightPlan(i).GetPosition() || FlightsList.GetFlightPlan(j).GetInitialPosition() == FlightsList.GetFlightPlan(j).GetPosition()) && (distanciaActual < distanciaMinima))
                        {
                            MessageBox.Show("Els avions es xoquen a l'inici, no es poden resoldre conflictes.", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        MatriuConflictes[NumConflictes, 0] = i;
                        MatriuConflictes[NumConflictes++, 1] = j;
                    }
                }
            }
            
            if (NumConflictes > 0)
            {
                return true;
            }
            return false;
        }

        private void ResoldreConflictes()
        {
            double dV = 1.0;
            double Vmin = 1.0;

            while (BuscarConflictes())
            {
                for (int i = 0; i < NumConflictes; i++)
                {
                    int id1 = MatriuConflictes[i, 0];
                    int id2 = MatriuConflictes[i, 1];
                    
                    FlightPlan avio1 = FlightsList.GetFlightPlan(id1);
                    FlightPlan avio2 = FlightsList.GetFlightPlan(id2);
                    
                    if (avio1.GetSpeed() >= avio2.GetSpeed())
                    {
                        avio1.SetVelocidad(avio1.GetSpeed() + dV);
                        if (avio2.GetSpeed() - dV >= Vmin)
                            avio2.SetVelocidad(avio2.GetSpeed() - dV);
                    }
                    else
                    {
                        if (avio1.GetSpeed() - dV >= Vmin)
                            avio1.SetVelocidad(avio1.GetSpeed() - dV);
                        avio2.SetVelocidad(avio2.GetSpeed() + dV);
                    }
                }
            }
        }
    }
}

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
using System.Timers;
using System.Windows.Forms;

namespace WindowsPrincipal
{
    public partial class SimulationForm : Form
    {
        const int MAX_CONFLICTS = 100;

        // Variables per a guardar que venen del principal
        private FlightPlanList FlightsList;
        private int OriginalCicles;
        private int cicles;
        private double securityDistance;
        
        // Fase 10: Conjunto para rastrear conflictos ya notificados
        private HashSet<string> conflictosNotificados = new HashSet<string>();
        int[,] MatriuConflictes = new int[MAX_CONFLICTS, 2];
        int NumConflictes = 0;

        private bool Mode = true;

        // Variables para guardar el estado anterior
        private Stack<FlightPlanList> previousFlightPlans = new Stack<FlightPlanList>();

        public SimulationForm()
        {
            InitializeComponent();
            
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
            CheckConflict();
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
                
                // Dibuixar els avions
                SimulationPanel.Controls[i].Location = new Point(
                    Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetX()) - 5, 
                    Convert.ToInt32(FlightsList.GetFlightPlan(i).GetPosition().GetY()) - 5
                );
            }
        }
        //para guardar estado actual
        private void SaveCurrentState()
        {
            previousFlightPlans.Push(FlightsList.copy());
        }

        //Restaura estado anterior
        private void UndoButton_Click(object sender, EventArgs e)
        {
            if (previousFlightPlans.Count <= 0)
            {
                MessageBox.Show("No hay ningún paso anterior para deshacer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FlightsList = previousFlightPlans.Pop();
            
            cicles++;
            SimulationPanel.Invalidate();
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
                SeePlaneDataOnClickForm SeePlaneDataForm = new SeePlaneDataOnClickForm(selectedFlightPlan);
                //SeePlaneDataForm.GetFlightPlan(selectedFlightPlan);
                SeePlaneDataForm.ShowDialog();
                // Actualitzar la velocitat si s'ha modificat
                double novaVelocitat = SeePlaneDataForm.GetVelocitatModificada();
                if (novaVelocitat != selectedFlightPlan.GetSpeed())
                {
                    selectedFlightPlan.SetVelocidad(novaVelocitat);
                }
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
                // Guardar estado antes de mover
                SaveCurrentState();

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
            FlightsList.RestartAll();

            //Limpiar estado guardado
            previousFlightPlans = new Stack<FlightPlanList>();
            
            cicles = OriginalCicles;

            // Limpiar conflictos notificados al reiniciar
            conflictosNotificados.Clear();
            
            AutoTimer.Stop();
            SimulationPanel.Invalidate();
            
            // Verificar conflictos después de reiniciar
            VerificarYNotificarConflictos();
            Mode = true;
            AutoSimulateButton.Text = "Start Simulation";
        }

        private void AutoSimulateButton_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                AutoTimer.Start();
                AutoSimulateButton.Text = "Stop Simulation";
            }
            else
            {
                AutoTimer.Stop();
                AutoSimulateButton.Text = "Start Simulation";
            }
            Mode = !Mode;
        }

        
        private void AutoTimer_Tick(object sender, EventArgs e)
        {
            if (cicles > 0)
            {
                //Guardar estado antes de mover
                SaveCurrentState();

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
                AutoTimer.Stop();
                MessageBox.Show("Simulación completada");
            }
        }

        /// <summary>
        /// Fase 10: Verifica conflictos y muestra notificación solo una vez por cada conflicto
        /// </summary>
        private void VerificarYNotificarConflictos()
        {
            int numAviones = FlightsList.GetNumeroFlightPlans();
            // En aquesta versio no volen que fem servir el Hash set. NO BORRAR els Hash sets!!!, els deixo comentats.
            //HashSet<string> conflictosActuales = new HashSet<string>();
            
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
                        
                        //conflictosActuales.Add(claveConflicto);
                        
                        // Solo notificar si es un conflicto nuevo
                        if (true)//!conflictosNotificados.Contains(claveConflicto))
                        {
                            conflictosNotificados.Add(claveConflicto);
                            AutoTimer.Stop();
                            
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
            // conflictosNotificados.RemoveWhere(c => !conflictosActuales.Contains(c));
        }

        /*
        private void ShowDataButton_Click(object sender, EventArgs e)
        {
            InfoVolsForm infoForm = new InfoVolsForm(FlightsList);
            infoForm.ShowDialog();
            
            /* ERIK: S'ha canviat per fer servir un datagridview en un altre formulari (Fase 9)
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
            *-/
        }*/

        // Fase 10: Verificar si habrá conflicto a lo largo de la simulación (predicción futura)
        /*
        private void CheckConflictButton_Click(object sender, EventArgs e)
        {
            CheckConflict();
        }*/
        
        private void CheckConflict()
        { 
            int numAviones = FlightsList.GetNumeroFlightPlans();
            
            if (numAviones < 2)
            {
                MessageBox.Show("Se necesitan al menos 2 vuelos para que haya conflictos.", "Información");
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
                    
                    //double distanciaActual = FlightsList.GetFlightPlan(i).GetPosition().Distancia(FlightsList.GetFlightPlan(j).GetPosition());
                    double distanciaMinima = FlightsList.GetFlightPlan(i).CalcularDistanciaMinimaFutura(FlightsList.GetFlightPlan(j));
                    double distanciaSeguridad = securityDistance;
                    
                    /*resultado += "Par: " + FlightsList.GetFlightPlan(i).GetId() + " - " + FlightsList.GetFlightPlan(j).GetId() + "\n";
                    resultado += "  Distancia actual: " + distanciaActual.ToString("F2") + "\n";
                    resultado += "  Distancia mínima prevista: " + distanciaMinima.ToString("F2") + "\n";
                    resultado += "  Distancia de seguridad requerida: " + distanciaSeguridad.ToString("F2") + "\n";*/
                    
                    if (distanciaMinima < distanciaSeguridad)
                    {
                        //resultado += "  ⚠️ SÍ - HABRÁ CONFLICTO durante la simulación\n";
                        //resultado += "  Los círculos de seguridad se solaparán en el futuro\n\n";
                        hayConflictosFuturos = true;
                    }
                    /*else
                    {
                        resultado += "  ✓ NO - Sin conflicto previsto\n";
                        resultado += "  Los vuelos mantendrán distancia segura\n\n";
                    }*/
                }
            }
            
            // Al clicar el No, no se resuelven los conflictos, pero al volver a abrir
            // el messageBox y clicar Yes, siguen sin resolverse. Hay que cerrar y abrir la simulación.
            // Lo cual no mola.
            //
            // ERIK: Aixo es completament fals. Funciona correctament.
            if (hayConflictosFuturos)
            {
                resultado += "\n⚠️ CONCLUSIÓN: HAY CONFLICTOS FUTUROS PREVISTOS\n";
                resultado += "Los vuelos entrarán en conflicto durante la simulación.";
                resultado += "\n\n¿Desea resolver los conflictos ajustando las velocidades de los vuelos?";
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
                return false;
            
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
            while (BuscarConflictes())
            {
                for (int i = 0; i < NumConflictes; i++)
                {
                    int id1 = MatriuConflictes[i, 0];
                    int id2 = MatriuConflictes[i, 1];

                    FlightPlan avio1 = FlightsList.GetFlightPlan(id1);
                    FlightPlan avio2 = FlightsList.GetFlightPlan(id2);

                    Position p1 = avio1.GetPosition();
                    Position p2 = avio2.GetPosition();
                    
                    Position d1 = p1.resta(avio1.GetFinalPosition(), avio1.GetInitialPosition());
                    Position d2 = p1.resta(avio2.GetFinalPosition(), avio2.GetInitialPosition());
                    d1 = d1.div(d1, d1.mod());
                    d2 = d1.div(d2, d2.mod());
                    
                    Position v1 = d1.mult(avio1.GetSpeed(), d1);
                    Position v2 = d1.mult(avio2.GetSpeed(), d2);
                    
                    Position dP =p1.resta(p1, p2);
                    Position dV = p1.resta(v1, v2);

                    double t = 0;
                    if (!p1.igual(dV, 0))
                    {
                        // El temps t que minimitza la distancia t'=−(Δp⋅Δv)/∥Δv∥**2
                        t = -dP.mult(dP, dV) / (dV.mod() * dV.mod());
                    }
                    // Si t'<0, la distancia mínima ja ha passat
                    t = Math.Max(t, 0);

                    Position distanciaMin = p1.suma(dP, p1.mult(t, dV));
                    double distanciaMinMod = distanciaMin.mod();

                    if (distanciaMinMod < securityDistance)
                    {
                        // Cal resoldre el conflicte
                        double reduccioVelocitat = 0.1 * (securityDistance - distanciaMinMod);
                        reduccioVelocitat = Math.Max(reduccioVelocitat, 1);
                        
                        double novaVelocitat1 = Math.Max(avio1.GetSpeed() - reduccioVelocitat, 0);
                        //double novaVelocitat2 = Math.Max(avio2.GetSpeed() - reduccioVelocitat, 0);

                        avio1.SetVelocidad(novaVelocitat1);
                        //avio2.SetVelocidad(novaVelocitat2);
                    }

                }
            }
        }
        
        /*
        private void SaveSimulationButton_Click(object sender, EventArgs e)
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
        }*/


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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
                    FlightsList.SaveToFile(saveDialog.FileName, OriginalCicles, securityDistance, true, cicles);
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

        private void checkConflictsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckConflict();
        }

        private void showFlightDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoVolsForm infoForm = new InfoVolsForm(FlightsList);
            infoForm.ShowDialog();
        }
    }
}

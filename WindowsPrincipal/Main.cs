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

using FlightLib;
using PDFManage;

namespace WindowsPrincipal
{
    public partial class Main : Form
    {
        // Variables per a guardar les dades que venen dels altres formularis
        FlightPlanList FlightsList;
        int cicles;
        int currentCicle;
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.GetFullPath(@"..\..\..\DebugData\");
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select Flight Plan File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string FilePath = openFileDialog.FileName;
                    FlightPlanList loadedFlightPlans = new FlightPlanList();
                    bool simulating = false;
                    
                    try
                    {
                        StreamReader FileReader = new StreamReader(FilePath);
                        string FileLine = FileReader.ReadLine();

                        if (FileLine != null && bool.Parse(FileLine))
                        {
                            simulating = true;
                            FileLine = FileReader.ReadLine();
                            currentCicle = int.Parse(FileLine);
                        }

                        string[] Line = FileReader.ReadLine().Split('.');
                        cicles = int.Parse(Line[0]);
                        securityDistance = double.Parse(Line[1]);
                        
                        FileLine = FileReader.ReadLine();

                        FlightPlan FP;
                        
                        while (FileLine != null)
                        {
                            if (simulating)
                            {
                                string[] FPCharacteristics = FileLine.Split('.');
                                FP = new FlightPlan(FPCharacteristics[0], FPCharacteristics[1],
                                    Convert.ToDouble(FPCharacteristics[2]),
                                    Convert.ToDouble(FPCharacteristics[3]), Convert.ToDouble(FPCharacteristics[6]),
                                    Convert.ToDouble(FPCharacteristics[7]), Convert.ToDouble(FPCharacteristics[8]),
                                    Convert.ToDouble(FPCharacteristics[4]), Convert.ToDouble(FPCharacteristics[5]));
                            }
                            else
                            {
                                string[] FPCharacteristics = FileLine.Split('.');
                                FP = new FlightPlan(FPCharacteristics[0], FPCharacteristics[1],
                                    Convert.ToDouble(FPCharacteristics[2]),
                                    Convert.ToDouble(FPCharacteristics[3]), Convert.ToDouble(FPCharacteristics[4]),
                                    Convert.ToDouble(FPCharacteristics[5]), Convert.ToDouble(FPCharacteristics[6]));
                            }
                            loadedFlightPlans.AddFlightPlan(FP);
                            FileLine = FileReader.ReadLine();
                        }

                        FileReader.Close();

                        FlightsList = loadedFlightPlans;
                        MessageBox.Show(
                            "File loaded successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("File not found. Please check the file path and try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show(
                            "File format is incorrect. Please ensure the file contains valid data separated by dots.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fishero corruptíssimo, ¿pa' qué toca'?: {ex.Message}", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
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
                    FlightsList.SaveToFile(saveDialog.FileName, cicles, securityDistance);
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

        private void exportToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var save = new SaveFileDialog())
            {
                save.Title = "Guardar informe PDF";
                save.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                save.DefaultExt = "pdf";
                save.FileName = $"Flights_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (save.ShowDialog() != DialogResult.OK)
                {
                    return; // usuario canceló
                }

                string filePath = save.FileName;
                try
                {
                    PDFManage.Manage.GenerarDocumento(FlightsList, cicles, securityDistance, filePath);
                    MessageBox.Show("PDF guardado en:\n" + filePath, "Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

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

namespace WindowsPrincipal
{
    // Formulari per carregar un fitxer de text amb els FlightPlans
    public partial class LoadFileForm : Form
    {
        // Llista on guardarem els vols carregats del fitxer
        FlightPlanList FlightPlans = new FlightPlanList();
        public LoadFileForm()
        {
            InitializeComponent();
        }
        private void LoadFileForm_Load(object sender, EventArgs e)
        {

        }

        // Carregar el fitxer quan es prem el botó
        private void LoadButton_Click(object sender, EventArgs e)
        {
            string FileName = FileNameTextBox.Text;
            // Comprovar que el fitxer és .txt
            string[] trozos = FileName.Split('.');
          if (trozos.Length != 2 || trozos[trozos.Length - 1] != "txt")
          {
                MessageBox.Show("File extension not valid or TextBox is blank. Use .txt files only and write the extension.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          else
          {
            try
            {
                // Ruta fixa al directori DebugData
                string FilePath = Path.Combine(@"..\..\..\DebugData\", FileName);
                StreamReader FileReader = new StreamReader(FilePath);
                string FileLine = FileReader.ReadLine();
                while (FileLine != null)
                {
                        string[] FPCharacteristics = FileLine.Split(',');
                        // Construcció del FlightPlan des dels valors del fitxer
                        FlightPlan FP = new FlightPlan(FPCharacteristics[0], FPCharacteristics[1], Convert.ToDouble(FPCharacteristics[2]),
                                                       Convert.ToDouble(FPCharacteristics[3]), Convert.ToDouble(FPCharacteristics[4]),
                                                       Convert.ToDouble(FPCharacteristics[5]), Convert.ToInt32(FPCharacteristics[6])); 
                        FlightPlans.AddFlightPlan(FP);
                        FileLine = FileReader.ReadLine();
                }
                FileReader.Close();
                MessageBox.Show("File loaded successfully!  \nRemember to add the Cicles and Security Distance.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Please check the file path and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("File format is incorrect. Please ensure the file contains valid data separated by commas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
        }

        // Retorna la llista de FlightPlans carregats des del fitxer
        public FlightPlanList GetFlightPlanList()
        {
            return FlightPlans;
        }

        // Tanca el formulari quan l'usuari accepta la seva derrota
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

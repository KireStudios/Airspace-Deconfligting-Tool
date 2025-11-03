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
    public partial class LoadFileForm : Form
    {
        List<FlightPlan> FlightPlans = new List<FlightPlan>();
        public LoadFileForm()
        {
            InitializeComponent();
        }
        private void LoadFileForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string FileName = FileNameTextBox.Text;
            string[] trozos = FileName.Split('.');
            if (trozos.Length != 2 || trozos[trozos.Length - 1] != "txt")
            {
                MessageBox.Show("File extension not valid or TextBox is blank. Use .txt files only and write the extension.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    StreamReader FileReader = new StreamReader(FileName);
                    string FileLine = FileReader.ReadLine();
                    while (FileLine != null)
                    {
                        string[] FPCharacteristics = FileLine.Split(',');
                        FlightPlan FP = new FlightPlan(FPCharacteristics[0], FPCharacteristics[1], Convert.ToDouble(FPCharacteristics[2]),
                                                       Convert.ToDouble(FPCharacteristics[3]), Convert.ToDouble(FPCharacteristics[4]),
                                                       Convert.ToDouble(FPCharacteristics[5]), Convert.ToInt32(FPCharacteristics[6]));
                        FlightPlans.Add(FP);
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

        public List<FlightPlan> GetFlightPlanList()
        {
            return FlightPlans;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FlightLib;

namespace WindowsPrincipal
{
    public partial class PlaneDataForm : Form
    {
        FlightPlanList FlightsList = new FlightPlanList();
        public PlaneDataForm()
        {
            InitializeComponent();
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
                SpeedTextBox.Text = null;  
                InitialPositionTextBox.Text = null;
                FinalPositionTextBox.Text = null;
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
            FlightPlan FP1 = new FlightPlan("FP1", "StandBy Airlines", 200, 200, 0, 0, 100);
            FlightPlan FP2 = new FlightPlan("FP2", "EasyFall",0, 200, 200, 0, 100);
            FlightPlan FP3 = new FlightPlan("FP3", "StandBy Airlines",400, 0, 350, 400, 150);
            FlightsList.AddFlightPlan(FP1);
            FlightsList.AddFlightPlan(FP2);
            FlightsList.AddFlightPlan(FP3);
            MessageBox.Show("3 test flights added correctly!!\n(FP1, StandBy Airlines,200, 200, 0, 0, 100)\n(FP2, EasyFall, 0, 200, 200, 0, 100)\n(FP3, StandBy Airlines,400, 0, 350, 400, 150)");
        }
    }
}

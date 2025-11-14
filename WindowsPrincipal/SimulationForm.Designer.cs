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
    partial class SimulationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SimulationPanel = new System.Windows.Forms.Panel();
            this.labelCoord0 = new System.Windows.Forms.Label();
            this.SimulationLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.RestartButton = new System.Windows.Forms.Button();
            this.AutoSimulateButton = new System.Windows.Forms.Button();
            this.ShowDataButton = new System.Windows.Forms.Button();
            this.CheckConflictButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SimulationPanel
            // 
            this.SimulationPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SimulationPanel.Location = new System.Drawing.Point(433, 162);
            this.SimulationPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SimulationPanel.Name = "SimulationPanel";
            this.SimulationPanel.Size = new System.Drawing.Size(664, 622);
            this.SimulationPanel.TabIndex = 0;
            // 
            // labelCoord0
            // 
            this.labelCoord0.AutoSize = true;
            this.labelCoord0.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCoord0.Location = new System.Drawing.Point(428, 122);
            this.labelCoord0.Name = "labelCoord0";
            this.labelCoord0.Size = new System.Drawing.Size(31, 32);
            this.labelCoord0.TabIndex = 1;
            this.labelCoord0.Text = "0";
            // 
            // SimulationLabel
            // 
            this.SimulationLabel.AutoSize = true;
            this.SimulationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SimulationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SimulationLabel.Location = new System.Drawing.Point(109, 71);
            this.SimulationLabel.Name = "SimulationLabel";
            this.SimulationLabel.Size = new System.Drawing.Size(197, 42);
            this.SimulationLabel.TabIndex = 2;
            this.SimulationLabel.Text = "Simulation";
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Location = new System.Drawing.Point(1119, 54);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(152, 65);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Close Simulation";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(141, 278);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 79);
            this.button1.TabIndex = 4;
            this.button1.Text = "Move";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(162, 414);
            this.RestartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(84, 29);
            this.RestartButton.TabIndex = 5;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // AutoSimulateButton
            // 
            this.AutoSimulateButton.Location = new System.Drawing.Point(109, 488);
            this.AutoSimulateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AutoSimulateButton.Name = "AutoSimulateButton";
            this.AutoSimulateButton.Size = new System.Drawing.Size(187, 50);
            this.AutoSimulateButton.TabIndex = 6;
            this.AutoSimulateButton.Text = "Start Auto Simulation";
            this.AutoSimulateButton.UseVisualStyleBackColor = true;
            this.AutoSimulateButton.Click += new System.EventHandler(this.AutoSimulateButton_Click);
            // 
            // ShowDataButton
            // 
            this.ShowDataButton.Location = new System.Drawing.Point(109, 638);
            this.ShowDataButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShowDataButton.Name = "ShowDataButton";
            this.ShowDataButton.Size = new System.Drawing.Size(187, 50);
            this.ShowDataButton.TabIndex = 8;
            this.ShowDataButton.Text = "Show Flight Data";
            this.ShowDataButton.UseVisualStyleBackColor = true;
            this.ShowDataButton.Click += new System.EventHandler(this.ShowDataButton_Click);
            // 
            // CheckConflictButton
            // 
            this.CheckConflictButton.Location = new System.Drawing.Point(109, 712);
            this.CheckConflictButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CheckConflictButton.Name = "CheckConflictButton";
            this.CheckConflictButton.Size = new System.Drawing.Size(187, 50);
            this.CheckConflictButton.TabIndex = 9;
            this.CheckConflictButton.Text = "Check Conflict";
            this.CheckConflictButton.UseVisualStyleBackColor = true;
            this.CheckConflictButton.Click += new System.EventHandler(this.CheckConflictButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(109, 562);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(187, 50);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save Simulation";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveSimulationButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(109, 362);
            this.UndoButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(187, 38);
            this.UndoButton.TabIndex = 11;
            this.UndoButton.Text = "Undo Last Step";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 854);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CheckConflictButton);
            this.Controls.Add(this.ShowDataButton);
            this.Controls.Add(this.AutoSimulateButton);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.labelCoord0);
            this.Controls.Add(this.SimulationLabel);
            this.Controls.Add(this.SimulationPanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SimulationForm";
            this.Text = "SimulationForm";
            this.Load += new System.EventHandler(this.SimulationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel SimulationPanel;
        private System.Windows.Forms.Label labelCoord0;
        private System.Windows.Forms.Label SimulationLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Button AutoSimulateButton;
        private System.Windows.Forms.Button ShowDataButton;
        private System.Windows.Forms.Button CheckConflictButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button UndoButton;

    }
}
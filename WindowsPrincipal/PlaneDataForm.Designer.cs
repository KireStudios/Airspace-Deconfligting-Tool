namespace WindowsPrincipal
{
    partial class PlaneDataForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IdentificationTextBox = new System.Windows.Forms.TextBox();
            this.InitialPositionTextBox = new System.Windows.Forms.TextBox();
            this.SpeedTextBox = new System.Windows.Forms.TextBox();
            this.AddFlightPlanButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.FinalPositionTextBox = new System.Windows.Forms.TextBox();
            this.DeveloperTestFlightsButton = new System.Windows.Forms.Button();
            this.CompanyTextBox = new System.Windows.Forms.TextBox();
            this.CompanyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Plane Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Identification";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(327, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Initial position (X and Y separated by a blank)";
            // 
            // IdentificationTextBox
            // 
            this.IdentificationTextBox.Location = new System.Drawing.Point(88, 182);
            this.IdentificationTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IdentificationTextBox.Name = "IdentificationTextBox";
            this.IdentificationTextBox.Size = new System.Drawing.Size(250, 26);
            this.IdentificationTextBox.TabIndex = 4;
            // 
            // InitialPositionTextBox
            // 
            this.InitialPositionTextBox.Location = new System.Drawing.Point(88, 417);
            this.InitialPositionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InitialPositionTextBox.Name = "InitialPositionTextBox";
            this.InitialPositionTextBox.Size = new System.Drawing.Size(250, 26);
            this.InitialPositionTextBox.TabIndex = 5;
            // 
            // SpeedTextBox
            // 
            this.SpeedTextBox.Location = new System.Drawing.Point(88, 340);
            this.SpeedTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpeedTextBox.Name = "SpeedTextBox";
            this.SpeedTextBox.Size = new System.Drawing.Size(250, 26);
            this.SpeedTextBox.TabIndex = 6;
            // 
            // AddFlightPlanButton
            // 
            this.AddFlightPlanButton.Location = new System.Drawing.Point(145, 552);
            this.AddFlightPlanButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddFlightPlanButton.Name = "AddFlightPlanButton";
            this.AddFlightPlanButton.Size = new System.Drawing.Size(136, 48);
            this.AddFlightPlanButton.TabIndex = 7;
            this.AddFlightPlanButton.Text = "Add FlightPlan";
            this.AddFlightPlanButton.UseVisualStyleBackColor = true;
            this.AddFlightPlanButton.Click += new System.EventHandler(this.AddFlightPlanButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Location = new System.Drawing.Point(621, 596);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(170, 60);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Final position (X and Y separated by a blank)";
            // 
            // FinalPositionTextBox
            // 
            this.FinalPositionTextBox.Location = new System.Drawing.Point(88, 493);
            this.FinalPositionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FinalPositionTextBox.Name = "FinalPositionTextBox";
            this.FinalPositionTextBox.Size = new System.Drawing.Size(250, 26);
            this.FinalPositionTextBox.TabIndex = 10;
            // 
            // DeveloperTestFlightsButton
            // 
            this.DeveloperTestFlightsButton.Location = new System.Drawing.Point(621, 458);
            this.DeveloperTestFlightsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeveloperTestFlightsButton.Name = "DeveloperTestFlightsButton";
            this.DeveloperTestFlightsButton.Size = new System.Drawing.Size(138, 61);
            this.DeveloperTestFlightsButton.TabIndex = 11;
            this.DeveloperTestFlightsButton.Text = "Developer Test Flights";
            this.DeveloperTestFlightsButton.UseVisualStyleBackColor = true;
            this.DeveloperTestFlightsButton.Click += new System.EventHandler(this.DeveloperTestFlightsButton_Click);
            // 
            // CompanyTextBox
            // 
            this.CompanyTextBox.Location = new System.Drawing.Point(88, 260);
            this.CompanyTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompanyTextBox.Name = "CompanyTextBox";
            this.CompanyTextBox.Size = new System.Drawing.Size(250, 26);
            this.CompanyTextBox.TabIndex = 13;
            // 
            // CompanyLabel
            // 
            this.CompanyLabel.AutoSize = true;
            this.CompanyLabel.Location = new System.Drawing.Point(70, 225);
            this.CompanyLabel.Name = "CompanyLabel";
            this.CompanyLabel.Size = new System.Drawing.Size(76, 20);
            this.CompanyLabel.TabIndex = 12;
            this.CompanyLabel.Text = "Company";
            // 
            // PlaneDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 686);
            this.Controls.Add(this.CompanyTextBox);
            this.Controls.Add(this.CompanyLabel);
            this.Controls.Add(this.DeveloperTestFlightsButton);
            this.Controls.Add(this.FinalPositionTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AddFlightPlanButton);
            this.Controls.Add(this.SpeedTextBox);
            this.Controls.Add(this.InitialPositionTextBox);
            this.Controls.Add(this.IdentificationTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PlaneDataForm";
            this.Text = "PlaneDataForm";
            this.Load += new System.EventHandler(this.PlaneDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox CompanyTextBox;
        private System.Windows.Forms.Label CompanyLabel;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IdentificationTextBox;
        private System.Windows.Forms.TextBox InitialPositionTextBox;
        private System.Windows.Forms.TextBox SpeedTextBox;
        private System.Windows.Forms.Button AddFlightPlanButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FinalPositionTextBox;
        private System.Windows.Forms.Button DeveloperTestFlightsButton;
    }
}
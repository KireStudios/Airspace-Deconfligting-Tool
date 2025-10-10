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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Plane Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Identification";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(274, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Initial position (X and Y separated by a blank)";
            // 
            // IdentificationTextBox
            // 
            this.IdentificationTextBox.Location = new System.Drawing.Point(78, 146);
            this.IdentificationTextBox.Name = "IdentificationTextBox";
            this.IdentificationTextBox.Size = new System.Drawing.Size(223, 22);
            this.IdentificationTextBox.TabIndex = 4;
            // 
            // InitialPositionTextBox
            // 
            this.InitialPositionTextBox.Location = new System.Drawing.Point(78, 291);
            this.InitialPositionTextBox.Name = "InitialPositionTextBox";
            this.InitialPositionTextBox.Size = new System.Drawing.Size(223, 22);
            this.InitialPositionTextBox.TabIndex = 5;
            // 
            // SpeedTextBox
            // 
            this.SpeedTextBox.Location = new System.Drawing.Point(78, 212);
            this.SpeedTextBox.Name = "SpeedTextBox";
            this.SpeedTextBox.Size = new System.Drawing.Size(223, 22);
            this.SpeedTextBox.TabIndex = 6;
            // 
            // AddFlightPlanButton
            // 
            this.AddFlightPlanButton.Location = new System.Drawing.Point(129, 442);
            this.AddFlightPlanButton.Name = "AddFlightPlanButton";
            this.AddFlightPlanButton.Size = new System.Drawing.Size(121, 38);
            this.AddFlightPlanButton.TabIndex = 7;
            this.AddFlightPlanButton.Text = "Add FlightPlan";
            this.AddFlightPlanButton.UseVisualStyleBackColor = true;
            this.AddFlightPlanButton.Click += new System.EventHandler(this.AddFlightPlanButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Location = new System.Drawing.Point(552, 477);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(151, 48);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Get me out of here";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(273, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Final position (X and Y separated by a blank)";
            // 
            // FinalPositionTextBox
            // 
            this.FinalPositionTextBox.Location = new System.Drawing.Point(78, 366);
            this.FinalPositionTextBox.Name = "FinalPositionTextBox";
            this.FinalPositionTextBox.Size = new System.Drawing.Size(223, 22);
            this.FinalPositionTextBox.TabIndex = 10;
            // 
            // DeveloperTestFlightsButton
            // 
            this.DeveloperTestFlightsButton.Location = new System.Drawing.Point(552, 366);
            this.DeveloperTestFlightsButton.Name = "DeveloperTestFlightsButton";
            this.DeveloperTestFlightsButton.Size = new System.Drawing.Size(123, 49);
            this.DeveloperTestFlightsButton.TabIndex = 11;
            this.DeveloperTestFlightsButton.Text = "Developer Test Flights";
            this.DeveloperTestFlightsButton.UseVisualStyleBackColor = true;
            this.DeveloperTestFlightsButton.Click += new System.EventHandler(this.DeveloperTestFlightsButton_Click);
            // 
            // PlaneDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
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
            this.Name = "PlaneDataForm";
            this.Text = "PlaneDataForm";
            this.Load += new System.EventHandler(this.PlaneDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

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
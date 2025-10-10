namespace WindowsPrincipal
{
    partial class CicleSecurityForm
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
            this.SecurityTextBox = new System.Windows.Forms.TextBox();
            this.CicleTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AutoFill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Security Distance and number of Cicles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Security Distance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of Cicles";
            // 
            // SecurityTextBox
            // 
            this.SecurityTextBox.Location = new System.Drawing.Point(134, 184);
            this.SecurityTextBox.Name = "SecurityTextBox";
            this.SecurityTextBox.Size = new System.Drawing.Size(199, 22);
            this.SecurityTextBox.TabIndex = 3;
            // 
            // CicleTextBox
            // 
            this.CicleTextBox.Location = new System.Drawing.Point(458, 184);
            this.CicleTextBox.Name = "CicleTextBox";
            this.CicleTextBox.Size = new System.Drawing.Size(199, 22);
            this.CicleTextBox.TabIndex = 4;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(362, 259);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 32);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Location = new System.Drawing.Point(353, 372);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(93, 34);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Return";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // AutoFill
            // 
            this.AutoFill.Location = new System.Drawing.Point(481, 259);
            this.AutoFill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AutoFill.Name = "AutoFill";
            this.AutoFill.Size = new System.Drawing.Size(90, 32);
            this.AutoFill.TabIndex = 7;
            this.AutoFill.Text = "Auto Fill";
            this.AutoFill.UseVisualStyleBackColor = true;
            this.AutoFill.Click += new System.EventHandler(this.fillAuto_Click);
            // 
            // CicleSecurityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AutoFill);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CicleTextBox);
            this.Controls.Add(this.SecurityTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CicleSecurityForm";
            this.Text = "CicleSecurityForm";
            this.Load += new System.EventHandler(this.CicleSecurityForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SecurityTextBox;
        private System.Windows.Forms.TextBox CicleTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button AutoFill;
    }
}
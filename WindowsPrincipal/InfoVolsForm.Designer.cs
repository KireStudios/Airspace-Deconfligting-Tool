using System.ComponentModel;

namespace WindowsPrincipal
{
    partial class InfoVolsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VolsDataGridView = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Pla1Button = new System.Windows.Forms.Button();
            this.Pla2Button = new System.Windows.Forms.Button();
            this.DistanciaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VolsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VolsDataGridView
            // 
            this.VolsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.VolsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.VolsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VolsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VolsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.VolsDataGridView.MaximumSize = new System.Drawing.Size(500, 1500);
            this.VolsDataGridView.MinimumSize = new System.Drawing.Size(500, 100);
            this.VolsDataGridView.Name = "VolsDataGridView";
            this.VolsDataGridView.ReadOnly = true;
            this.VolsDataGridView.RowHeadersWidth = 51;
            this.VolsDataGridView.RowTemplate.Height = 28;
            this.VolsDataGridView.Size = new System.Drawing.Size(500, 194);
            this.VolsDataGridView.TabIndex = 0;
            // 
            // Pla1Button
            // 
            this.Pla1Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pla1Button.Location = new System.Drawing.Point(520, 12);
            this.Pla1Button.Name = "Pla1Button";
            this.Pla1Button.Size = new System.Drawing.Size(175, 35);
            this.Pla1Button.TabIndex = 1;
            this.Pla1Button.Text = "Seleccionar el primer vol";
            this.Pla1Button.UseVisualStyleBackColor = true;
            this.Pla1Button.Click += new System.EventHandler(this.Pla1Button_Click);
            // 
            // Pla2Button
            // 
            this.Pla2Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pla2Button.Location = new System.Drawing.Point(520, 53);
            this.Pla2Button.Name = "Pla2Button";
            this.Pla2Button.Size = new System.Drawing.Size(175, 35);
            this.Pla2Button.TabIndex = 2;
            this.Pla2Button.Text = "Seleccionar el segon vol";
            this.Pla2Button.UseVisualStyleBackColor = true;
            this.Pla2Button.Click += new System.EventHandler(this.Pla2Button_Click);
            // 
            // DistanciaLabel
            // 
            this.DistanciaLabel.Location = new System.Drawing.Point(520, 102);
            this.DistanciaLabel.Name = "DistanciaLabel";
            this.DistanciaLabel.Size = new System.Drawing.Size(175, 46);
            this.DistanciaLabel.TabIndex = 3;
            this.DistanciaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoVolsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(712, 194);
            this.Controls.Add(this.DistanciaLabel);
            this.Controls.Add(this.Pla2Button);
            this.Controls.Add(this.Pla1Button);
            this.Controls.Add(this.VolsDataGridView);
            this.MaximumSize = new System.Drawing.Size(730, 1500);
            this.MinimumSize = new System.Drawing.Size(730, 100);
            this.Name = "InfoVolsForm";
            this.Load += new System.EventHandler(this.InfoVolsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VolsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label DistanciaLabel;

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Pla1Button;
        private System.Windows.Forms.Button Pla2Button;

        private System.Windows.Forms.DataGridView VolsDataGridView;

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
    }
}
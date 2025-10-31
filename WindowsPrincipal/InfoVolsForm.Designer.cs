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
            ((System.ComponentModel.ISupportInitialize)(this.VolsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VolsDataGridView
            // 
            this.VolsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.VolsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.VolsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VolsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VolsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.VolsDataGridView.Name = "VolsDataGridView";
            this.VolsDataGridView.RowTemplate.Height = 28;
            this.VolsDataGridView.Size = new System.Drawing.Size(503, 194);
            this.VolsDataGridView.TabIndex = 0;
            // 
            // InfoVolsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(503, 194);
            this.Controls.Add(this.VolsDataGridView);
            this.MaximumSize = new System.Drawing.Size(525, 1500);
            this.MinimumSize = new System.Drawing.Size(525, 100);
            this.Name = "InfoVolsForm";
            this.Load += new System.EventHandler(this.InfoVolsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VolsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

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
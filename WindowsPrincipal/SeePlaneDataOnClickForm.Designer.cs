namespace WindowsPrincipal
{
    partial class SeePlaneDataOnClickForm
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
            this.PlaneDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PlaneDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PlaneDataGridView
            // 
            this.PlaneDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PlaneDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.PlaneDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlaneDataGridView.Location = new System.Drawing.Point(0, 0);
            this.PlaneDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.PlaneDataGridView.Name = "PlaneDataGridView";
            this.PlaneDataGridView.RowHeadersWidth = 51;
            this.PlaneDataGridView.RowTemplate.Height = 24;
            this.PlaneDataGridView.Size = new System.Drawing.Size(400, 185);
            this.PlaneDataGridView.TabIndex = 0;
            this.PlaneDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlaneDataGridView_CellValueChanged);
            // 
            // SeePlaneDataOnClickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(398, 184);
            this.Controls.Add(this.PlaneDataGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SeePlaneDataOnClickForm";
            this.Text = "Plane Data";
            this.Load += new System.EventHandler(this.SeePlaneDataOnClickForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlaneDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PlaneDataGridView;
    }
}
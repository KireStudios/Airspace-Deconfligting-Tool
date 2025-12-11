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
            this.LogoCompaniaPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlaneDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoCompaniaPictureBox)).BeginInit();
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
            this.PlaneDataGridView.Size = new System.Drawing.Size(413, 206);
            this.PlaneDataGridView.TabIndex = 0;
            this.PlaneDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlaneDataGridView_CellValueChanged);
            // 
            // LogoCompaniaPictureBox
            // 
            this.LogoCompaniaPictureBox.Location = new System.Drawing.Point(416, 0);
            this.LogoCompaniaPictureBox.Name = "LogoCompaniaPictureBox";
            this.LogoCompaniaPictureBox.Size = new System.Drawing.Size(60, 60);
            this.LogoCompaniaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoCompaniaPictureBox.TabIndex = 1;
            this.LogoCompaniaPictureBox.TabStop = false;
            this.LogoCompaniaPictureBox.Visible = false;
            // 
            // SeePlaneDataOnClickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(552, 262);
            this.Controls.Add(this.LogoCompaniaPictureBox);
            this.Controls.Add(this.PlaneDataGridView);
            this.Name = "SeePlaneDataOnClickForm";
            this.Text = "Plane Data";
            this.Load += new System.EventHandler(this.SeePlaneDataOnClickForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlaneDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoCompaniaPictureBox)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.DataGridView PlaneDataGridView;
        private System.Windows.Forms.PictureBox LogoCompaniaPictureBox;
        
        
        #endregion
    }
}
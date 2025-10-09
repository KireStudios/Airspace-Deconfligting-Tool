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
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PlaneDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PlaneDataGridView
            // 
            this.PlaneDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlaneDataGridView.Location = new System.Drawing.Point(211, 117);
            this.PlaneDataGridView.Name = "PlaneDataGridView";
            this.PlaneDataGridView.RowHeadersWidth = 51;
            this.PlaneDataGridView.RowTemplate.Height = 24;
            this.PlaneDataGridView.Size = new System.Drawing.Size(416, 266);
            this.PlaneDataGridView.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(68, 231);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SeePlaneDataOnClickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 481);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PlaneDataGridView);
            this.Name = "SeePlaneDataOnClickForm";
            this.Text = "Plane Data";
            this.Load += new System.EventHandler(this.SeePlaneDataOnClickForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlaneDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PlaneDataGridView;
        private System.Windows.Forms.Button CloseButton;
    }
}
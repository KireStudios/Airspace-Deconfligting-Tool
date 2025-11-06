namespace WindowsPrincipal
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCiclesAndSecurityDistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initializeSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BienvenidaLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.filesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1308, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDataToolStripMenuItem,
            this.addCiclesAndSecurityDistanceToolStripMenuItem,
            this.initializeSimulationToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // addDataToolStripMenuItem
            // 
            this.addDataToolStripMenuItem.Name = "addDataToolStripMenuItem";
            this.addDataToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.addDataToolStripMenuItem.Text = "Add planes data";
            this.addDataToolStripMenuItem.Click += new System.EventHandler(this.addDataToolStripMenuItem_Click);
            // 
            // addCiclesAndSecurityDistanceToolStripMenuItem
            // 
            this.addCiclesAndSecurityDistanceToolStripMenuItem.Name = "addCiclesAndSecurityDistanceToolStripMenuItem";
            this.addCiclesAndSecurityDistanceToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.addCiclesAndSecurityDistanceToolStripMenuItem.Text = "Add cicles and security distance";
            this.addCiclesAndSecurityDistanceToolStripMenuItem.Click += new System.EventHandler(this.addCiclesAndSecurityDistanceToolStripMenuItem_Click);
            // 
            // initializeSimulationToolStripMenuItem
            // 
            this.initializeSimulationToolStripMenuItem.Name = "initializeSimulationToolStripMenuItem";
            this.initializeSimulationToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.initializeSimulationToolStripMenuItem.Text = "Initialize simulation";
            this.initializeSimulationToolStripMenuItem.Click += new System.EventHandler(this.initializeSimulationToolStripMenuItem_Click);
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFileToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.filesToolStripMenuItem.Text = "File";
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.saveFileToolStripMenuItem.Text = "New";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // BienvenidaLabel
            // 
            this.BienvenidaLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BienvenidaLabel.AutoSize = true;
            this.BienvenidaLabel.Location = new System.Drawing.Point(842, 96);
            this.BienvenidaLabel.Name = "BienvenidaLabel";
            this.BienvenidaLabel.Size = new System.Drawing.Size(92, 16);
            this.BienvenidaLabel.TabIndex = 1;
            this.BienvenidaLabel.Text = "Hola caracola";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(1007, 510);
            this.CloseButton.MaximumSize = new System.Drawing.Size(150, 50);
            this.CloseButton.MinimumSize = new System.Drawing.Size(150, 50);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(150, 50);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close this ADT";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1308, 644);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.BienvenidaLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCiclesAndSecurityDistanceToolStripMenuItem;
        private System.Windows.Forms.Label BienvenidaLabel;
        private System.Windows.Forms.ToolStripMenuItem initializeSimulationToolStripMenuItem;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    }
}


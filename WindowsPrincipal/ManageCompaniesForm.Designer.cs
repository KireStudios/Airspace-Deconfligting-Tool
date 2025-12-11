using System.ComponentModel;

namespace WindowsPrincipal
{
    partial class ManageCompaniesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView CompaniesDataGridView;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox TelephoneTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label TelephoneLabel;
        private System.Windows.Forms.Label EmailLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.CompaniesDataGridView = new System.Windows.Forms.DataGridView();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.TelephoneTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.TelephoneLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CompaniesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CompaniesDataGridView
            // 
            this.CompaniesDataGridView.ColumnHeadersHeight = 29;
            this.CompaniesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.CompaniesDataGridView.Name = "CompaniesDataGridView";
            this.CompaniesDataGridView.RowHeadersWidth = 51;
            this.CompaniesDataGridView.Size = new System.Drawing.Size(460, 200);
            this.CompaniesDataGridView.TabIndex = 0;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(138, 227);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(150, 22);
            this.NameTextBox.TabIndex = 2;
            // 
            // TelephoneTextBox
            // 
            this.TelephoneTextBox.Location = new System.Drawing.Point(138, 257);
            this.TelephoneTextBox.Name = "TelephoneTextBox";
            this.TelephoneTextBox.Size = new System.Drawing.Size(150, 22);
            this.TelephoneTextBox.TabIndex = 4;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(138, 287);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(150, 22);
            this.EmailTextBox.TabIndex = 6;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(374, 230);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 30);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Add Company";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(364, 279);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(122, 30);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete Selected";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(12, 230);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(62, 23);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name:";
            // 
            // TelephoneLabel
            // 
            this.TelephoneLabel.Location = new System.Drawing.Point(12, 260);
            this.TelephoneLabel.Name = "TelephoneLabel";
            this.TelephoneLabel.Size = new System.Drawing.Size(100, 23);
            this.TelephoneLabel.TabIndex = 3;
            this.TelephoneLabel.Text = "Telephone:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.Location = new System.Drawing.Point(12, 290);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(100, 23);
            this.EmailLabel.TabIndex = 5;
            this.EmailLabel.Text = "Email:";
            // 
            // ManageCompaniesForm
            // 
            this.ClientSize = new System.Drawing.Size(576, 323);
            this.Controls.Add(this.CompaniesDataGridView);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.TelephoneLabel);
            this.Controls.Add(this.TelephoneTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DeleteButton);
            this.Name = "ManageCompaniesForm";
            this.Text = "Manage Companies";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageCompaniesForm_FormClosing);
            this.Load += new System.EventHandler(this.ManageCompaniesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CompaniesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

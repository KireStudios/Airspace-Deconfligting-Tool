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

            // CompaniesDataGridView
            this.CompaniesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.CompaniesDataGridView.Size = new System.Drawing.Size(460, 200);

            // Labels and TextBoxes
            this.NameLabel.Text = "Name:";
            this.NameLabel.Location = new System.Drawing.Point(12, 230);
            this.NameTextBox.Location = new System.Drawing.Point(80, 227);
            this.NameTextBox.Size = new System.Drawing.Size(150, 20);

            this.TelephoneLabel.Text = "Telephone:";
            this.TelephoneLabel.Location = new System.Drawing.Point(12, 260);
            this.TelephoneTextBox.Location = new System.Drawing.Point(80, 257);
            this.TelephoneTextBox.Size = new System.Drawing.Size(150, 20);

            this.EmailLabel.Text = "Email:";
            this.EmailLabel.Location = new System.Drawing.Point(12, 290);
            this.EmailTextBox.Location = new System.Drawing.Point(80, 287);
            this.EmailTextBox.Size = new System.Drawing.Size(150, 20);

            // Buttons
            this.AddButton.Text = "Add Company";
            this.AddButton.Location = new System.Drawing.Point(250, 255);
            this.AddButton.Size = new System.Drawing.Size(100, 30);
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);

            this.DeleteButton.Text = "Delete Selected";
            this.DeleteButton.Location = new System.Drawing.Point(360, 255);
            this.DeleteButton.Size = new System.Drawing.Size(110, 30);
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(484, 330);
            this.Controls.Add(this.CompaniesDataGridView);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.TelephoneLabel);
            this.Controls.Add(this.TelephoneTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DeleteButton);
            this.Text = "Manage Companies";
            this.Load += new System.EventHandler(this.ManageCompaniesForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageCompaniesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CompaniesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using UserManage;

namespace WindowsPrincipal
{
    public partial class ManageCompaniesForm : Form
    {
        private Manage manage;

        public ManageCompaniesForm()
        {
            InitializeComponent();
            manage = new Manage();
        }

        private void ManageCompaniesForm_Load(object sender, EventArgs e)
        {
            manage.Iniciar();
            RefreshCompanies();
        }

        private void ManageCompaniesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { manage.Cerrar(); } catch { }
        }

        private void RefreshCompanies()
        {
            DataTable dt = manage.GetCompanies();
            CompaniesDataGridView.DataSource = dt;
            CompaniesDataGridView.ReadOnly = true;
            CompaniesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string tel = TelephoneTextBox.Text.Trim();
            string mail = EmailTextBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Company name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = manage.CreateCompany(name, tel, mail);
            if (success)
            {
                MessageBox.Show("Company added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                RefreshCompanies();
            }
            else
            {
                MessageBox.Show("Failed to add company. It may already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (CompaniesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a company to delete.", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = CompaniesDataGridView.SelectedRows[0].Cells["name"].Value?.ToString();
            if (string.IsNullOrEmpty(name)) return;

            var result = MessageBox.Show($"Delete company '{name}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool success = manage.DeleteCompany(name);
                if (success)
                {
                    RefreshCompanies();
                }
                else
                {
                    MessageBox.Show("Failed to delete company.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            NameTextBox.Text = "";
            TelephoneTextBox.Text = "";
            EmailTextBox.Text = "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsPrincipal
{
    public partial class LoadFileForm : Form
    {
        public LoadFileForm()
        {
            InitializeComponent();
        }
        private void LoadFileForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            List<string> fileLines = new List<string>();
            string FileName = FileNameTextBox.Text;

        }
    }
}

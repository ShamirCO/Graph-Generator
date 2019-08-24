using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    partial class FormMSTSolutionSet : Form
    {
        public FormMSTSolutionSet(List<Edge> solutionSet, string algorithm)
        {
            InitializeComponent();

            Text += algorithm;

            DataGridViewSolutionSet.DataSource = solutionSet;

            DataGridViewSolutionSet.Columns[3].Visible = false;
        }

        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}

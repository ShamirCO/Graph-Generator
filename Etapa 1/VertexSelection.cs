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
    partial class FormVertexSelection : Form
    {
        public FormVertexSelection(List<Vertex> vertexList, string vertexLabel)
        {
            InitializeComponent();

            Text += vertexLabel;
            LabelVertex.Text += vertexLabel + ":";

            ComboBoxVertexes.DataSource = vertexList;
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public int GetSelectedVertex()
        {
            return ComboBoxVertexes.SelectedIndex;
        }
    }
}

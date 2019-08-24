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
    partial class FormPreyVertexSelection : Form
    {
        public FormPreyVertexSelection(List<Vertex> originVertexes, List<Vertex> destinationVertexes, string preyID)
        {
            InitializeComponent();

            LabelPrey.Text += preyID;

            ComboBoxOriginVertex.DataSource = originVertexes;
            ComboBoxDestinationVertex.DataSource = destinationVertexes;
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public int GetSelectedOriginVertex()
        {
            return ComboBoxOriginVertex.SelectedIndex;
        }

        public int GetSelectedDestinationVertex()
        {
            return ComboBoxDestinationVertex.SelectedIndex;
        }
    }
}

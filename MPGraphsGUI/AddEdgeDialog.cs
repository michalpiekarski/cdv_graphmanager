using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPGraphsGUI
{
    public partial class AddEdgeDialog : Form
    {
        public int? VertexIndexA { get; private set; }
        public int? VertexIndexB { get; private set; }
        public int? Weight { get; private set; }

        public AddEdgeDialog(bool isWeighted = false)
        {
            InitializeComponent();
            this.VertexIndexA = null;
            this.VertexIndexB = null;
            this.Weight = null;
            if (isWeighted == false)
            {
                weightsLabel.Enabled = false;
                weightInput.Enabled = false;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.VertexIndexA = (int)vertexIndexAInput.Value;
            this.VertexIndexB = (int)vertexIndexBInput.Value;
            this.Weight = (int)weightInput.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

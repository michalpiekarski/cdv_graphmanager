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
        public AddEdgeDialog()
        {
            InitializeComponent();
            this.VertexIndexA = null;
            this.VertexIndexB = null;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.VertexIndexA = (int)vertexIndexAInput.Value;
            this.VertexIndexB = (int)vertexIndexBInput.Value;
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

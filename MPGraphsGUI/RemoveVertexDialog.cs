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
    public partial class RemoveVertexDialog : Form
    {
        public int? VertexIndex { get; private set; }
        public RemoveVertexDialog()
        {
            InitializeComponent();
            this.VertexIndex = null;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.VertexIndex = (int)vertexIndexInput.Value;
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

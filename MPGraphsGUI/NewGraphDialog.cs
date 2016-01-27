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
    public partial class NewGraphDialog : Form
    {
        public string GraphName { get; private set; }
        public string GraphType { get; private set; }
        public bool? GraphDirected { get; private set; }
        public NewGraphDialog()
        {
            InitializeComponent();
            this.GraphName = null;
            this.GraphType = null;
            this.GraphDirected = null;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.GraphName = graphNameInput.Text;
            this.GraphType = graphTypeInput.SelectedItem.ToString();
            this.GraphDirected = directedInput.Checked;
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

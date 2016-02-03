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
        MainWindow mainRef;
        public NewGraphDialog(MainWindow mainRef)
        {
            InitializeComponent();
            this.GraphName = null;
            this.GraphType = null;
            this.GraphDirected = null;
            graphTypeInput.SelectedIndex = 0;
            this.mainRef = mainRef;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            graphNameLabel.ForeColor = SystemColors.ControlText;
            graphNameLabel.Font = SystemFonts.DefaultFont;
            if (graphNameInput.Text == "" || mainRef.Graphs.ContainsKey(graphNameInput.Text))
            {
                graphNameLabel.ForeColor = Color.Red;
                Font f = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                graphNameLabel.Font = f;
                return;
            }
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

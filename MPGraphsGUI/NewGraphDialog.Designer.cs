namespace MPGraphsGUI
{
    partial class NewGraphDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.graphTypeLabel = new System.Windows.Forms.Label();
            this.graphNameInput = new System.Windows.Forms.TextBox();
            this.graphTypeInput = new System.Windows.Forms.ComboBox();
            this.graphNameLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.directedInput = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.graphTypeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.graphNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.okButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.graphNameInput, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.graphTypeInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.directedInput, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 111);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // graphTypeLabel
            // 
            this.graphTypeLabel.AutoSize = true;
            this.graphTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTypeLabel.Location = new System.Drawing.Point(3, 26);
            this.graphTypeLabel.Name = "graphTypeLabel";
            this.graphTypeLabel.Size = new System.Drawing.Size(67, 27);
            this.graphTypeLabel.TabIndex = 0;
            this.graphTypeLabel.Text = "Typ grafu";
            this.graphTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphNameInput
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.graphNameInput, 2);
            this.graphNameInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphNameInput.Location = new System.Drawing.Point(76, 3);
            this.graphNameInput.Name = "graphNameInput";
            this.graphNameInput.Size = new System.Drawing.Size(205, 20);
            this.graphNameInput.TabIndex = 1;
            // 
            // graphTypeInput
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.graphTypeInput, 2);
            this.graphTypeInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTypeInput.FormattingEnabled = true;
            this.graphTypeInput.Items.AddRange(new object[] {
            "Macierz incydencji",
            "Macierz sąsiedztwa",
            "Macierz incydencji z wagami",
            "Macierz sąsiedztwa z wagami"});
            this.graphTypeInput.Location = new System.Drawing.Point(76, 29);
            this.graphTypeInput.Name = "graphTypeInput";
            this.graphTypeInput.Size = new System.Drawing.Size(205, 21);
            this.graphTypeInput.TabIndex = 2;
            // 
            // graphNameLabel
            // 
            this.graphNameLabel.AutoSize = true;
            this.graphNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphNameLabel.Location = new System.Drawing.Point(3, 0);
            this.graphNameLabel.Name = "graphNameLabel";
            this.graphNameLabel.Size = new System.Drawing.Size(67, 26);
            this.graphNameLabel.TabIndex = 3;
            this.graphNameLabel.Text = "Nazwa grafu";
            this.graphNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okButton.Location = new System.Drawing.Point(181, 79);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 29);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.Location = new System.Drawing.Point(76, 79);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 29);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // directedInput
            // 
            this.directedInput.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.directedInput, 2);
            this.directedInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directedInput.Location = new System.Drawing.Point(76, 56);
            this.directedInput.Name = "directedInput";
            this.directedInput.Size = new System.Drawing.Size(205, 17);
            this.directedInput.TabIndex = 3;
            this.directedInput.Text = "Jest skierowany";
            this.directedInput.UseVisualStyleBackColor = true;
            // 
            // NewGraphDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGraphDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nowy graf";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label graphTypeLabel;
        private System.Windows.Forms.Label graphNameLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox graphNameInput;
        private System.Windows.Forms.ComboBox graphTypeInput;
        private System.Windows.Forms.CheckBox directedInput;
    }
}
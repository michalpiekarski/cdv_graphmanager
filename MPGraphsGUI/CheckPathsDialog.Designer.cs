namespace MPGraphsGUI
{
    partial class CheckPathsDialog
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
            this.calculatePathsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.diamLabel = new System.Windows.Forms.Label();
            this.radLabel = new System.Windows.Forms.Label();
            this.graphCenterLabel = new System.Windows.Forms.Label();
            this.dimValue = new System.Windows.Forms.NumericUpDown();
            this.radValue = new System.Windows.Forms.NumericUpDown();
            this.graphCenterList = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dimValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radValue)).BeginInit();
            this.SuspendLayout();
            // 
            // calculatePathsButton
            // 
            this.calculatePathsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.calculatePathsButton.Location = new System.Drawing.Point(0, 0);
            this.calculatePathsButton.MinimumSize = new System.Drawing.Size(0, 50);
            this.calculatePathsButton.Name = "calculatePathsButton";
            this.calculatePathsButton.Size = new System.Drawing.Size(207, 50);
            this.calculatePathsButton.TabIndex = 0;
            this.calculatePathsButton.Text = "Wylicz średnicę, promień i centrum grafu";
            this.calculatePathsButton.UseVisualStyleBackColor = true;
            this.calculatePathsButton.Click += new System.EventHandler(this.calculatePathsButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.diamLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.graphCenterLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dimValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.graphCenterList, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(207, 211);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // diamLabel
            // 
            this.diamLabel.AutoSize = true;
            this.diamLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diamLabel.Location = new System.Drawing.Point(3, 0);
            this.diamLabel.Name = "diamLabel";
            this.diamLabel.Size = new System.Drawing.Size(76, 26);
            this.diamLabel.TabIndex = 0;
            this.diamLabel.Text = "Średnica:";
            this.diamLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radLabel
            // 
            this.radLabel.AutoSize = true;
            this.radLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel.Location = new System.Drawing.Point(3, 26);
            this.radLabel.Name = "radLabel";
            this.radLabel.Size = new System.Drawing.Size(76, 26);
            this.radLabel.TabIndex = 1;
            this.radLabel.Text = "Promień:";
            this.radLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // graphCenterLabel
            // 
            this.graphCenterLabel.AutoSize = true;
            this.graphCenterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphCenterLabel.Location = new System.Drawing.Point(3, 52);
            this.graphCenterLabel.Name = "graphCenterLabel";
            this.graphCenterLabel.Size = new System.Drawing.Size(76, 159);
            this.graphCenterLabel.TabIndex = 2;
            this.graphCenterLabel.Text = "Centrum grafu:";
            this.graphCenterLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dimValue
            // 
            this.dimValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dimValue.Enabled = false;
            this.dimValue.Location = new System.Drawing.Point(85, 3);
            this.dimValue.Name = "dimValue";
            this.dimValue.Size = new System.Drawing.Size(119, 20);
            this.dimValue.TabIndex = 3;
            // 
            // radValue
            // 
            this.radValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radValue.Enabled = false;
            this.radValue.Location = new System.Drawing.Point(85, 29);
            this.radValue.Name = "radValue";
            this.radValue.Size = new System.Drawing.Size(119, 20);
            this.radValue.TabIndex = 4;
            // 
            // graphCenterList
            // 
            this.graphCenterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphCenterList.Location = new System.Drawing.Point(85, 55);
            this.graphCenterList.Name = "graphCenterList";
            this.graphCenterList.Size = new System.Drawing.Size(119, 153);
            this.graphCenterList.TabIndex = 5;
            this.graphCenterList.UseCompatibleStateImageBehavior = false;
            this.graphCenterList.View = System.Windows.Forms.View.List;
            // 
            // CheckPathsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.calculatePathsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckPathsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckPathsDialog";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dimValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button calculatePathsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label diamLabel;
        private System.Windows.Forms.Label radLabel;
        private System.Windows.Forms.Label graphCenterLabel;
        private System.Windows.Forms.NumericUpDown dimValue;
        private System.Windows.Forms.NumericUpDown radValue;
        private System.Windows.Forms.ListView graphCenterList;
    }
}
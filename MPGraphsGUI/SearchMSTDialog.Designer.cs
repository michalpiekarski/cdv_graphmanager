﻿namespace MPGraphsGUI
{
    partial class SearchMSTDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.MSTButton = new System.Windows.Forms.Button();
            this.MSTResultOutput = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // MSTButton
            // 
            this.MSTButton.AutoSize = true;
            this.MSTButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MSTButton.Location = new System.Drawing.Point(0, 0);
            this.MSTButton.MinimumSize = new System.Drawing.Size(0, 50);
            this.MSTButton.Name = "MSTButton";
            this.MSTButton.Size = new System.Drawing.Size(250, 50);
            this.MSTButton.TabIndex = 1;
            this.MSTButton.Text = "Szukaj MST";
            this.MSTButton.UseVisualStyleBackColor = true;
            this.MSTButton.Click += new System.EventHandler(this.MSTButton_Click);
            // 
            // MSTResultOutput
            // 
            this.MSTResultOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MSTResultOutput.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MSTResultOutput.Location = new System.Drawing.Point(0, 50);
            this.MSTResultOutput.MaxLength = 1000000;
            this.MSTResultOutput.Multiline = true;
            this.MSTResultOutput.Name = "MSTResultOutput";
            this.MSTResultOutput.ReadOnly = true;
            this.MSTResultOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MSTResultOutput.Size = new System.Drawing.Size(250, 417);
            this.MSTResultOutput.TabIndex = 2;
            this.MSTResultOutput.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MSTResultOutput);
            this.splitContainer1.Panel1.Controls.Add(this.MSTButton);
            this.splitContainer1.Size = new System.Drawing.Size(735, 467);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 3;
            // 
            // SearchMSTDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 467);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchMSTDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchEulerDialog";
            this.TopMost = true;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MSTButton;
        private System.Windows.Forms.TextBox MSTResultOutput;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
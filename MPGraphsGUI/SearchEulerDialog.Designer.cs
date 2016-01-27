namespace MPGraphsGUI
{
    partial class SearchEulerDialog
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
            this.searchEulerButton = new System.Windows.Forms.Button();
            this.searchEulerResutOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // searchEulerButton
            // 
            this.searchEulerButton.AutoSize = true;
            this.searchEulerButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchEulerButton.Location = new System.Drawing.Point(0, 0);
            this.searchEulerButton.MinimumSize = new System.Drawing.Size(0, 50);
            this.searchEulerButton.Name = "searchEulerButton";
            this.searchEulerButton.Size = new System.Drawing.Size(443, 50);
            this.searchEulerButton.TabIndex = 0;
            this.searchEulerButton.Text = "Szukaj cuklu/scieżki Eulera";
            this.searchEulerButton.UseVisualStyleBackColor = true;
            this.searchEulerButton.Click += new System.EventHandler(this.searchEulerButton_Click);
            // 
            // searchEulerResutOutput
            // 
            this.searchEulerResutOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchEulerResutOutput.Location = new System.Drawing.Point(0, 50);
            this.searchEulerResutOutput.MaxLength = 1000000;
            this.searchEulerResutOutput.Multiline = true;
            this.searchEulerResutOutput.Name = "searchEulerResutOutput";
            this.searchEulerResutOutput.ReadOnly = true;
            this.searchEulerResutOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.searchEulerResutOutput.Size = new System.Drawing.Size(443, 210);
            this.searchEulerResutOutput.TabIndex = 1;
            this.searchEulerResutOutput.WordWrap = false;
            // 
            // SearchEulerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 260);
            this.Controls.Add(this.searchEulerResutOutput);
            this.Controls.Add(this.searchEulerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchEulerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchEulerDialog";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchEulerButton;
        private System.Windows.Forms.TextBox searchEulerResutOutput;
    }
}
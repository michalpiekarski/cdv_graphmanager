namespace MPGraphsGUI
{
    partial class CheckConnectedDialog
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
            this.strongConnectedButton = new System.Windows.Forms.Button();
            this.weakConnectedButton = new System.Windows.Forms.Button();
            this.strongConnectedResultCheckbox = new System.Windows.Forms.CheckBox();
            this.weakConnectedResultCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // strongConnectedButton
            // 
            this.strongConnectedButton.Location = new System.Drawing.Point(12, 12);
            this.strongConnectedButton.Name = "strongConnectedButton";
            this.strongConnectedButton.Size = new System.Drawing.Size(156, 23);
            this.strongConnectedButton.TabIndex = 0;
            this.strongConnectedButton.Text = "Sprawdź silną spójność";
            this.strongConnectedButton.UseVisualStyleBackColor = true;
            this.strongConnectedButton.Click += new System.EventHandler(this.strongConnectedButton_Click);
            // 
            // weakConnectedButton
            // 
            this.weakConnectedButton.Enabled = false;
            this.weakConnectedButton.Location = new System.Drawing.Point(12, 41);
            this.weakConnectedButton.Name = "weakConnectedButton";
            this.weakConnectedButton.Size = new System.Drawing.Size(156, 23);
            this.weakConnectedButton.TabIndex = 1;
            this.weakConnectedButton.Text = "Sprawdź słabą spójnośc";
            this.weakConnectedButton.UseVisualStyleBackColor = true;
            this.weakConnectedButton.Click += new System.EventHandler(this.weakConnectedButton_Click);
            // 
            // strongConnectedResultCheckbox
            // 
            this.strongConnectedResultCheckbox.AutoSize = true;
            this.strongConnectedResultCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.strongConnectedResultCheckbox.Enabled = false;
            this.strongConnectedResultCheckbox.Location = new System.Drawing.Point(174, 16);
            this.strongConnectedResultCheckbox.Name = "strongConnectedResultCheckbox";
            this.strongConnectedResultCheckbox.Size = new System.Drawing.Size(56, 17);
            this.strongConnectedResultCheckbox.TabIndex = 2;
            this.strongConnectedResultCheckbox.Text = "Wynik";
            this.strongConnectedResultCheckbox.UseVisualStyleBackColor = true;
            // 
            // weakConnectedResultCheckbox
            // 
            this.weakConnectedResultCheckbox.AutoSize = true;
            this.weakConnectedResultCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.weakConnectedResultCheckbox.Enabled = false;
            this.weakConnectedResultCheckbox.Location = new System.Drawing.Point(174, 45);
            this.weakConnectedResultCheckbox.Name = "weakConnectedResultCheckbox";
            this.weakConnectedResultCheckbox.Size = new System.Drawing.Size(56, 17);
            this.weakConnectedResultCheckbox.TabIndex = 3;
            this.weakConnectedResultCheckbox.Text = "Wynik";
            this.weakConnectedResultCheckbox.UseVisualStyleBackColor = true;
            // 
            // CheckConnectedDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 77);
            this.Controls.Add(this.weakConnectedResultCheckbox);
            this.Controls.Add(this.strongConnectedResultCheckbox);
            this.Controls.Add(this.weakConnectedButton);
            this.Controls.Add(this.strongConnectedButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckConnectedDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckConnectedDialog";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button strongConnectedButton;
        private System.Windows.Forms.Button weakConnectedButton;
        private System.Windows.Forms.CheckBox strongConnectedResultCheckbox;
        private System.Windows.Forms.CheckBox weakConnectedResultCheckbox;
    }
}
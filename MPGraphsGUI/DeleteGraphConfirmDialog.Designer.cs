namespace MPGraphsGUI
{
    partial class DeleteGraphConfirmDialog
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
            this.deleteLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteLabel
            // 
            this.deleteLabel.AutoSize = true;
            this.deleteLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteLabel.Location = new System.Drawing.Point(0, 0);
            this.deleteLabel.Name = "deleteLabel";
            this.deleteLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.deleteLabel.Size = new System.Drawing.Size(272, 21);
            this.deleteLabel.TabIndex = 0;
            this.deleteLabel.Text = "Czy na pewno chcesz usunąć ten graf?";
            this.deleteLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.noButton);
            this.panel1.Controls.Add(this.yesButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 40);
            this.panel1.TabIndex = 1;
            // 
            // yesButton
            // 
            this.yesButton.AutoSize = true;
            this.yesButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.yesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.yesButton.Location = new System.Drawing.Point(199, 0);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 40);
            this.yesButton.TabIndex = 0;
            this.yesButton.Text = "TAK";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // noButton
            // 
            this.noButton.AutoSize = true;
            this.noButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.noButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.noButton.Location = new System.Drawing.Point(124, 0);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 40);
            this.noButton.TabIndex = 1;
            this.noButton.Text = "NIE";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // DeleteGraphConfirmDialog
            // 
            this.AcceptButton = this.yesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.noButton;
            this.ClientSize = new System.Drawing.Size(274, 61);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.deleteLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteGraphConfirmDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeleteGraphConfirmDialog";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deleteLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button yesButton;
    }
}
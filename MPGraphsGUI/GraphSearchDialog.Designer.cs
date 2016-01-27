namespace MPGraphsGUI
{
    partial class GraphSearchDialog
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
            this.searchButton = new System.Windows.Forms.Button();
            this.vertexIndexLabel = new System.Windows.Forms.Label();
            this.vertexIndexInput = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.searchResultOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.vertexIndexInput)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.AutoSize = true;
            this.searchButton.Location = new System.Drawing.Point(262, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(90, 23);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "Wyszukaj";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // vertexIndexLabel
            // 
            this.vertexIndexLabel.AutoSize = true;
            this.vertexIndexLabel.Location = new System.Drawing.Point(12, 9);
            this.vertexIndexLabel.Name = "vertexIndexLabel";
            this.vertexIndexLabel.Size = new System.Drawing.Size(188, 13);
            this.vertexIndexLabel.TabIndex = 1;
            this.vertexIndexLabel.Text = "Przeszukaj od wierzchołka o indeksie:";
            // 
            // vertexIndexInput
            // 
            this.vertexIndexInput.AutoSize = true;
            this.vertexIndexInput.Location = new System.Drawing.Point(206, 7);
            this.vertexIndexInput.MinimumSize = new System.Drawing.Size(50, 0);
            this.vertexIndexInput.Name = "vertexIndexInput";
            this.vertexIndexInput.Size = new System.Drawing.Size(50, 20);
            this.vertexIndexInput.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(359, 0);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // searchResultOutput
            // 
            this.searchResultOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchResultOutput.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchResultOutput.Location = new System.Drawing.Point(0, 34);
            this.searchResultOutput.MaxLength = 1000000;
            this.searchResultOutput.MinimumSize = new System.Drawing.Size(0, 300);
            this.searchResultOutput.Multiline = true;
            this.searchResultOutput.Name = "searchResultOutput";
            this.searchResultOutput.ReadOnly = true;
            this.searchResultOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.searchResultOutput.Size = new System.Drawing.Size(359, 300);
            this.searchResultOutput.TabIndex = 4;
            // 
            // GraphSearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 334);
            this.Controls.Add(this.searchResultOutput);
            this.Controls.Add(this.vertexIndexLabel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.vertexIndexInput);
            this.Controls.Add(this.searchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GraphSearchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GraphSearchDialog";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.vertexIndexInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label vertexIndexLabel;
        private System.Windows.Forms.NumericUpDown vertexIndexInput;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox searchResultOutput;
    }
}
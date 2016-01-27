namespace MPGraphsGUI
{
    partial class ShowListOfNeighbours
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
            this.vertexIndexInput = new System.Windows.Forms.NumericUpDown();
            this.incidentList = new System.Windows.Forms.ListView();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vertexIndexInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podaj indeks wierzchołka dla którego ma zostać wyświetlona lista sąsiadów:";
            // 
            // vertexIndexInput
            // 
            this.vertexIndexInput.Location = new System.Drawing.Point(12, 44);
            this.vertexIndexInput.Name = "vertexIndexInput";
            this.vertexIndexInput.Size = new System.Drawing.Size(87, 20);
            this.vertexIndexInput.TabIndex = 1;
            // 
            // incidentList
            // 
            this.incidentList.Location = new System.Drawing.Point(207, 9);
            this.incidentList.Name = "incidentList";
            this.incidentList.Size = new System.Drawing.Size(95, 280);
            this.incidentList.TabIndex = 2;
            this.incidentList.UseCompatibleStateImageBehavior = false;
            this.incidentList.View = System.Windows.Forms.View.List;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(126, 44);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Szukaj";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // ShowListOfNeighbours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 301);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.incidentList);
            this.Controls.Add(this.vertexIndexInput);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowListOfNeighbours";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowListOfNeighbours";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.vertexIndexInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown vertexIndexInput;
        private System.Windows.Forms.ListView incidentList;
        private System.Windows.Forms.Button searchButton;
    }
}
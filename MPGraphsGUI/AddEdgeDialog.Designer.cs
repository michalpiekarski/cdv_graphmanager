﻿namespace MPGraphsGUI
{
    partial class AddEdgeDialog
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.vertexIndexAInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.vertexIndexBInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.weightsLabel = new System.Windows.Forms.Label();
            this.weightInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.vertexIndexAInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertexIndexBInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightInput)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(116, 118);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(197, 118);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // vertexIndexAInput
            // 
            this.vertexIndexAInput.Location = new System.Drawing.Point(195, 40);
            this.vertexIndexAInput.Name = "vertexIndexAInput";
            this.vertexIndexAInput.Size = new System.Drawing.Size(77, 20);
            this.vertexIndexAInput.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Wierzchołek B:";
            // 
            // vertexIndexBInput
            // 
            this.vertexIndexBInput.Location = new System.Drawing.Point(195, 66);
            this.vertexIndexBInput.Name = "vertexIndexBInput";
            this.vertexIndexBInput.Size = new System.Drawing.Size(77, 20);
            this.vertexIndexBInput.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Wierzchołek A:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Podaj indeksy wierzchołków do połączenia krawędzią:";
            // 
            // weightsLabel
            // 
            this.weightsLabel.AutoSize = true;
            this.weightsLabel.Location = new System.Drawing.Point(149, 94);
            this.weightsLabel.Name = "weightsLabel";
            this.weightsLabel.Size = new System.Drawing.Size(39, 13);
            this.weightsLabel.TabIndex = 14;
            this.weightsLabel.Text = "Waga:";
            // 
            // weightInput
            // 
            this.weightInput.Location = new System.Drawing.Point(195, 92);
            this.weightInput.Name = "weightInput";
            this.weightInput.Size = new System.Drawing.Size(77, 20);
            this.weightInput.TabIndex = 15;
            // 
            // AddEdgeDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(284, 153);
            this.ControlBox = false;
            this.Controls.Add(this.weightInput);
            this.Controls.Add(this.weightsLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.vertexIndexAInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vertexIndexBInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEdgeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEdgeDialog";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.vertexIndexAInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertexIndexBInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown vertexIndexAInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown vertexIndexBInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label weightsLabel;
        private System.Windows.Forms.NumericUpDown weightInput;
    }
}
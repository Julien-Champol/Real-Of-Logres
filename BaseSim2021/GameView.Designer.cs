﻿
namespace BaseSim2021
{
    partial class GameView
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
            this.diffLabel = new System.Windows.Forms.Label();
            this.turnLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.gloryLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // diffLabel
            // 
            this.diffLabel.AutoSize = true;
            this.diffLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.diffLabel.Location = new System.Drawing.Point(871, 375);
            this.diffLabel.Name = "diffLabel";
            this.diffLabel.Size = new System.Drawing.Size(28, 17);
            this.diffLabel.TabIndex = 2;
            this.diffLabel.Text = "     ";
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.turnLabel.Location = new System.Drawing.Point(1091, 375);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(24, 17);
            this.turnLabel.TabIndex = 3;
            this.turnLabel.Text = "    ";
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.moneyLabel.Location = new System.Drawing.Point(871, 487);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(20, 17);
            this.moneyLabel.TabIndex = 4;
            this.moneyLabel.Text = "   ";
            // 
            // gloryLabel
            // 
            this.gloryLabel.AutoSize = true;
            this.gloryLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gloryLabel.Location = new System.Drawing.Point(1095, 487);
            this.gloryLabel.Name = "gloryLabel";
            this.gloryLabel.Size = new System.Drawing.Size(20, 17);
            this.gloryLabel.TabIndex = 5;
            this.gloryLabel.Text = "   ";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(676, 375);
            this.nextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(107, 26);
            this.nextButton.TabIndex = 6;
            this.nextButton.Text = "Tour Suivant";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(272, 423);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(124, 22);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.Visible = false;
            this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputTextBox_KeyDown);
            // 
            // outputListBox
            // 
            this.outputListBox.FormattingEnabled = true;
            this.outputListBox.HorizontalScrollbar = true;
            this.outputListBox.ItemHeight = 16;
            this.outputListBox.Location = new System.Drawing.Point(879, 556);
            this.outputListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.outputListBox.Name = "outputListBox";
            this.outputListBox.Size = new System.Drawing.Size(236, 84);
            this.outputListBox.TabIndex = 1;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 939);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.gloryLabel);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.diffLabel);
            this.Controls.Add(this.outputListBox);
            this.Controls.Add(this.inputTextBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameView";
            this.Text = "Fenêtre Principale";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameView_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameView_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameView_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label diffLabel;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Label gloryLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.ListBox outputListBox;
    }
}


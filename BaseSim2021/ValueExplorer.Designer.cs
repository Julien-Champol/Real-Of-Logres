
namespace BaseSim2021
{
    partial class ValueExplorer
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
            this.nomLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            this.valueNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.secondCost = new System.Windows.Forms.Label();
            this.firstCost = new System.Windows.Forms.Label();
            this.activityLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.histogrammeTitle = new System.Windows.Forms.Label();
            this.lienValeur = new System.Windows.Forms.Label();
            this.coûtDirect = new System.Windows.Forms.Label();
            this.gloireDirect = new System.Windows.Forms.Label();
            this.desRealTimeCost = new System.Windows.Forms.Label();
            this.desRealTimeGlory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.BackColor = System.Drawing.Color.Red;
            this.nomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomLabel.Location = new System.Drawing.Point(22, 18);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(51, 20);
            this.nomLabel.TabIndex = 0;
            this.nomLabel.Text = "label1";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(23, 59);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(45, 16);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "label2";
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueLabel.Location = new System.Drawing.Point(50, 142);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(41, 15);
            this.valueLabel.TabIndex = 3;
            this.valueLabel.Text = "label1";
            // 
            // valueNumUpDown
            // 
            this.valueNumUpDown.Location = new System.Drawing.Point(175, 142);
            this.valueNumUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valueNumUpDown.Name = "valueNumUpDown";
            this.valueNumUpDown.Size = new System.Drawing.Size(120, 20);
            this.valueNumUpDown.TabIndex = 4;
            this.valueNumUpDown.ValueChanged += new System.EventHandler(this.valueNumUpDown_ValueChanged);
            // 
            // secondCost
            // 
            this.secondCost.AutoSize = true;
            this.secondCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondCost.Location = new System.Drawing.Point(50, 254);
            this.secondCost.Name = "secondCost";
            this.secondCost.Size = new System.Drawing.Size(41, 15);
            this.secondCost.TabIndex = 5;
            this.secondCost.Text = "label1";
            // 
            // firstCost
            // 
            this.firstCost.AutoSize = true;
            this.firstCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstCost.Location = new System.Drawing.Point(50, 201);
            this.firstCost.Name = "firstCost";
            this.firstCost.Size = new System.Drawing.Size(41, 15);
            this.firstCost.TabIndex = 6;
            this.firstCost.Text = "label2";
            // 
            // activityLabel
            // 
            this.activityLabel.AutoSize = true;
            this.activityLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.activityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityLabel.Location = new System.Drawing.Point(50, 329);
            this.activityLabel.Name = "activityLabel";
            this.activityLabel.Size = new System.Drawing.Size(46, 18);
            this.activityLabel.TabIndex = 7;
            this.activityLabel.Text = "label1";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(846, 295);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(846, 355);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // histogrammeTitle
            // 
            this.histogrammeTitle.AutoSize = true;
            this.histogrammeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogrammeTitle.Location = new System.Drawing.Point(450, 107);
            this.histogrammeTitle.Name = "histogrammeTitle";
            this.histogrammeTitle.Size = new System.Drawing.Size(41, 15);
            this.histogrammeTitle.TabIndex = 10;
            this.histogrammeTitle.Text = "label1";
            // 
            // lienValeur
            // 
            this.lienValeur.AutoSize = true;
            this.lienValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lienValeur.Location = new System.Drawing.Point(687, 107);
            this.lienValeur.Name = "lienValeur";
            this.lienValeur.Size = new System.Drawing.Size(41, 15);
            this.lienValeur.TabIndex = 11;
            this.lienValeur.Text = "label1";
            // 
            // coûtDirect
            // 
            this.coûtDirect.AutoSize = true;
            this.coûtDirect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coûtDirect.Location = new System.Drawing.Point(687, 201);
            this.coûtDirect.Name = "coûtDirect";
            this.coûtDirect.Size = new System.Drawing.Size(41, 15);
            this.coûtDirect.TabIndex = 12;
            this.coûtDirect.Text = "label1";
            // 
            // gloireDirect
            // 
            this.gloireDirect.AutoSize = true;
            this.gloireDirect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gloireDirect.Location = new System.Drawing.Point(687, 303);
            this.gloireDirect.Name = "gloireDirect";
            this.gloireDirect.Size = new System.Drawing.Size(41, 15);
            this.gloireDirect.TabIndex = 13;
            this.gloireDirect.Text = "label1";
            // 
            // desRealTimeCost
            // 
            this.desRealTimeCost.AutoSize = true;
            this.desRealTimeCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desRealTimeCost.Location = new System.Drawing.Point(687, 164);
            this.desRealTimeCost.Name = "desRealTimeCost";
            this.desRealTimeCost.Size = new System.Drawing.Size(41, 15);
            this.desRealTimeCost.TabIndex = 14;
            this.desRealTimeCost.Text = "label1";
            // 
            // desRealTimeGlory
            // 
            this.desRealTimeGlory.AutoSize = true;
            this.desRealTimeGlory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desRealTimeGlory.Location = new System.Drawing.Point(687, 265);
            this.desRealTimeGlory.Name = "desRealTimeGlory";
            this.desRealTimeGlory.Size = new System.Drawing.Size(41, 15);
            this.desRealTimeGlory.TabIndex = 15;
            this.desRealTimeGlory.Text = "label1";
            // 
            // ValueExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 521);
            this.Controls.Add(this.desRealTimeGlory);
            this.Controls.Add(this.desRealTimeCost);
            this.Controls.Add(this.gloireDirect);
            this.Controls.Add(this.coûtDirect);
            this.Controls.Add(this.lienValeur);
            this.Controls.Add(this.histogrammeTitle);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.activityLabel);
            this.Controls.Add(this.firstCost);
            this.Controls.Add(this.secondCost);
            this.Controls.Add(this.valueNumUpDown);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.nomLabel);
            this.Name = "ValueExplorer";
            this.Text = "ValueExplorer";
            this.Load += new System.EventHandler(this.ValueExplorer_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ValueExplorer_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.valueNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nomLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label secondCost;
        private System.Windows.Forms.Label firstCost;
        private System.Windows.Forms.Label activityLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.NumericUpDown valueNumUpDown;
        private System.Windows.Forms.Label histogrammeTitle;
        private System.Windows.Forms.Label lienValeur;
        private System.Windows.Forms.Label coûtDirect;
        private System.Windows.Forms.Label gloireDirect;
        private System.Windows.Forms.Label desRealTimeCost;
        private System.Windows.Forms.Label desRealTimeGlory;
    }
}
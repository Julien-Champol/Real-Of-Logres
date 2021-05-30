using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2021
{
    public partial class ValueExplorer : Form
    {
        private IndexedValue theIndexedValue;
        public IndexedValue TheIndexedValue { get { return this.theIndexedValue; } }

        public int numericUpDownValue { get { return (int)valueNumUpDown.Value; } }

        public ValueExplorer(IndexedValue index)
        {
            InitializeComponent();
            this.theIndexedValue = index;
        }

        /// <summary>
        /// The method handling the load event from our window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueExplorer_Load(object sender, EventArgs e)
        {
            String[] presentationFinale = Regex.Split(TheIndexedValue.CompletePresentation(), Environment.NewLine);
            nomLabel.Text = presentationFinale[0];
            descriptionLabel.Text = presentationFinale[1];
            valueLabel.Text = presentationFinale[2];
            valueNumUpDown.Value = TheIndexedValue.Value;
            firstCost.Text = presentationFinale[3];
            secondCost.Text = presentationFinale[4];
            activityLabel.Text = presentationFinale[5];
            histogrammeTitle.Text = "Valeurs en relation :";
        }

        /// <summary>
        /// The method used to display the histogram
        /// </summary>
        /// <param name="g"></param>
        public void histogramme_Draw(Graphics g)
        {
            Rectangle histogramme = new Rectangle(335, 147, 290, 340);
            Pen histogrammePen = new Pen(Color.Black, 3);
            g.DrawRectangle(histogrammePen, histogramme);

            int y = 155;
            foreach (IndexedValue link in TheIndexedValue.OutputWeights.Keys)
            {
                Point drawPoint = new Point(345, y);
                g.DrawString(link.Name, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, drawPoint);
                y += 40;
                TrackBar effect = new TrackBar();
                if (TheIndexedValue.OutputWeights[link] < 0)
                {
                    effect.Location = new Point(436, y - 40);
                    effect.Value = 0;
                    effect.Maximum = 4;
                    effect.Show();
                    Controls.Add(effect);
                }
                else if (TheIndexedValue.OutputWeights[link] > 0
                  && TheIndexedValue.OutputWeights[link].ToString().Contains("0,00"))
                {
                    effect.Location = new Point(436, y - 40);
                    effect.Value = 2;
                    effect.Maximum = 4;
                    effect.Show();
                    Controls.Add(effect);
                }
                else if (TheIndexedValue.OutputWeights[link] > 0
                 && TheIndexedValue.OutputWeights[link].ToString().Contains("0,0"))
                {
                    effect.Location = new Point(436, y - 40);
                    effect.Value = 3;
                    effect.Maximum = 4;
                    effect.Show();
                    Controls.Add(effect);
                }
                else if (TheIndexedValue.OutputWeights[link] > 0
               && TheIndexedValue.OutputWeights[link].ToString().Contains("0,00"))
                {
                    effect.Location = new Point(436, y - 40);
                    effect.Value = 4;
                    effect.Maximum = 4;
                    effect.Show();
                    Controls.Add(effect);
                }

            }
        }

        /// <summary>
        /// Method mainly used to call the histogramme_Draw one on start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueExplorer_Paint(object sender, PaintEventArgs e)
        {
            histogramme_Draw(e.Graphics);
        }

        /// <summary>
        /// Handling the value changing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valueNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)valueNumUpDown.Value;
            int mCost = 0;
            int gCost = 0;
            lienValeur.Text = "Modifications en direct :";
            desRealTimeCost.Text = "Coût monétaire en temps réel";
            desRealTimeGlory.Text = "Coût (gloire) en temps réel";
            TheIndexedValue?.PreviewPolicyChange(ref val, out mCost, out gCost);
            coûtDirect.Text = mCost.ToString();
            gloireDirect.Text = gCost.ToString();
        }
    }
}

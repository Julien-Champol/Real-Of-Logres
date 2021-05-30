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
            Rectangle histogramme = new Rectangle(335, 147, 290, 310);
            Pen histogrammePen = new Pen(Color.Black, 3);
            g.DrawRectangle(histogrammePen, histogramme);

            int y = 155;
            foreach (IndexedValue link in TheIndexedValue.OutputWeights.Keys)
            {
                Point drawPoint = new Point(345, y);
                g.DrawString(link.Name, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, drawPoint);
                y += 40;
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
    }
}

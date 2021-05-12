using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2021
{
    /// <summary>
    /// Class representing data about the display methods of the IndexedValues.
    /// </summary>
    class IndexedValueView
    {

        private IndexedValue IndexedValue;

        /* Coordinate */
        private int x;
        private int y;

        /* Size of the rectangle. */
        private int widthRectangle;
        public int WidthRectangle { get { return widthRectangle; } set => widthRectangle = value; }

        private int heightRectangle;
        public int HeightRectangle { get { return heightRectangle; } set => heightRectangle = value; }

        /*The color of the rectangle */
        private Color color;


        public Color Color { set => color = value; }

        /// <summary>
        /// Parametirized constructor of the IndexedValueView class.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="coordinates"></param>
        public IndexedValueView(IndexedValue index, Point coordinates)
        {
            this.IndexedValue = index;
            this.x = coordinates.X;
            this.y = coordinates.Y;
            this.widthRectangle = 70;
            this.heightRectangle = 70;
            this.color = Color.CadetBlue;
        }

        /// <summary>
        /// Draw method of the IndexedValueView class.
        /// </summary>
        /// <param name="e"></param>
        public void IndexedValueView_Draw(Graphics g)
        {
            Pen rectanglePen = new Pen(this.color, 3);
            int absciss = this.x;
            int ordinate = this.y;
            int width = this.widthRectangle;
            int height = this.heightRectangle;
            Rectangle displayedRectangle = new Rectangle(absciss, ordinate, width, height);
            g.DrawRectangle(rectanglePen, displayedRectangle);
            g.DrawString(IndexedValue.Name, new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Red, displayedRectangle);
        }

    }
}

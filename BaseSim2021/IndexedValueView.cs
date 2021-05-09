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
        public int WidthRectangle { set => widthRectangle = value; }

        private int heightRectangle;
        public int HeightRectangle { set => heightRectangle = value; }

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
            this.widthRectangle = 80;
            this.heightRectangle = 80;
            this.color = Color.Red;
        }

        /// <summary>
        /// Draw method of the IndexedValueView class.
        /// </summary>
        /// <param name="e"></param>
        public void IndexedValueView_Draw(PaintEventArgs e)
        {
            Pen rectanglePen = new Pen(this.color, 3);
            int absciss = this.x;
            int ordinate = this.y;
            int width = this.widthRectangle;
            int height = this.heightRectangle;
            e.Graphics.DrawRectangle(rectanglePen, absciss, ordinate, width, height);
        }

    }
}

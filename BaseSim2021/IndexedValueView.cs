using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2021
{
    class IndexedValueView
    {

        private IndexedValue IndexedValue;

        /* Coordinate */
        private int x;
        private int y;

        /* Size of the rectangle. */
        private int widthRectangle;
        private int heightRectangle;

        /*The color of the rectangle */
        private Color color;

        public IndexedValueView(IndexedValue index, int rectangleAbsciss, int rectangleOrdinate, int width, int height, Color color)
        {
            this.IndexedValue = index;
            this.x = rectangleAbsciss;
            this.y = rectangleOrdinate;
            this.widthRectangle = width;
            this.heightRectangle = height;
            this.color = color;
        }

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

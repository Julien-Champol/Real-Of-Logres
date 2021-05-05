using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSim2021
{
    class IndexedValueView
    {

        private IndexedValue IndexedValue;

        /* Coordinate */
        private int x;
        private int y;

        /* Size of the rectangle. */
        private int sizeRecatngle;

        /*The color of the rectangle */
        private Color color;

        public IndexedValueView(IndexedValue index, int rectangleAbsciss, int rectangleOrdinate, int size, Color color)
        {
            this.IndexedValue = index;
            this.x = rectangleAbsciss;
            this.y = rectangleOrdinate;
            this.sizeRecatngle = size;
            this.color = color;
        }

        public void IndexedValueView_Draw()
        {

        }

    }
}

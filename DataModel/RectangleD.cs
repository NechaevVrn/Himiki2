using System;
using System.Collections.Generic;
using System.Text;

namespace QuadroSoft.Enose.DataModel
{
    public struct RectangleD
    {
        double x, y, width, height;

        public RectangleD(double x, double y, double width, double height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public double Bottom
        {
            get { return y + height; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double Left
        {
            get { return x; }
        }

        public double Right
        {
            get { return x + width; }
        }

        public double Top
        {
            get { return y; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }


        public bool Contains(PointD pt)
        {
            return (pt.Y >= y) && (pt.Y <= y + height) && (pt.X >= x) && (pt.X <= x + height);
        }
    }
}

using System;                       

namespace QuadroSoft.Enose.DataModel
{
    public struct PointD
    {
        private double x, y;

        public PointD(double x, double y)
        {
            this.x = x;
            this.y = y;
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

        public override string ToString()
        {
            return "[" + x + "; " + y + "]";
        }
    }
}

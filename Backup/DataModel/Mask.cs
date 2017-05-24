using System;
using System.Collections.Generic;
using System.Text;

namespace QuadroSoft.Enose.DataModel
{
    public class Mask
    {
        private int id;
        private string name;
        double[] points;

        public Mask(int ID, string Name, double[] points)
        {
            this.id = ID;
            this.name = Name;
            this.points = points;
        }

        public int ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double[] TimePoints
        {
            get { return points; }
            set { points = value; }
        }

        public override string ToString()
        {
            return Name;//+ " [" + id + "]";
        }

    }
}

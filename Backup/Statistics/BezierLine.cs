using System;
using System.Collections.Generic;
using System.Text;
using QuadroSoft.Enose.DataModel;

namespace QuadroSoft.Enose.Statistics
{
    public class BezierLine
    {
        private PointD[] points;
        private double distance;

       
        public BezierLine(PointD[] points, double distance)
        {
            this.points = points;
            this.distance = distance;
        }


        public PointD[] GetPoints(int GradesPerInterval)
        {
            double eps = 0.001d;
            List<PointD> result = new List<PointD>();

            double t = 0d;
            double dt = 1d / GradesPerInterval;
            double dx, dy;
            double ddx, ddy; 

            for (int i = 0; i < points.Length - 1; i++)
            {
                PointD P0, P1, P2, P3;

                P0 = points[i];
                P3 = points[i + 1];

                ddx = points[i + 1].X - points[i].X;
                ddy = points[i + 1].Y - points[i].Y;

                if (i == 0)
                    P1 = P0;
                else
                {
                    dx = points[i + 1].X - points[i - 1].X;
                    dy = points[i + 1].Y - points[i - 1].Y;

                    double k = 0d;

                    if (Math.Abs(dx) > eps)
                    {
                        k = dy / dx;
                        double d = distance;// / Math.Sqrt(k * k + 1);
                        P1 = new PointD(P0.X + d, P0.Y + k * d);
                    }
                    else
                    {
                        P1 = new PointD(P0.X, P0.Y + distance * Math.Sign(dy));
                    }
                }

                if (i == points.Length - 2)
                    P2 = P3;
                else
                {

                    dx = points[i + 2].X - points[i].X;
                    dy = points[i + 2].Y - points[i].Y;

                    double k = 0d;

                    if (Math.Abs(dx) > eps)
                    {
                        k = dy / dx;
                        double d = distance;// / Math.Sqrt(k * k + 1);
                            P2 = new PointD(P3.X - d, P3.Y - k * d);
                    }
                    else
                        P2 = new PointD(P3.X, P3.Y - distance * Math.Sign(dy));

                }
                double x; 
                double y;

                
                for (t = 0d; t < 1d; t += dt)
                {
                    x = P0.X * (1 - t) * (1 - t) * (1 - t) +
                        P1.X * t * (1 - t) * (1 - t) * 3 +
                        P2.X * t * t * (1 - t) * 3 +
                        P3.X * t * t * t;

                    y = P0.Y * (1 - t) * (1 - t) * (1 - t) +
                        P1.Y * t * (1 - t) * (1 - t) * 3 +
                        P2.Y * t * t * (1 - t) * 3 +
                        P3.Y * t * t * t;

                    result.Add(new PointD(x, y));
                }
            }


            result.Add(points[points.Length - 1]);
           return result.ToArray();
        }
    }
}

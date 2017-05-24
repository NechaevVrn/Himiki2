using System;
using System.Collections.Generic;
using System.Text;

namespace QuadroSoft.Enose.DataModel
{
    public class Measure
    {
        private MeasureData measure;
        private Mask mask;
        double timeCorr;

        public Measure(MeasureData meas, Mask mask, double timeCorrecture)
        {
            this.measure = meas;
            this.mask = mask;
            timeCorr = timeCorrecture;
        }

        public Dictionary<Sensor, List<PointD>> getMaskData()
        {
            DateTime start = measure.StartTime;
            Dictionary<Sensor, List<PointD>> res = new Dictionary<Sensor,List<PointD>>();

            foreach (Sensor sen in measure.Data.Keys)
                res.Add(sen, new List<PointD>());

            
            foreach (double sek in mask.TimePoints)
            {
                Dictionary<Sensor, double> da = measure.GetDataAtTheMoment(start.AddSeconds(sek - timeCorr));
                foreach (Sensor sen in da.Keys)
                    if (res.ContainsKey(sen))
                        if (sek >= 0 && sek <= measure.FullMeasureLength)
                            res[sen].Add(new PointD(sek, da[sen]));
            }

            return res;
        }

        public MeasureData MeasureData
        {
            get { return measure; }
        }

        public double MaxDelta
        {
            get
            {
               
                Dictionary<Sensor, List<PointD>> data = getMaskData();
                double d = double.MinValue;
                Dictionary<Sensor, double> start = measure.StartValues;
                foreach (Sensor s in data.Keys)
                    foreach (PointD p in data[s])
                        if (start[s] - p.Y > d) d = start[s] - p.Y;

                return d;
            }
        }

        public double MinDelta
        {
            get
            {
                Dictionary<Sensor, List<PointD>> data = getMaskData();
                Dictionary<Sensor, double> start = measure.StartValues;
                double d = double.MaxValue;
                foreach (Sensor s in data.Keys)
                    foreach (PointD p in data[s])
                        if (start[s] - p.Y< d) d =  start[s] - p.Y;
                return d;
            }
        }

        public double MaxAbsDelta
        {
            get
            {
                Dictionary<Sensor, List<PointD>> data = getMaskData();
                Dictionary<Sensor, double> start = measure.StartValues;
                double d = 0d;
                foreach (Sensor s in data.Keys)
                    foreach (PointD p in data[s])
                        if (Math.Abs(p.Y - start[s]) > Math.Abs(d)) d = start[s] - p.Y;
                return d;
            }
        }

        public double MinAbsDelta
        {
            get
            {
                Dictionary<Sensor, double> start = measure.StartValues;
                Dictionary<Sensor, List<PointD>> data = getMaskData();
                double d = double.MaxValue;
                foreach (Sensor s in data.Keys)
                    foreach (PointD p in data[s])
                        if (Math.Abs(p.Y - start[s]) < Math.Abs(d)) d = start[s] - p.Y;
                return d;
            }
        }

        public double area(List<Sensor> sens)
        {
            if (mask == null) return 0d;
            double result = 0d;

            Dictionary<Sensor, List<PointD>> data = getMaskData();

            Dictionary<Sensor, double> start = measure.StartValues;

            foreach (Sensor sensor in sens)//data.Keys)
            {
                List<PointD> points = data[sensor];

                for (int i = 0; (i + 1) < points.Count; i++)
                {
                    double y1, y2;
                    double dx = points[i + 1].X - points[i].X;
                    y1 = start[sensor] - points[i].Y;
                    y2 = start[sensor] - points[i + 1].Y;
                    
                    if (y1 * y2 >= 0)
                        result += Math.Abs((y1 + y2) / 2d * dx);
                    else
                    {
                        double dx1 = (Math.Abs(y1) / Math.Abs(y1) + Math.Abs(y2)) * dx;
                        result += Math.Abs( (dx1 * Math.Abs(y1) + (dx - dx1) * Math.Abs(y2)) / 2d);
                    }

                }
            }
            
            return result;
        }

        public static MeasureData calculateMedianMeasure(Dictionary<MeasureData, double> measuresCorrecture, Mask mask, double length)
        {
            Dictionary<Sensor, Dictionary<double, double>> data = new Dictionary<Sensor,Dictionary<double, double>>();
            Dictionary<Sensor, int> dividers = new Dictionary<Sensor,int>();
            Dictionary<MeasureData, Dictionary<Sensor, double>> inits = new Dictionary<MeasureData, Dictionary<Sensor, double>>();
            Dictionary<Sensor, double> starts = new Dictionary<Sensor, double>();

            foreach (MeasureData md in measuresCorrecture.Keys)
                inits.Add(md, md.StartValues);

            foreach (MeasureData md in measuresCorrecture.Keys)
            {
                Dictionary<Sensor, double> sv = md.StartValues;
                foreach (Sensor s in md.AllData.Keys)
                {
                    if (!data.ContainsKey(s)) data.Add(s,new Dictionary<double, double>());
                    
                    if (!dividers.ContainsKey(s))
                        dividers.Add(s, 1);
                    else
                        dividers[s] = dividers[s] + 1;

                    if (!starts.ContainsKey(s))
                        starts.Add(s, sv[s]);
                    else
                        starts[s] = starts[s] + sv[s];
                }
            }


            Dictionary<Sensor, double> _starts = new Dictionary<Sensor, double>();
            foreach (Sensor s in starts.Keys)
                _starts.Add(s, starts[s] / dividers[s]);
                

            
            List<double> ticks = new List<double>();


            foreach (double tick in mask.TimePoints)
                if (tick <= length)
                    ticks.Add(tick);

            foreach (double tick in ticks)
            {
                foreach (Sensor ssen in data.Keys)
                    data[ssen].Add(tick, 0d);

                foreach (MeasureData md in measuresCorrecture.Keys)
                {
                    Dictionary<Sensor, double> momdat = md.GetDataAtTheMoment(md.StartTime.AddSeconds(tick - measuresCorrecture[md]));
                    foreach (Sensor ssen in momdat.Keys)
                        data[ssen][tick] = data[ssen][tick] - (momdat[ssen] - inits[md][ssen]);
                }

                foreach (Sensor ssen in data.Keys)
                    data[ssen][tick] = data[ssen][tick] / dividers[ssen];
            }

               
                
            Dictionary<Sensor, List<PointD>> fdata = new Dictionary<Sensor,List<PointD>>();

            foreach (Sensor sen in data.Keys)
            {
                fdata.Add(sen, new List<PointD>());
                fdata[sen].Add(new PointD(-1d, _starts[sen]));
                foreach (double time in data[sen].Keys)
                    fdata[sen].Add(new PointD(time, _starts[sen] - data[sen][time]));
            }


            MeasureData result = new MeasureData(fdata, -1, "", DateTime.Now, "", -1, length, 1, false, mask);
            return result;
        }

    }
}

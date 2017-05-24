using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace QuadroSoft.Enose.DataModel
{
    public class MeasureData
    {
        private Dictionary<Sensor, List<PointD>> data;
        private Dictionary<Sensor, Dictionary<double, double>> dispdata = null;
        private Dictionary<Sensor, bool> used;

        string name, description;
        DateTime dateTime;
        int gid, id;
        double fullLength, Interval;
        bool isMeasured;
        Mask mask;

        public MeasureData(
            Dictionary< Sensor, List<PointD>> data, 
            int measureid,
            string name, 
            DateTime time,
            string description, 
            int GID, 
            double fullLength, 
            double Interval,
            bool isMeasured,
            Mask mask
            )

        {
            this.data = data;
            used = new Dictionary<Sensor,bool>();
            foreach (Sensor s in data.Keys)
                used.Add(s, true);
            this.name = name;
            this.description = description;
            this.id = measureid;
            this.dateTime = time;
            this.gid = GID;
            this.fullLength = fullLength;
            this.Interval = Interval;
            this.isMeasured = isMeasured;
            this.mask = mask;
        }


        public MeasureData
            (
            Dictionary<DateTime, double[]> data,
            double[] init,
            bool[] used,
            Sensor[] sensors,
            int measureid,
            string name,
            string description,
            int GID,
            double fullLength,
            double Interval,
            bool isMeasured,
            Mask mask
            )
        {
            Dictionary<Sensor, List<PointD>> measdata = new Dictionary<Sensor, List<PointD>>();
            this.used = new Dictionary<Sensor,bool>();
            Dictionary<DateTime, double[]>.Enumerator en = data.GetEnumerator();
            en.MoveNext();
            DateTime start = en.Current.Key;

            this.dateTime = start;
            for (int i = 0; i < used.Length; i++)
            {

                Sensor sensor = sensors[i];
                this.used.Add(sensor, used[i]);

                measdata.Add(sensor, new List<PointD>());

                measdata[sensor].Add(new PointD(-1d, init[i]));
                foreach (DateTime dt in data.Keys)
                    measdata[sensor].Add(new PointD((0d + dt.Ticks - start.Ticks) / 10e6d, data[dt][i]));

            }
            this.data = measdata;
            this.name = name;
            this.description = description;
            this.id = measureid;
            this.gid = GID;
            this.fullLength = fullLength;
            this.Interval = Interval;
            this.isMeasured = isMeasured;
            this.mask = mask;
        }


        public Dictionary<Sensor, Dictionary<double, double>> DispData
        {
            get
            {
                return dispdata;
            }
            set
            {
                dispdata = value;
            }
        }

        /// <summary>
        /// Название измерения
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Описание измерения
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Группа, которой принадлежит измерение
        /// </summary>
        public int GroupID
        {
            get { return gid; }
            set { gid = value; }
        }

        /// <summary>
        /// Полная продолжительность измерения
        /// </summary>
        public double FullMeasureLength
        {
            get { return fullLength; }
        }

        /// <summary>
        /// Интервал отображения
        /// </summary>
        public double MeasureInterval
        {
            get { return Interval; }
        }

        /// <summary>
        /// Измерено? или создано статистически
        /// </summary>
        public bool IsMeasured
        {
            get { return isMeasured; }
        }

        /// <summary>
        /// Идентификатор измерения
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Время начала измерения
        /// </summary>
        public DateTime StartTime
        {
            get { return dateTime; }
        }

        /// <summary>
        /// Инициализирующие значения сигнала сенсоров
        /// </summary>
        public Dictionary<Sensor, double> StartValues
        {
            get
            {
                Dictionary<Sensor, double> dc = new Dictionary<Sensor, double>();
                foreach (Sensor sensor in data.Keys)
                {
                    double d = 0d;

                    foreach (PointD dat in data[sensor])
                        if (dat.X < 0)
                        {
                            d = dat.Y;
                            break;
                        }

                    dc.Add(sensor, d);
                }
                return dc;
            }
        }

        /// <summary>
        /// Маска, наложенная по умолчанию
        /// </summary>
        public Mask DefaultMask
        {
            get { return mask; }
            set { mask = value; }
        }

        /// <summary>
        /// Данные, полученные с сенсоров
        /// </summary>
        public Dictionary<Sensor, List<PointD>> Data
        {
            get
            {
                Dictionary<Sensor, List<PointD>> res =new Dictionary<Sensor,List<PointD>>();
                foreach (Sensor sen in data.Keys)
                    if (used[sen])
                        res.Add(sen, data[sen]);
                return res;
            }
        }

        public Dictionary<Sensor, List<PointD>> AllData
        {
            get { return data; }
        }

        public Dictionary<Sensor, bool> Used
        {
            get { return used; }
        }

        /// <summary>
        /// Получить инициирующее значение для сенсора
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private double getInitialFreqForSensor(Sensor s)
        {
            List<PointD> p = data[s];
            int i=0;
            while ( (i < p.Count) && (p[i].X > 0) ) i++;
            if (i < p.Count)
                return p[i].Y;
            else return 0d;
        }

        /// <summary>
        /// Получить данные в момент времени
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Dictionary<Sensor, double> GetDataAtTheMoment(DateTime time)
        {
            Dictionary<Sensor, double> result = new Dictionary<Sensor, double>(); 

            foreach (Sensor sensor in data.Keys)
                if (used[sensor])
                {
                    double value = double.MinValue;

                    List<PointD> points = data[sensor];

                    double moment = (0d + time.Ticks - StartTime.Ticks) / 10e6;
                    double initval = getInitialFreqForSensor(sensor);

                    int less = -1;
                    int more = -1;

                    for (int i = 1; i < points.Count; i++)
                    {
                        if (points[i].X <= moment) less = i;
                        if (more == -1)
                            if (points[i].X > moment)
                                more = i;
                    }

                    if (more != -1 && less != -1)
                        value = points[less].Y + (points[more].Y - points[less].Y) * (moment - points[less].X) / (points[more].X - points[less].X);
                    else if (more == -1)
                        value = points.Count > 0 ? points[points.Count - 1].Y : 0d;
                    else
                        value = points[1].Y;

                    result.Add(sensor, value);
                }
            return result;
        }

        /// <summary>
        /// Перекрытие ToString():
        /// </summary>
        /// <returns> название (время)</returns>
        public override string ToString()
        {
            return name + " (" + this.StartTime.ToString("dd.MM.yy HH:mm") + ") [" + FullMeasureLength + " c.]" +
                (isMeasured ? "" : "[Σ" + (DispData != null && DispData.Count != 0 ? "+" : "") + "]");
                
        }

        public double Max
        {
            get
            {
                double d = double.MinValue;
                foreach (Sensor s in data.Keys)
                    foreach (PointD p in data[s])
                        if (p.Y > d) d = p.Y;
                return d;
            }
        }

        public double Min
        {
            get
            {
                double d = double.MaxValue;
                foreach (Sensor s in data.Keys)
                    foreach (PointD p in data[s])
                        if (p.Y < d) d = p.Y;
                return d;
            }
        }

        public double MaxAbs
        {
            get
            {
                double d = 0d;
                foreach (Sensor s in data.Keys)
                    foreach (PointD p in data[s])
                        if (Math.Abs(p.Y) > Math.Abs(d)) d = p.Y;
                return d;
            }
        }

        public double MinAbs
        {
            get
            {
                double d = double.MaxValue;
                foreach (Sensor s in data.Keys)
                    foreach (PointD p in data[s])
                        if (Math.Abs(p.Y) < Math.Abs(d)) d = p.Y;
                return d;
            }
        }

        public string toXML()
        {
            string xml = "<measure>\r\n";


            xml += "  <name>" + this.Name + "</name>\r\n";
            xml += "  <description>" + (this.Description == null ? "" : this.Description) + "</description>\r\n";
            xml += "  <group>" +this.GroupID +"</group>\r\n";
            xml += "  <length>" + this.FullMeasureLength + "</length>\r\n";
            xml += "  <ismeasured>" + this.IsMeasured + "</ismeasured>\r\n";
            xml += "  <mask>" + (this.DefaultMask == null ? "-1" : this.DefaultMask.ID.ToString()) + "</mask>\r\n";
            xml += "  <start>" + this.StartTime.ToString() + "</start>\r\n";
            

            Dictionary<Sensor, double> init = this.StartValues;
            foreach (Sensor s in init.Keys)
            {
                xml += "  <sensor sid='" + s.SID + "' initial='" + init[s] + "'>\r\n";
                foreach (PointD point in data[s])
                {

                    string smile = dispdata != null && point.X >= 0d ? "' disp='" + dispdata[s][point.X] : "";
                    xml += "    <point time='" + point.X + "' value='" + point.Y + smile + "'/>\r\n";
                }
                xml += " </sensor>\r\n";
            }
            xml += "</measure>";
            return xml;
        }

        public static MeasureData fromXML(string XML, List<Mask> masks, List<Sensor> sensors)
        {
            XmlDocument xdoc = new XmlDocument();
            try
            {
                xdoc.LoadXml(XML);
                string name = xdoc.GetElementsByTagName("name")[0].InnerText;
                string desc = xdoc.GetElementsByTagName("description")[0].InnerText;
                int gid = Convert.ToInt32(xdoc.GetElementsByTagName("group")[0].InnerText);
                int mask = Convert.ToInt32(xdoc.GetElementsByTagName("mask")[0].InnerText);

                DateTime start = DateTime.Parse(xdoc.GetElementsByTagName("start")[0].InnerText);
                double length = double.Parse(xdoc.GetElementsByTagName("length")[0].InnerText);
                bool isMeasured = bool.Parse(xdoc.GetElementsByTagName("ismeasured")[0].InnerText);

                Dictionary<Sensor, Dictionary<double, double>> dispdata = null;

                if (!isMeasured)
                    dispdata = new Dictionary<Sensor, Dictionary<double, double>>();


                XmlNodeList list = xdoc.GetElementsByTagName("sensor");
                Dictionary<Sensor, List<PointD>> data = new Dictionary<Sensor, List<PointD>>();

                Mask m = null;
                foreach (Mask mm in masks)
                    if (mm.ID == mask) m = mm;


                foreach (XmlNode node in list)
                {
                    string sid = node.Attributes["sid"].Value;

                    Sensor s  = null;
                    foreach (Sensor se in sensors) if (se.SID == sid) s = se;

                    if (s != null)
                    {
                        data.Add(s, new List<PointD>());
                        if (!isMeasured)
                            dispdata.Add(s, new Dictionary<double,double>());
                        foreach (XmlNode dnode in node.ChildNodes)
                        {
                            PointD point = new PointD();
                            XmlAttributeCollection collect = dnode.Attributes;
                            point.X = double.Parse(collect["time"].Value);
                            point.Y = double.Parse(collect["value"].Value);
                            if (point.X >= 0d)
                            if (!isMeasured)
                            try
                            {
                                dispdata[s].Add(point.X, Double.Parse(collect["disp"].Value));
                            }
                            catch {}
                            data[s].Add(point);
                        }
                    }
                }

                MeasureData dat = new MeasureData(data, -1, name, start, desc, gid, length, 1, isMeasured, m);
                dat.DispData = dispdata;
                return dat;
            }
            catch (Exception ex) { message = ex.Message; return null; }
        }

        public static string message;

        public string ToCSV(Mask mask)
        {
            if (mask == null) throw new Exception("Не задана маска измерения");
            
            DateTime starttime = StartTime;
            string separator = ";";
            string nl = "\r\n";

            string result = "\"Название\"" + separator + "\"" + Name + "\"" + nl;
            result += "\"Продолжительность\"" + separator + FullMeasureLength + nl;
            result += "\"Тип\"" + separator + (IsMeasured ? "измерение" : "среднее измерение") + nl;
            result += "\"Статистические данные\"" + separator + (DispData != null ? "есть" : "нет") + nl;
            result += "\"Начало\"" + separator + starttime.ToString() + nl;
            result += nl;



            Dictionary<Sensor, double> start = StartValues;
            result += "\"Значения\"" + nl + "\"время\\сенсоры\"";

            foreach (Sensor s in start.Keys)
                result += separator + "\"" + s.ToString() + "\"";

            result += nl + "\"Базовая частота\"";
            foreach (Sensor s in start.Keys)
                result += separator + start[s].ToString();

            for (int i = 0; i < mask.TimePoints.Length && mask.TimePoints[i] <= FullMeasureLength; i++)
            {
                result += nl;
                double tick = mask.TimePoints[i];
                Dictionary<Sensor, double> data = this.GetDataAtTheMoment(starttime.AddSeconds(tick));
                foreach (Sensor sen in start.Keys)
                    result += separator + data[sen].ToString();
            }

            if (DispData != null)
            {
                result += nl + "\"доверительные интервалы\"" + nl;
                foreach (Sensor s in DispData.Keys)
                {
                    result += "\"" + s + " (cек)" + "\"" + separator;
                    foreach (double t in DispData[s].Keys)
                        result += t.ToString()  + separator;
                    result += nl + "\"дов. интервал +/-\"" + separator;
                    foreach (double t in DispData[s].Keys)
                        result += DispData[s][t].ToString() + separator;
                    result += nl;
                }
            }



            return result;
        }
    }

}

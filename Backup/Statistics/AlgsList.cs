using System;
using System.Collections.Generic;
using System.Text;
using QuadroSoft.Enose.DataModel;

namespace QuadroSoft.Enose.Statistics
{
    public class AlgsList
    {
        #region Константные массивы
        public static double[] Q095 = new double[]
        {
            0.95d, 0,95d, 0.95d, 0.94d, 0.77d, 0.64d, 0.56d, 0.51d, 0.47d, 0.44d, 0.41d
        };

        public static double[] STU_K095 = new double[]
        {
            double.MaxValue, 12.7060, 4.3020, 3.182, 2.776, 2.570, 2.4460, 2.3646, 2.3060, 2.2622, 2.2281, 2.201, 2.1788, 2.1604, 2.1448,
            2.1314, 2.1190, 2.1098, 2.1009, 2.0930, 2.08600, 2.0790, 2.0739, 2.0687,2.0639, 2.0595, 2.059, 2.0518, 2.0484, 2.0452, 2.0423
        };


        public static string[] algs = new string[] 
        {
            "Статически надёжное среднее",
            "Сравнение измерений"
        };
        #endregion

        /// <summary>
        /// Просеять по Q-критерию
        /// </summary>
        /// <param name="select">набор данных</param>
        /// <returns>без "грубых промахов"</returns>
        private static List<double> Q_095(List<double> select)
        {
            select.Sort();

            if (select.Count < 3) return select;
            else if (select[0] == select[select.Count - 1]) return select;
            else 
            {
                double q = (select[1] - select[0]) / (select[select.Count - 1] - select[0]);
                bool stable = q < Q095[Math.Min(Q095.Length - 1, select.Count - 1)];
                if (!stable) select.Remove(select[0]);
            }

            if (select.Count < 3) return select;
            else if (select[0] == select[select.Count - 1]) return select;
            else
            {
                double q = (select[select.Count - 1] - select[select.Count - 2]) / (select[select.Count - 1] - select[0]);
                bool stable = q < Q095[Math.Min(Q095.Length - 1, select.Count - 1)];
                if (!stable) select.Remove(select[select.Count - 1]);
            }

            return select;

        }

        /// <summary>
        /// Среднее
        /// </summary>
        /// <param name="select">данные</param>
        /// <returns>среднее</returns>
        private static double mean(List<double> select)
        {
            double sum = 0d;
            
            foreach (double d in select)
                sum += d;

            return sum / select.Count;
        }

        /// <summary>
        /// Средняя крадратичная ошибка
        /// </summary>
        /// <param name="select">данные</param>
        /// <returns>значение</returns>
        private static double SKO(List<double> select)
        {
            double meanV = mean(select);
            double sq = 0;
            foreach (double d in select)
                sq += (d - meanV) * (d - meanV);

            return Math.Sqrt(sq / (select.Count - 1));
        }
        
        /// <summary>
        /// радиус доверительного интервала
        /// </summary>
        /// <param name="select">данные</param>
        /// <returns>deltaX</returns>
        private static double dX(List<double> select)
        {
            return STU_K095[Math.Min(STU_K095.Length - 1, select.Count - 1)] * SKO(select) / Math.Sqrt(select.Count);
        }

        /// <summary>
        /// Статистически надёжное среднее
        /// </summary>
        /// <param name="measuresCorrecture">измерения с корректировкой времени</param>
        /// <param name="mask">маска</param>
        /// <param name="length">продолжительность</param>
        /// <returns>среднее, просеенное через Q-критерий, и снабженное информацией о доверительных интервалах</returns>
        public static MeasureData reliableMiddle(Dictionary<MeasureData, double> measuresCorrecture, string measureName, Mask mask, double length)
        {
            Dictionary<Sensor, Dictionary<double, List<double>>> data = new Dictionary<Sensor, Dictionary<double, List<double>>>();
            Dictionary<Sensor, Dictionary<double, Dictionary<double, double>>> dispdata = new Dictionary<Sensor, Dictionary<double, Dictionary<double, double>>>();
            Dictionary<Sensor, int> dividers = new Dictionary<Sensor, int>();
            Dictionary<MeasureData, Dictionary<Sensor, double>> inits = new Dictionary<MeasureData, Dictionary<Sensor, double>>();
            Dictionary<Sensor, double> starts = new Dictionary<Sensor, double>();

            #region В _starts поместили средний старт и инициализировали data
            foreach (MeasureData md in measuresCorrecture.Keys)
                inits.Add(md, md.StartValues);

            foreach (MeasureData md in measuresCorrecture.Keys)
            {
                Dictionary<Sensor, double> sv = md.StartValues;
                foreach (Sensor s in md.AllData.Keys)
                {
                    if (!data.ContainsKey(s)) data.Add(s, new Dictionary<double, List<double>>());
                    if (!dispdata.ContainsKey(s)) dispdata.Add(s, new Dictionary<double, Dictionary<double, double>>());

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
            #endregion

            #region Собрали тики в ticks
            List<double> ticks = new List<double>();


            foreach (double tick in mask.TimePoints)
                if (tick <= length)
                    ticks.Add(tick);

            #endregion

            #region Складываем по маске точки

            foreach (double tick in ticks)
            {
                foreach (MeasureData md in measuresCorrecture.Keys)
                {
                    Dictionary<Sensor, double> vals = md.GetDataAtTheMoment(md.StartTime.AddSeconds(tick - measuresCorrecture[md]));

                    foreach (Sensor sensor in vals.Keys)
                    {
                        if (!data[sensor].ContainsKey(tick))
                            data[sensor].Add(tick, new List<double>());
                        if (!dispdata[sensor].ContainsKey(tick))
                            dispdata[sensor].Add(tick, new Dictionary<double,double>());
                        
                        data[sensor][tick].Add(_starts[sensor] - vals[sensor]);
                    }
                }
            }

            #endregion

            #region Статистика к бою

            foreach (Sensor sensor in dispdata.Keys)
            {
                //dispdata.Add(sensor, new Dictionary<double,Dictionary<double,double>>());

                foreach (double tick in dispdata[sensor].Keys)
                {
                   // dispdata[sensor].Add(tick, new Dictionary<double,double>());
                    
                    List<double> select = Q_095(data[sensor][tick]);

                    dispdata[sensor][tick].Add(mean(select), dX(select));
                }
            }

            #endregion

            #region Пересбор данных

            Dictionary<Sensor, List<PointD>> newdata = new Dictionary<Sensor,List<PointD>>();
            Dictionary<Sensor, Dictionary<double, double>> newdispdata = new Dictionary<Sensor, Dictionary<double, double>>();

            foreach (Sensor s in dispdata.Keys)
            {
                newdata.Add(s, new List<PointD>());
                newdispdata.Add(s, new Dictionary<double, double>());

                newdata[s].Add(new PointD(-1, _starts[s]));
                foreach (double d in dispdata[s].Keys)
                {
                    Dictionary<double, double> pair = dispdata[s][d];
                    
                    double k = 0;
                    foreach (double q in pair.Keys) k = q;

                    newdata[s].Add(new PointD(d, _starts[s] - k));
                    newdispdata[s].Add(d, pair[k]);
                }

            }

            #endregion 

            MeasureData mdata = new MeasureData(newdata, -1, measureName, DateTime.Now, "", -1, length, 1, false, mask);
            mdata.DispData = newdispdata;
            return mdata;
        }

        /// <summary>
        /// Сравнение измерений
        /// </summary>
        /// <param name="baseData">базовое, статистически усреднённое измерение, содержащее данные о доверительном интервале</param>
        /// <param name="compared">сравниваемое измерение</param>
        /// <param name="timeCorrection">коррекция времени сравниваемого измерения</param>
        /// <returns>набор данных с некоторыми результатами</returns>
        public static Dictionary<string, object> Correspondence(MeasureData baseData, MeasureData compared, double timeCorrection)
        {
            Dictionary<string, object> result = new Dictionary<string,object>();
            string errorlog = "";

            if (baseData.IsMeasured || baseData.DispData == null)
            {
                errorlog += "Базовое измерение не является статистическим средним.";
                result.Add("ok", false);
                result.Add("errorlog", errorlog);
                return result;
            }

            Dictionary<Sensor, List<double>> inSigma = new Dictionary<Sensor,List<double>>();
            Dictionary<Sensor, List<double>> in3Sigma = new Dictionary<Sensor,List<double>>();
            Dictionary<Sensor, List<double>> outOf3Sigma = new Dictionary<Sensor,List<double>>();

            foreach (Sensor sensor in baseData.Data.Keys)
            {
                if (compared.Data.ContainsKey(sensor))
                {
                    inSigma.Add(sensor, new List<double>());
                    in3Sigma.Add(sensor, new List<double>());
                    outOf3Sigma.Add(sensor, new List<double>());




                    foreach (PointD point in baseData.Data[sensor])
                    {

                        double time = point.X;
                        if (time >= 0d)
                        {
                            double value = point.Y;
                            double dX = baseData.DispData[sensor][time];
                            double comparedvalue = compared.GetDataAtTheMoment(compared.StartTime.AddSeconds(time - timeCorrection))[sensor];


                            if (Math.Abs(comparedvalue - value) < dX) inSigma[sensor].Add(time);
                            else if (Math.Abs(comparedvalue - value) < 3 * dX) in3Sigma[sensor].Add(time);
                            else outOf3Sigma[sensor].Add(time);
                        }

                    }
                }
                else
                {
                    errorlog += "<<" + sensor.ToString() + ">> : не найден в измерении <<" + compared.ToString() + ">>";
                }
            }
            result.Add("ok", true);
            result.Add("errorlog", errorlog);
            result.Add("sigma", inSigma);
            result.Add("3sigma", in3Sigma);
            result.Add("unstable", outOf3Sigma);

            return result;

        }
    }
}

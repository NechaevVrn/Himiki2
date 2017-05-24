using System;
using System.Windows.Forms;
using QuadroSoft.Enose.DataAccess;
using QuadroSoft.Enose.Driver;
using System.Drawing;
using QuadroSoft.Enose.DataModel;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Data;

namespace QuadroSoft.Enose
{
    static class Program
    {
        /// <summary>
        /// расположение файла конфигурации приложения
        /// </summary>
        static string configfile = "config.xml";

        /// <summary>
        /// Тип сенсора.
        /// </summary>
        public enum SensorType { flow, request, stub }

        #region тэги файла конфигурации

        static string COMPORT = "comport";
        static string MEASURE_PROFILE_ID = "measureprofileid";
        static string CONNECTION_STRING = "connectionstring";
        static string STABLE_TIME = "stabletime";
        static string STABLE_AMP = "stableamplitude";
        static string SENSOR_TYPE = "hardware";

        #endregion

        /// <summary>
        /// Хранилище настроек приложения, маппинг на config
        /// </summary>
        public class Presets
        {
            /// <summary>
            /// строка подключения к базе
            /// </summary>
            public static string connectionString;
            /// <summary>
            /// Имя com-порта
            /// </summary>
            public static string comPortName;
            /// <summary>
            /// Идентификатор профиля в базе
            /// </summary>
            public static int profileID;
            /// <summary>
            /// Время стабильного сигнала (сек)
            /// </summary>
            public static double stableTime;
            /// <summary>
            /// Амплитуда стабильного сигнала (Гц)
            /// </summary>
            public static double stableAmp;
            /// <summary>
            /// Тип газоанализатора
            /// </summary>
            public static SensorType sensortype;
            
            private static MeasureProfile currentProfile;
            /// <summary>
            /// текущий выбранный профиль измерения
            /// </summary>
            public static MeasureProfile CurrentProfile
            {
                get { return currentProfile; }
                set
                {
                    profileID = (currentProfile = value) != null ? currentProfile.ID : -1;
                    if (MainWin != null) MainWin.stackPlotters(currentProfile);
                }
            }

            private static MainWindow mw;
            /// <summary>
            /// Основное окно приложения
            /// </summary>
            public static MainWindow MainWin
            {
                get { return mw; }
                set { mw = value; }
            }
        }

        /// <summary>
        /// Различные сервисные методы для отрисовки интерфейса и контроля всякого
        /// </summary>
        public class Service
        {
            #region Построение дерева измерений

            /// <summary>
            /// Добавление подузлов дерева измерений к узлу дерева TreeView
            /// </summary>
            /// <param name="node">узел TreeNode</param>
            /// <param name="gtn">узел логического дерева (группа измерений)</param>
            /// <param name="showmeasures">отображать измерения?</param>
            private static void addSub(TreeNode node, QuadroSoft.Enose.DataAccess.DataProvider.GroupTreeNode gtn, bool showmeasures)
            {
                node.Tag = gtn;
                foreach (DataProvider.GroupTreeNode gnode in gtn.SubNodes)
                {
                    TreeNode n;
                    addSub( n = node.Nodes.Add(gnode.ID.ToString(), gnode.ToString()), gnode, showmeasures);
                    n.ImageIndex = n.SelectedImageIndex = 0;
                    
                }
                if (showmeasures)
                    foreach (int id in gtn.Measures.Keys)
                    {
                        TreeNode n = node.Nodes.Add(id.ToString(), gtn.Measures[id]);
                        n.ImageIndex = n.SelectedImageIndex = 1;
                        n.ForeColor = Color.Green;
                        n.Tag = id;
                    }
            }

            /// <summary>
            /// отстроить дерево измерений на TreeView
            /// </summary>
            /// <param name="treeView">Компонент treeview</param>
            /// <param name="gtn">верхний узел логического дерева</param>
            /// <param name="showmeasures">отображать измерения?</param>
            private static void PlotGroupTree(TreeView treeView, QuadroSoft.Enose.DataAccess.DataProvider.GroupTreeNode gtn, bool showmeasures)
            {
                treeView.Nodes.Clear();
                TreeNode tree = treeView.Nodes.Add(gtn.Name);
                treeView.Tag = gtn;

                if (gtn.SubNodes != null)
                    foreach (DataProvider.GroupTreeNode gnode in gtn.SubNodes)
                    {
                        TreeNode n;
                        addSub(n = tree.Nodes.Add(gnode.ID.ToString(), gnode.ToString()), gnode, showmeasures);
                        n.ImageIndex = n.SelectedImageIndex = 0;
                    }
                if (showmeasures)
                    if (gtn.Measures != null)
                    foreach (int id in gtn.Measures.Keys)
                    {
                        TreeNode n = tree.Nodes.Add("" + id, gtn.Measures[id]);
                        n.ForeColor = Color.Green;
                        n.Tag = id;
                        n.ImageIndex = n.SelectedImageIndex = 1;
                    }

            }

            /// <summary>
            /// отстроить дерево измерений на TreeView
            /// </summary>
            /// <param name="treeView">компонент treeview</param>
            /// <param name="showmeasures">показывать измерения?</param>
            public static void PlotGroupTree(TreeView treeView, bool showmeasures)
            {
                if (DataProvider != null)
                PlotGroupTree(
                    treeView, 
                    DataProvider.GetMeasuresTreeFrom(null,
                        new DataProvider.GroupTreeNode(-1, "Все измерения", "")
                        ),
                    showmeasures
                    );
            }

            #endregion

            #region проверка стабильности измерений

            public const int CHECK_NO_SIGNAL = 0;
            public const int CHECK_NOT_STABLE = 1;
            public const int CHECK_NOT_IN_PASSPORT = 2;
            public const int CHECK_STABLE = 3;

            /// <summary>
            /// Проверка данных на стабильность
            /// </summary>
            /// <param name="sensor">Сенсор</param>
            /// <param name="data"> Самые свежие данные сенсора</param>
            /// <returns>константа стабильности Program.Service.CHECK_*</returns>
            public static int checkOk(Sensor sensor, PointD[] data)
            {
                if (data == null || sensor == null || data.Length == 0) return CHECK_NO_SIGNAL;

                PointD startPoint = data[0];
                PointD finalPoint = data[data.Length - 1];

                if (finalPoint.Y < 1d) return CHECK_NO_SIGNAL;

                bool inPassportFork = true;

                foreach (PointD point in data)
                    if ((point.Y > sensor.PassportFrequency + sensor.PassportAmplitude)
                        ||
                        (point.Y < sensor.PassportFrequency - sensor.PassportAmplitude)
                        )
                        inPassportFork = false;

                if (!inPassportFork) return CHECK_NOT_IN_PASSPORT;

                if (finalPoint.X - startPoint.X <= Presets.stableTime) return CHECK_NOT_STABLE;

                double max = double.MinValue;
                double min = double.MaxValue;

                foreach (PointD point in data)
                    if ((point.X <= finalPoint.X) && (point.X >= finalPoint.X - Presets.stableTime))
                    {
                        if (point.Y < min) min = point.Y;
                        if (point.Y > max) max = point.Y;
                    }

                if (max - min > Presets.stableAmp) return CHECK_NOT_STABLE;

                return CHECK_STABLE;

            }

            #endregion

            #region Перед запуском измерения

            /// <summary>
            /// Преобразование данных из объекта газоанализатора в данные, привязанные к сенсорам по профилю
            /// </summary>
            /// <param name="win">окно данных</param>
            /// <param name="profile">профиль проверки</param>
            /// <param name="min">минимальное значение времени</param>
            /// <param name="max">максимальное значение времени</param>
            /// <returns>данные, пригодные для проверки на стабильность</returns>
            public static Dictionary<Sensor, List<PointD>> WinToData(Dictionary<DateTime, double[]> win, MeasureProfile profile, out DateTime min, out DateTime max)
            {
                max = min = DateTime.Now;
                Dictionary<Sensor, List<PointD>> result = new Dictionary<Sensor, List<PointD>>();
                if (win.Keys.Count < 1) return result;

                Dictionary<DateTime, double[]>.KeyCollection.Enumerator en = win.Keys.GetEnumerator();
                if (en.MoveNext()) min = en.Current;

                foreach (int pos in profile.Settings.Keys) result.Add(profile.Settings[pos], new List<PointD>());

                foreach (DateTime dt in win.Keys)
                {
                    max = dt;
                    double val = (dt.Ticks - min.Ticks) / 10e6d;

                    foreach (int pos in profile.Settings.Keys)
                        result[profile.Settings[pos]].Add(new PointD(val, win[dt][pos]));
                }

                return result;
            }

            public static double[] getInitValues(Dictionary<DateTime, double[]> win, MeasureProfile applied)
            {
                double[] init = new double[Program.nose.SensorCount];
                int count = win.Count;
                DateTime[] times = new DateTime[count];
                win.Keys.CopyTo(times, 0);
                DateTime last = times[times.Length - 1];

                for (int i = 0; i < init.Length; i++) init[i] = 0d;

                int c = 0;
                ///!!!!! ТОНКО ТУТ ЕСЛИ НЕПРАВИЛЬНО - ФИКСИТЬ!!!!
                for (int i = times.Length - 1; i >= 0 && (0d + last.Ticks - times[i].Ticks) / 1e7d < Program.Presets.stableTime; c++, i--)
                    for (int j = 0; j < Program.nose.SensorCount; j++)
                        init[j] += win[times[i]][j];

                if (c > 0)
                    for (int i = 0; i < init.Length; i++) init[i] /= c;

                double[] theinit = new double[applied.Settings.Count];

                int ii = 0;
                foreach (int pos in applied.Settings.Keys)
                    theinit[ii++] = (int)init[pos];

                return theinit;
            }

            #endregion
        }

        /// <summary>
        /// Провайдер доступа к БД
        /// </summary>
        public static DataProvider DataProvider;
     
        /// <summary>
        /// Объект электронного носа
        /// </summary>
        public static INose nose;
        
        /// <summary>
        /// стартовая директория 
        /// </summary>
        private static DirectoryInfo dir;

        /// <summary>
        /// Загрузка конфигурации приложения
        /// </summary>
        public static void loadConfiguration()
        {
            XmlDocument xdoc = new XmlDocument();

            Presets.profileID = -1;
            Presets.comPortName = "COM1";
            Presets.connectionString = "Data Source=sniffdb.sdf;encryption mode=platform default;Password=password;";
            Presets.stableTime = 6d;
            Presets.stableAmp = 5d;
            Presets.sensortype = SensorType.flow;

            try
            {
                xdoc.LoadXml(File.ReadAllText(dir.FullName + "/" + configfile));
            }
            catch (Exception ex)
            {
                Error.Log(ex);
                return;
            }

            try
            {
                Presets.profileID = Convert.ToInt32(xdoc.GetElementsByTagName(MEASURE_PROFILE_ID)[0].InnerText);
            }
            catch (Exception ex) { Error.Log(ex); }
            try
            {
                Presets.connectionString = xdoc.GetElementsByTagName(CONNECTION_STRING)[0].InnerText;
            }
            catch (Exception ex) { Error.Log(ex); }
            try
            {
                Presets.comPortName = xdoc.GetElementsByTagName(COMPORT)[0].InnerText;
            }
            catch (Exception ex) { Error.Log(ex); }
            try
            {
                Presets.stableTime = Convert.ToInt32(xdoc.GetElementsByTagName(STABLE_TIME)[0].InnerText);
            }
            catch (Exception ex) { Error.Log(ex); }
            try
            {
                Presets.stableAmp = Convert.ToInt32(xdoc.GetElementsByTagName(STABLE_AMP)[0].InnerText);
            }
            catch (Exception ex) { Error.Log(ex); }

            try
            {
                string stype = xdoc.GetElementsByTagName(SENSOR_TYPE)[0].InnerText.ToLower();

                if (stype == "flow")
                    Presets.sensortype = SensorType.flow;
                else if (stype == "request")
                    Presets.sensortype = SensorType.request;
                else
                    Presets.sensortype = SensorType.stub;
            }
            catch (Exception ex) { Error.Log(ex); }
        }

        /// <summary>
        /// Запись конфигурации приложения
        /// </summary>
        public static void writeConfig()
        {
            Directory.SetCurrentDirectory(dir.FullName);
            string config = "<config>\r\n";
            config += "  <" + MEASURE_PROFILE_ID + ">" + Presets.profileID + "</" + MEASURE_PROFILE_ID + ">\r\n";
            config += "  <" + CONNECTION_STRING + ">" + Presets.connectionString + "</" + CONNECTION_STRING + ">\r\n";
            config += "  <" + COMPORT + ">" + Presets.comPortName + "</" + COMPORT + ">\r\n";
            config += "  <" + STABLE_TIME + ">" + Presets.stableTime + "</" + STABLE_TIME + ">\r\n";
            config += "  <" + STABLE_AMP + ">" + Presets.stableAmp + "</" + STABLE_AMP + ">\r\n";
            config += "  <" + SENSOR_TYPE + ">" + Presets.sensortype.ToString() + "</" + SENSOR_TYPE + ">\r\n";
            config += "</config>";

            File.WriteAllText(configfile, config);
        }

        /// <summary>
        /// Инициализацация приложения
        /// </summary>
        private static void init()
        {
            try
            {
                //dir = new DirectoryInfo("./");
                dir = new DirectoryInfo(Application.StartupPath);
                loadConfiguration();

                #region CheckPorts
                string[] ports = SerialPort.GetPortNames();

                bool cont = false;
                foreach (string pn in ports) cont |= Presets.comPortName.ToLower() == pn.ToLower();

                if (!cont)
                {
                    if (MessageBox.Show("В настройках указан нечуществующий COM-порт.\r\nПрограмма может попытаться опеределить используемый порт.\r\nДля этого подключите и включите прибор.\r\nПродолжить?", "COM порт", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (!GetPort())
                            Thread.CurrentThread.Abort();
                    }
                    else
                        Thread.CurrentThread.Abort();
                }
                #endregion

                #region checkCS
                try
                {
                    DataProvider = new DataProvider(Presets.connectionString, DataProvider.DBType.SqlCompact);
                }
                catch (Exception ex)
                {
                    Error.Log(ex);
                    MessageBox.Show("Не удалось подключиться к БД: " + ex.Message);
                    Thread.CurrentThread.Abort();
                }

                #endregion

                DataProvider.getMeasureProfiles();
                DataProvider.getSensorList();

                List<MeasureProfile> lst = DataProvider.MeasureProfiles;
                Presets.CurrentProfile = DataProvider.getMeasureProfileByID(Presets.profileID);

                switch (Presets.sensortype)
                {
                    case SensorType.flow: nose = new FlowNose(Presets.comPortName, 20); break;
                    case SensorType.request: nose = new RequestNose(Presets.comPortName, 20); break;
                    case SensorType.stub: nose = new StubNose(Presets.comPortName, 20, new bool[] { true, true, true, true, true, true, true, true }); break;
                }


                nose.start();
            }
            catch (Exception ex2) { Error.Log(ex2); }
        }

        /// <summary>
        /// Автоопределение порта
        /// </summary>
        private static bool GetPort()
        {
            string[] ports = SerialPort.GetPortNames();
            Dictionary<string, SensorType> ps = new Dictionary<string,SensorType>();

            byte[] buff = new byte[128];

            foreach (string port in ports)
            {
                SerialPort sp = null;

                #region As flow
                try
                {
                    sp = new SerialPort(port, 6 * 9600, Parity.None, 8, StopBits.One);
                    sp.ReadTimeout = 2000;
                    sp.Open();
                    if (sp.Read(buff, 0, 32) > 0) ps.Add(port, SensorType.flow);

                }
                catch
                {
                }
                finally
                {
                    try { sp.Close(); } catch { }
                }
                #endregion

                #region As Request
                if (!ps.ContainsKey(port))
                    try
                    {
                        sp = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
                        sp.ReadTimeout = 2000;

                        sp.Open();
                        sp.Write(new byte[1] { 1 }, 0, 1);

                        Thread.Sleep(1200);

                        if (sp.Read(buff, 0, 32) > 0)
                            ps.Add(port, SensorType.request);

                    }
                    catch { }
                    finally
                    {
                        try { sp.Close(); } catch { }
                    }

                if (!ps.ContainsKey(port))
                    ps.Add(port, SensorType.request);
                #endregion
            }

            if (ps.Count == 0)
            {
                MessageBox.Show("Не удалось обнаружить прибор.");
            }
            else 
            {
                bool ok = false;

                foreach (string s in ps.Keys)
                {
                    ok = MessageBox.Show("Предполагаемая конфигурация:\r\n" + s + ": " + ps[s].ToString(), "Конфигурация", MessageBoxButtons.YesNo) == DialogResult.Yes;
                    if (ok)
                    {
                        Presets.comPortName = s;
                        Presets.sensortype = ps[s];
                        return true;
                    }
                }
            }
            return false;


        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Presets.MainWin = new MainWindow());
        }
    }
}

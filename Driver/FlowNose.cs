using System;
using System.Collections.Generic;
using System.Text;
using QuadroSoft.Enose.Driver;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace QuadroSoft.Enose.Driver
{
    public class FlowNose: INose
    {

        private double critical_level = 2000000d;

        private string name = "МАГ-1; Поточный";
        private int sensor_count = 8;
        private int queue_length = 20;
        private int com_read_timeout = 1000;

        private double[] last = new double[8];

        class Pair
        {
            public double[] v;
            public DateTime d;
            public Pair(DateTime d, double[] v)
            {
                this.d = d;
                this.v = v;
            }
        }

        private Thread thread;
        private bool isMeasuring = false;
        private bool isPowered = false;
        private bool isReading = false;

        private byte[] buffer = new byte[64];
        SerialPort port;

        Queue<Pair> queue, queueForStoring;

        public FlowNose(string serialPortName, int queueSize)
        {
            port = new SerialPort(serialPortName, 6 * 9600, Parity.None, 8, StopBits.One);
            queue_length = queueSize;
            queue = new Queue<Pair>(queue_length + 5);
            port.ReadTimeout = com_read_timeout;
        }


        #region IDisposable Members

        public void Dispose()
        {
            stop();

            if (port != null)
                if (port.IsOpen)
                   port.Close();

        }

        #endregion

        private double[] toDouble(byte[] data)
        {
            double[] values = new double[8];

            for (int i = 0; i < 8; i++)
            {
                int n = buffer[i * 4 + 3] >> 4;
                int d0 = (buffer[i * 4 + 3] & 0xF) * 0x100 * 0x100 * 0x100;
                int d1 = buffer[i * 4 + 2] * 0x100 * 0x100;
                int d2 = buffer[i * 4 + 1] * 0x100;
                int d3 = buffer[i * 4];

                values[n - 1] = d0 + d1 + d2 + d3;
            }
            return values;
        }

        private DateTime lastRead = DateTime.Now;

        private void recieved(object sender, SerialDataReceivedEventArgs args)
        {
            try
            {
                int readen = 0;
                while (readen < 32)
                    readen += port.Read(buffer, readen, 8);

                lastRead = DateTime.Now;

                double[] dat = toDouble(buffer);
                last = dat;

                if (isReading)
                {
                    try
                    {
                        Pair p = new Pair(DateTime.Now, dat);

                        queue.Enqueue(p);

                        if (isMeasuring)
                            queueForStoring.Enqueue(p);

                        while (queue.Count > queue_length)
                            queue.Dequeue();
                    }
                    catch (Exception) { return; }
                }
            }
            catch { last = null; }
        }


        #region ReadControl
        private void read()
        {
            while (true)
            {
                Thread.Sleep(2000);
                double ds = (DateTime.Now.Ticks - lastRead.Ticks) / 1e7d;
                if (ds > 3)
                    reinit();
            }
        }

        void reinit()
        {
            long t = DateTime.Now.Ticks;
            port.Close();
            port = new SerialPort(port.PortName, 6 * 9600, Parity.None, 8, StopBits.One);
            port.Open();
            File.AppendAllText("l", " >> " + (DateTime.Now.Ticks - t) + "\r\n");
            lastRead = DateTime.Now;
        }
        #endregion

        #region INose Members

        /// <summary>
        /// имя прибора
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        public bool IsPlugged
        {
            get
            {
                return getPluggedState();
            }
        }

        private bool getPluggedState()
        {
            return last != null;
        }

        public bool IsPoweredOn
        {
            get { return IsPlugged; }
        }

        public bool powerOn()
        {
            isPowered = true;
            return IsPoweredOn;
        }

        public bool powerOff()
        {
            isPowered = false;
            return !IsPoweredOn;
        }

        public int SensorCount
        {
            get { return sensor_count; }
        }

        public bool[] PluggedSensorState
        {
            get { return DataSendingSensorState; }
        }

        public bool[] DataSendingSensorState
        {
            get 
            {
                bool[] result = new bool[sensor_count];
                for (int i = 0; i < sensor_count; i++) result[i] = false; 

                if (last != null)
                    for (int i = 0; i < sensor_count; i++) result[i] = last[i] > critical_level;

                return result;                
            }
        }

        public bool start()
        {
            port.DataReceived += new SerialDataReceivedEventHandler(recieved);
            port.Open();
            isReading = true;
            thread = new Thread(new ThreadStart(read));
            thread.Start();
            return true;
        }

        public bool stop()
        {
            isReading = false;
            try
            {
                thread.Abort();
            }
            catch { }
            return true;
        }

        public Dictionary<DateTime, double[]> getWindow()
        {
            Dictionary<DateTime, double[]> data = new Dictionary<DateTime, double[]>();
            try
            {
                if (queue != null)
                {
                    foreach (Pair p in queue)
                        if (!data.ContainsKey(p.d))
                            data.Add(p.d, p.v);
                }
                else queue = new Queue<Pair>();
            }
            catch (Exception ex)
            {
                File.AppendAllText("err.log" , ex.StackTrace);
            }
            return data;
        }

        public Dictionary<DateTime, double[]> getMesureData()
        {
            Dictionary<DateTime, double[]> data = new Dictionary<DateTime, double[]>();
            try
            {
                if (queueForStoring != null)
                {
                    foreach (Pair p in queueForStoring)
                        data.Add(p.d, p.v);
                }
                else queueForStoring = new Queue<Pair>();
            }
            catch (Exception ex)
            {
                File.AppendAllText("err.log", ex.StackTrace);
            }
            return data;
        }

        public bool startMeasure()
        {
            isMeasuring = true;
            if (queueForStoring == null)
                queueForStoring = new Queue<Pair>(2000);
            queueForStoring.Clear();

            return true;
        }

        public bool stopMeasure()
        {
            isMeasuring = false;
            return true;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace QuadroSoft.Enose.Driver
{
    public class StubNose : INose
    {

        #region Settings

        private string name = "НОСЭЛЬка-М; значения по запросу";
        private int request_wait_time = 1100;
        private int sensor_count = 8;
        private int com_read_timeout = 2000;
        private byte[] command_power_on = new byte[] { 1 };
        private byte[] command_power_off = new byte[] { 3 };
        private byte[] command_get_data = new byte[] { 2 };

        private int queue_length;

        #endregion


        private bool[] enabled;

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
        private bool isPowered = false;

        private bool isReading = false;
        private bool isMeasuring = false;


        private byte[] buffer = new byte[1024];
        SerialPort port;

        Queue<Pair> queue, queueForStoring;

        void read()
        {
            while (isReading)
            {
                double[] data = getData();
                Pair p = new Pair(DateTime.Now, data);

                queue.Enqueue(p);

                if (isMeasuring)
                    queueForStoring.Enqueue(p);

                while (queue.Count > queue_length)
                    queue.Dequeue();
            }
        }

        private bool[] getPluggedState()
        {
            bool[] result = new bool[sensor_count];

            port.Write(command_power_on, 0, 1);
            Thread.Sleep(request_wait_time);

            
            for (int i = 0; i < sensor_count; i++)
            {
                //int n = (buffer[i] >> 3) - 1;
                //bool ok = buffer[i] % 2 == 1;
                result[i] = true && enabled[i];
            }

            return result;

        }

        private double[] getData()
        {
            double[] values = new double[sensor_count];

            port.Write(command_get_data, 0, 1);
            Thread.Sleep(request_wait_time);

            for (int i = 0; i < sensor_count; i++)
                values[i] = enabled[i] ? 10000000d + 4 * (int)(16 * Math.Sin(i + DateTime.Now.Ticks / 1e7d / (1d + i))) : 0;
            
            return values;
        }

        public StubNose(string serialPortName, int queueSize, bool[] plugged)
        {
            port = new SerialPort(serialPortName, 9600, Parity.None, 8, StopBits.One);
            queue_length = queueSize;
            queue = new Queue<Pair>(queue_length + 5);
            port.ReadTimeout = com_read_timeout;
            port.Open();

            enabled = plugged;

        }

        //-----------------------------------------------------------------

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
                bool res = false;
                try
                {
                    getPluggedState();
                    res = true;
                }
                catch { }
                return res;
            }
        }

        public bool IsPoweredOn
        {
            get { return isPowered; }
        }

        public bool powerOn()
        {
            return isPowered = IsPlugged;
        }

        public bool powerOff()
        {
            port.Write(command_power_off, 0, 1);
            isPowered = false;
            return true;
        }

        public int SensorCount
        {
            get { return sensor_count; }
        }

        public bool[] PluggedSensorState
        {
            get { return getPluggedState(); }
        }

        public bool[] DataSendingSensorState
        {
            get
            {
                bool[] res = new bool[sensor_count];
                double[] data = getData();

                for (int i = 0; i < sensor_count; i++)
                    res[i] = data[i] > 1;

                return res;
            }
        }

        public bool start()
        {
            isReading = true;
            thread = new Thread(new ThreadStart(read));
            thread.Start();
            return true;
        }

        public bool stop()
        {
            isReading = isMeasuring = false;
            try
            {
                if (thread != null)
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
                    foreach (Pair p in queue.ToArray())
                        data.Add(p.d, p.v);
                }
                else queue = new Queue<Pair>();
            }
            catch {  }
            return data;
        }

        public Dictionary<DateTime, double[]> getMesureData()
        {
            Dictionary<DateTime, double[]> data = new Dictionary<DateTime, double[]>();
            try
            {
                if (queueForStoring != null)
                {
                    foreach (Pair p in queueForStoring.ToArray())
                        data.Add(p.d, p.v);
                }
                else queueForStoring = new Queue<Pair>();
            }
            catch { }
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

        #region IDisposable Members

        public void Dispose()
        {
            stop();

            if (port != null)
                if (port.IsOpen)
                {
                    port.Write(new byte[] { 3 }, 0, 1);
                    port.Close();
                }
        }

        #endregion
    }
}

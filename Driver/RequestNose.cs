using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace QuadroSoft.Enose.Driver
{
    public class RequestNose : INose
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
                try
                {
                    double[] data = getData();
                    Pair p = new Pair(DateTime.Now, data);

                    queue.Enqueue(p);

                    if (isMeasuring)
                        queueForStoring.Enqueue(p);

                    while (queue.Count > queue_length)
                        queue.Dequeue();
                }
                catch (Exception ex) { return; }
            }
        }

        private bool[] getPluggedState()
        {
            bool[] result = new bool[sensor_count];

            port.Write(command_power_on, 0, 1);
            Thread.Sleep(request_wait_time);

            int read = port.Read(buffer, 0, sensor_count);

            if (read != sensor_count)
                throw new Exception("Нос не подключен корректно.");

            for (int i = 0; i < sensor_count; i++)
            {
                int n = (buffer[i] >> 3) - 1;
                bool ok = buffer[i] % 2 == 1;
                result[n] = ok;
            }

            return result;

        }

        private double[] getData()
        {
            double[] values = new double[sensor_count];
            
            port.Write(command_get_data, 0, 1);
            Thread.Sleep(request_wait_time);

            int read = port.Read(buffer, 0, sensor_count * 4);

            if (read != sensor_count * 4)
                throw new Exception("Нос не подключен корректно.");

            for (int i = 0; i < sensor_count; i++)
            {
                int n = buffer[i * 4] >> 3;
                int d0 = (buffer[i * 4] & 0x7) * 0x100 * 0x100 * 0x100;
                int d1 = buffer[i * 4 + 1] * 0x100 * 0x100;
                int d2 = buffer[i * 4 + 2] * 0x100;
                int d3 = buffer[i * 4 + 3];

                values[n - 1] = d0 + d1 + d2 + d3;
            }
            return values;
        }

        public RequestNose(string serialPortName, int queueSize)
        {
            port = new SerialPort(serialPortName, 9600, Parity.None, 8, StopBits.One);
            queue_length = queueSize;
            queue = new Queue<Pair>(queue_length + 5);
            port.ReadTimeout = com_read_timeout;
            port.Open();
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
                try
                {

                    double[] data = getData();

                    for (int i = 0; i < sensor_count; i++)
                        res[i] = data[i] > 1;

                }
                catch (Exception ex)
                {
                }

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
                    foreach (Pair p in queue)
                        data.Add(p.d, p.v);
                else queue = new Queue<Pair>();
            }
            catch (Exception ex)
            {
                File.AppendAllText("err.log", ex.StackTrace);
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
                File.AppendAllText("err.log" , ex.StackTrace);
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

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                stop();

                if (port != null)
                    try
                    {
                        if (port.IsOpen)
                        {

                            port.Write(new byte[] { 3 }, 0, 1);
                            port.Close();
                        }
                    }
                    catch { }
            }
            catch { }
        }

        #endregion
    }
}

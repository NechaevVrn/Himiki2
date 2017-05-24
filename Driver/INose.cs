using System;
using System.Collections.Generic;
using System.Text;

namespace QuadroSoft.Enose.Driver
{
    public interface INose : IDisposable
    {

        /// <summary>
        /// Название прибора
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Подключен ли к порту
        /// </summary>
        bool IsPlugged { get; }

        bool IsPoweredOn { get; }

        bool powerOn();

        bool powerOff();

        int SensorCount { get; }

        bool[] PluggedSensorState { get; }

        bool[] DataSendingSensorState { get; }

        bool start();

        bool stop();

        Dictionary<DateTime, double[]> getWindow();

        Dictionary<DateTime, double[]> getMesureData();

        bool startMeasure();

        bool stopMeasure();

    }
}

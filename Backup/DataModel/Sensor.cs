using System;
using System.Collections.Generic;
using System.Text;

namespace QuadroSoft.Enose.DataModel
{
    public class Sensor : IComparable
    {
        private string sid;
        private string name;
        private string description;
        private Dictionary<string, object> settings = null;


        /// <summary>
        /// Интервал, на котором измерение сенсора должно быть стабильным
        /// </summary>
        public const string STABILITY_INTERVAL = "STABINT";

        /// <summary>
        /// Максимальная амплитуда для стабильного сенсора
        /// </summary>
        public const string STABILITY_AMPLITUDE = "STABAMP";

        public const string PASSPORT_FREQ = "mainfreq";
        public const string PASSPORT_AMP = "amp";

        public Sensor(string SID, string Name, string Description, Dictionary<string, object> settings)
        {
            this.sid = SID;
            this.name = Name;
            this.description = Description;
            this.settings = settings;
        }
        
        public Sensor(string SID, string Name, string Description, string settingsString) : 
            this(SID, Name, Description, ServiceFunctions.parseProperties(settingsString))
        {
            
            
        }

        /// <summary>
        /// идентификатор сенсора
        /// </summary>
        public string SID
        {
            get { return sid; }
            set { sid = value; }
        }

        /// <summary>
        /// Название сенсора
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Описание сенсора
        /// </summary>
        public string Description
        {
            get { return description; }
        }

        /// <summary>
        /// Настройки сенсора
        /// </summary>
        public Dictionary<string, object> Settings
        {
            get { return settings; }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Sensor)))
                return (obj as Sensor).SID == this.SID;
            else return false;
                    
        }

        public override string ToString()
        {
            return Name + " [" + SID + "] ";
        }

        public double PassportFrequency
        {
            get
            {
                if (settings == null) return 0;
                if (!settings.ContainsKey(PASSPORT_FREQ)) return 0;
                return Convert.ToDouble(settings[PASSPORT_FREQ]);
            }
            set
            {
                if (settings == null)
                    settings = new Dictionary<string, object>();

                if (!settings.ContainsKey(PASSPORT_FREQ))
                    settings.Add(PASSPORT_FREQ, value);
                else
                    settings[PASSPORT_FREQ] = value;
            }
        }

        public double PassportAmplitude
        {
            get
            {
                if (settings == null) return 0;
                if (!settings.ContainsKey(PASSPORT_AMP)) return 0;
                return Convert.ToDouble(settings[PASSPORT_AMP]);
            }
            set
            {
                if (settings == null)
                    settings = new Dictionary<string, object>();

                if (!settings.ContainsKey(PASSPORT_AMP))
                    settings.Add(PASSPORT_AMP, value);
                else
                    settings[PASSPORT_AMP] = value;
            }
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (!(obj is Sensor) || obj == null)
                return 1;
            return this.SID.CompareTo((obj as Sensor).SID);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QuadroSoft.Enose.DataModel
{
    public class MeasureProfile
    {
        private Dictionary<int, Sensor> set;
        private int id;
        private string name;
        private int time;
        private int maskID;

        public MeasureProfile() { }

        public MeasureProfile(int id, string name, Dictionary<int, Sensor> settings, int time, int maskID)
        {
            this.id = id;
            this.name = name;
            set = settings;
            this.time = time;
            this.maskID = maskID;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Dictionary<int, Sensor> Settings
        {
            get { return set; }
            set { set = value; }
        }

        public override string ToString()
        {
            return Name;//+ " (" + ID + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is MeasureProfile))
                return false;
            return this.ID.Equals((obj as MeasureProfile).ID);
        }

        public override int GetHashCode()
        {
            return id;
        }

        public int MaskID
        {
            get { return maskID; }
            set { maskID = value; }
        }

        public int Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
    
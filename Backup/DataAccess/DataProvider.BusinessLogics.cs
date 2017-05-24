using System;
using System.Collections.Generic;
using System.Text;
using QuadroSoft.Enose.DataModel;
using System.Data;

namespace QuadroSoft.Enose.DataAccess
{
    public partial class DataProvider
    {

        public static int MagicNumber = 123456;

        public class GroupTreeNode
        {
            string name, description;
            List<GroupTreeNode> subNodes;
            Dictionary<int, string> measures;
            int id;

            public int ID
            {
                get { return id; }
                set { id = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Description
            {
                get { return description; }
                set { description = value; }
            }

            public List<GroupTreeNode> SubNodes
            {
                get { return subNodes; }
                set { subNodes = value; }
            }

            public Dictionary<int, string> Measures
            {
                get { return measures; }
                set { measures = value; }
            }

            public GroupTreeNode(int id, string name, string description)
            {
                this.id = id;
                this.name = name;
                this.description = description;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private List<Sensor> sensorList = null;
        private List<MeasureProfile> measureProfiles = null;
        private List<Mask> masks = null;    

        public List<Sensor> SensorList
        {
            get
            {
                if (sensorList == null)
                    sensorList = getSensorList();
                return sensorList;
            }
        }

        public List<MeasureProfile> MeasureProfiles
        {
            get
            {
                if (measureProfiles == null)
                    measureProfiles = getMeasureProfiles();
                return measureProfiles;
            }
        }

        public List<Mask> Masks
        {
            get
            {
                if (masks == null)
                    masks = getAllMasks();
                return masks;
            }
        }

        public string getSIDbyID(int id)
        {
            return executeScalar("SELECT SID FROM Sensors WHERE ID=" + id) as string;
        }

        public int getIDbySID(string sid)
        {
            try
            {
                return (int)executeScalar("SELECT ID FROM Sensors WHERE SID=" + qouted(sid));
            }
            catch { return -1; }
        }

        public Sensor getSensorBySID(string SID)
        {
            foreach (Sensor sensor in SensorList)
                if (sensor.SID == SID)
                    return sensor;

            return null;
        }

        public bool insertSensor(Sensor sensor)
        {
            string SID, Name, Description, Settings;

            int count = (int)executeScalar("SELECT COUNT(*) FROM Sensors WHERE SID='" + sensor.SID + "'");

            if (count > 0) return false;

            SID = "'" +  sensor.SID + "'";
            Name = "'" + sensor.Name + "'";
            Description = sensor.Description == null ? "NULL" : "'" + sensor.Description  + "'";
            Settings = "'" + ServiceFunctions.serializeProperties(sensor.Settings) + "'";

            string query = "INSERT INTO SENSORS (SID, [Name], Description, Settings) VALUES (" + SID + ", " + Name + ", " + Description + ", " + Settings + ")";

            try
            {
                int res = executeNonQuery(query);
                sensorList = getSensorList();
                return res > 0;
            }
            catch (Exception ex)
            {
                sensorList = getSensorList();
                throw ex;
            }
        }

        public bool updateSensor(Sensor sensor, string sid)
        {
            string SID, Name, Description, Settings;
            int id = getIDbySID(sid);

            int count = (int)executeScalar("SELECT COUNT(*) FROM Sensors WHERE ID=" + id);
            if (count == 0) return false;

            SID = qouted(sensor.SID);
            Name = qouted(sensor.Name);
            Description = sensor.Description == null ? "NULL" : qouted(sensor.Description);
            Settings = "'" + ServiceFunctions.serializeProperties(sensor.Settings) + "'";

            string query = "UPDATE SENSORS SET [SID]=" + SID + ", [Name]=" + Name + ", Description=" + Description + ", Settings=" + Settings + " WHERE ID=" + id;

            try
            {
                int res = executeNonQuery(query);
                sensorList = getSensorList();
                return res > 0;
            }
            catch (Exception ex)
            {
                sensorList = getSensorList();
                throw ex;
            }
        }

        public bool deleteSensor(Sensor sensor)
        {
            bool r = executeNonQuery("DELETE FROM Sensors WHERE SID='" + sensor.SID + "'") > 0;
            sensorList = getSensorList();
            return r;
        }

        public List<Sensor> getSensorList()
        {
            List<Sensor> result = new List<Sensor>();
            IDataReader reader = executeSelect("SELECT * FROM Sensors");

            while (reader.Read())
            {
                string SID = reader["SID"] as string;
                string Name = reader["Name"] as string;
                string Description = 
                    reader["Description"] != DBNull.Value 
                    ? reader["Description"] as string 
                    : null;
                string Settings = reader["Settings"] as string;

                result.Add(new Sensor(SID, Name, Description, Settings));
            }
            reader.Close();
            sensorList = result;
            return result;
        }

        public MeasureData getMeasureDataByID(int mid)
        {
            Dictionary<Sensor, List<PointD>> data = new Dictionary<Sensor,List<PointD>>();
            Dictionary<Sensor, Dictionary<double, double>> dispdata = new Dictionary<Sensor,Dictionary<double,double>>();
            Dictionary<int, string> idsid = new Dictionary<int,string>();


            string query = "SELECT * FROM Data WHERE MeasureID=" + mid + "ORDER BY TimeValue";

            IDataReader reader = executeSelect(query);

            while (reader.Read())
            {
                Sensor sensor = null;
                string SID;
                
                int id = (int)reader["SensorID"];

                if (!idsid.ContainsKey(id))
                {
                    SID = executeScalar("SELECT SID FROM SENSORS WHERE ID=" + id) as string;
                    idsid.Add(id, SID);
                }

                sensor = getSensorBySID(idsid[id]);

                if (!data.ContainsKey(sensor))
                    data.Add(sensor, new List<PointD>());
                if (!dispdata.ContainsKey(sensor))
                    dispdata.Add(sensor, new Dictionary<double,double>());


                double TimeValue = Convert.ToDouble(reader["TimeValue"]);
                double FreqValue = Convert.ToDouble(reader["FreqValue"]);

                if (TimeValue < MagicNumber)
                    data[sensor].Add(new PointD(TimeValue, FreqValue));
                else
                    dispdata[sensor].Add(TimeValue - MagicNumber, FreqValue);
            }

            reader.Close();

            reader = executeSelect("SELECT * FROM Measures WHERE ID=" + mid);

            MeasureData measureData = null;

            if (reader.Read())
            {
                int id = (int)reader["ID"];
                
                string Name = reader["Name"] as string;

                string Description = (reader["Description"] != DBNull.Value) ? reader["Description"] as string : null;

                double fullLength = Convert.ToDouble(reader["FullLength"]);
                
                double Interval = Convert.ToDouble(reader["Interval"]);

                DateTime time = Convert.ToDateTime(reader["StartTime"]);
                
                bool isMeasured = Convert.ToBoolean(reader["isMeasured"]);

                int GroupId = (reader["GroupId"] != DBNull.Value) ? (int)reader["GroupId"] : -1;

                int MaskId = (reader["DefaultMask"] != DBNull.Value) ? (int)reader["DefaultMask"] : -1;

                reader.Close();

                measureData = new MeasureData(data, id, Name, time, Description, GroupId, fullLength, Interval, isMeasured, MaskId >=0 ? getMaskByID(MaskId) : null );
                if (!isMeasured) 
                    measureData.DispData = dispdata;
            }
            else
            {
                reader.Close(); 
                return null;
            }

            return measureData;
        }

        public bool updateMeasureData(MeasureData mdata)
        {
            string query = "UPDATE Measures SET GroupID=" + deNullID(mdata.GroupID);
            query += ", [Name]=" + qouted(mdata.Name);
            query += ", [Description]=" + qouted(mdata.Description);
            query += ", DefaultMask=" + deNullMaskID(mdata.DefaultMask);
            query += " WHERE ID=" + mdata.ID;
            int res = executeNonQuery(query);
            return res == 1;
        }

        public int insertMeasureData(MeasureData mdata)
        {
            string query;

            IDbTransaction tran = connection.BeginTransaction();
            int mid = -1;
            try
            {
                query = "INSERT INTO Measures ([Name], StartTime, Description, IsMeasured, GroupID, FullLength, Interval, DefaultMask) VALUES ";
                query += "(";
                query += qouted(mdata.Name) + ",";
                query += qouted(mdata.StartTime.ToString("yyyyMMdd HH:mm:ss")) + ", ";
                query += qouted(mdata.Description) + ", ";
                query += (mdata.IsMeasured ? "1" : "0") + ", ";
                query += deNullID(mdata.GroupID) + ", ";
                query += "" + mdata.FullMeasureLength.ToString().Replace(ServiceFunctions.rightsep, ServiceFunctions.wrongsep) + ", ";
                query += "" + mdata.MeasureInterval.ToString().Replace(ServiceFunctions.rightsep, ServiceFunctions.wrongsep) + ", ";
                query += "" + deNullMaskID(mdata.DefaultMask);
                query += ")";

                if (!(executeNonQuery(query) > 0)) return -1;

                mid = (int)executeScalar("SELECT MAX(ID) FROM Measures");

                foreach (Sensor sensor in mdata.AllData.Keys)
                {
                    int sensorid = getIDbySID(sensor.SID);

                    foreach (PointD point in mdata.AllData[sensor])
                    {
                        query = "INSERT INTO Data (MeasureID, TimeValue, FreqValue, SensorID) VALUES (";
                        query += "" + mid + ", " + point.X.ToString().Replace(ServiceFunctions.rightsep, ServiceFunctions.wrongsep)
                                          + ", " + point.Y.ToString().Replace(ServiceFunctions.rightsep, ServiceFunctions.wrongsep)
                                          + ", " + sensorid + ")";

                        if (executeNonQuery(query) != 1) throw new Exception();
                    }


                    if (!mdata.IsMeasured && mdata.DispData != null)
                        foreach (double tick in mdata.DispData[sensor].Keys)
                        {

                            query = "INSERT INTO Data (MeasureID, TimeValue, FreqValue, SensorID) VALUES (";
                            query += "" + mid + ", " + (tick + MagicNumber).ToString().Replace(ServiceFunctions.rightsep, ServiceFunctions.wrongsep)
                                              + ", " + mdata.DispData[sensor][tick].ToString().Replace(ServiceFunctions.rightsep, ServiceFunctions.wrongsep)
                                              + ", " + sensorid + ")";
                            if (executeNonQuery(query) != 1) throw new Exception();
                        }
                }
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }

            return mid;
        }

        public Mask getMaskByID(int id)
        {
            string query = "SELECT [Name] FROM Mask WHERE ID=" + id;

            string name;
            List<double> points = new List<double>();

            name = executeScalar(query) as string;

            if (name == null) return null;

            query = "SELECT TimeValue FROM MaskData WHERE MaskID=" + id + " ORDER BY TimeValue";

            IDataReader reader = executeSelect(query);

            while (reader.Read())
                points.Add((double)reader["TimeValue"]);

            reader.Close();

            return new Mask(id, name, points.ToArray());
        }

        public List<Mask> getAllMasks()
        {
            List<int> ids = new List<int>();
            List<Mask> lmasks = new List<Mask>();

            IDataReader reader = executeSelect("SELECT ID FROM Mask");

            while (reader.Read())
                ids.Add((int)reader["ID"]);

            reader.Close();

            foreach (int id in ids)
                lmasks.Add(getMaskByID(id));

            masks = lmasks;

            return masks;
        }

        public bool insertMask(Mask mask)
        {
            IDbTransaction trans = connection.BeginTransaction();
            try
            {
                string query = "INSERT INTO Mask ([Name]) VALUES (" + qouted(mask.Name) + ")";
                executeNonQuery(query);
                int id = (int)executeScalar("SELECT MAX(ID) FROM Mask");

                foreach (double time in mask.TimePoints)
                {
                    query = "INSERT INTO MaskData ([MaskID], [TimeValue]) VALUES (" + id + ", " +
                        time.ToString().Replace(',', '.') + ")";
                    executeNonQuery(query);
                }

                getAllMasks();
            }
            catch
            {
                trans.Rollback();
                return false;
            }

            return true;
        }

        public bool updateMask(Mask mask)
        {
            IDbTransaction trans = connection.BeginTransaction();
            try
            {
                delete("MaskData", "MaskID=" + mask.ID);
              
                int id = mask.ID;
                string query = "UPDATE Mask SET Name=" + qouted(mask.Name) + " WHERE ID=" + id;

                foreach (double time in mask.TimePoints)
                {
                    query = "INSERT INTO MaskData ([MaskID], [TimeValue]) VALUES (" + id + ", " +
                        time.ToString().Replace(',', '.') + ")";
                    executeNonQuery(query);
                }

                getAllMasks();
            }
            catch
            {
                trans.Rollback();
                return false;
            }

            return true;
        }

        public List<MeasureProfile> getMeasureProfiles()
        {
            string query = "SELECT * FROM MeasureProfile ORDER BY ID";

            IDataReader reader = executeSelect(query);

            List<MeasureProfile> list = new List<MeasureProfile>();

            while (reader.Read())
            {
                int id = (int)reader["ID"];
                string name = reader["name"] as string;
                int time = reader["TimeValue"] == DBNull.Value ? -1 : (int)reader["TimeValue"];
                int maskid = reader["MaskID"] == DBNull.Value ? -1 : (int)reader["MaskID"];
                list.Add(new MeasureProfile(id, name, new Dictionary<int, Sensor>(), time, maskid));
            }

            reader.Close();

            foreach (MeasureProfile prof in list)
            {
                query = "SELECT * FROM MeasureProfileData WHERE MeasureProfileID=" + prof.ID;

                reader = executeSelect(query);

                Dictionary<int, int> senpos = new Dictionary<int, int>();

                while (reader.Read())
                    senpos.Add((int)reader["Position"], (int)reader["SensorID"]);

                reader.Close();

                foreach (int pos in senpos.Keys)
                    prof.Settings.Add(pos, getSensorBySID(getSIDbyID(senpos[pos])));
            }
            measureProfiles = list;
            return list;
        }

        public MeasureProfile getMeasureProfileByID(int id)
        {
            MeasureProfile res = null;
            measureProfiles = getMeasureProfiles();

            foreach (MeasureProfile mp in MeasureProfiles)
                if (mp.ID == id) res = mp;

            return res;
        }

        public bool insertMeasureProfile(MeasureProfile profile)
        {
            IDbTransaction trans = connection.BeginTransaction();

            try
            {
                string query = "INSERT INTO MeasureProfile (Name, MaskID, TimeValue) VALUES (" + qouted(profile.Name);
                query += ", " + (profile.MaskID > 0 ? profile.MaskID.ToString() : "NULL") + ", " + (profile.Time > 0 ? profile.Time.ToString() : "NULL") + ")";
                executeNonQuery(query);

                int id = (int)executeScalar("SELECT MAX(ID) FROM MeasureProfile");

                foreach (int pos in profile.Settings.Keys)
                {
                    query = "INSERT INTO MeasureProfileData (SensorID, MeasureProfileID, Position) VALUES (";
                    query += "" + getIDbySID(profile.Settings[pos].SID) + ", " + id + ", " + pos + ")";
                    executeNonQuery(query);
                }
            }
            catch
            {
                trans.Rollback();
                return false;
            }


            trans.Commit();
            measureProfiles = getMeasureProfiles();
            return true;
        }


        private List<int> GetStatMeasures()
        {
            var statMeasures = new List<int>();
            string query = "SELECT DISTINCT MeasureId FROM Data WHERE TimeValue>=" + MagicNumber;
            IDataReader reader = executeSelect(query);
            while (reader.Read())
            {
                statMeasures.Add((int)reader["MeasureId"]);
            }
            reader.Close();
            return statMeasures;
        }



        //-----------------------------------------------------------//

        public GroupTreeNode GetMeasuresTreeFrom(List<int> statMeasures, GroupTreeNode node)
        {
            if (statMeasures==null)
                statMeasures = GetStatMeasures();
            string query = "SELECT * FROM GroupTree WHERE ParentID" + ((node.ID == -1) ? (" IS NULL") : ("=" + node.ID));

            IDataReader reader = executeSelect(query);

            if (node.SubNodes == null)
                node.SubNodes = new List<GroupTreeNode>();

            if (node.Measures == null)
                node.Measures = new Dictionary<int, string>();

            while (reader.Read())
            {
                int id = (int)reader["ID"];
                string name = reader["Name"] as string;
                string description = reader["Description"] == DBNull.Value ? null : (reader["Description"] as string);
               
                node.SubNodes.Add(new GroupTreeNode(id, name, description));
            }

            reader.Close();

             query = "SELECT ID, [Name], StartTime, IsMeasured, FullLength FROM Measures WHERE GroupID" + ((node.ID == -1) ? (" IS NULL") : ("=" + node.ID));

            reader = executeSelect(query);
            while (reader.Read())
            {
                int id = (int)reader["ID"];
                string name = reader["Name"] as string;
                DateTime dt = (DateTime)reader["StartTime"];
                bool IsMeasured = Convert.ToBoolean(reader["IsMeasured"]);
                int flen = (int)((double)reader["FullLength"]);
                MeasureData md = new MeasureData(new Dictionary<Sensor, List<PointD>>(), id, name, dt, "", -1, flen, 1, IsMeasured, null);
                if (statMeasures.Contains(id))
                {
                    md.DispData = new Dictionary<Sensor, Dictionary<double, double>>();
                    md.DispData.Add(sensorList[0], new Dictionary<double,double>());
                }
                node.Measures.Add(id, md.ToString());
            }

            reader.Close();


            
            for (int i = 0; i < node.SubNodes.Count; i++)
                node.SubNodes[i] = GetMeasuresTreeFrom(statMeasures,node.SubNodes[i]);
            


            return node;
        }

        public int AddGroupTo(GroupTreeNode group, int gid)
        {
            string query = "INSERT INTO GroupTree ([Name], [Description], ParentID) VALUES (";
            query += qouted(group.Name) + ", " + qouted(group.Description) + ", " + ((gid != -1) ? gid.ToString() : "NULL") + ")";

            executeNonQuery(query);

            int scalar = (int)executeScalar("SELECT MAX(ID) FROM GroupTree");
            return scalar;
        }

        public void EditGroup(GroupTreeNode group)
        {
            string query = "UPDATE GroupTree SET [Name]=" + qouted(group.Name) + " Description=" + qouted(group.Description) +
                " WHERE ID=" + group.ID;
            executeNonQuery(query);
        }

        public void EditGroupParent(GroupTreeNode group, int parentID)
        {
            string query = "UPDATE GroupTree ParentID=" + (parentID == -1 ? "NULL" : parentID.ToString()) +
                " WHERE ID=" + group.ID;
            executeNonQuery(query);
        }

        public bool willMakeCycle(int childGID, int newPGID)
        {
            if (childGID == newPGID)
                return true;

            int _newPGID = newPGID;

            do
            {
                object o = executeScalar("SELECT ParentID FROM GroupTree WHERE ID=" + newPGID);
                if (o == null) return true;
                if (o == DBNull.Value) _newPGID = -1;
                else _newPGID = (int)o;
            }
            while (_newPGID != -1 && _newPGID != childGID);

            return _newPGID != -1;
        }

        public void DeleteGroup(int id)
        {
            try
            {
                string allid = "SELECT ID FROM GroupTree WHERE ParentID=";
                string q = "SELECT COUNT(*) FROM GroupTree WHERE ParentID=";

                if ((int)executeScalar(q + id) > 0)
                {
                    List<int> ids = new List<int>();

                    IDataReader reader = executeSelect(allid + id);

                    while (reader.Read())
                        ids.Add((int)reader["ID"]);
                    
                    reader.Close();

                    foreach (int nid in ids)
                        DeleteGroup(nid);
                }

                delete("GroupTree", "ID=" + id);
            }
            catch { }
        }

        public void updateGroupParentId(int GID, int GPID)
        {
            string query = "UPDATE GroupTree SET ParentID=" + (GPID > 0 ? GPID.ToString() : "NULL") + " WHERE ID=" + GID;
            executeNonQuery(query);
        }

        public void RenameGroup(int GID, string newname)
        {
            string query = "UPDATE GroupTree SET [Name]=" + qouted(newname) + " WHERE ID=" + GID;
            executeNonQuery(query);
        }
    }
}

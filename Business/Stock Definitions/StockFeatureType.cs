using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class StockFeatureType
    {
        public StockFeatureType(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~StockFeatureType()
        {
            if (Table != null)
                Table.Dispose();

            Table = null;
        }

        #region Row

        public class Recording
        {
            public Recording()
            {
                Reset();
            }

            public long StockFeatureTypeID { get; set; }
            public string StockCode { get; set; }
            public string Name { get; set; }
            public long MachineGroup1ID { get; set; }
            public long MachineGroup2ID { get; set; }
            public long MachineGroup3ID { get; set; }
            public long MachineGroup4ID { get; set; }
            public string Code1 { get; set; }
            public string Code2 { get; set; }
            public decimal Code3 { get; set; }
            public int ColorTypeID { get; set; }
            public int TouchnessID { get; set; }
            public int FeatureID { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                StockFeatureTypeID = MachineGroup1ID = MachineGroup2ID = MachineGroup3ID = MachineGroup4ID = 0;
                Code3 = 0;
                ColorTypeID = TouchnessID = FeatureID = 0;
                StockCode = Name = Code1 = Code2 = "";
                Status = Status.Active;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    StockFeatureTypeID = Utility.ToLong(row["StockFeatureTypeID"]);
                    StockCode = row["StockCode"].ToString();
                    Name = row["Name"].ToString();
                    MachineGroup1ID = Utility.ToLong(row["MachineGroup1ID"]);
                    MachineGroup2ID = Utility.ToLong(row["MachineGroup2ID"]);
                    MachineGroup3ID = Utility.ToLong(row["MachineGroup3ID"]);
                    MachineGroup4ID = Utility.ToLong(row["MachineGroup4ID"]);
                    Code1 = row["Code1"].ToString();
                    Code2 = row["Code2"].ToString();
                    Code3 = Utility.ToDecimal(row["Code3"]);
                    ColorTypeID = Utility.ToInt32(row["ColorTypeID"]);
                    TouchnessID = Utility.ToInt32(row["TouchnessID"]);
                    FeatureID = Utility.ToInt32(row["FeatureID"]);
                    Status = (Status)Utility.ToByte(row["Status"]);
                    RowGUID = Utility.ToGuid(row["RowGUID"]);
                }
            }
        }

        #endregion Row

        #region Definitions

        private readonly SqlConnection Connection;
        private DataTable Table;

        private static DataTable List;

        public Recording Record;

        public const string TableName = "[dbo].[tblStockFeatureType]";

        public enum Status
        {
            Deleted = -1,
            Passive = 0,
            Active = 1
        }

        public static DataTable StatusList()
        {
            var dStatus = new DataTable();

            dStatus.Columns.Add("Name", typeof(string));
            dStatus.Columns.Add("Value", typeof(short));

            dStatus.Rows.Add("Etkin", (short)Status.Active);
            dStatus.Rows.Add("Devre Dışı", (short)Status.Passive);
            dStatus.Rows.Add("Silindi", (short)Status.Deleted);

            return dStatus;
        }

        #endregion Definitions

        #region Data

        public DataTable GetTable()
        {
            return Table;
        }

        public static DataTable GetList(SqlConnection connection, bool OnlyActive = true)
        {
            if (Database.CheckConnection(connection))
                List = Select("", OnlyActive ? 1 : 0, connection);
            else
                List = null;

            return List;
        }

        public int Insert(ref object StockFeatureTypeID, object StockCode, object Name, object MachineGroup1ID,
            object MachineGroup2ID, object MachineGroup3ID, object MachineGroup4ID, object Code1, object Code2,
            object Code3, object ColorTypeID, object TouchnessID, object FeatureID, object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spStockFeatureTypeInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockFeatureTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockFeatureTypeID"].Value = Utility.ToDBNull(StockFeatureTypeID);
                    cmd.Parameters["@StockFeatureTypeID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroup1ID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroup1ID"].Value = Utility.ToDBNull(MachineGroup1ID);
                    cmd.Parameters["@MachineGroup1ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroup2ID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroup2ID"].Value = Utility.ToDBNull(MachineGroup2ID);
                    cmd.Parameters["@MachineGroup2ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroup3ID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroup3ID"].Value = Utility.ToDBNull(MachineGroup3ID);
                    cmd.Parameters["@MachineGroup3ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroup4ID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroup4ID"].Value = Utility.ToDBNull(MachineGroup4ID);
                    cmd.Parameters["@MachineGroup4ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code1", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code1"].Value = Utility.ToDBNull(Code1);
                    cmd.Parameters["@Code1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code2", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code2"].Value = Utility.ToDBNull(Code2);
                    cmd.Parameters["@Code2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code3", SqlDbType.Decimal);
                    cmd.Parameters["@Code3"].Value = Utility.ToDBNull(Code3);
                    cmd.Parameters["@Code3"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Code3"].Precision = 18;
                    cmd.Parameters["@Code3"].Scale = 2;

                    cmd.Parameters.Add("@ColorTypeID", SqlDbType.Int);
                    cmd.Parameters["@ColorTypeID"].Value = Utility.ToDBNull(ColorTypeID);
                    cmd.Parameters["@ColorTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@TouchnessID", SqlDbType.Int);
                    cmd.Parameters["@TouchnessID"].Value = Utility.ToDBNull(TouchnessID);
                    cmd.Parameters["@TouchnessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FeatureID", SqlDbType.Int);
                    cmd.Parameters["@FeatureID"].Value = Utility.ToDBNull(FeatureID);
                    cmd.Parameters["@FeatureID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                    cmd.Parameters["@Status"].Value = Utility.ToDBNull(Status);
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                    RowGUID = Guid.NewGuid();

                    cmd.Parameters.Add("@RowGUID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@RowGUID"].Value = Utility.ToDBNull(RowGUID);
                    cmd.Parameters["@RowGUID"].Direction = ParameterDirection.Input;

                    //Common.AddLog(ref cmd, Utility.ToLong(UserID), Utility.ToGuid(RowGUID), true, true);

                    cmd.Parameters.Add("@Result", SqlDbType.Int);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    StockFeatureTypeID = cmd.Parameters["@StockFeatureTypeID"].Value;

                    return Utility.ToInt32(cmd.Parameters["@Result"].Value);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                }
            }

            return -1;
        }

        public int Update(object StockFeatureTypeID, object StockCode, object Name, object MachineGroup1ID,
            object MachineGroup2ID, object MachineGroup3ID, object MachineGroup4ID, object Code1, object Code2,
            object Code3, object ColorTypeID, object TouchnessID, object FeatureID, object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spStockFeatureTypeUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockFeatureTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockFeatureTypeID"].Value = Utility.ToDBNull(StockFeatureTypeID);
                    cmd.Parameters["@StockFeatureTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroup1ID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroup1ID"].Value = Utility.ToDBNull(MachineGroup1ID);
                    cmd.Parameters["@MachineGroup1ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroup2ID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroup2ID"].Value = Utility.ToDBNull(MachineGroup2ID);
                    cmd.Parameters["@MachineGroup2ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroup3ID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroup3ID"].Value = Utility.ToDBNull(MachineGroup3ID);
                    cmd.Parameters["@MachineGroup3ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroup4ID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroup4ID"].Value = Utility.ToDBNull(MachineGroup4ID);
                    cmd.Parameters["@MachineGroup4ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code1", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code1"].Value = Utility.ToDBNull(Code1);
                    cmd.Parameters["@Code1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code2", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code2"].Value = Utility.ToDBNull(Code2);
                    cmd.Parameters["@Code2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code3", SqlDbType.Decimal);
                    cmd.Parameters["@Code3"].Value = Utility.ToDBNull(Code3);
                    cmd.Parameters["@Code3"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Code3"].Precision = 18;
                    cmd.Parameters["@Code3"].Scale = 2;

                    cmd.Parameters.Add("@ColorTypeID", SqlDbType.Int);
                    cmd.Parameters["@ColorTypeID"].Value = Utility.ToDBNull(ColorTypeID);
                    cmd.Parameters["@ColorTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@TouchnessID", SqlDbType.Int);
                    cmd.Parameters["@TouchnessID"].Value = Utility.ToDBNull(TouchnessID);
                    cmd.Parameters["@TouchnessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FeatureID", SqlDbType.Int);
                    cmd.Parameters["@FeatureID"].Value = Utility.ToDBNull(FeatureID);
                    cmd.Parameters["@FeatureID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                    cmd.Parameters["@Status"].Value = Utility.ToDBNull(Status);
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@RowGUID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@RowGUID"].Value = Utility.ToDBNull(RowGUID);
                    cmd.Parameters["@RowGUID"].Direction = ParameterDirection.Input;

                    //Common.AddLog(ref cmd, Utility.ToLong(UserID), Utility.ToGuid(RowGUID), false);

                    cmd.Parameters.Add("@Result", SqlDbType.Int);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    return Utility.ToInt32(cmd.Parameters["@Result"].Value);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                }
            }

            return -1;
        }

        public int Delete(object StockFeatureTypeID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spStockFeatureTypeDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockFeatureTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockFeatureTypeID"].Value = StockFeatureTypeID;
                    cmd.Parameters["@StockFeatureTypeID"].Direction = ParameterDirection.Input;

                    //Common.AddLog(ref cmd, Utility.ToLong(UserID), Utility.ToGuid(RowGUID), false);

                    cmd.Parameters.Add("@Result", SqlDbType.Int);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    return Utility.ToInt32(cmd.Parameters["@Result"].Value);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                }
            }

            return -1;
        }

        public static DataTable Select(string StockCode, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spStockFeatureTypeSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@StockCode"].Value = StockCode;
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                    cmd.Parameters["@Status"].Value = Status;
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, TableName);

                    return ds.Tables[0];
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                }
            }

            return null;
        }

        public static DataTable GetList(SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "SELECT [StockFeatureTypeID],[StockFeatureType] FROM [dbo].[vwStockFeatureType]";
                    cmd.CommandType = CommandType.Text;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, TableName);

                    return ds.Tables[0];
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                }
            }

            return null;
        }

        #endregion Data
    }
}
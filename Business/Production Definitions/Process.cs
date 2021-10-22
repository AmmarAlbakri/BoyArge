using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class Process
    {
        public Process(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~Process()
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

            public long ProcessID { get; set; }
            public long ZoneID { get; set; }
            public long MachineGroupID { get; set; }
            public long ProcessTypeID { get; set; }
            public string Specode { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Note { get; set; }
            public string Code1 { get; set; }
            public string Code2 { get; set; }
            public decimal Code3 { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                ProcessID = ZoneID = MachineGroupID = ProcessTypeID = 0;
                Status = Status.Active;
                Code = Name = Note = Specode = Code1 = Code2 = "";
                Code3 = 0;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    ProcessID = Utility.ToLong(row["ProcessID"]);
                    ZoneID = Utility.ToLong(row["ZoneID"]);
                    MachineGroupID = Utility.ToLong(row["MachineGroupID"]);
                    ProcessTypeID = Utility.ToLong(row["ProcessTypeID"]);
                    Specode = row["Specode"].ToString();
                    Code = row["Code"].ToString();
                    Name = row["Name"].ToString();
                    Note = row["Note"].ToString();
                    Code1 = row["Code1"].ToString();
                    Code2 = row["Code2"].ToString();
                    Code3 = Utility.ToDecimal(row["Code3"]);
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

        public const string TableName = "[dbo].[tblProcess]";

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

        public static DataTable GetList(SqlConnection connection, long ZoneID, bool OnlyActive = true)
        {
            if (Database.CheckConnection(connection))
                List = Select(0, ZoneID, OnlyActive ? 1 : 0, connection);
            else
                List = null;

            return List;
        }

        public int Insert(ref object ProcessID, object ZoneID, object MachineGroupID, object ProcessTypeID,
            object Specode, object Name, object Code, object Note, object Code1, object Code2, object Code3,
            object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spProcessInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = Utility.ToDBNull(ProcessID);
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = Utility.ToDBNull(MachineGroupID);
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessTypeID", SqlDbType.Int);
                    cmd.Parameters["@ProcessTypeID"].Value = Utility.ToDBNull(ProcessTypeID);
                    cmd.Parameters["@ProcessTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Specode", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Specode"].Value = Utility.ToDBNull(Specode);
                    cmd.Parameters["@Specode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Note", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Note"].Value = Utility.ToDBNull(Note);
                    cmd.Parameters["@Note"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code1", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Code1"].Value = Utility.ToDBNull(Code1);
                    cmd.Parameters["@Code1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code2", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Code2"].Value = Utility.ToDBNull(Code2);
                    cmd.Parameters["@Code2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code3", SqlDbType.Decimal);
                    cmd.Parameters["@Code3"].Value = Utility.ToDBNull(Code3);
                    cmd.Parameters["@Code3"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Code3"].Precision = 18;
                    cmd.Parameters["@Code3"].Scale = 4;

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

                    ProcessID = cmd.Parameters["@ProcessID"].Value;

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

        public int Update(object ProcessID, object ZoneID, object MachineGroupID, object ProcessTypeID, object Specode,
            object Name, object Code, object Note, object Code1, object Code2, object Code3, object Status,
            object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spProcessUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = Utility.ToDBNull(ProcessID);
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = Utility.ToDBNull(MachineGroupID);
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessTypeID", SqlDbType.Int);
                    cmd.Parameters["@ProcessTypeID"].Value = Utility.ToDBNull(ProcessTypeID);
                    cmd.Parameters["@ProcessTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Specode", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Specode"].Value = Utility.ToDBNull(Specode);
                    cmd.Parameters["@Specode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Note", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Note"].Value = Utility.ToDBNull(Note);
                    cmd.Parameters["@Note"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code1", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Code1"].Value = Utility.ToDBNull(Code1);
                    cmd.Parameters["@Code1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code2", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Code2"].Value = Utility.ToDBNull(Code2);
                    cmd.Parameters["@Code2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code3", SqlDbType.Decimal);
                    cmd.Parameters["@Code3"].Value = Utility.ToDBNull(Code3);
                    cmd.Parameters["@Code3"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Code3"].Precision = 18;
                    cmd.Parameters["@Code3"].Scale = 4;

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

        public int Delete(object ProcessID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spProcessDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = ProcessID;
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long ProcessID, long ZoneID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spProcessSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.SmallInt);
                    cmd.Parameters["@ProcessID"].Value = ProcessID;
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.SmallInt);
                    cmd.Parameters["@ZoneID"].Value = ZoneID;
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

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

        public static DataTable SelectByStock(string StockCode, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spProcessSelectByStock]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
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

        #endregion Data
    }
}
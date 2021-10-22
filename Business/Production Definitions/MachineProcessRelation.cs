using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class MachineProcessRelation
    {
        public MachineProcessRelation(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~MachineProcessRelation()
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

            public long MachineProcessRelationID { get; set; }
            public long MachineID { get; set; }
            public long ProcessID { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                MachineProcessRelationID = MachineID = ProcessID = 0;
                Status = Status.Active;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    MachineProcessRelationID = Utility.ToLong(row["MachineProcessRelationID"]);
                    MachineID = Utility.ToLong(row["MachineID"]);
                    ProcessID = Utility.ToLong(row["ProcessID"]);
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

        public const string TableName = "[dbo].[tblMachineProcessRelation]";

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
                List = Select(0, 0, 0, OnlyActive ? 1 : 0, connection);
            else
                List = null;

            return List;
        }

        public int Insert(ref object MachineProcessRelationID, object MachineID, object ProcessID, object Status,
            ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spMachineProcessRelationInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineProcessRelationID", SqlDbType.Int);
                    cmd.Parameters["@MachineProcessRelationID"].Value = Utility.ToDBNull(MachineProcessRelationID);
                    cmd.Parameters["@MachineProcessRelationID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = Utility.ToDBNull(MachineID);
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = Utility.ToDBNull(ProcessID);
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

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

                    MachineProcessRelationID = cmd.Parameters["@MachineProcessRelationID"].Value;

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

        public int Update(object MachineProcessRelationID, object MachineID, object ProcessID, object Status,
            object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spMachineProcessRelationUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineProcessRelationID", SqlDbType.Int);
                    cmd.Parameters["@MachineProcessRelationID"].Value = Utility.ToDBNull(MachineProcessRelationID);
                    cmd.Parameters["@MachineProcessRelationID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = Utility.ToDBNull(MachineID);
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = Utility.ToDBNull(ProcessID);
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

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

        public int Delete(object MachineProcessRelationID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spMachineProcessRelationDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineProcessRelationID", SqlDbType.Int);
                    cmd.Parameters["@MachineProcessRelationID"].Value = MachineProcessRelationID;
                    cmd.Parameters["@MachineProcessRelationID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long MachineProcessRelationID, long MachineID, long ProcessID, int Status,
            SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spMachineProcessRelationSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineProcessRelationID", SqlDbType.Int);
                    cmd.Parameters["@MachineProcessRelationID"].Value = MachineProcessRelationID;
                    cmd.Parameters["@MachineProcessRelationID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = MachineID;
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = ProcessID;
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

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
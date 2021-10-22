using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class Zone
    {
        public Zone(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~Zone()
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

            public long ZoneID { get; set; }
            public long FirmID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                ZoneID = FirmID = 0;
                Status = Status.Active;
                Code = Name = "";
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    ZoneID = Utility.ToLong(row["ZoneID"]);
                    FirmID = Utility.ToLong(row["FirmID"]);
                    Code = row["Code"].ToString();
                    Name = row["Name"].ToString();
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

        public const string TableName = "[dbo].[tblZone]";

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

        public static DataTable GetList(SqlConnection connection, long FirmID, bool OnlyActive = true)
        {
            if (Database.CheckConnection(connection))
                List = Select(0, FirmID, OnlyActive ? 1 : 0, connection);
            else
                List = null;

            return List;
        }

        //public void Refresh(bool OnlyActive, bool Dummy)
        //{
        //    if (!Dummy)
        //    {
        //        StringBuilder sql = new StringBuilder();

        //        sql.AppendLine("SELECT");
        //        sql.AppendLine("    [ZoneID],");
        //        sql.AppendLine("    [FirmID],");
        //        sql.AppendLine("    [Code],");
        //        sql.AppendLine("    [Name],");
        //        sql.AppendLine("    [Status],");
        //        sql.AppendLine("    [RowGUID]");
        //        sql.AppendLine("FROM [dbo].[tblZone]");

        //        if (OnlyActive)
        //            sql.AppendLine("WHERE [Status] > 0");
        //        else
        //            sql.AppendLine("WHERE [Status] >= 0");

        //        sql.AppendLine("ORDER BY [Code]");

        //        this.Table = Database.GetList(sql.ToString(), this.Connection, Zone.TableName);
        //    }
        //    else
        //    {
        //        this.Table = new DataTable(Zone.TableName);

        //        this.Table.Columns.Add("ZoneID", typeof(long));
        //        this.Table.Columns.Add("FirmID", typeof(long));
        //        this.Table.Columns.Add("Code", typeof(string));
        //        this.Table.Columns.Add("Name", typeof(string));
        //        this.Table.Columns.Add("Status", typeof(Int16));
        //        this.Table.Columns.Add("RowGUID", typeof(string));

        //        this.Table.AcceptChanges();
        //    }
        //}

        public int Insert(ref object ZoneID, object FirmID, object Name, object Code, object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spZoneInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@FirmID", SqlDbType.Int);
                    cmd.Parameters["@FirmID"].Value = Utility.ToDBNull(FirmID);
                    cmd.Parameters["@FirmID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

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

                    ZoneID = cmd.Parameters["@ZoneID"].Value;

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

        public int Update(object ZoneID, object FirmID, object Name, object Code, object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spZoneUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FirmID", SqlDbType.Int);
                    cmd.Parameters["@FirmID"].Value = Utility.ToDBNull(FirmID);
                    cmd.Parameters["@FirmID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

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

        public int Delete(object ZoneID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spZoneDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = ZoneID;
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long ZoneID, long FirmID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spZoneSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.SmallInt);
                    cmd.Parameters["@ZoneID"].Value = ZoneID;
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FirmID", SqlDbType.SmallInt);
                    cmd.Parameters["@FirmID"].Value = FirmID;
                    cmd.Parameters["@FirmID"].Direction = ParameterDirection.Input;

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
using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class MachineGroup
    {
        public MachineGroup(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~MachineGroup()
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

            public long MachineGroupID { get; set; }
            public long ZoneID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public decimal ShiftHour { get; set; }
            public decimal ShiftDay { get; set; }
            public int ShiftCount { get; set; }
            public decimal PersonelHour { get; set; }
            public decimal PersonelDay { get; set; }
            public decimal ZoneExpensePercent { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                MachineGroupID = ZoneID = ShiftCount = 0;
                ShiftHour = ShiftDay = PersonelHour = PersonelDay = ZoneExpensePercent = 0;
                Status = Status.Active;
                Code = Name = "";
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    MachineGroupID = Utility.ToLong(row["MachineGroupID"]);
                    ZoneID = Utility.ToLong(row["ZoneID"]);
                    Code = row["Code"].ToString();
                    Name = row["Name"].ToString();
                    ShiftHour = Utility.ToDecimal(row["ShiftHour"]);
                    ShiftDay = Utility.ToDecimal(row["ShiftDay"]);
                    ShiftCount = Utility.ToInt32(row["ShiftCount"]);
                    PersonelHour = Utility.ToDecimal(row["PersonelHour"]);
                    PersonelDay = Utility.ToDecimal(row["PersonelDay"]);
                    ZoneExpensePercent = Utility.ToDecimal(row["ZoneExpensePercent"]);
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

        public const string TableName = "[dbo].[tblMachineGroup]";

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

        //public void Refresh(bool OnlyActive, bool Dummy)
        //{
        //    if (!Dummy)
        //    {
        //        StringBuilder sql = new StringBuilder();

        //        sql.AppendLine("SELECT");
        //        sql.AppendLine("    [MachineGroupID],");
        //        sql.AppendLine("    [ZoneID],");
        //        sql.AppendLine("    [Code],");
        //        sql.AppendLine("    [Name],");
        //        sql.AppendLine("    [Status],");
        //        sql.AppendLine("    [RowGUID]");
        //        sql.AppendLine("FROM [dbo].[tblMachineGroup]");

        //        if (OnlyActive)
        //            sql.AppendLine("WHERE [Status] > 0");
        //        else
        //            sql.AppendLine("WHERE [Status] >= 0");

        //        sql.AppendLine("ORDER BY [Code]");

        //        this.Table = Database.GetList(sql.ToString(), this.Connection, MachineGroup.TableName);
        //    }
        //    else
        //    {
        //        this.Table = new DataTable(MachineGroup.TableName);

        //        this.Table.Columns.Add("MachineGroupID", typeof(long));
        //        this.Table.Columns.Add("ZoneID", typeof(long));
        //        this.Table.Columns.Add("Code", typeof(string));
        //        this.Table.Columns.Add("Name", typeof(string));
        //        this.Table.Columns.Add("Status", typeof(Int16));
        //        this.Table.Columns.Add("RowGUID", typeof(string));

        //        this.Table.AcceptChanges();
        //    }
        //}

        public int Insert(ref object MachineGroupID, object ZoneID, object Name, object Code, object ShiftHour,
            object ShiftDay, object ShiftCount, object PersonelHour, object PersonelDay, object ZoneExpensePercent,
            object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spMachineGroupInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = Utility.ToDBNull(MachineGroupID);
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ShiftHour", SqlDbType.Decimal);
                    cmd.Parameters["@ShiftHour"].Value = Utility.ToDBNull(ShiftHour);
                    cmd.Parameters["@ShiftHour"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ShiftHour"].Precision = 18;
                    cmd.Parameters["@ShiftHour"].Scale = 2;

                    cmd.Parameters.Add("@ShiftDay", SqlDbType.Decimal);
                    cmd.Parameters["@ShiftDay"].Value = Utility.ToDBNull(ShiftDay);
                    cmd.Parameters["@ShiftDay"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ShiftDay"].Precision = 18;
                    cmd.Parameters["@ShiftDay"].Scale = 2;

                    cmd.Parameters.Add("@ShiftCount", SqlDbType.Int);
                    cmd.Parameters["@ShiftCount"].Value = Utility.ToDBNull(ShiftCount);
                    cmd.Parameters["@ShiftCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@PersonelHour", SqlDbType.Decimal);
                    cmd.Parameters["@PersonelHour"].Value = Utility.ToDBNull(PersonelHour);
                    cmd.Parameters["@PersonelHour"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@PersonelHour"].Precision = 18;
                    cmd.Parameters["@PersonelHour"].Scale = 2;

                    cmd.Parameters.Add("@PersonelDay", SqlDbType.Decimal);
                    cmd.Parameters["@PersonelDay"].Value = Utility.ToDBNull(PersonelDay);
                    cmd.Parameters["@PersonelDay"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@PersonelDay"].Precision = 18;
                    cmd.Parameters["@PersonelDay"].Scale = 2;

                    cmd.Parameters.Add("@ZoneExpensePercent", SqlDbType.Decimal);
                    cmd.Parameters["@ZoneExpensePercent"].Value = Utility.ToDBNull(ZoneExpensePercent);
                    cmd.Parameters["@ZoneExpensePercent"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ZoneExpensePercent"].Precision = 18;
                    cmd.Parameters["@ZoneExpensePercent"].Scale = 2;
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

                    MachineGroupID = cmd.Parameters["@MachineGroupID"].Value;

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

        public int Update(object MachineGroupID, object ZoneID, object Name, object Code, object ShiftHour,
            object ShiftDay, object ShiftCount, object PersonelHour, object PersonelDay, object ZoneExpensePercent,
            object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spMachineGroupUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = Utility.ToDBNull(MachineGroupID);
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ShiftHour", SqlDbType.Decimal);
                    cmd.Parameters["@ShiftHour"].Value = Utility.ToDBNull(ShiftHour);
                    cmd.Parameters["@ShiftHour"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ShiftHour"].Precision = 18;
                    cmd.Parameters["@ShiftHour"].Scale = 2;

                    cmd.Parameters.Add("@ShiftDay", SqlDbType.Decimal);
                    cmd.Parameters["@ShiftDay"].Value = Utility.ToDBNull(ShiftDay);
                    cmd.Parameters["@ShiftDay"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ShiftDay"].Precision = 18;
                    cmd.Parameters["@ShiftDay"].Scale = 2;

                    cmd.Parameters.Add("@ShiftCount", SqlDbType.Int);
                    cmd.Parameters["@ShiftCount"].Value = Utility.ToDBNull(ShiftCount);
                    cmd.Parameters["@ShiftCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@PersonelHour", SqlDbType.Decimal);
                    cmd.Parameters["@PersonelHour"].Value = Utility.ToDBNull(PersonelHour);
                    cmd.Parameters["@PersonelHour"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@PersonelHour"].Precision = 18;
                    cmd.Parameters["@PersonelHour"].Scale = 2;

                    cmd.Parameters.Add("@PersonelDay", SqlDbType.Decimal);
                    cmd.Parameters["@PersonelDay"].Value = Utility.ToDBNull(PersonelDay);
                    cmd.Parameters["@PersonelDay"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@PersonelDay"].Precision = 18;
                    cmd.Parameters["@PersonelDay"].Scale = 2;

                    cmd.Parameters.Add("@ZoneExpensePercent", SqlDbType.Decimal);
                    cmd.Parameters["@ZoneExpensePercent"].Value = Utility.ToDBNull(ZoneExpensePercent);
                    cmd.Parameters["@ZoneExpensePercent"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ZoneExpensePercent"].Precision = 18;
                    cmd.Parameters["@ZoneExpensePercent"].Scale = 2;

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

        public int Delete(object MachineGroupID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spMachineGroupDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = MachineGroupID;
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long MachineGroupID, long ZoneID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spMachineGroupSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.SmallInt);
                    cmd.Parameters["@MachineGroupID"].Value = MachineGroupID;
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

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

        #endregion Data
    }
}
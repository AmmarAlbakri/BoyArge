using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class DepartmentRelation
    {
        public DepartmentRelation(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~DepartmentRelation()
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

            public long DepartmentRelationID { get; set; }
            public long DepartmentID { get; set; }
            public long MachineGroupID { get; set; }
            public long TitleID { get; set; }
            public long ExchangeTypeID { get; set; }
            public int WorkerCount { get; set; }
            public decimal Cost { get; set; }
            public bool DirectOrIndirect { get; set; }
            public bool PrivateOrPublic { get; set; }
            public bool SalaryOrOvertime { get; set; }
            public bool AnnualorMonthly { get; set; }
            public bool ShiftorDaytime { get; set; }
            public DateTime Month { get; set; }
            public DateTime Date { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                DepartmentRelationID = DepartmentID = TitleID = ExchangeTypeID = 0;
                Cost = WorkerCount = 0;
                Status = Status.Active;
                DirectOrIndirect = PrivateOrPublic = SalaryOrOvertime = AnnualorMonthly = ShiftorDaytime = false;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    DepartmentRelationID = Utility.ToLong(row["DepartmentRelationID"]);
                    DepartmentID = Utility.ToLong(row["DepartmentID"]);
                    MachineGroupID = Utility.ToLong(row["MachineGroupID"]);
                    TitleID = Utility.ToLong(row["TitleID"]);
                    ExchangeTypeID = Utility.ToLong(row["ExchangeTypeID"]);
                    WorkerCount = Utility.ToInt32(row["WorkerCount"]);
                    Cost = Utility.ToDecimal(row["Cost"]);
                    DirectOrIndirect = Utility.ToBoolean(row["DirectOrIndirect"]);
                    PrivateOrPublic = Utility.ToBoolean(row["PrivateOrPublic"]);
                    SalaryOrOvertime = Utility.ToBoolean(row["SalaryOrOvertime"]);
                    AnnualorMonthly = Utility.ToBoolean(row["AnnualorMonthly"]);
                    ShiftorDaytime = Utility.ToBoolean(row["ShiftorDaytime"]);
                    Month = Utility.ToDateTime(row["Month"]);
                    Date = Utility.ToDateTime(row["Date"]);
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

        public const string TableName = "[dbo].[tblDepartmentRelation]";

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
                List = Select(0, OnlyActive ? 1 : 0, connection);
            else
                List = null;

            return List;
        }

        public int Insert(ref object DepartmentRelationID, object MachineGroupID, object DepartmentID, object TitleID,
            object ExchangeTypeID, object WorkerCount, object Cost, object DirectOrIndirect, object PrivateOrPublic,
            object SalaryOrOvertime, object AnnualorMonthly, object ShiftorDaytime, object Month, object Date,
            object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spDepartmentRelationInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartmentRelationID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentRelationID"].Value = Utility.ToDBNull(DepartmentRelationID);
                    cmd.Parameters["@DepartmentRelationID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentID"].Value = Utility.ToDBNull(DepartmentID);
                    cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = Utility.ToDBNull(MachineGroupID);
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@TitleID", SqlDbType.Int);
                    cmd.Parameters["@TitleID"].Value = Utility.ToDBNull(TitleID);
                    cmd.Parameters["@TitleID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExchangeTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExchangeTypeID"].Value = Utility.ToDBNull(ExchangeTypeID);
                    cmd.Parameters["@ExchangeTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@WorkerCount", SqlDbType.Int);
                    cmd.Parameters["@WorkerCount"].Value = Utility.ToDBNull(WorkerCount);
                    cmd.Parameters["@WorkerCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Cost", SqlDbType.Decimal);
                    cmd.Parameters["@Cost"].Value = Utility.ToDBNull(Cost);
                    cmd.Parameters["@Cost"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Cost"].Precision = 18;
                    cmd.Parameters["@Cost"].Scale = 2;

                    cmd.Parameters.Add("@DirectOrIndirect", SqlDbType.Bit);
                    cmd.Parameters["@DirectOrIndirect"].Value = Utility.ToDBNull(DirectOrIndirect);
                    cmd.Parameters["@DirectOrIndirect"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@PrivateOrPublic", SqlDbType.Bit);
                    cmd.Parameters["@PrivateOrPublic"].Value = Utility.ToDBNull(PrivateOrPublic);
                    cmd.Parameters["@PrivateOrPublic"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@SalaryOrOvertime", SqlDbType.Bit);
                    cmd.Parameters["@SalaryOrOvertime"].Value = Utility.ToDBNull(SalaryOrOvertime);
                    cmd.Parameters["@SalaryOrOvertime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@AnnualorMonthly", SqlDbType.Bit);
                    cmd.Parameters["@AnnualorMonthly"].Value = Utility.ToDBNull(AnnualorMonthly);
                    cmd.Parameters["@AnnualorMonthly"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ShiftorDaytime", SqlDbType.Bit);
                    cmd.Parameters["@ShiftorDaytime"].Value = Utility.ToDBNull(ShiftorDaytime);
                    cmd.Parameters["@ShiftorDaytime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Month", SqlDbType.Date);
                    cmd.Parameters["@Month"].Value = Utility.ToDBNull(Month);
                    cmd.Parameters["@Month"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

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

                    DepartmentID = cmd.Parameters["@DepartmentID"].Value;

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

        public int Update(object DepartmentRelationID, object MachineGroupID, object DepartmentID, object TitleID,
            object ExchangeTypeID, object WorkerCount, object Cost, object DirectOrIndirect, object PrivateOrPublic,
            object SalaryOrOvertime, object AnnualorMonthly, object ShiftorDaytime, object Month, object Date,
            object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spDepartmentRelationUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartmentRelationID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentRelationID"].Value = Utility.ToDBNull(DepartmentRelationID);
                    cmd.Parameters["@DepartmentRelationID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentID"].Value = Utility.ToDBNull(DepartmentID);
                    cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = Utility.ToDBNull(MachineGroupID);
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@TitleID", SqlDbType.Int);
                    cmd.Parameters["@TitleID"].Value = Utility.ToDBNull(TitleID);
                    cmd.Parameters["@TitleID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExchangeTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExchangeTypeID"].Value = Utility.ToDBNull(ExchangeTypeID);
                    cmd.Parameters["@ExchangeTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@WorkerCount", SqlDbType.Int);
                    cmd.Parameters["@WorkerCount"].Value = Utility.ToDBNull(WorkerCount);
                    cmd.Parameters["@WorkerCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Cost", SqlDbType.Decimal);
                    cmd.Parameters["@Cost"].Value = Utility.ToDBNull(Cost);
                    cmd.Parameters["@Cost"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Cost"].Precision = 18;
                    cmd.Parameters["@Cost"].Scale = 2;

                    cmd.Parameters.Add("@DirectOrIndirect", SqlDbType.Bit);
                    cmd.Parameters["@DirectOrIndirect"].Value = Utility.ToDBNull(DirectOrIndirect);
                    cmd.Parameters["@DirectOrIndirect"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@PrivateOrPublic", SqlDbType.Bit);
                    cmd.Parameters["@PrivateOrPublic"].Value = Utility.ToDBNull(PrivateOrPublic);
                    cmd.Parameters["@PrivateOrPublic"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@SalaryOrOvertime", SqlDbType.Bit);
                    cmd.Parameters["@SalaryOrOvertime"].Value = Utility.ToDBNull(SalaryOrOvertime);
                    cmd.Parameters["@SalaryOrOvertime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@AnnualorMonthly", SqlDbType.Bit);
                    cmd.Parameters["@AnnualorMonthly"].Value = Utility.ToDBNull(AnnualorMonthly);
                    cmd.Parameters["@AnnualorMonthly"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ShiftorDaytime", SqlDbType.Bit);
                    cmd.Parameters["@ShiftorDaytime"].Value = Utility.ToDBNull(ShiftorDaytime);
                    cmd.Parameters["@ShiftorDaytime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Month", SqlDbType.Date);
                    cmd.Parameters["@Month"].Value = Utility.ToDBNull(Month);
                    cmd.Parameters["@Month"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

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

        public int Delete(object DepartmentRelationID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spDepartmentRelationDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartmentRelationID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentRelationID"].Value = DepartmentRelationID;
                    cmd.Parameters["@DepartmentRelationID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long DepartmentRelationID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spDepartmentRelationSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartmentRelationID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentRelationID"].Value = DepartmentRelationID;
                    cmd.Parameters["@DepartmentRelationID"].Direction = ParameterDirection.Input;

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
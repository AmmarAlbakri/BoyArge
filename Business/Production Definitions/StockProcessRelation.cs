using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class StockProcessRelation
    {
        public StockProcessRelation(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~StockProcessRelation()
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

            public long StockProcessRelationID { get; set; }
            public long StockGroupID { get; set; }
            public long ProcessID { get; set; }
            public long MachineID { get; set; }
            public long ArithmeticOperatorID { get; set; }
            public decimal TurnOver { get; set; }
            public decimal Efficiency { get; set; }
            public decimal Wastage { get; set; }
            public decimal Amount { get; set; }
            public int PeriodCount { get; set; }
            public int WorkerCount { get; set; }
            public bool MachineOrProcess { get; set; }
            public int LineNumber { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                StockProcessRelationID = StockGroupID = ProcessID = MachineID = ArithmeticOperatorID = 0;
                TurnOver = Efficiency = Wastage = Amount = PeriodCount = WorkerCount = LineNumber = 0;
                Status = Status.Active;
                MachineOrProcess = false;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    StockProcessRelationID = Utility.ToLong(row["StockProcessRelationID"]);
                    StockGroupID = Utility.ToLong(row["StockGroupID"]);
                    ProcessID = Utility.ToLong(row["ProcessID"]);
                    MachineID = Utility.ToLong(row["MachineID"]);
                    ArithmeticOperatorID = Utility.ToLong(row["ArithmeticOperatorID"]);
                    TurnOver = Utility.ToDecimal(row["TurnOver"]);
                    Efficiency = Utility.ToDecimal(row["Efficiency"]);
                    Wastage = Utility.ToDecimal(row["Wastage"]);
                    Amount = Utility.ToDecimal(row["Amount"]);
                    PeriodCount = Utility.ToInt32(row["PeriodCount"]);
                    WorkerCount = Utility.ToInt32(row["WorkerCount"]);
                    MachineOrProcess = Utility.ToBoolean(row["MachineOrProcess"]);
                    LineNumber = Utility.ToInt32(row["LineNumber"]);
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

        public const string TableName = "[dbo].[tblStockProcessRelation]";

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
                List = Select(0, 0, 0, 0, OnlyActive ? 1 : 0, connection);
            else
                List = null;

            return List;
        }

        public int Insert(ref object StockProcessRelationID, object StockGroupID, object ProcessID, object MachineID,
            object ArithmeticOperatorID, object TurnOver, object Efficiency, object Wastage, object Amount,
            object PeriodCount, object WorkerCount, object MachineOrProcess, object LineNumber, object Status,
            ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spStockProcessRelationInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockProcessRelationID", SqlDbType.Int);
                    cmd.Parameters["@StockProcessRelationID"].Value = Utility.ToDBNull(StockProcessRelationID);
                    cmd.Parameters["@StockProcessRelationID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = Utility.ToDBNull(ProcessID);
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = Utility.ToDBNull(MachineID);
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ArithmeticOperatorID", SqlDbType.Int);
                    cmd.Parameters["@ArithmeticOperatorID"].Value = Utility.ToDBNull(ArithmeticOperatorID);
                    cmd.Parameters["@ArithmeticOperatorID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@TurnOver", SqlDbType.Decimal);
                    cmd.Parameters["@TurnOver"].Value = Utility.ToDBNull(TurnOver);
                    cmd.Parameters["@TurnOver"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@TurnOver"].Precision = 18;
                    cmd.Parameters["@TurnOver"].Scale = 2;

                    cmd.Parameters.Add("@Efficiency", SqlDbType.Decimal);
                    cmd.Parameters["@Efficiency"].Value = Utility.ToDBNull(Efficiency);
                    cmd.Parameters["@Efficiency"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Efficiency"].Precision = 18;
                    cmd.Parameters["@Efficiency"].Scale = 2;

                    cmd.Parameters.Add("@Wastage", SqlDbType.Decimal);
                    cmd.Parameters["@Wastage"].Value = Utility.ToDBNull(Wastage);
                    cmd.Parameters["@Wastage"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Wastage"].Precision = 18;
                    cmd.Parameters["@Wastage"].Scale = 2;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

                    cmd.Parameters.Add("@PeriodCount", SqlDbType.Int);
                    cmd.Parameters["@PeriodCount"].Value = Utility.ToDBNull(PeriodCount);
                    cmd.Parameters["@PeriodCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@WorkerCount", SqlDbType.Int);
                    cmd.Parameters["@WorkerCount"].Value = Utility.ToDBNull(WorkerCount);
                    cmd.Parameters["@WorkerCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineOrProcess", SqlDbType.SmallInt);
                    cmd.Parameters["@MachineOrProcess"].Value = Utility.ToDBNull(MachineOrProcess);
                    cmd.Parameters["@MachineOrProcess"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@LineNumber", SqlDbType.Int);
                    cmd.Parameters["@LineNumber"].Value = Utility.ToDBNull(LineNumber);
                    cmd.Parameters["@LineNumber"].Direction = ParameterDirection.Input;

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

                    StockProcessRelationID = cmd.Parameters["@StockProcessRelationID"].Value;

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

        public int Update(object StockProcessRelationID, object StockGroupID, object ProcessID, object MachineID,
            object ArithmeticOperatorID, object TurnOver, object Efficiency, object Wastage, object Amount,
            object PeriodCount, object WorkerCount, object MachineOrProcess, object LineNumber, object Status,
            object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spStockProcessRelationUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockProcessRelationID", SqlDbType.Int);
                    cmd.Parameters["@StockProcessRelationID"].Value = Utility.ToDBNull(StockProcessRelationID);
                    cmd.Parameters["@StockProcessRelationID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = Utility.ToDBNull(ProcessID);
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = Utility.ToDBNull(MachineID);
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ArithmeticOperatorID", SqlDbType.Int);
                    cmd.Parameters["@ArithmeticOperatorID"].Value = Utility.ToDBNull(ArithmeticOperatorID);
                    cmd.Parameters["@ArithmeticOperatorID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@TurnOver", SqlDbType.Decimal);
                    cmd.Parameters["@TurnOver"].Value = Utility.ToDBNull(TurnOver);
                    cmd.Parameters["@TurnOver"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@TurnOver"].Precision = 18;
                    cmd.Parameters["@TurnOver"].Scale = 2;

                    cmd.Parameters.Add("@Efficiency", SqlDbType.Decimal);
                    cmd.Parameters["@Efficiency"].Value = Utility.ToDBNull(Efficiency);
                    cmd.Parameters["@Efficiency"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Efficiency"].Precision = 18;
                    cmd.Parameters["@Efficiency"].Scale = 2;

                    cmd.Parameters.Add("@Wastage", SqlDbType.Decimal);
                    cmd.Parameters["@Wastage"].Value = Utility.ToDBNull(Wastage);
                    cmd.Parameters["@Wastage"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Wastage"].Precision = 18;
                    cmd.Parameters["@Wastage"].Scale = 2;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

                    cmd.Parameters.Add("@PeriodCount", SqlDbType.Int);
                    cmd.Parameters["@PeriodCount"].Value = Utility.ToDBNull(PeriodCount);
                    cmd.Parameters["@PeriodCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@WorkerCount", SqlDbType.Int);
                    cmd.Parameters["@WorkerCount"].Value = Utility.ToDBNull(WorkerCount);
                    cmd.Parameters["@WorkerCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineOrProcess", SqlDbType.SmallInt);
                    cmd.Parameters["@MachineOrProcess"].Value = Utility.ToDBNull(MachineOrProcess);
                    cmd.Parameters["@MachineOrProcess"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@LineNumber", SqlDbType.Int);
                    cmd.Parameters["@LineNumber"].Value = Utility.ToDBNull(LineNumber);
                    cmd.Parameters["@LineNumber"].Direction = ParameterDirection.Input;

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

        public int Delete(object StockProcessRelationID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spStockProcessRelationDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockProcessRelationID", SqlDbType.Int);
                    cmd.Parameters["@StockProcessRelationID"].Value = StockProcessRelationID;
                    cmd.Parameters["@StockProcessRelationID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long StockProcessRelationID, long StockGroupID, long ProcessID, long MachineID,
            int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spStockProcessRelationSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockProcessRelationID", SqlDbType.Int);
                    cmd.Parameters["@StockProcessRelationID"].Value = StockProcessRelationID;
                    cmd.Parameters["@StockProcessRelationID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = StockGroupID;
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = ProcessID;
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = MachineID;
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

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
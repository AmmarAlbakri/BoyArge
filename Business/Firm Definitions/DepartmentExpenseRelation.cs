using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class DepartmentExpenseRelation
    {
        public DepartmentExpenseRelation(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~DepartmentExpenseRelation()
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

            public long DepartmentExpenseRelationID { get; set; }
            public long DepartmentID { get; set; }
            public long MachineGroupID { get; set; }
            public long ExpenseID { get; set; }
            public long ExchangeTypeID { get; set; }
            public string StockCode { get; set; }
            public long UnitID { get; set; }
            public decimal Price { get; set; }
            public decimal Amount { get; set; }
            public bool AnnualOrMonthly { get; set; }
            public bool DirectOrIndirect { get; set; }
            public DateTime Month { get; set; }
            public DateTime Date { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                DepartmentExpenseRelationID = DepartmentID = MachineGroupID = ExpenseID = ExchangeTypeID = UnitID = 0;
                Price = 0;
                StockCode = "";
                AnnualOrMonthly = DirectOrIndirect = false;
                Status = Status.Active;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    DepartmentExpenseRelationID = Utility.ToLong(row["DepartmentExpenseRelationID"]);
                    DepartmentID = Utility.ToLong(row["DepartmentID"]);
                    MachineGroupID = Utility.ToLong(row["MachineGroupID"]);
                    ExpenseID = Utility.ToLong(row["ExpenseID"]);
                    ExchangeTypeID = Utility.ToLong(row["ExchangeTypeID"]);
                    StockCode = row["StockCode"].ToString();
                    UnitID = Utility.ToLong(row["UnitID"]);
                    Price = Utility.ToDecimal(row["Price"]);
                    AnnualOrMonthly = Utility.ToBoolean(row["AnnualOrMonthly"]);
                    DirectOrIndirect = Utility.ToBoolean(row["DirectOrIndirect"]);
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

        public const string TableName = "[dbo].[tblDepartmentExpenseRelation]";

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

        public int Insert(ref object DepartmentExpenseRelationID, object DepartmentID, object MachineGroupID,
            object ExpenseID, object ExchangeTypeID, object StockCode, object UnitID, object Price, object Amount,
            object AnnualOrMonthly, object DirectOrIndirect, object Month, object Date, object Status,
            ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spDepartmentExpenseRelationInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartmentExpenseRelationID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentExpenseRelationID"].Value =
                        Utility.ToDBNull(DepartmentExpenseRelationID);
                    cmd.Parameters["@DepartmentExpenseRelationID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentID"].Value = Utility.ToDBNull(DepartmentID);
                    cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = Utility.ToDBNull(MachineGroupID);
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseID"].Value = Utility.ToDBNull(ExpenseID);
                    cmd.Parameters["@ExpenseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExchangeTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExchangeTypeID"].Value = Utility.ToDBNull(ExchangeTypeID);
                    cmd.Parameters["@ExchangeTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitID", SqlDbType.Int);
                    cmd.Parameters["@UnitID"].Value = Utility.ToDBNull(UnitID);
                    cmd.Parameters["@UnitID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    cmd.Parameters["@Price"].Value = Utility.ToDBNull(Price);
                    cmd.Parameters["@Price"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Price"].Precision = 18;
                    cmd.Parameters["@Price"].Scale = 4;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 4;

                    cmd.Parameters.Add("@AnnualorMonthly", SqlDbType.Bit);
                    cmd.Parameters["@AnnualorMonthly"].Value = Utility.ToDBNull(AnnualOrMonthly);
                    cmd.Parameters["@AnnualorMonthly"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DirectOrIndirect", SqlDbType.Bit);
                    cmd.Parameters["@DirectOrIndirect"].Value = Utility.ToDBNull(DirectOrIndirect);
                    cmd.Parameters["@DirectOrIndirect"].Direction = ParameterDirection.Input;

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

                    DepartmentExpenseRelationID = cmd.Parameters["@DepartmentExpenseRelationID"].Value;

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

        public int Update(object DepartmentExpenseRelationID, object DepartmentID, object MachineGroupID,
            object ExpenseID, object ExchangeTypeID, object StockCode, object UnitID, object Price, object Amount,
            object AnnualOrMonthly, object DirectOrIndirect, object Month, object Date, object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spDepartmentExpenseRelationUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartmentExpenseRelationID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentExpenseRelationID"].Value =
                        Utility.ToDBNull(DepartmentExpenseRelationID);
                    cmd.Parameters["@DepartmentExpenseRelationID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentID"].Value = Utility.ToDBNull(DepartmentID);
                    cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = Utility.ToDBNull(MachineGroupID);
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseID"].Value = Utility.ToDBNull(ExpenseID);
                    cmd.Parameters["@ExpenseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExchangeTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExchangeTypeID"].Value = Utility.ToDBNull(ExchangeTypeID);
                    cmd.Parameters["@ExchangeTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitID", SqlDbType.Int);
                    cmd.Parameters["@UnitID"].Value = Utility.ToDBNull(UnitID);
                    cmd.Parameters["@UnitID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    cmd.Parameters["@Price"].Value = Utility.ToDBNull(Price);
                    cmd.Parameters["@Price"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Price"].Precision = 18;
                    cmd.Parameters["@Price"].Scale = 4;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 4;

                    cmd.Parameters.Add("@AnnualorMonthly", SqlDbType.Bit);
                    cmd.Parameters["@AnnualorMonthly"].Value = Utility.ToDBNull(AnnualOrMonthly);
                    cmd.Parameters["@AnnualorMonthly"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DirectOrIndirect", SqlDbType.Bit);
                    cmd.Parameters["@DirectOrIndirect"].Value = Utility.ToDBNull(DirectOrIndirect);
                    cmd.Parameters["@DirectOrIndirect"].Direction = ParameterDirection.Input;

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

        public int Delete(object DepartmentExpenseRelationID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spDepartmentExpenseRelationDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartmentExpenseRelationID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentExpenseRelationID"].Value = DepartmentExpenseRelationID;
                    cmd.Parameters["@DepartmentExpenseRelationID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long DepartmentExpenseRelationID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spDepartmentExpenseRelationSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartmentExpenseRelationID", SqlDbType.Int);
                    cmd.Parameters["@DepartmentExpenseRelationID"].Value = DepartmentExpenseRelationID;
                    cmd.Parameters["@DepartmentExpenseRelationID"].Direction = ParameterDirection.Input;

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
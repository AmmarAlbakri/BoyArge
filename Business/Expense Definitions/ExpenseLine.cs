using Core;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class ExpenseLine : INotifyPropertyChanged
    {
        public ExpenseLine(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        ~ExpenseLine()
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

            public long ExpenseLineID { get; set; }
            public long ExpenseID { get; set; }
            public long StockGroupID { get; set; }
            public string StockCode { get; set; }
            public long ProcessID { get; set; }
            public long MachineID { get; set; }
            public long ExchangeTypeID { get; set; }
            public long UnitID { get; set; }
            public decimal Price { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
            public string Note { get; set; }
            public string Code1 { get; set; }
            public string Code2 { get; set; }
            public decimal Code3 { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                ExpenseLineID = ExpenseID = StockGroupID = ProcessID = MachineID = ExchangeTypeID = UnitID = 0;
                Status = Status.Active;
                Price = Amount = Code3 = 0;
                StockCode = Note = Code1 = Code2 = "";
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    ExpenseLineID = Utility.ToLong(row["ExpenseLineID"]);
                    ExpenseID = Utility.ToLong(row["ExpenseID"]);
                    StockGroupID = Utility.ToLong(row["StockGroupID"]);
                    StockCode = row["StockCode"].ToString();
                    ProcessID = Utility.ToLong(row["ProcessID"]);
                    MachineID = Utility.ToLong(row["MachineID"]);
                    ExchangeTypeID = Utility.ToLong(row["ExchangeTypeID"]);
                    UnitID = Utility.ToLong(row["UnitID"]);
                    Price = Utility.ToDecimal(row["Price"]);
                    Amount = Utility.ToDecimal(row["Amount"]);
                    Date = Utility.ToDateTime(row["Date"]);
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

        public const string TableName = "[dbo].[tblExpenseLine]";

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

        public int Insert(ref object ExpenseLineID, object ExpenseID, object StockCode, object StockGroupID,
            object ProcessID, object MachineID, object ExchangeTypeID, object UnitID, object Price, object Amount,
            object Date, object Note, object Code1, object Code2, object Code3, object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spExpenseLineInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpenseLineID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseLineID"].Value = Utility.ToDBNull(ExpenseLineID);
                    cmd.Parameters["@ExpenseLineID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseID"].Value = Utility.ToDBNull(ExpenseID);
                    cmd.Parameters["@ExpenseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = Utility.ToDBNull(ProcessID);
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = Utility.ToDBNull(MachineID);
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExchangeTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExchangeTypeID"].Value = Utility.ToDBNull(ExchangeTypeID);
                    cmd.Parameters["@ExchangeTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitID", SqlDbType.Int);
                    cmd.Parameters["@UnitID"].Value = Utility.ToDBNull(UnitID);
                    cmd.Parameters["@UnitID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    cmd.Parameters["@Price"].Value = Utility.ToDBNull(Price);
                    cmd.Parameters["@Price"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Price"].Precision = 18;
                    cmd.Parameters["@Price"].Scale = 2;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

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

                    ExpenseLineID = cmd.Parameters["@ExpenseLineID"].Value;

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

        public int Update(object ExpenseLineID, object ExpenseID, object StockCode, object StockGroupID,
            object ProcessID, object MachineID, object ExchangeTypeID, object UnitID, object Price, object Amount,
            object Date, object Note, object Code1, object Code2, object Code3, object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spExpenseLineUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpenseLineID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseLineID"].Value = Utility.ToDBNull(ExpenseLineID);
                    cmd.Parameters["@ExpenseLineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseID"].Value = Utility.ToDBNull(ExpenseID);
                    cmd.Parameters["@ExpenseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = Utility.ToDBNull(ProcessID);
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = Utility.ToDBNull(MachineID);
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExchangeTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExchangeTypeID"].Value = Utility.ToDBNull(ExchangeTypeID);
                    cmd.Parameters["@ExchangeTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitID", SqlDbType.Int);
                    cmd.Parameters["@UnitID"].Value = Utility.ToDBNull(UnitID);
                    cmd.Parameters["@UnitID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    cmd.Parameters["@Price"].Value = Utility.ToDBNull(Price);
                    cmd.Parameters["@Price"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Price"].Precision = 18;
                    cmd.Parameters["@Price"].Scale = 2;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

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

        public int Delete(object ExpenseLineID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spExpenseLineDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpenseLineID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseLineID"].Value = ExpenseLineID;
                    cmd.Parameters["@ExpenseLineID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long ExpenseLineID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spExpenseLineSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpenseLineID", SqlDbType.SmallInt);
                    cmd.Parameters["@ExpenseLineID"].Value = ExpenseLineID;
                    cmd.Parameters["@ExpenseLineID"].Direction = ParameterDirection.Input;

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

        public static CustomObservableCollection<Recording> GetExpenseLines(SqlConnection connection)
        {
            var dt = GetList(connection);

            if (dt == null) return null;

            var ExpenseLineItems = new CustomObservableCollection<Recording>();

            Recording record;

            foreach (DataRow row in dt.Rows)
            {
                record = new Recording();

                record.Change(row);

                ExpenseLineItems.Insert(ExpenseLineItems.Count, record);
            }

            return ExpenseLineItems;
        }

        #endregion Data
    }
}
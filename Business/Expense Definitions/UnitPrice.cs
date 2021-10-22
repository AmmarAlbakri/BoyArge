using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class UnitPrice
    {
        public UnitPrice(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~UnitPrice()
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

            public long UnitPriceID { get; set; }
            public long ExpenseID { get; set; }
            public string StockCode { get; set; }
            public long ExchangeTypeID { get; set; }
            public decimal Price { get; set; }
            public int ExpireDay { get; set; }
            public DateTime Date { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                UnitPriceID = ExpenseID = ExchangeTypeID = 0;
                StockCode = "";
                Status = Status.Active;
                Price = ExpireDay = 0;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    UnitPriceID = Utility.ToLong(row["UnitPriceID"]);
                    ExpenseID = Utility.ToLong(row["ExpenseID"]);
                    StockCode = row["StockCode"].ToString();
                    ExchangeTypeID = Utility.ToLong(row["ExchangeTypeID"]);
                    Price = Utility.ToDecimal(row["Price"]);
                    ExpireDay = Utility.ToInt32(row["ExpireDay"]);
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

        public const string TableName = "[dbo].[tblUnitPrice]";

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

        public int Insert(ref object UnitPriceID, object ExpenseID, object StockCode, object ExchangeTypeID,
            object Price, object ExpireDay, object Date, object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spUnitPriceInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnitPriceID", SqlDbType.Int);
                    cmd.Parameters["@UnitPriceID"].Value = Utility.ToDBNull(UnitPriceID);
                    cmd.Parameters["@UnitPriceID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseID"].Value = Utility.ToDBNull(ExpenseID);
                    cmd.Parameters["@ExpenseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExchangeTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExchangeTypeID"].Value = Utility.ToDBNull(ExchangeTypeID);
                    cmd.Parameters["@ExchangeTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    cmd.Parameters["@Price"].Value = Utility.ToDBNull(Price);
                    cmd.Parameters["@Price"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Price"].Precision = 18;
                    cmd.Parameters["@Price"].Scale = 4;

                    cmd.Parameters.Add("@ExpireDay", SqlDbType.Int);
                    cmd.Parameters["@ExpireDay"].Value = Utility.ToDBNull(ExpireDay);
                    cmd.Parameters["@ExpireDay"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ExpireDay"].Precision = 18;
                    cmd.Parameters["@ExpireDay"].Scale = 2;

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

                    UnitPriceID = cmd.Parameters["@UnitPriceID"].Value;

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

        public int Update(object UnitPriceID, object ExpenseID, object StockCode, object ExchangeTypeID, object Price,
            object ExpireDay, object Date, object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spUnitPriceUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnitPriceID", SqlDbType.Int);
                    cmd.Parameters["@UnitPriceID"].Value = Utility.ToDBNull(UnitPriceID);
                    cmd.Parameters["@UnitPriceID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseID"].Value = Utility.ToDBNull(ExpenseID);
                    cmd.Parameters["@ExpenseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExchangeTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExchangeTypeID"].Value = Utility.ToDBNull(ExchangeTypeID);
                    cmd.Parameters["@ExchangeTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    cmd.Parameters["@Price"].Value = Utility.ToDBNull(Price);
                    cmd.Parameters["@Price"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Price"].Precision = 18;
                    cmd.Parameters["@Price"].Scale = 4;

                    cmd.Parameters.Add("@ExpireDay", SqlDbType.Int);
                    cmd.Parameters["@ExpireDay"].Value = Utility.ToDBNull(ExpireDay);
                    cmd.Parameters["@ExpireDay"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ExpireDay"].Precision = 18;
                    cmd.Parameters["@ExpireDay"].Scale = 2;

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

        public int Delete(object UnitPriceID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spUnitPriceDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnitPriceID", SqlDbType.Int);
                    cmd.Parameters["@UnitPriceID"].Value = UnitPriceID;
                    cmd.Parameters["@UnitPriceID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long UnitPriceID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spUnitPriceSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnitPriceID", SqlDbType.SmallInt);
                    cmd.Parameters["@UnitPriceID"].Value = UnitPriceID;
                    cmd.Parameters["@UnitPriceID"].Direction = ParameterDirection.Input;

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
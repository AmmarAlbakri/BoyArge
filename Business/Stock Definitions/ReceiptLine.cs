using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class ReceiptLine
    {
        public ReceiptLine(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~ReceiptLine()
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

            public long ReceiptLineID { get; set; }
            public long ReceiptID { get; set; }
            public long LineNumber { get; set; }
            public string OperationCode { get; set; }
            public string ChemicalCode { get; set; }
            public long CalculateType { get; set; }
            public long ChemicalType { get; set; }
            public decimal UnitAmount { get; set; }
            public decimal TotalAmount { get; set; }
            public decimal Amount { get; set; }
            public string Note { get; set; }
            public decimal Price { get; set; }
            public long ExchangeTypeID { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                ReceiptLineID = ReceiptID = LineNumber = ExchangeTypeID = CalculateType = ChemicalType = 0;
                OperationCode = ChemicalCode = Note = "";
                UnitAmount = TotalAmount = Amount = Price = 0;
                Status = Status.Active;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    ReceiptLineID = Utility.ToLong(row["ReceiptLineID"]);
                    ReceiptID = Utility.ToLong(row["ReceiptID"]);
                    LineNumber = Utility.ToLong(row["LineNumber"]);
                    OperationCode = row["OperationCode"].ToString();
                    ChemicalCode = row["ChemicalCode"].ToString();
                    CalculateType = Utility.ToLong(row["CalculateType"]);
                    ChemicalType = Utility.ToLong(row["ChemicalType"]);
                    UnitAmount = Utility.ToDecimal(row["UnitAmount"]);
                    TotalAmount = Utility.ToDecimal(row["TotalAmount"]);
                    Amount = Utility.ToDecimal(row["Amount"]);
                    Note = row["Note"].ToString();
                    Price = Utility.ToDecimal(row["Price"]);
                    ExchangeTypeID = Utility.ToLong(row["ExchangeTypeID"]);
                    Status = (Status)Utility.ToByte(row["Status"]);
                    RowGUID = Utility.ToGuid(row["RowGUID"]);
                }
            }
        }

        #endregion Row

        #region Definitions

        private readonly SqlConnection Connection;
        private DataTable Table;

        //private static readonly DataTable List;

        public Recording Record;

        public const string TableName = "[dbo].[tblReceiptLine]";

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

        //public static DataTable GetList(SqlConnection connection, bool OnlyActive = true)
        //{
        //    if (Database.CheckConnection(connection))
        //        ReceiptLine.List = ReceiptLine.Select(0, OnlyActive ? 1 : 0, connection);
        //    else
        //        ReceiptLine.List = null;

        //    return ReceiptLine.List;
        //}

        public int Insert(ref object ReceiptLineID, object ReceiptID, object LineNumber, object OperationCode,
            object ChemicalCode, object CalculateType, object ChemicalType, object UnitAmount, object TotalAmount,
            object Amount, object Note, object Price, object ExchangeTypeID, object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spReceiptLineInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReceiptLineID", SqlDbType.Int);
                    cmd.Parameters["@ReceiptLineID"].Value = Utility.ToDBNull(ReceiptLineID);
                    cmd.Parameters["@ReceiptLineID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ReceiptID", SqlDbType.Int);
                    cmd.Parameters["@ReceiptID"].Value = Utility.ToDBNull(ReceiptID);
                    cmd.Parameters["@ReceiptID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@LineNumber", SqlDbType.Int);
                    cmd.Parameters["@LineNumber"].Value = Utility.ToDBNull(LineNumber);
                    cmd.Parameters["@LineNumber"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OperationCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@OperationCode"].Value = Utility.ToDBNull(OperationCode);
                    cmd.Parameters["@OperationCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ChemicalCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ChemicalCode"].Value = Utility.ToDBNull(ChemicalCode);
                    cmd.Parameters["@ChemicalCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CalculateType", SqlDbType.Int);
                    cmd.Parameters["@CalculateType"].Value = Utility.ToDBNull(CalculateType);
                    cmd.Parameters["@CalculateType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ChemicalType", SqlDbType.Int);
                    cmd.Parameters["@ChemicalType"].Value = Utility.ToDBNull(ChemicalType);
                    cmd.Parameters["@ChemicalType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitAmount", SqlDbType.Decimal);
                    cmd.Parameters["@UnitAmount"].Value = Utility.ToDBNull(UnitAmount);
                    cmd.Parameters["@UnitAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@UnitAmount"].Precision = 18;
                    cmd.Parameters["@UnitAmount"].Scale = 2;

                    cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                    cmd.Parameters["@TotalAmount"].Value = Utility.ToDBNull(TotalAmount);
                    cmd.Parameters["@TotalAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@TotalAmount"].Precision = 18;
                    cmd.Parameters["@TotalAmount"].Scale = 2;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

                    cmd.Parameters.Add("@Note", SqlDbType.VarChar, 250);
                    cmd.Parameters["@Note"].Value = Utility.ToDBNull(Note);
                    cmd.Parameters["@Note"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    cmd.Parameters["@Price"].Value = Utility.ToDBNull(Price);
                    cmd.Parameters["@Price"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Price"].Precision = 18;
                    cmd.Parameters["@Price"].Scale = 2;

                    cmd.Parameters.Add("@ExchangeTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExchangeTypeID"].Value = Utility.ToDBNull(ExchangeTypeID);
                    cmd.Parameters["@ExchangeTypeID"].Direction = ParameterDirection.Input;

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

                    ReceiptLineID = cmd.Parameters["@ReceiptLineID"].Value;

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

        public int Update(object ReceiptLineID, object ReceiptID, object LineNumber, object OperationCode,
            object ChemicalCode, object CalculateType, object ChemicalType, object UnitAmount, object TotalAmount,
            object Amount, object Note, object Price, object ExchangeTypeID, object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spReceiptLineUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReceiptLineID", SqlDbType.Int);
                    cmd.Parameters["@ReceiptLineID"].Value = Utility.ToDBNull(ReceiptLineID);
                    cmd.Parameters["@ReceiptLineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ReceiptID", SqlDbType.Int);
                    cmd.Parameters["@ReceiptID"].Value = Utility.ToDBNull(ReceiptID);
                    cmd.Parameters["@ReceiptID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@LineNumber", SqlDbType.Int);
                    cmd.Parameters["@LineNumber"].Value = Utility.ToDBNull(LineNumber);
                    cmd.Parameters["@LineNumber"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OperationCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@OperationCode"].Value = Utility.ToDBNull(OperationCode);
                    cmd.Parameters["@OperationCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ChemicalCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ChemicalCode"].Value = Utility.ToDBNull(ChemicalCode);
                    cmd.Parameters["@ChemicalCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CalculateType", SqlDbType.Int);
                    cmd.Parameters["@CalculateType"].Value = Utility.ToDBNull(CalculateType);
                    cmd.Parameters["@CalculateType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ChemicalType", SqlDbType.Int);
                    cmd.Parameters["@ChemicalType"].Value = Utility.ToDBNull(ChemicalType);
                    cmd.Parameters["@ChemicalType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitAmount", SqlDbType.Decimal);
                    cmd.Parameters["@UnitAmount"].Value = Utility.ToDBNull(UnitAmount);
                    cmd.Parameters["@UnitAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@UnitAmount"].Precision = 18;
                    cmd.Parameters["@UnitAmount"].Scale = 2;

                    cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                    cmd.Parameters["@TotalAmount"].Value = Utility.ToDBNull(TotalAmount);
                    cmd.Parameters["@TotalAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@TotalAmount"].Precision = 18;
                    cmd.Parameters["@TotalAmount"].Scale = 2;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

                    cmd.Parameters.Add("@Note", SqlDbType.VarChar, 250);
                    cmd.Parameters["@Note"].Value = Utility.ToDBNull(Note);
                    cmd.Parameters["@Note"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    cmd.Parameters["@Price"].Value = Utility.ToDBNull(Price);
                    cmd.Parameters["@Price"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Price"].Precision = 18;
                    cmd.Parameters["@Price"].Scale = 2;

                    cmd.Parameters.Add("@ExchangeTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExchangeTypeID"].Value = Utility.ToDBNull(ExchangeTypeID);
                    cmd.Parameters["@ExchangeTypeID"].Direction = ParameterDirection.Input;

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

        public int Delete(object ReceiptLineID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spReceiptLineDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReceiptLineID", SqlDbType.Int);
                    cmd.Parameters["@ReceiptLineID"].Value = ReceiptLineID;
                    cmd.Parameters["@ReceiptLineID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long ReceiptID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spReceiptLineSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReceiptID", SqlDbType.SmallInt);
                    cmd.Parameters["@ReceiptID"].Value = ReceiptID;
                    cmd.Parameters["@ReceiptID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                    //cmd.Parameters["@Status"].Value = Status;
                    //cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

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
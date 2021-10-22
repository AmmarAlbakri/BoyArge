using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class Receipt
    {
        public Receipt(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~Receipt()
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

            public long ReceiptID { get; set; }
            public long StockGroupID { get; set; }
            public string StockCode { get; set; }
            public long ConicTypeID { get; set; }
            public long ProcessID { get; set; }
            public long MachineID { get; set; }
            public string FicheNumber { get; set; }
            public string ReceiptNumber { get; set; }
            public string SerialNumber { get; set; }
            public decimal Amount { get; set; }
            public decimal OrderAmount { get; set; }
            public decimal Flotte { get; set; }
            public decimal ConicAmount { get; set; }
            public int ColorType { get; set; }
            public int Touchness { get; set; }
            public int Feature { get; set; }
            public decimal MinDyeCapacity { get; set; }
            public decimal MaxDyeCapacity { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                ReceiptID = StockGroupID = ConicTypeID = MachineID = ProcessID = 0;
                StockCode = FicheNumber = ReceiptNumber = SerialNumber = "";
                Amount = OrderAmount = Flotte = ConicAmount = ColorType = Touchness = Feature = 0;
                MinDyeCapacity = MaxDyeCapacity = 0;
                Status = Status.Active;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    ReceiptID = Utility.ToLong(row["ReceiptID"]);
                    StockGroupID = Utility.ToLong(row["StockGroupID"]);
                    StockCode = row["StockCode"].ToString();
                    ConicTypeID = Utility.ToLong(row["ConicTypeID"]);
                    ProcessID = Utility.ToLong(row["ProcessID"]);
                    MachineID = Utility.ToLong(row["MachineID"]);
                    FicheNumber = row["FicheNumber"].ToString();
                    ReceiptNumber = row["ReceiptNumber"].ToString();
                    SerialNumber = row["SerialNumber"].ToString();
                    Amount = Utility.ToDecimal(row["Amount"]);
                    OrderAmount = Utility.ToDecimal(row["OrderAmount"]);
                    Flotte = Utility.ToDecimal(row["Flotte"]);
                    ConicAmount = Utility.ToDecimal(row["ConicAmount"]);
                    ColorType = Utility.ToInt32(row["ColorType"]);
                    Touchness = Utility.ToInt32(row["Touchness"]);
                    Feature = Utility.ToInt32(row["Feature"]);
                    MinDyeCapacity = Utility.ToDecimal(row["MinDyeCapacity"]);
                    MaxDyeCapacity = Utility.ToDecimal(row["MaxDyeCapacity"]);
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

        public const string TableName = "[dbo].[tblReceipt]";

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

        public int Insert(ref object ReceiptID, object StockGroupID, object StockCode, object ConicTypeID,
            object ProcessID, object MachineID, object FicheNumber, object ReceiptNumber, object SerialNumber, object Amount,
            object OrderAmount, object Flotte, object ConicAmount, object ColorType, object Touchness, object Feature,
            object MinDyeCapacity, object MaxDyeCapacity, object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spReceiptInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReceiptID", SqlDbType.Int);
                    cmd.Parameters["@ReceiptID"].Value = Utility.ToDBNull(ReceiptID);
                    cmd.Parameters["@ReceiptID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ConicTypeID", SqlDbType.Int);
                    cmd.Parameters["@ConicTypeID"].Value = Utility.ToDBNull(ConicTypeID);
                    cmd.Parameters["@ConicTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = Utility.ToDBNull(ProcessID);
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = Utility.ToDBNull(MachineID);
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FicheNumber", SqlDbType.VarChar, 500);
                    cmd.Parameters["@FicheNumber"].Value = Utility.ToDBNull(FicheNumber);
                    cmd.Parameters["@FicheNumber"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ReceiptNumber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ReceiptNumber"].Value = Utility.ToDBNull(ReceiptNumber);
                    cmd.Parameters["@ReceiptNumber"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@SerialNumber"].Value = Utility.ToDBNull(SerialNumber);
                    cmd.Parameters["@SerialNumber"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OrderAmount", SqlDbType.Decimal);
                    cmd.Parameters["@OrderAmount"].Value = Utility.ToDBNull(OrderAmount);
                    cmd.Parameters["@OrderAmount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Flotte", SqlDbType.Decimal);
                    cmd.Parameters["@Flotte"].Value = Utility.ToDBNull(Flotte);
                    cmd.Parameters["@Flotte"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ConicAmount", SqlDbType.Decimal);
                    cmd.Parameters["@ConicAmount"].Value = Utility.ToDBNull(ConicAmount);
                    cmd.Parameters["@ConicAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ConicAmount"].Precision = 18;
                    cmd.Parameters["@ConicAmount"].Scale = 2;

                    cmd.Parameters.Add("@ColorType", SqlDbType.Int);
                    cmd.Parameters["@ColorType"].Value = Utility.ToDBNull(ColorType);
                    cmd.Parameters["@ColorType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Touchness", SqlDbType.Int);
                    cmd.Parameters["@Touchness"].Value = Utility.ToDBNull(Touchness);
                    cmd.Parameters["@Touchness"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Feature", SqlDbType.Int);
                    cmd.Parameters["@Feature"].Value = Utility.ToDBNull(Feature);
                    cmd.Parameters["@Feature"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MinDyeCapacity", SqlDbType.Decimal);
                    cmd.Parameters["@MinDyeCapacity"].Value = Utility.ToDBNull(MinDyeCapacity);
                    cmd.Parameters["@MinDyeCapacity"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@MinDyeCapacity"].Precision = 18;
                    cmd.Parameters["@MinDyeCapacity"].Scale = 2;

                    cmd.Parameters.Add("@MaxDyeCapacity", SqlDbType.Decimal);
                    cmd.Parameters["@MaxDyeCapacity"].Value = Utility.ToDBNull(MaxDyeCapacity);
                    cmd.Parameters["@MaxDyeCapacity"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@MaxDyeCapacity"].Precision = 18;
                    cmd.Parameters["@MaxDyeCapacity"].Scale = 2;

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

                    ReceiptID = cmd.Parameters["@ReceiptID"].Value;

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

        public int Update(object ReceiptID, object StockGroupID, object StockCode, object ConicTypeID, object ProcessID, object MachineID,
            object FicheNumber, object ReceiptNumber, object SerialNumber, object Amount, object OrderAmount,
            object Flotte, object ConicAmount, object ColorType, object Touchness, object Feature,
            object MinDyeCapacity, object MaxDyeCapacity, object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spReceiptUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReceiptID", SqlDbType.Int);
                    cmd.Parameters["@ReceiptID"].Value = Utility.ToDBNull(ReceiptID);
                    cmd.Parameters["@ReceiptID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ConicTypeID", SqlDbType.Int);
                    cmd.Parameters["@ConicTypeID"].Value = Utility.ToDBNull(ConicTypeID);
                    cmd.Parameters["@ConicTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProcessID", SqlDbType.Int);
                    cmd.Parameters["@ProcessID"].Value = Utility.ToDBNull(ProcessID);
                    cmd.Parameters["@ProcessID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = Utility.ToDBNull(MachineID);
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FicheNumber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@FicheNumber"].Value = Utility.ToDBNull(FicheNumber);
                    cmd.Parameters["@FicheNumber"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ReceiptNumber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ReceiptNumber"].Value = Utility.ToDBNull(ReceiptNumber);
                    cmd.Parameters["@ReceiptNumber"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50);
                    cmd.Parameters["@SerialNumber"].Value = Utility.ToDBNull(SerialNumber);
                    cmd.Parameters["@SerialNumber"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

                    cmd.Parameters.Add("@OrderAmount", SqlDbType.Decimal);
                    cmd.Parameters["@OrderAmount"].Value = Utility.ToDBNull(OrderAmount);
                    cmd.Parameters["@OrderAmount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Flotte", SqlDbType.Decimal);
                    cmd.Parameters["@Flotte"].Value = Utility.ToDBNull(Flotte);
                    cmd.Parameters["@Flotte"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Flotte"].Precision = 18;
                    cmd.Parameters["@Flotte"].Scale = 2;

                    cmd.Parameters.Add("@ConicAmount", SqlDbType.Decimal);
                    cmd.Parameters["@ConicAmount"].Value = Utility.ToDBNull(ConicAmount);
                    cmd.Parameters["@ConicAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ConicAmount"].Precision = 18;
                    cmd.Parameters["@ConicAmount"].Scale = 2;

                    cmd.Parameters.Add("@ColorType", SqlDbType.Int);
                    cmd.Parameters["@ColorType"].Value = Utility.ToDBNull(ColorType);
                    cmd.Parameters["@ColorType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Touchness", SqlDbType.Int);
                    cmd.Parameters["@Touchness"].Value = Utility.ToDBNull(Touchness);
                    cmd.Parameters["@Touchness"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Feature", SqlDbType.Int);
                    cmd.Parameters["@Feature"].Value = Utility.ToDBNull(Feature);
                    cmd.Parameters["@Feature"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MinDyeCapacity", SqlDbType.Decimal);
                    cmd.Parameters["@MinDyeCapacity"].Value = Utility.ToDBNull(MinDyeCapacity);
                    cmd.Parameters["@MinDyeCapacity"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@MinDyeCapacity"].Precision = 18;
                    cmd.Parameters["@MinDyeCapacity"].Scale = 2;

                    cmd.Parameters.Add("@MaxDyeCapacity", SqlDbType.Decimal);
                    cmd.Parameters["@MaxDyeCapacity"].Value = Utility.ToDBNull(MaxDyeCapacity);
                    cmd.Parameters["@MaxDyeCapacity"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@MaxDyeCapacity"].Precision = 18;
                    cmd.Parameters["@MaxDyeCapacity"].Scale = 2;

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

        public int Delete(object ReceiptID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spReceiptDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReceiptID", SqlDbType.Int);
                    cmd.Parameters["@ReceiptID"].Value = ReceiptID;
                    cmd.Parameters["@ReceiptID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long ReceiptID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spReceiptSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReceiptID", SqlDbType.SmallInt);
                    cmd.Parameters["@ReceiptID"].Value = ReceiptID;
                    cmd.Parameters["@ReceiptID"].Direction = ParameterDirection.Input;

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
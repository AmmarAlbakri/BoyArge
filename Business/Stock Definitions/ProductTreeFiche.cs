using Core;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Business
{
    public class ProductTreeFiche : INotifyPropertyChanged
    {
        public ProductTreeFiche(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~ProductTreeFiche()
        {
            if (Table != null)
                Table.Dispose();

            Table = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        #region Row

        public class Recording
        {
            public Recording()
            {
                Reset();
            }

            public long ProductTreeFicheID { get; set; }
            public long StockFeatureTypeID { get; set; }
            public string MainStockCode { get; set; }
            public DateTime Date { get; set; }
            public int OrderType { get; set; }
            public int CapacityType { get; set; }

            public int DeliveryType { get; set; }
            public int PaymentDate { get; set; }
            public int PackageType { get; set; }
            public decimal OrderAmount { get; set; }
            public decimal RingNr { get; set; }
            public decimal BukumNr { get; set; }
            public decimal FinalNr { get; set; }
            public string DyeType { get; set; }
            public string Code1 { get; set; }
            public string Code2 { get; set; }
            public decimal Code3 { get; set; }
            public decimal BottleNeck { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public Guid FicheGUID { get; set; }
            public IList<Recording> ProductTreeFicheList { get; set; }

            public void Reset()
            {
                ProductTreeFicheID = StockFeatureTypeID =
                    OrderType = CapacityType = DeliveryType = PaymentDate = PackageType = 0;
                MainStockCode = DyeType = Code1 = Code2 = "";
                OrderAmount = 0;
                Code3 = 0;
                RingNr = BukumNr = FinalNr = 0;
                Status = Status.Active;
                RowGUID = FicheGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row == null) return;

                ProductTreeFicheID = Utility.ToLong(row["ProductTreeFicheID"]);
                StockFeatureTypeID = Utility.ToLong(row["StockFeatureTypeID"]);
                MainStockCode = row["MainStockCode"].ToString();
                Date = Utility.ToDateTime(row["Date"]);
                OrderType = Utility.ToInt32(row["OrderType"]);
                CapacityType = Utility.ToInt32(row["CapacityType"]);
                DeliveryType = Utility.ToInt32(row["DeliveryType"]);
                PaymentDate = Utility.ToInt32(row["PaymentDate"]);
                PackageType = Utility.ToInt32(row["PackageType"]);
                OrderAmount = Utility.ToDecimal(row["OrderAmount"]);
                RingNr = Utility.ToDecimal(row["RingNr"]);
                BukumNr = Utility.ToDecimal(row["BukumNr"]);
                FinalNr = Utility.ToDecimal(row["FinalNr"]);
                DyeType = row["DyeType"].ToString();
                Code1 = row["Code1"].ToString();
                Code2 = row["Code2"].ToString();
                Code3 = Utility.ToDecimal(row["Code3"]);
                BottleNeck = Utility.ToDecimal(row["BottleNeck"]);
                Status = (Status)Utility.ToByte(row["Status"]);
                RowGUID = Utility.ToGuid(row["RowGUID"]);
                FicheGUID = Utility.ToGuid(row["FicheGUID"]);
            }
        }

        #endregion Row

        #region Definitions

        private readonly SqlConnection Connection;
        private DataTable Table;

        private static DataTable List;

        public Recording Record;

        public const string TableName = "[dbo].[tblProductTreeFiche]";

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

        public static DataTable GetList(SqlConnection connection, bool OnlyActive = true)
        {
            List = Database.CheckConnection(connection) ? Select(0, "", 0, OnlyActive ? 1 : 0, connection) : null;

            return List;
        }

        public DataTable GetTable()
        {
            return Table;
        }

        //public static DataTable GetList(SqlConnection connection, bool OnlyActive = true)
        //{
        //    if (Database.CheckConnection(connection))
        //        ProductTreeFiche.List = ProductTreeFiche.Select(0, OnlyActive ? 1 : 0, connection);
        //    else
        //        ProductTreeFiche.List = null;

        //    return ProductTreeFiche.List;
        //}

        public int Insert(ref object ProductTreeFicheID, object StockFeatureTypeID, object MainStockCode, object Date,
            object OrderType, object CapacityType, object DeliveryType, object PaymentDate, object PackageType,
            object OrderAmount, object RingNr, object BukumNr, object FinalNr, object DyeType, object Code1,
            object Code2, object Code3, object Status,
            //ref object RowGUID, object FicheGUID,
            SqlTransaction transaction)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    cmd.CommandText = "[dbo].[spProductTreeFicheInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@StockFeatureTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockFeatureTypeID"].Value = Utility.ToDBNull(StockFeatureTypeID);
                    cmd.Parameters["@StockFeatureTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MainStockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@MainStockCode"].Value = Utility.ToDBNull(MainStockCode);
                    cmd.Parameters["@MainStockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OrderType", SqlDbType.Int);
                    cmd.Parameters["@OrderType"].Value = Utility.ToDBNull(OrderType);
                    cmd.Parameters["@OrderType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CapacityType", SqlDbType.Int);
                    cmd.Parameters["@CapacityType"].Value = Utility.ToDBNull(CapacityType);
                    cmd.Parameters["@CapacityType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DeliveryType", SqlDbType.Int);
                    cmd.Parameters["@DeliveryType"].Value = Utility.ToDBNull(DeliveryType);
                    cmd.Parameters["@DeliveryType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@PaymentDate", SqlDbType.Int);
                    cmd.Parameters["@PaymentDate"].Value = Utility.ToDBNull(PaymentDate);
                    cmd.Parameters["@PaymentDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@PackageType", SqlDbType.Int);
                    cmd.Parameters["@PackageType"].Value = Utility.ToDBNull(PackageType);
                    cmd.Parameters["@PackageType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OrderAmount", SqlDbType.Decimal);
                    cmd.Parameters["@OrderAmount"].Value = Utility.ToDBNull(OrderAmount);
                    cmd.Parameters["@OrderAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@OrderAmount"].Precision = 18;
                    cmd.Parameters["@OrderAmount"].Scale = 2;

                    cmd.Parameters.Add("@RingNr", SqlDbType.Int);
                    cmd.Parameters["@RingNr"].Value = Utility.ToDBNull(RingNr);
                    cmd.Parameters["@RingNr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@BukumNr", SqlDbType.Int);
                    cmd.Parameters["@BukumNr"].Value = Utility.ToDBNull(BukumNr);
                    cmd.Parameters["@BukumNr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FinalNr", SqlDbType.Int);
                    cmd.Parameters["@FinalNr"].Value = Utility.ToDBNull(FinalNr);
                    cmd.Parameters["@FinalNr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DyeType", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DyeType"].Value = Utility.ToDBNull(DyeType);
                    cmd.Parameters["@DyeType"].Direction = ParameterDirection.Input;

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

                    //RowGUID = Guid.NewGuid();

                    //cmd.Parameters.Add("@RowGUID", SqlDbType.UniqueIdentifier);
                    //cmd.Parameters["@RowGUID"].Value = Utility.ToDBNull(RowGUID);
                    //cmd.Parameters["@RowGUID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.Add("@FicheGUID", SqlDbType.UniqueIdentifier);
                    //cmd.Parameters["@FicheGUID"].Value = Utility.ToDBNull(FicheGUID);
                    //cmd.Parameters["@FicheGUID"].Direction = ParameterDirection.Input;

                    //Common.AddLog(ref cmd, Utility.ToLong(UserID), Utility.ToGuid(RowGUID), true, true);

                    cmd.Parameters.Add("@Result", SqlDbType.Int);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    ProductTreeFicheID = cmd.Parameters["@ProductTreeFicheID"].Value;

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

        public int Update(object ProductTreeFicheID, object StockFeatureTypeID, object MainStockCode, object Date,
            object OrderType, object CapacityType, object DeliveryType, object PaymentDate, object PackageType,
            object OrderAmount, object RingNr, object BukumNr, object FinalNr, object DyeType, object Code1,
            object Code2, object Code3, object Status,
            //object RowGUID, object FicheGUID,
            SqlTransaction transaction)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    cmd.CommandText = "[dbo].[spProductTreeFicheUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockFeatureTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockFeatureTypeID"].Value = Utility.ToDBNull(StockFeatureTypeID);
                    cmd.Parameters["@StockFeatureTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MainStockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@MainStockCode"].Value = Utility.ToDBNull(MainStockCode);
                    cmd.Parameters["@MainStockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OrderType", SqlDbType.Int);
                    cmd.Parameters["@OrderType"].Value = Utility.ToDBNull(OrderType);
                    cmd.Parameters["@OrderType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CapacityType", SqlDbType.Int);
                    cmd.Parameters["@CapacityType"].Value = Utility.ToDBNull(CapacityType);
                    cmd.Parameters["@CapacityType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DeliveryType", SqlDbType.Int);
                    cmd.Parameters["@DeliveryType"].Value = Utility.ToDBNull(DeliveryType);
                    cmd.Parameters["@DeliveryType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@PaymentDate", SqlDbType.Int);
                    cmd.Parameters["@PaymentDate"].Value = Utility.ToDBNull(PaymentDate);
                    cmd.Parameters["@PaymentDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@PackageType", SqlDbType.Int);
                    cmd.Parameters["@PackageType"].Value = Utility.ToDBNull(PackageType);
                    cmd.Parameters["@PackageType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OrderAmount", SqlDbType.Decimal);
                    cmd.Parameters["@OrderAmount"].Value = Utility.ToDBNull(OrderAmount);
                    cmd.Parameters["@OrderAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@OrderAmount"].Precision = 18;
                    cmd.Parameters["@OrderAmount"].Scale = 2;

                    cmd.Parameters.Add("@RingNr", SqlDbType.Int);
                    cmd.Parameters["@RingNr"].Value = Utility.ToDBNull(RingNr);
                    cmd.Parameters["@RingNr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@BukumNr", SqlDbType.Int);
                    cmd.Parameters["@BukumNr"].Value = Utility.ToDBNull(BukumNr);
                    cmd.Parameters["@BukumNr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FinalNr", SqlDbType.Int);
                    cmd.Parameters["@FinalNr"].Value = Utility.ToDBNull(FinalNr);
                    cmd.Parameters["@FinalNr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DyeType", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DyeType"].Value = Utility.ToDBNull(DyeType);
                    cmd.Parameters["@DyeType"].Direction = ParameterDirection.Input;

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

                    //cmd.Parameters.Add("@RowGUID", SqlDbType.UniqueIdentifier);
                    //cmd.Parameters["@RowGUID"].Value = Utility.ToDBNull(RowGUID);
                    //cmd.Parameters["@RowGUID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.Add("@FicheGUID", SqlDbType.UniqueIdentifier);
                    //cmd.Parameters["@FicheGUID"].Value = Utility.ToDBNull(FicheGUID);
                    //cmd.Parameters["@FicheGUID"].Direction = ParameterDirection.Input;

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

        public static void Delete(object ProductTreeFicheID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText = $"DELETE FROM tblProductTree where ProductTreeFicheID={ProductTreeFicheID}";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = $"DELETE FROM tblProductTreeFiche where ProductTreeFicheID={ProductTreeFicheID}";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    XtraMessageBox.Show(" " + ProductTreeFicheID + " Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    XtraMessageBox.Show("Ürün silinemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                }
            }
        }

        public static DataTable Select(long ProductTreeFicheID, string MainStockCode, int StockFeatureTypeID, int Status, SqlConnection connection, int Type = -1)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spProductTreeFicheSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = ProductTreeFicheID;
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MainStockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@MainStockCode"].Value = MainStockCode;
                    cmd.Parameters["@MainStockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockFeatureTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockFeatureTypeID"].Value = StockFeatureTypeID;
                    cmd.Parameters["@StockFeatureTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                    cmd.Parameters["@Status"].Value = Status;
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Type", SqlDbType.SmallInt);
                    cmd.Parameters["@Type"].Value = Type;
                    cmd.Parameters["@Type"].Direction = ParameterDirection.Input;

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

        public static CustomObservableCollection<Recording> GetFiches(SqlConnection connection)
        {
            var dt = GetList(connection);

            if (dt == null) return null;

            var firmItems = new CustomObservableCollection<Recording>();

            Recording record;

            foreach (DataRow row in dt.Rows)
            {
                record = new Recording();

                record.Change(row);

                firmItems.Insert(firmItems.Count, record);
            }

            return firmItems;
        }

        public static int UpdateUnitCost(long ProductTreeFicheID, decimal UnitCost, decimal bottleNeck, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spProductTreeFicheUpdateUnitCost]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = ProductTreeFicheID;
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                    cmd.Parameters["@UnitCost"].Value = UnitCost;
                    cmd.Parameters["@UnitCost"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@UnitCost"].Precision = 18;
                    cmd.Parameters["@UnitCost"].Scale = 4;

                    cmd.Parameters.Add("@BottleNeck", SqlDbType.Decimal);
                    cmd.Parameters["@BottleNeck"].Value = bottleNeck;
                    cmd.Parameters["@BottleNeck"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@BottleNeck"].Precision = 18;
                    cmd.Parameters["@BottleNeck"].Scale = 4;

                    cmd.Parameters.Add("@Result", SqlDbType.Int);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    return Utility.ToInt32(cmd.Parameters["@Result"].Value);
                }
                finally
                {
                    cmd.Dispose();
                }
            }

            return -1;
        }

        /// <summary>
        ///     vwAnnualDepartmentExpenseRelation
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetProductUnitCost(object MainStockCode, object StockFeatureTypeID, object OrderAmount,
            object RingBobinNr, object BukumNr, object FinalNr, object Date, object CapacityType, object PaymentDate,
            object PackageType, object OrderType, object DeliveryType, object CalculateType, object ProductTreeFicheID,
            SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spProductUnitCost]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MainStockCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@MainStockCode"].Value = Utility.ToDBNull(MainStockCode);
                    cmd.Parameters["@MainStockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockFeatureTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockFeatureTypeID"].Value = Utility.ToDBNull(StockFeatureTypeID);
                    cmd.Parameters["@StockFeatureTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OrderAmount", SqlDbType.Decimal);
                    cmd.Parameters["@OrderAmount"].Value = Utility.ToDBNull(OrderAmount);
                    cmd.Parameters["@OrderAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@OrderAmount"].Precision = 18;
                    cmd.Parameters["@OrderAmount"].Scale = 2;

                    cmd.Parameters.Add("@RingBobinNr", SqlDbType.Decimal);
                    cmd.Parameters["@RingBobinNr"].Value = Utility.ToDBNull(RingBobinNr);
                    cmd.Parameters["@RingBobinNr"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@RingBobinNr"].Precision = 18;
                    cmd.Parameters["@RingBobinNr"].Scale = 2;

                    cmd.Parameters.Add("@BukumNr", SqlDbType.Decimal);
                    cmd.Parameters["@BukumNr"].Value = Utility.ToDBNull(BukumNr);
                    cmd.Parameters["@BukumNr"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@BukumNr"].Precision = 18;
                    cmd.Parameters["@BukumNr"].Scale = 2;

                    cmd.Parameters.Add("@FinalNr", SqlDbType.Decimal);
                    cmd.Parameters["@FinalNr"].Value = Utility.ToDBNull(FinalNr);
                    cmd.Parameters["@FinalNr"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@FinalNr"].Precision = 18;
                    cmd.Parameters["@FinalNr"].Scale = 2;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Date;
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CapacityType", SqlDbType.Int);
                    cmd.Parameters["@CapacityType"].Value = Utility.ToDBNull(CapacityType);
                    cmd.Parameters["@CapacityType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@PaymentDate", SqlDbType.Int);
                    cmd.Parameters["@PaymentDate"].Value = Utility.ToDBNull(PaymentDate);
                    cmd.Parameters["@PaymentDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@PackageType", SqlDbType.Int);
                    cmd.Parameters["@PackageType"].Value = Utility.ToDBNull(PackageType);
                    cmd.Parameters["@PackageType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OrderType", SqlDbType.Int);
                    cmd.Parameters["@OrderType"].Value = Utility.ToDBNull(OrderType);
                    cmd.Parameters["@OrderType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DeliveryType", SqlDbType.Int);
                    cmd.Parameters["@DeliveryType"].Value = Utility.ToDBNull(DeliveryType);
                    cmd.Parameters["@DeliveryType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CalculateType", SqlDbType.Bit);
                    cmd.Parameters["@CalculateType"].Value = Utility.ToDBNull(CalculateType);
                    cmd.Parameters["@CalculateType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;

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

        public static DataTable GetGroupUnitCost(object MainStockCode, object StockFeatureTypeID, object OrderAmount,
            object RingBobinNr, object BukumNr, object FinalNr, object Date, object CapacityType, object CalculateType,
            SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spGroupUnitCost]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MainStockCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@MainStockCode"].Value = Utility.ToDBNull(MainStockCode);
                    cmd.Parameters["@MainStockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockFeatureTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockFeatureTypeID"].Value = Utility.ToDBNull(StockFeatureTypeID);
                    cmd.Parameters["@StockFeatureTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OrderAmount", SqlDbType.Decimal);
                    cmd.Parameters["@OrderAmount"].Value = Utility.ToDBNull(OrderAmount);
                    cmd.Parameters["@OrderAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@OrderAmount"].Precision = 18;
                    cmd.Parameters["@OrderAmount"].Scale = 2;

                    cmd.Parameters.Add("@RingBobinNr", SqlDbType.Decimal);
                    cmd.Parameters["@RingBobinNr"].Value = Utility.ToDBNull(RingBobinNr);
                    cmd.Parameters["@RingBobinNr"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@RingBobinNr"].Precision = 18;
                    cmd.Parameters["@RingBobinNr"].Scale = 2;

                    cmd.Parameters.Add("@BukumNr", SqlDbType.Decimal);
                    cmd.Parameters["@BukumNr"].Value = Utility.ToDBNull(BukumNr);
                    cmd.Parameters["@BukumNr"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@BukumNr"].Precision = 18;
                    cmd.Parameters["@BukumNr"].Scale = 2;

                    cmd.Parameters.Add("@FinalNr", SqlDbType.Decimal);
                    cmd.Parameters["@FinalNr"].Value = Utility.ToDBNull(FinalNr);
                    cmd.Parameters["@FinalNr"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@FinalNr"].Precision = 18;
                    cmd.Parameters["@FinalNr"].Scale = 2;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CapacityType", SqlDbType.Int);
                    cmd.Parameters["@CapacityType"].Value = Utility.ToDBNull(CapacityType);
                    cmd.Parameters["@CapacityType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CalculateType", SqlDbType.Bit);
                    cmd.Parameters["@CalculateType"].Value = Utility.ToDBNull(CalculateType);
                    cmd.Parameters["@CalculateType"].Direction = ParameterDirection.Input;

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

        public static DataTable GetProcessUnitCost(object MainStockCode, object StockFeatureTypeID, object OrderAmount,
            object RingBobinNr, object BukumNr, object FinalNr, object Date, object CapacityType, object CalculateType,
            object ProductTreeFicheID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spProcessUnitCost]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MainStockCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@MainStockCode"].Value = Utility.ToDBNull(MainStockCode);
                    cmd.Parameters["@MainStockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockFeatureTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockFeatureTypeID"].Value = Utility.ToDBNull(StockFeatureTypeID);
                    cmd.Parameters["@StockFeatureTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OrderAmount", SqlDbType.Decimal);
                    cmd.Parameters["@OrderAmount"].Value = Utility.ToDBNull(OrderAmount);
                    cmd.Parameters["@OrderAmount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@OrderAmount"].Precision = 18;
                    cmd.Parameters["@OrderAmount"].Scale = 2;

                    cmd.Parameters.Add("@RingBobinNr", SqlDbType.Decimal);
                    cmd.Parameters["@RingBobinNr"].Value = Utility.ToDBNull(RingBobinNr);
                    cmd.Parameters["@RingBobinNr"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@RingBobinNr"].Precision = 18;
                    cmd.Parameters["@RingBobinNr"].Scale = 2;

                    cmd.Parameters.Add("@BukumNr", SqlDbType.Decimal);
                    cmd.Parameters["@BukumNr"].Value = Utility.ToDBNull(BukumNr);
                    cmd.Parameters["@BukumNr"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@BukumNr"].Precision = 18;
                    cmd.Parameters["@BukumNr"].Scale = 2;

                    cmd.Parameters.Add("@FinalNr", SqlDbType.Decimal);
                    cmd.Parameters["@FinalNr"].Value = Utility.ToDBNull(FinalNr);
                    cmd.Parameters["@FinalNr"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@FinalNr"].Precision = 18;
                    cmd.Parameters["@FinalNr"].Scale = 2;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CapacityType", SqlDbType.Int);
                    cmd.Parameters["@CapacityType"].Value = Utility.ToDBNull(CapacityType);
                    cmd.Parameters["@CapacityType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CalculateType", SqlDbType.Bit);
                    cmd.Parameters["@CalculateType"].Value = Utility.ToDBNull(CalculateType);
                    cmd.Parameters["@CalculateType"].Direction = ParameterDirection.Input;

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

        public static DataTable GetTmpProductUnitCost(object ProductTreeFicheID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText =
                        $"SELECT * " +
                        $"FROM [dbArge].[dbo].[TmpProductUnitCost] where ProductTreeFicheID={ProductTreeFicheID} and [CalculateType]=1";

                    cmd.CommandType = CommandType.Text;

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

        public static DataTable GetTmpProcessUnitCost(object ProductTreeFicheID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText =
                        $"SELECT * " +
                        $"FROM [dbArge].[dbo].[TmpProcessUnitCost] where ProductTreeFicheID={ProductTreeFicheID} and [CalculateType]=1";

                    cmd.CommandType = CommandType.Text;

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

        public static DataTable GetTmpGroupUnitCost(object ProductTreeFicheID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spGroupUnitCostSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@CalculateType", SqlDbType.Int);
                    cmd.Parameters["@CalculateType"].Value = Utility.ToDBNull(1);
                    cmd.Parameters["@CalculateType"].Direction = ParameterDirection.Input;

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
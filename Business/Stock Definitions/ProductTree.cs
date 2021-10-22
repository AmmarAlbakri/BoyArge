using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Business
{
    public class ProductTree
    {
        public ProductTree(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~ProductTree()
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

            public long ProductTreeID { get; set; }
            public long ProductTreeFicheID { get; set; }
            public long StockGroupID { get; set; }
            public DateTime Date { get; set; }
            public int Touchness { get; set; }
            public int Feature { get; set; }
            public int Level { get; set; }
            public int LevelType { get; set; }
            public long ParentID { get; set; }
            public long ZoneID { get; set; }
            public int DyeProcess { get; set; }
            public string StockCode { get; set; }
            //public string StockName { get; set; }

            public string ColorType { get; set; }
            public decimal Amount { get; set; }
            public decimal Wastage { get; set; }
            public decimal Total { get; set; }
            public int NFold { get; set; }
            public int ProductTreeIndex { get; set; }
            public string Code1 { get; set; }
            public string Code2 { get; set; }
            public decimal Code3 { get; set; }
            public decimal UnitCost { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }
            public Guid FicheGUID { get; set; }
            public IList<Recording> ProductTreeList { get; set; }

            public void Reset()
            {
                ProductTreeID = ProductTreeFicheID = StockGroupID =
                ParentID = ZoneID = Touchness = Feature = Level = LevelType = DyeProcess = 0;
                StockCode = ColorType = Code1 = Code2 = "";
                Amount = Wastage = Total = NFold = ProductTreeIndex = 0;
                Code3 = UnitCost = 0;
                Status = Status.Active;
                RowGUID = FicheGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row == null) return;

                ProductTreeID = Utility.ToLong(row["ProductTreeID"]);
                ProductTreeFicheID = Utility.ToLong(row["ProductTreeFicheID"]);
                StockGroupID = Utility.ToLong(row["StockGroupID"]);
                Date = Utility.ToDateTime(row["Date"]);
                Touchness = Utility.ToInt32(row["Touchness"]);
                Feature = Utility.ToInt32(row["Feature"]);
                Level = Utility.ToInt32(row["Level"]);
                LevelType = Utility.ToInt32(row["LevelType"]);
                ParentID = Utility.ToLong(row["ParentID"]);
                ZoneID = Utility.ToLong(row["ZoneID"]);
                DyeProcess = Utility.ToInt32(row["DyeProcess"]);
                StockCode = row["StockCode"].ToString();
                ColorType = row["ColorType"].ToString();
                Amount = Utility.ToDecimal(row["Amount"]);
                Wastage = Utility.ToDecimal(row["Wastage"]);
                Total = Utility.ToInt32(row["Total"]);
                NFold = Utility.ToInt32(row["NFold"]);
                ProductTreeIndex = Utility.ToInt32(row["ProductTreeIndex"]);
                Code1 = row["Code1"].ToString();
                Code2 = row["Code2"].ToString();
                Code3 = Utility.ToDecimal(row["Code3"]);
                UnitCost = Utility.ToDecimal(row["UnitCost"]);
                Status = (Status)Utility.ToByte(row["Status"]);
                RowGUID = Utility.ToGuid(row["RowGUID"]);
                FicheGUID = Utility.ToGuid(row["FicheGUID"]);
            }
        }

        #endregion Row

        #region Definitions

        private readonly SqlConnection Connection;
        private DataTable Table;

        //private static DataTable List;

        public Recording Record;

        public const string TableName = "[dbo].[tblProductTree]";

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

        public static DataTable LevelTypeList()
        {
            var dLevelType = new DataTable();
            dLevelType.Columns.Add("LevelType", typeof(int));
            dLevelType.Columns.Add("Code", typeof(string));

            dLevelType.Rows.Add(0, "Ana Ürün");
            dLevelType.Rows.Add(1, "Alt Ürün");
            dLevelType.Rows.Add(2, "Hammadde");

            return dLevelType;
        }

        public static DataTable DyeProcessList()
        {
            var dDyeProcess = new DataTable();
            dDyeProcess.Columns.Add("DyeProcess", typeof(int));
            dDyeProcess.Columns.Add("Code", typeof(string));

            dDyeProcess.Rows.Add(0, "Yok");
            dDyeProcess.Rows.Add(1, "Boyama");
            dDyeProcess.Rows.Add(2, "Diğer");

            return dDyeProcess;
        }

        public static DataTable ColorTypeList()
        {
            var dColorType = new DataTable();
            dColorType.Columns.Add("ColorType", typeof(int));
            dColorType.Columns.Add("Code", typeof(string));

            dColorType.Rows.Add(0, "");
            dColorType.Rows.Add(1, "Açık");
            dColorType.Rows.Add(2, "Orta");
            dColorType.Rows.Add(3, "Koyu");
            dColorType.Rows.Add(4, "Süper Koyu");

            return dColorType;
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
        //        ProductTree.List = ProductTree.Select(0, OnlyActive ? 1 : 0, connection);
        //    else
        //        ProductTree.List = null;

        //    return ProductTree.List;
        //}

        public int Insert(ref object ProductTreeID, object ProductTreeFicheID, object StockGroupID, object Date,
            object Touchness, object Feature, object Level, object LevelType, object ParentID, object ZoneID,
            object DyeProcess, object StockCode, object ColorType, object Amount, object Wastage, object Total,
            object NFold, object ProductTreeIndex, object Code1, object Code2, object Code3, object UnitCost,
            object Status, object ColorCode, object Color,
            //ref object RowGUID, object FicheGUID,
            SqlTransaction transaction)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spProductTreeInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = transaction;

                    cmd.Parameters.Add("@ProductTreeID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeID"].Value = Utility.ToDBNull(ProductTreeID);
                    cmd.Parameters["@ProductTreeID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Touchness", SqlDbType.Int);
                    cmd.Parameters["@Touchness"].Value = Utility.ToDBNull(Touchness);
                    cmd.Parameters["@Touchness"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Feature", SqlDbType.Int);
                    cmd.Parameters["@Feature"].Value = Utility.ToDBNull(Feature);
                    cmd.Parameters["@Feature"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Level", SqlDbType.Int);
                    cmd.Parameters["@Level"].Value = Utility.ToDBNull(Level);
                    cmd.Parameters["@Level"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@LevelType", SqlDbType.Int);
                    cmd.Parameters["@LevelType"].Value = Utility.ToDBNull(LevelType);
                    cmd.Parameters["@LevelType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ParentID", SqlDbType.Int);
                    cmd.Parameters["@ParentID"].Value = Utility.ToDBNull(ParentID);
                    cmd.Parameters["@ParentID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DyeProcess", SqlDbType.Int);
                    cmd.Parameters["@DyeProcess"].Value = Utility.ToDBNull(DyeProcess);
                    cmd.Parameters["@DyeProcess"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ColorType", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ColorType"].Value = Utility.ToDBNull(ColorType);
                    cmd.Parameters["@ColorType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

                    cmd.Parameters.Add("@Wastage", SqlDbType.Decimal);
                    cmd.Parameters["@Wastage"].Value = Utility.ToDBNull(Wastage);
                    cmd.Parameters["@Wastage"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Wastage"].Precision = 18;
                    cmd.Parameters["@Wastage"].Scale = 2;

                    cmd.Parameters.Add("@Total", SqlDbType.Decimal);
                    cmd.Parameters["@Total"].Value = Utility.ToDBNull(Total);
                    cmd.Parameters["@Total"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Total"].Precision = 18;
                    cmd.Parameters["@Total"].Scale = 2;

                    cmd.Parameters.Add("@NFold", SqlDbType.Int);
                    cmd.Parameters["@NFold"].Value = Utility.ToDBNull(NFold);
                    cmd.Parameters["@NFold"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProductTreeIndex", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeIndex"].Value = Utility.ToDBNull(ProductTreeIndex);
                    cmd.Parameters["@ProductTreeIndex"].Direction = ParameterDirection.Input;

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

                    cmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                    cmd.Parameters["@UnitCost"].Value = Utility.ToDBNull(UnitCost);
                    cmd.Parameters["@UnitCost"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@UnitCost"].Precision = 18;
                    cmd.Parameters["@UnitCost"].Scale = 4;

                    cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                    cmd.Parameters["@Status"].Value = Utility.ToDBNull(Status);
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ColorCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ColorCode"].Value = Utility.ToDBNull(ColorCode);
                    cmd.Parameters["@ColorCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Color", SqlDbType.VarChar, 30);
                    cmd.Parameters["@Color"].Value = Utility.ToDBNull(Color);
                    cmd.Parameters["@Color"].Direction = ParameterDirection.Input;

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

                    ProductTreeID = cmd.Parameters["@ProductTreeID"].Value;

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

        public int Update(object ProductTreeID, object ProductTreeFicheID, object StockGroupID, object Date,
            object Touchness, object Feature, object Level, object LevelType, object ParentID, object ZoneID,
            object DyeProcess, object StockCode, object ColorType, object Amount, object Wastage, object Total,
            object NFold, object ProductTreeIndex, object Code1, object Code2, object Code3, object UnitCost,
            object Status, object ColorCode, object Color,
            //object RowGUID, object FicheGUID,
            SqlTransaction transaction)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spProductTreeUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = transaction;

                    cmd.Parameters.Add("@ProductTreeID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeID"].Value = Utility.ToDBNull(ProductTreeID);
                    cmd.Parameters["@ProductTreeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Touchness", SqlDbType.Int);
                    cmd.Parameters["@Touchness"].Value = Utility.ToDBNull(Touchness);
                    cmd.Parameters["@Touchness"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Feature", SqlDbType.Int);
                    cmd.Parameters["@Feature"].Value = Utility.ToDBNull(Feature);
                    cmd.Parameters["@Feature"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Level", SqlDbType.Int);
                    cmd.Parameters["@Level"].Value = Utility.ToDBNull(Level);
                    cmd.Parameters["@Level"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@LevelType", SqlDbType.Int);
                    cmd.Parameters["@LevelType"].Value = Utility.ToDBNull(LevelType);
                    cmd.Parameters["@LevelType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ParentID", SqlDbType.Int);
                    cmd.Parameters["@ParentID"].Value = Utility.ToDBNull(ParentID);
                    cmd.Parameters["@ParentID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@DyeProcess", SqlDbType.Int);
                    cmd.Parameters["@DyeProcess"].Value = Utility.ToDBNull(DyeProcess);
                    cmd.Parameters["@DyeProcess"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 50);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ColorType", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ColorType"].Value = Utility.ToDBNull(ColorType);
                    cmd.Parameters["@ColorType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

                    cmd.Parameters.Add("@Wastage", SqlDbType.Decimal);
                    cmd.Parameters["@Wastage"].Value = Utility.ToDBNull(Wastage);
                    cmd.Parameters["@Wastage"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Wastage"].Precision = 18;
                    cmd.Parameters["@Wastage"].Scale = 2;

                    cmd.Parameters.Add("@Total", SqlDbType.Decimal);
                    cmd.Parameters["@Total"].Value = Utility.ToDBNull(Total);
                    cmd.Parameters["@Total"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Total"].Precision = 18;
                    cmd.Parameters["@Total"].Scale = 2;

                    cmd.Parameters.Add("@NFold", SqlDbType.Int);
                    cmd.Parameters["@NFold"].Value = Utility.ToDBNull(NFold);
                    cmd.Parameters["@NFold"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProductTreeIndex", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeIndex"].Value = Utility.ToDBNull(ProductTreeIndex);
                    cmd.Parameters["@ProductTreeIndex"].Direction = ParameterDirection.Input;

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

                    cmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                    cmd.Parameters["@UnitCost"].Value = Utility.ToDBNull(UnitCost);
                    cmd.Parameters["@UnitCost"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@UnitCost"].Precision = 18;
                    cmd.Parameters["@UnitCost"].Scale = 4;

                    cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                    cmd.Parameters["@Status"].Value = Utility.ToDBNull(Status);
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ColorCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ColorCode"].Value = Utility.ToDBNull(ColorCode);
                    cmd.Parameters["@ColorCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Color", SqlDbType.VarChar, 30);
                    cmd.Parameters["@Color"].Value = Utility.ToDBNull(Color);
                    cmd.Parameters["@Color"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.Add("@RowGUID", SqlDbType.UniqueIdentifier);
                    //cmd.Parameters["@RowGUID"].Value = Utility.ToGuid(RowGUID);
                    //cmd.Parameters["@RowGUID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.Add("@FicheGUID", SqlDbType.UniqueIdentifier);
                    //cmd.Parameters["@FicheGUID"].Value = Utility.ToGuid(FicheGUID);
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

        public int Delete(object ProductTreeID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spProductTreeDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeID"].Value = ProductTreeID;
                    cmd.Parameters["@ProductTreeID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long ProductTreeFicheID,
            //string MainStockCode, int StockFeatureTypeID,
            int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spProductTreeSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = ProductTreeFicheID;
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.Add("@MainStockCode", SqlDbType.VarChar, 50);
                    //cmd.Parameters["@MainStockCode"].Value = MainStockCode;
                    //cmd.Parameters["@MainStockCode"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.Add("@StockFeatureTypeID", SqlDbType.Int);
                    //cmd.Parameters["@StockFeatureTypeID"].Value = StockFeatureTypeID;
                    //cmd.Parameters["@StockFeatureTypeID"].Direction = ParameterDirection.Input;

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

        public static DataTable GetAnnualCosts(SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText =
                        "SELECT [Month],[ExchangeType],[Department],[MachineGroup],[Expense],[ExpenseType],[Price] FROM [dbo].[vwAnnualCosts]";
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

        /// <summary>
        ///     vwAnnualDepartmentExpenseRelation
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetAnnualDER(SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText =
                        "SELECT [ExpenseType],[Expense],[Department],[MachineGroup],[Price],[ExchangeType] FROM [dbo].[vwAnnualDepartmentExpenseRelation]";
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

        public static DataTable GetIndirectExpense(int Month, int Year, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText =
                        $"SELECT * FROM [dbo].[vwDepartmentRelation] WHERE [Doğrudan/Dolaylı] = 'İndirekt' AND DATEPART(YEAR, [Donem]) = {Year} --AND DATEPART(MONTH, [Donem]) = {Month}";
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

        public static DataTable GetChemicalExpense(object ProductTreeFicheID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "[dbo].[spGetChemicalExpense]";
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);

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

        public static DataTable GetWorkerExpense(object ProductTreeFicheID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spWorkerExpense]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.VarChar, 25);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);

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

        public static DataTable UpdateRawMaterialCost(object ProductTreeFicheID, DateTime Date, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spGetRawMaterialCost]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);

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

        public static DataTable GetWorkerExpenseByStockGroup(string StockCode, DateTime Date, long StockGroupID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spWorkerExpenseByStockGroup]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 25);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);

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

        public static DataTable GetInvoiceExpense(object ProductTreeFicheID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spInvoiceExpense]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.VarChar, 25);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);

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

        public static DataTable GetCapacity(object ProductTreeFicheID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spCapacity]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int, 25);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);

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

        public static DataTable GetCPMProductTree(object MamulReceteNo, object Date, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    var sql = new StringBuilder();

                    sql.AppendLine("SELECT * FROM tblCPMProductTree(@MamulReceteNo,@Date)");

                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@MamulReceteNo", SqlDbType.VarChar, 25);
                    cmd.Parameters["@MamulReceteNo"].Value = Utility.ToDBNull(MamulReceteNo);
                    cmd.Parameters["@MamulReceteNo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;
                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, "TEXMRH");

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

        public static DataTable GetCPMOrderProductTree(object SiparisReceteNo, object Date, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                DataTable dt = new DataTable();

                try
                {
                    var sql = new StringBuilder();

                    sql.AppendLine("SELECT * FROM tblCPMOrderProductTree(@SiparisReceteNo,@Date)");

                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@SiparisReceteNo", SqlDbType.VarChar, 25);
                    cmd.Parameters["@SiparisReceteNo"].Value = Utility.ToDBNull(SiparisReceteNo);
                    cmd.Parameters["@SiparisReceteNo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                    var da = new SqlDataAdapter(cmd);
                    //var ds = new DataSet();

                    da.Fill(dt);
                    return dt;
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

        public static int UnitCostUpdate(object ProductTreeFicheID, object StockCode, object Total, object UnitCost, SqlConnection Connection, SqlTransaction transaction)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spProductTreeUnitCostUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = transaction;

                    cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                    cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheID);
                    cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 25);
                    cmd.Parameters["@StockCode"].Value = Utility.ToDBNull(StockCode);
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Total", SqlDbType.Decimal);
                    cmd.Parameters["@Total"].Value = Utility.ToDBNull(Total);
                    cmd.Parameters["@Total"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Total"].Precision = 18;
                    cmd.Parameters["@Total"].Scale = 2;

                    cmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                    cmd.Parameters["@UnitCost"].Value = Utility.ToDBNull(UnitCost);
                    cmd.Parameters["@UnitCost"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@UnitCost"].Precision = 18;
                    cmd.Parameters["@UnitCost"].Scale = 4;

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

        public static DataTable GetProcess(object StockGroupID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText =
                        $"SELECT * " +
                        $"FROM [dbArge].[dbo].[vwStockProcessRelation] ";

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

        #endregion Data
    }
}
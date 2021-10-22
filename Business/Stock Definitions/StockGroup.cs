using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class StockGroup
    {
        public StockGroup(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~StockGroup()
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

            public long StockGroupID { get; set; }
            public long ZoneID { get; set; }
            public long ProductGroupID { get; set; }
            public long StockTypeID { get; set; }
            public long StockPropertyID { get; set; }
            public long StockProductTypeID { get; set; }
            public long UnitID { get; set; }
            public string Name { get; set; }
            public decimal MinValue { get; set; }
            public decimal MaxValue { get; set; }
            public string NFold { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                StockGroupID = ZoneID =
                    ProductGroupID = StockTypeID = StockPropertyID = StockProductTypeID = UnitID = 0;
                MinValue = MaxValue = 0;
                Name = NFold = "";
                Status = Status.Active;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    StockGroupID = Utility.ToLong(row["StockGroupID"]);
                    ZoneID = Utility.ToLong(row["ZoneID"]);
                    ProductGroupID = Utility.ToLong(row["ProductGroupID"]);
                    StockTypeID = Utility.ToLong(row["StockTypeID"]);
                    StockPropertyID = Utility.ToLong(row["StockPropertyID"]);
                    StockProductTypeID = Utility.ToLong(row["StockProductTypeID"]);
                    UnitID = Utility.ToLong(row["UnitID"]);
                    Name = row["Name"].ToString();
                    MinValue = Utility.ToDecimal(row["MinValue"]);
                    MaxValue = Utility.ToDecimal(row["MaxValue"]);
                    NFold = row["NFold"].ToString();
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

        public const string TableName = "[dbo].[tblStockGroup]";

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

        public int Insert(ref object StockGroupID, object ZoneID, object ProductGroupID, object StockTypeID,
            object StockPropertyID, object StockProductTypeID, object UnitID, object Name, object MinValue,
            object MaxValue, object NFold, object Status, ref object RowGUID
        )
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spStockGroupInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProductGroupID", SqlDbType.Int);
                    cmd.Parameters["@ProductGroupID"].Value = Utility.ToDBNull(ProductGroupID);
                    cmd.Parameters["@ProductGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockTypeID"].Value = Utility.ToDBNull(StockTypeID);
                    cmd.Parameters["@StockTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockPropertyID", SqlDbType.Int);
                    cmd.Parameters["@StockPropertyID"].Value = Utility.ToDBNull(StockPropertyID);
                    cmd.Parameters["@StockPropertyID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockProductTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockProductTypeID"].Value = Utility.ToDBNull(StockProductTypeID);
                    cmd.Parameters["@StockProductTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitID", SqlDbType.Int);
                    cmd.Parameters["@UnitID"].Value = Utility.ToDBNull(UnitID);
                    cmd.Parameters["@UnitID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MinValue", SqlDbType.Decimal);
                    cmd.Parameters["@MinValue"].Value = Utility.ToDBNull(MinValue);
                    cmd.Parameters["@MinValue"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@MinValue"].Precision = 18;
                    cmd.Parameters["@MinValue"].Scale = 2;

                    cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal);
                    cmd.Parameters["@MaxValue"].Value = Utility.ToDBNull(MaxValue);
                    cmd.Parameters["@MaxValue"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@MaxValue"].Precision = 18;
                    cmd.Parameters["@MaxValue"].Scale = 2;

                    cmd.Parameters.Add("@NFold", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NFold"].Value = Utility.ToDBNull(NFold);
                    cmd.Parameters["@NFold"].Direction = ParameterDirection.Input;

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

                    StockGroupID = cmd.Parameters["@StockGroupID"].Value;

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

        public int Update(object StockGroupID, object ZoneID, object ProductGroupID, object StockTypeID,
            object StockPropertyID, object StockProductTypeID, object UnitID, object Name, object MinValue,
            object MaxValue, object NFold, object Status, object RowGUID
        )
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spStockGroupUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = Utility.ToDBNull(StockGroupID);
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProductGroupID", SqlDbType.Int);
                    cmd.Parameters["@ProductGroupID"].Value = Utility.ToDBNull(ProductGroupID);
                    cmd.Parameters["@ProductGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockTypeID"].Value = Utility.ToDBNull(StockTypeID);
                    cmd.Parameters["@StockTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockPropertyID", SqlDbType.Int);
                    cmd.Parameters["@StockPropertyID"].Value = Utility.ToDBNull(StockPropertyID);
                    cmd.Parameters["@StockPropertyID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@StockProductTypeID", SqlDbType.Int);
                    cmd.Parameters["@StockProductTypeID"].Value = Utility.ToDBNull(StockProductTypeID);
                    cmd.Parameters["@StockProductTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitID", SqlDbType.Int);
                    cmd.Parameters["@UnitID"].Value = Utility.ToDBNull(UnitID);
                    cmd.Parameters["@UnitID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MinValue", SqlDbType.Decimal);
                    cmd.Parameters["@MinValue"].Value = Utility.ToDBNull(MinValue);
                    cmd.Parameters["@MinValue"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@MinValue"].Precision = 18;
                    cmd.Parameters["@MinValue"].Scale = 2;

                    cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal);
                    cmd.Parameters["@MaxValue"].Value = Utility.ToDBNull(MaxValue);
                    cmd.Parameters["@MaxValue"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@MaxValue"].Precision = 18;
                    cmd.Parameters["@MaxValue"].Scale = 2;

                    cmd.Parameters.Add("@NFold", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NFold"].Value = Utility.ToDBNull(NFold);
                    cmd.Parameters["@NFold"].Direction = ParameterDirection.Input;

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

        public int Delete(object StockGroupID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spStockGroupDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.Int);
                    cmd.Parameters["@StockGroupID"].Value = StockGroupID;
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long StockGroupID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spStockGroupSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockGroupID", SqlDbType.SmallInt);
                    cmd.Parameters["@StockGroupID"].Value = StockGroupID;
                    cmd.Parameters["@StockGroupID"].Direction = ParameterDirection.Input;

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

        public static DataTable GetList(SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "SELECT [StockGroupID],[StockGroup] FROM [dbo].[vwStockGroup]";
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
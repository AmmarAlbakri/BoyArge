using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class ConicType
    {
        public ConicType(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~ConicType()
        {
            Table?.Dispose();

            Table = null;
        }

        #region Row

        public class Recording
        {
            public Recording()
            {
                Reset();
            }

            public long ConicTypeID { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public decimal ConicConverterFactor { get; set; }
            public decimal Amount { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                ConicTypeID = 0;
                ConicConverterFactor = Amount = 0;
                Type = Name = "";
                Status = Status.Active;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    ConicTypeID = Utility.ToLong(row["ConicTypeID"]);
                    Type = row["Type"].ToString();
                    Name = row["Name"].ToString();
                    ConicConverterFactor = Utility.ToDecimal(row["ConicConverterFactor"]);
                    Amount = Utility.ToDecimal(row["Amount"]);
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

        public const string TableName = "[dbo].[tblConicType]";

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

        public int Insert(ref object ConicTypeID, object Name, object Type, object ConicConverterFactor, object Amount,
            object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spConicTypeInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConicTypeID", SqlDbType.Int);
                    cmd.Parameters["@ConicTypeID"].Value = Utility.ToDBNull(ConicTypeID);
                    cmd.Parameters["@ConicTypeID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Type", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Type"].Value = Utility.ToDBNull(Type);
                    cmd.Parameters["@Type"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ConicConverterFactor", SqlDbType.Decimal);
                    cmd.Parameters["@ConicConverterFactor"].Value = Utility.ToDBNull(ConicConverterFactor);
                    cmd.Parameters["@ConicConverterFactor"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ConicConverterFactor"].Precision = 18;
                    cmd.Parameters["@ConicConverterFactor"].Scale = 5;

                    cmd.Parameters.Add("@Amount", SqlDbType.Int);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

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

                    ConicTypeID = cmd.Parameters["@ConicTypeID"].Value;

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

        public int Update(object ConicTypeID, object Name, object Type, object ConicConverterFactor, object Amount,
            object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spConicTypeUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConicTypeID", SqlDbType.Int);
                    cmd.Parameters["@ConicTypeID"].Value = Utility.ToDBNull(ConicTypeID);
                    cmd.Parameters["@ConicTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Type", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Type"].Value = Utility.ToDBNull(Type);
                    cmd.Parameters["@Type"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ConicConverterFactor", SqlDbType.Decimal);
                    cmd.Parameters["@ConicConverterFactor"].Value = Utility.ToDBNull(ConicConverterFactor);
                    cmd.Parameters["@ConicConverterFactor"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ConicConverterFactor"].Precision = 18;
                    cmd.Parameters["@ConicConverterFactor"].Scale = 5;

                    cmd.Parameters.Add("@Amount", SqlDbType.Int);
                    cmd.Parameters["@Amount"].Value = Utility.ToDBNull(Amount);
                    cmd.Parameters["@Amount"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;

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

        public int Delete(object ConicTypeID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spConicTypeDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConicTypeID", SqlDbType.Int);
                    cmd.Parameters["@ConicTypeID"].Value = ConicTypeID;
                    cmd.Parameters["@ConicTypeID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long ConicTypeID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spConicTypeSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConicTypeID", SqlDbType.SmallInt);
                    cmd.Parameters["@ConicTypeID"].Value = ConicTypeID;
                    cmd.Parameters["@ConicTypeID"].Direction = ParameterDirection.Input;

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
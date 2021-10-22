using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class TableStatus
    {
        public TableStatus(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~TableStatus()
        {
            Table?.Dispose();

            Table = null;
        }

        /// <summary>
        ///     Tablonun belirli Status kolonundaki değeri değiştirmek için kullanılır
        /// </summary>
        /// <param name="Connection"> Sql bağlantı nesnesi</param>
        /// <param name="TableName">[dbo].[tbl....]</param>
        /// <param name="FieldName">[IDColumn]</param>
        /// <param name="FieldID">ID'ye karşılık gelen value</param>
        /// <param name="Status"> Yeni Status değeri</param>
        /// <returns></returns>
        public static int Toggle(SqlConnection Connection, object TableName, object FieldName, object FieldID,
            object Status)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spToggleStatus]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TableName"].Value = Utility.ToDBNull(TableName);
                    cmd.Parameters["@TableName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FieldName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@FieldName"].Value = Utility.ToDBNull(FieldName);
                    cmd.Parameters["@FieldName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FieldID", SqlDbType.VarChar, 50);
                    cmd.Parameters["@FieldID"].Value = Utility.ToDBNull(FieldID);
                    cmd.Parameters["@FieldID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Status", SqlDbType.VarChar, 4);
                    cmd.Parameters["@Status"].Value = Utility.ToDBNull(Status);
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

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

        #region Row

        public class Recording
        {
            public Recording()
            {
                Reset();
            }

            public long TableStatusID { get; set; }
            public string TableName { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string NameEn { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                TableStatusID = 0;
                TableName = "";
                Status = Status.Active;
                Code = Name = NameEn = "";
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    TableStatusID = Utility.ToLong(row["TableStatusID"]);
                    TableName = row["TableName"].ToString();
                    Code = row["Code"].ToString();
                    Name = row["Name"].ToString();
                    NameEn = row["NameEn"].ToString();
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

        public const string _TableName = "[dbo].[tblTableStatus]";

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

        public static DataTable GetList(SqlConnection connection, string tableName)
        {
            List = Database.CheckConnection(connection) ? Select(tableName, connection) : null;

            return List;
        }

        public int Insert(ref object TableStatusID, object TableName, object Name, object NameEn, object Code,
            object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spTableStatusInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TableStatusID", SqlDbType.Int);
                    cmd.Parameters["@TableStatusID"].Value = Utility.ToDBNull(TableStatusID);
                    cmd.Parameters["@TableStatusID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TableName"].Value = Utility.ToDBNull(TableName);
                    cmd.Parameters["@TableName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@NameEn", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NameEn"].Value = Utility.ToDBNull(NameEn);
                    cmd.Parameters["@NameEn"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

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

                    TableStatusID = cmd.Parameters["@TableStatusID"].Value;

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

        public int Update(object TableStatusID, object TableName, object Name, object NameEn, object Code,
            object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spTableStatusUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TableStatusID", SqlDbType.Int);
                    cmd.Parameters["@TableStatusID"].Value = Utility.ToDBNull(TableStatusID);
                    cmd.Parameters["@TableStatusID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TableName"].Value = Utility.ToDBNull(TableName);
                    cmd.Parameters["@TableName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@NameEn", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NameEn"].Value = Utility.ToDBNull(NameEn);
                    cmd.Parameters["@NameEn"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

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

        public int Delete(object TableStatusID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spTableStatusDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TableStatusID", SqlDbType.Int);
                    cmd.Parameters["@TableStatusID"].Value = TableStatusID;
                    cmd.Parameters["@TableStatusID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(string TableName, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spTableStatusSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TableName"].Value = TableName;
                    cmd.Parameters["@TableName"].Direction = ParameterDirection.Input;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, _TableName);

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
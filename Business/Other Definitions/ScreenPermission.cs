using Core;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class ScreenPermission : INotifyPropertyChanged
    {
        public ScreenPermission(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        ~ScreenPermission()
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

            public long ScreenPermissionID { get; set; }
            public long UserID { get; set; }
            public long ScreenID { get; set; }
            public bool Access { get; set; }
            public bool Edit { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public long ModuleID { get; set; }
            public string Platform { get; set; }
            public string Module { get; set; }
            public string UserName { get; set; }
            public string Screen { get; set; }
            public string Definition { get; set; }

            public void Reset()
            {
                ScreenPermissionID = UserID = ScreenID = 0;
                Access = Edit = false;
                Status = Status.Active;
                RowGUID = Guid.Empty;

                ModuleID = 0;
                Platform = Module = UserName = Screen;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    ScreenPermissionID = Utility.ToLong(row["ScreenPermissionID"]);
                    UserID = Utility.ToLong(row["UserID"]);
                    ScreenID = Utility.ToLong(row["ScreenID"]);
                    Access = Utility.ToBoolean(row["Access"]);
                    Edit = Utility.ToBoolean(row["Edit"]);
                    Status = (Status)Utility.ToByte(row["Status"]);
                    RowGUID = Utility.ToGuid(row["RowGUID"]);

                    ModuleID = Utility.ToLong(row["ModuleID"]);
                    Platform = row["Platform"].ToString();
                    Module = row["Module"].ToString();
                    UserName = row["UserName"].ToString();
                    Screen = row["Screen"].ToString();
                    Definition = row["Definition"].ToString();
                }
            }
        }

        #endregion Row

        #region Definitions

        private readonly SqlConnection Connection;
        private DataTable Table;

        private static DataTable List;

        public Recording Record;

        public const string TableName = "[dbo].[tblScreenPermission]";

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

        public int Insert(ref object ScreenPermissionID, object UserID, object ScreenID, object Access, object Edit,
            object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spScreenPermissionInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ScreenPermissionID", SqlDbType.Int);
                    cmd.Parameters["@ScreenPermissionID"].Value = Utility.ToDBNull(ScreenPermissionID);
                    cmd.Parameters["@ScreenPermissionID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters["@UserID"].Value = Utility.ToDBNull(UserID);
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ScreenID", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ScreenID"].Value = Utility.ToDBNull(ScreenID);
                    cmd.Parameters["@ScreenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Access", SqlDbType.Bit);
                    cmd.Parameters["@Access"].Value = Utility.ToDBNull(Access);
                    cmd.Parameters["@Access"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Edit", SqlDbType.Bit);
                    cmd.Parameters["@Edit"].Value = Utility.ToDBNull(Edit);
                    cmd.Parameters["@Edit"].Direction = ParameterDirection.Input;

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

                    ScreenPermissionID = cmd.Parameters["@ScreenPermissionID"].Value;

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

        public int Update(object ScreenPermissionID, object UserID, object ScreenID, object Access, object Edit,
            object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spScreenPermissionUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ScreenPermissionID", SqlDbType.Int);
                    cmd.Parameters["@ScreenPermissionID"].Value = Utility.ToDBNull(ScreenPermissionID);
                    cmd.Parameters["@ScreenPermissionID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters["@UserID"].Value = Utility.ToDBNull(UserID);
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ScreenID", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ScreenID"].Value = Utility.ToDBNull(ScreenID);
                    cmd.Parameters["@ScreenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Access", SqlDbType.Bit);
                    cmd.Parameters["@Access"].Value = Utility.ToDBNull(Access);
                    cmd.Parameters["@Access"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Edit", SqlDbType.Bit);
                    cmd.Parameters["@Edit"].Value = Utility.ToDBNull(Edit);
                    cmd.Parameters["@Edit"].Direction = ParameterDirection.Input;

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

        public int Delete(object ScreenPermissionID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spScreenPermissionDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ScreenPermissionID", SqlDbType.Int);
                    cmd.Parameters["@ScreenPermissionID"].Value = ScreenPermissionID;
                    cmd.Parameters["@ScreenPermissionID"].Direction = ParameterDirection.Input;

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

        public int BatchUpdate(int PermissionType, int ModuleID, int UserID, bool State)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spScreenPermissionBatchUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PermissionType", SqlDbType.Int);
                    cmd.Parameters["@PermissionType"].Value = Utility.ToDBNull(PermissionType);
                    cmd.Parameters["@PermissionType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ModuleID", SqlDbType.Int);
                    cmd.Parameters["@ModuleID"].Value = Utility.ToDBNull(ModuleID);
                    cmd.Parameters["@ModuleID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters["@UserID"].Value = Utility.ToDBNull(UserID);
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@State", SqlDbType.Bit);
                    cmd.Parameters["@State"].Value = Utility.ToDBNull(State);
                    cmd.Parameters["@State"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long UserID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spScreenPermissionSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters["@UserID"].Value = UserID;
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

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

        public static DataTable GetUserPermissions(long UserID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spGetUserPermissions]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters["@UserID"].Value = UserID;
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

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

        public static DataTable GetPermissionTree(SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spGetPermissionTree]";
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public static bool ScreenPermissionEdit(long UserID, string ControlName, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spScreenPermissionEdit]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters["@UserID"].Value = UserID;
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ControlName", SqlDbType.VarChar);
                    cmd.Parameters["@ControlName"].Value = ControlName;
                    cmd.Parameters["@ControlName"].Direction = ParameterDirection.Input;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, TableName);

                    if (ds.Tables[0] != null)
                        return Utility.ToBoolean(ds.Tables[0].Rows[0][0]);
                    else
                        return false;
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

            return false;
        }

        public static CustomObservableCollection<Recording> GetScreenPermissions(SqlConnection connection)
        {
            var dt = GetPermissionTree(connection);

            if (dt == null) return null;

            var ScreenPermissionItems = new CustomObservableCollection<Recording>();

            Recording record;

            foreach (DataRow row in dt.Rows)
            {
                record = new Recording();

                record.Change(row);

                ScreenPermissionItems.Insert(ScreenPermissionItems.Count, record);
            }

            return ScreenPermissionItems;
        }

        public static DataTable GetUserPermissionByPlatform(long UserID, string Platform, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spGetUserPermissionByPlatform]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters["@UserID"].Value = Utility.ToDBNull(UserID);
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Platform", SqlDbType.VarChar);
                    cmd.Parameters["@Platform"].Value = Utility.ToDBNull(Platform);
                    cmd.Parameters["@Platform"].Direction = ParameterDirection.Input;

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

//spGetUserPermissionByPlatform
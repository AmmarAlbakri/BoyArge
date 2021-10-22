using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class Screen
    {
        public Screen(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~Screen()
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

            public long ScreenID { get; set; }
            public long ParentID { get; set; }
            public string Name { get; set; }
            public string ControlName { get; set; }
            public string Definition { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                ScreenID = ParentID = 0;
                Name = ControlName = Definition = "";
                Status = Status.Active;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    ScreenID = Utility.ToLong(row["ScreenID"]);
                    ParentID = Utility.ToLong(row["ParentID"]);
                    Name = row["Name"].ToString();
                    ControlName = row["ControlName"].ToString();
                    Definition = row["Definition"].ToString();

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

        public const string TableName = "[dbo].[tblScreen]";

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

        public int Insert(ref object ScreenID, object ParentID, object Name, object ControlName, object Definition,
            object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spScreenInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ScreenID", SqlDbType.Int);
                    cmd.Parameters["@ScreenID"].Value = Utility.ToDBNull(ScreenID);
                    cmd.Parameters["@ScreenID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ParentID", SqlDbType.Int);
                    cmd.Parameters["@ParentID"].Value = Utility.ToDBNull(ParentID);
                    cmd.Parameters["@ParentID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ControlName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ControlName"].Value = Utility.ToDBNull(ControlName);
                    cmd.Parameters["@ControlName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Definition", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Definition"].Value = Utility.ToDBNull(Definition);
                    cmd.Parameters["@Definition"].Direction = ParameterDirection.Input;

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

                    ScreenID = cmd.Parameters["@ScreenID"].Value;

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

        public int Update(object ScreenID, object ParentID, object Name, object ControlName, object Definition,
            object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spScreenUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ScreenID", SqlDbType.Int);
                    cmd.Parameters["@ScreenID"].Value = Utility.ToDBNull(ScreenID);
                    cmd.Parameters["@ScreenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ParentID", SqlDbType.Int);
                    cmd.Parameters["@ParentID"].Value = Utility.ToDBNull(ParentID);
                    cmd.Parameters["@ParentID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ControlName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ControlName"].Value = Utility.ToDBNull(ControlName);
                    cmd.Parameters["@ControlName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Definition", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Definition"].Value = Utility.ToDBNull(Definition);
                    cmd.Parameters["@Definition"].Direction = ParameterDirection.Input;

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

        public int Delete(object ScreenID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spScreenDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ScreenID", SqlDbType.Int);
                    cmd.Parameters["@ScreenID"].Value = ScreenID;
                    cmd.Parameters["@ScreenID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long ScreenID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spScreenSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ScreenID", SqlDbType.SmallInt);
                    cmd.Parameters["@ScreenID"].Value = ScreenID;
                    cmd.Parameters["@ScreenID"].Direction = ParameterDirection.Input;

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

        public static int CheckScreen(string ScreenName, string ControlName, string Definition, int ModuleID, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spScreenCheck]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ScreenName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ScreenName"].Value = ScreenName;
                    cmd.Parameters["@ScreenName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ControlName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ControlName"].Value = ControlName;
                    cmd.Parameters["@ControlName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Definition", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Definition"].Value = Definition;
                    cmd.Parameters["@Definition"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ModuleID", SqlDbType.Int);
                    cmd.Parameters["@ModuleID"].Value = ModuleID;
                    cmd.Parameters["@ModuleID"].Direction = ParameterDirection.Input;

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

        #endregion Data
    }
}
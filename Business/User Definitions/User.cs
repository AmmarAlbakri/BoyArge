using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class User
    {
        public User(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~User()
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

            public long UserID { get; set; }
            public string UserName { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                UserID = 0;
                UserName = Name = Surname = Password = Email = Phone = "";
                Status = Status.Active;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    UserID = Utility.ToLong(row["UserID"]);
                    UserName = row["UserName"].ToString();
                    Name = row["Name"].ToString();
                    Surname = row["Surname"].ToString();
                    //this.Password = row["Password"].ToString();
                    Email = row["Email"].ToString();
                    Phone = row["Phone"].ToString();
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

        public const string TableName = "[dbo].[tblUser]";

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

        public static int Login(SqlConnection connection, string UserName, string Password)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spLogin]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@UserName"].Value = UserName;
                    cmd.Parameters["@UserName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Password"].Value = Password;
                    cmd.Parameters["@Password"].Direction = ParameterDirection.Input;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, TableName);

                    var dt = ds.Tables[0];

                    if (dt == null || dt.Rows.Count == 0)
                        return 0;
                    else
                        return Utility.ToInt32(dt.Rows[0][0]);
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

            return 0;
        }

        public static int UpdatePassword(SqlConnection connection, long UserID, string Password, string NewPassword)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spUpdatePassword]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 50);
                    cmd.Parameters["@UserID"].Value = UserID;
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Password"].Value = Password;
                    cmd.Parameters["@Password"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@NewPassword", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NewPassword"].Value = NewPassword;
                    cmd.Parameters["@NewPassword"].Direction = ParameterDirection.Input;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, TableName);

                    var dt = ds.Tables[0];

                    if (dt == null || dt.Rows.Count == 0)
                        return 0;
                    else
                        return Utility.ToInt32(dt.Rows[0][0]);
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

            return 0;
        }

        public DataTable GetTable()
        {
            return Table;
        }

        public static DataTable GetList(SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
                List = Select(0, (short)Status.Active, connection);
            else
                List = null;

            return List;
        }

        public int Insert(ref object UserID, object UserName, object Name, object Surname, object Password,
            object Email, object Phone, object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spUserInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters["@UserID"].Value = Utility.ToDBNull(UserID);
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@UserName"].Value = Utility.ToDBNull(UserName);
                    cmd.Parameters["@UserName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Surname", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Surname"].Value = Utility.ToDBNull(Surname);
                    cmd.Parameters["@Surname"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Password"].Value = Utility.ToDBNull(Password);
                    cmd.Parameters["@Password"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Email"].Value = Utility.ToDBNull(Email);
                    cmd.Parameters["@Email"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Phone"].Value = Utility.ToDBNull(Phone);
                    cmd.Parameters["@Phone"].Direction = ParameterDirection.Input;

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

                    UserID = cmd.Parameters["@UserID"].Value;

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

        public int Update(object UserID, object UserName, object Name, object Surname, object Password, object Email,
            object Phone, object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spUserUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters["@UserID"].Value = Utility.ToDBNull(UserID);
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@UserName"].Value = Utility.ToDBNull(UserName);
                    cmd.Parameters["@UserName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Surname", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Surname"].Value = Utility.ToDBNull(Surname);
                    cmd.Parameters["@Surname"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Password"].Value = Utility.ToDBNull(Password);
                    cmd.Parameters["@Password"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Email"].Value = Utility.ToDBNull(Email);
                    cmd.Parameters["@Email"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Phone"].Value = Utility.ToDBNull(Phone);
                    cmd.Parameters["@Phone"].Direction = ParameterDirection.Input;

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

        public int Delete(object UserID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spUserDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    cmd.Parameters["@UserID"].Value = UserID;
                    cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

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
                    cmd.CommandText = "[dbo].[spUserSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.SmallInt);
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

        #endregion Data
    }
}
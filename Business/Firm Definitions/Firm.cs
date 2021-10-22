using Core;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class Firm : INotifyPropertyChanged
    {
        public Firm(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        ~Firm()
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

            public long FirmID { get; set; }
            public Status Status { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                FirmID = 0;
                Status = Status.Active;
                Code = Name = "";
                Phone = "";
                Email = Address = "";
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    FirmID = Utility.ToLong(row["FirmID"]);
                    Status = (Status)Utility.ToByte(row["Status"]);
                    Code = row["Code"].ToString();
                    Name = row["Name"].ToString();
                    Phone = row["Phone"].ToString();
                    Email = row["Email"].ToString();
                    Address = row["Address"].ToString();
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

        public const string TableName = "[dbo].[tblFirm]";

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
            List = Database.CheckConnection(connection) ? Select(0, OnlyActive ? 1 : 0, connection) : null;

            return List;
        }

        public static CustomObservableCollection<Recording> GetFirms(SqlConnection connection)
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

        public int Insert(ref object FirmID, object Code, object Name, object Phone, object Email, object Address,
            object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spFirmInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirmID", SqlDbType.Int);
                    cmd.Parameters["@FirmID"].Value = Utility.ToDBNull(FirmID);
                    cmd.Parameters["@FirmID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Phone"].Value = Utility.ToDBNull(Phone);
                    cmd.Parameters["@Phone"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Email"].Value = Utility.ToDBNull(Email);
                    cmd.Parameters["@Email"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 255);
                    cmd.Parameters["@Address"].Value = Utility.ToDBNull(Address);
                    cmd.Parameters["@Address"].Direction = ParameterDirection.Input;

                    RowGUID = Guid.NewGuid();

                    //Common.AddLog(ref cmd, Utility.ToLong(UserID), Utility.ToGuid(RowGUID), true, true);

                    cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                    cmd.Parameters["@Status"].Value = Utility.ToDBNull(Status);
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@RowGUID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@RowGUID"].Value = Utility.ToDBNull(RowGUID);
                    cmd.Parameters["@RowGUID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@Result", SqlDbType.Int);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    FirmID = cmd.Parameters["@FirmID"].Value;

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

        public int Update(object FirmID, object Code, object Name, object Phone, object Email, object Address,
            object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spFirmUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirmID", SqlDbType.Int);
                    cmd.Parameters["@FirmID"].Value = Utility.ToDBNull(FirmID);
                    cmd.Parameters["@FirmID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Phone"].Value = Utility.ToDBNull(Phone);
                    cmd.Parameters["@Phone"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Email"].Value = Utility.ToDBNull(Email);
                    cmd.Parameters["@Email"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 255);
                    cmd.Parameters["@Address"].Value = Utility.ToDBNull(Address);
                    cmd.Parameters["@Address"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                    cmd.Parameters["@Status"].Value = Utility.ToDBNull(Status);
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                    //Common.AddLog(ref cmd, Utility.ToLong(UserID), Utility.ToGuid(RowGUID), false);

                    cmd.Parameters.Add("@RowGUID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@RowGUID"].Value = Utility.ToDBNull(RowGUID);
                    cmd.Parameters["@RowGUID"].Direction = ParameterDirection.Input;

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

        public int Delete(object FirmID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spFirmDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirmID", SqlDbType.Int);
                    cmd.Parameters["@FirmID"].Value = FirmID;
                    cmd.Parameters["@FirmID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long FirmID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spFirmSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirmID", SqlDbType.SmallInt);
                    cmd.Parameters["@FirmID"].Value = FirmID;
                    cmd.Parameters["@FirmID"].Direction = ParameterDirection.Input;

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
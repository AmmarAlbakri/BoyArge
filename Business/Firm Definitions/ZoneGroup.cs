using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Business
{
    public class ZoneGroup
    {
        #region Row
        public class Recording
        {
            public long ZoneGroupID { get; set; }            
            public long ZoneID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }


            public Recording()
            {
                this.Reset();
            }

            public void Reset()
            {
                this.ZoneGroupID = this.ZoneID = 0;
                this.Status = Status.Active;
                this.Code = this.Name = "";
                this.RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    this.ZoneGroupID = Utility.ToLong(row["ZoneGroupID"]);
                    this.ZoneID = Utility.ToLong(row["ZoneID"]);
                    this.Code = row["Code"].ToString();
                    this.Name = row["Name"].ToString();
                    this.Status = (Status)Utility.ToByte(row["Status"]);
                    this.RowGUID = Utility.ToGuid(row["RowGUID"]);
                }
            }
        }
        #endregion

        #region Definitions
        private SqlConnection Connection;
        private DataTable Table;

        private static DataTable List;

        public Recording Record;

        public const string TableName = "[dbo].[tblZoneGroup]";

        public enum Status
        {
            Deleted = -1,
            Passive = 0,
            Active = 1
        }

        public static DataTable StatusList()
        {
            DataTable dStatus = new DataTable();

            dStatus.Columns.Add("Name", typeof(string));
            dStatus.Columns.Add("Value", typeof(Int16));

            dStatus.Rows.Add("Etkin", (Int16)Status.Active);
            dStatus.Rows.Add("Devre Dışı", (Int16)Status.Passive);
            dStatus.Rows.Add("Silindi", (Int16)Status.Deleted);

            return dStatus;
        }
        #endregion

        public ZoneGroup(SqlConnection connection)
        {
            this.Connection = connection;
            this.Record = new Recording();
        }

        ~ZoneGroup()
        {
            if (this.Table != null)
                this.Table.Dispose();

            this.Table = null;
        }

        #region Data
        public DataTable GetTable()
        {
            return this.Table;
        }
        public static DataTable GetList(SqlConnection connection, long ZoneID, bool OnlyActive = true)
        {
            if (Database.CheckConnection(connection))
                ZoneGroup.List = ZoneGroup.Select(0, ZoneID, OnlyActive ? 1 : 0, connection);
            else
                ZoneGroup.List = null;

            return ZoneGroup.List;
        }

        //public void Refresh(bool OnlyActive, bool Dummy)
        //{
        //    if (!Dummy)
        //    {
        //        StringBuilder sql = new StringBuilder();

        //        sql.AppendLine("SELECT");
        //        sql.AppendLine("    [ZoneGroupID],");
        //        sql.AppendLine("    [ZoneID],");
        //        sql.AppendLine("    [Code],");
        //        sql.AppendLine("    [Name],");
        //        sql.AppendLine("    [Status],");
        //        sql.AppendLine("    [RowGUID]");
        //        sql.AppendLine("FROM [dbo].[tblZoneGroup]");

        //        if (OnlyActive)
        //            sql.AppendLine("WHERE [Status] > 0");
        //        else
        //            sql.AppendLine("WHERE [Status] >= 0");

        //        sql.AppendLine("ORDER BY [Code]");

        //        this.Table = Database.GetList(sql.ToString(), this.Connection, ZoneGroup.TableName);
        //    }
        //    else
        //    {
        //        this.Table = new DataTable(ZoneGroup.TableName);

        //        this.Table.Columns.Add("ZoneGroupID", typeof(long));
        //        this.Table.Columns.Add("ZoneID", typeof(long));
        //        this.Table.Columns.Add("Code", typeof(string));
        //        this.Table.Columns.Add("Name", typeof(string));
        //        this.Table.Columns.Add("Status", typeof(Int16)); 
        //        this.Table.Columns.Add("RowGUID", typeof(string));

        //        this.Table.AcceptChanges();
        //    }
        //}

        public int Insert(ref object ZoneGroupID, object ZoneID, object Name, object Code, object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(this.Connection))
            {
                SqlCommand cmd = this.Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spZoneGroupInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZoneGroupID", SqlDbType.Int);
                    cmd.Parameters["@ZoneGroupID"].Value = Utility.ToDBNull(ZoneGroupID);
                    cmd.Parameters["@ZoneGroupID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

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

                    ZoneGroupID = cmd.Parameters["@ZoneGroupID"].Value;

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
            else
                return -1;
        }

        public int Update(object ZoneGroupID, object ZoneID, object Name, object Code, object Status, object RowGUID )
        {
            if (Database.CheckConnection(this.Connection))
            {
                SqlCommand cmd = this.Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spZoneGroupUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZoneGroupID", SqlDbType.Int);
                    cmd.Parameters["@ZoneGroupID"].Value = Utility.ToDBNull(ZoneGroupID);
                    cmd.Parameters["@ZoneGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.Int);
                    cmd.Parameters["@ZoneID"].Value = Utility.ToDBNull(ZoneID);
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

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
            else
                return -1;
        }

        public int Delete(object ZoneGroupID)
        {
            if (Database.CheckConnection(this.Connection))
            {
                SqlCommand cmd = this.Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spZoneGroupDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZoneGroupID", SqlDbType.Int);
                    cmd.Parameters["@ZoneGroupID"].Value = ZoneGroupID;
                    cmd.Parameters["@ZoneGroupID"].Direction = ParameterDirection.Input;

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
            else
                return -1;
        }

        public static DataTable Select(long ZoneGroupID,long ZoneID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                SqlCommand cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spZoneGroupSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZoneGroupID", SqlDbType.SmallInt);
                    cmd.Parameters["@ZoneGroupID"].Value = ZoneGroupID;
                    cmd.Parameters["@ZoneGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ZoneID", SqlDbType.SmallInt);
                    cmd.Parameters["@ZoneID"].Value = ZoneID;
                    cmd.Parameters["@ZoneID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                    cmd.Parameters["@Status"].Value = Status;
                    cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, ZoneGroup.TableName);

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
            else
                return null;
        }
        #endregion
    }

}

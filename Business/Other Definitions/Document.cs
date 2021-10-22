using Core;
using DevExpress.DashboardCommon;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace Business
{
    public class Document
    {
        public Document(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~Document()
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

            public long DocumentID { get; set; }
            public long ModuleID { get; set; }
            public string Type { get; set; }
            public string Caption { get; set; }
            public string Name { get; set; }
            public object Data { get; set; }
            public DateTime Date { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                DocumentID = ModuleID = 0;
                Type = Name = Caption = "";
                Data = null;
                Status = Status.Active;
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    DocumentID = Utility.ToLong(row["DocumentID"]);
                    ModuleID = Utility.ToLong(row["ModuleID"]);
                    Type = row["Type"].ToString();
                    Name = row["Name"].ToString();
                    Caption = row["Caption"].ToString();
                    Data = row["Data"];
                    Date = Utility.ToDateTime(row["Date"]);
                    Status = (Status)Utility.ToByte(row["Status"]);
                    RowGUID = Utility.ToGuid(row["RowGUID"]);
                }
            }
        }

        #endregion Row

        #region Definitions

        private readonly SqlConnection Connection;
        private DataTable Table;

        public Recording Record;

        public const string TableName = "[dbo].[tblDocument]";

        public enum Status
        {
            Deleted = -1,
            Passive = 0,
            Active = 1
        }

        public enum Module
        {
            None,
            MrSmart,
            DrCPM,
            FollowMe,
            MrSmartWeb,
            DrCPMWeb,
            FollowMeWeb
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

        //public static DataTable GetList(SqlConnection connection, string Status)
        //{
        //    if (Database.CheckConnection(connection))

        //        List = Select(0, "", Status, connection);
        //    else
        //        List = null;

        //    return List;
        //}

        public int Insert(ref object DocumentID, object ModuleID, object Name, object Caption, object Type, object Data, object Date, object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spDocumentInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentID", SqlDbType.Int);
                    cmd.Parameters["@DocumentID"].Value = Utility.ToDBNull(DocumentID);
                    cmd.Parameters["@DocumentID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ModuleID", SqlDbType.Int);
                    cmd.Parameters["@ModuleID"].Value = Utility.ToDBNull(ModuleID);
                    cmd.Parameters["@ModuleID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 255);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Caption", SqlDbType.NVarChar, 255);
                    cmd.Parameters["@Caption"].Value = Utility.ToDBNull(Caption);
                    cmd.Parameters["@Caption"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Type", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Type"].Value = Utility.ToDBNull(Type);
                    cmd.Parameters["@Type"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Data", SqlDbType.VarBinary);
                    cmd.Parameters["@Data"].Value = Utility.ToDBNull(Data);
                    cmd.Parameters["@Data"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

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

                    DocumentID = cmd.Parameters["@DocumentID"].Value;

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

        public int Update(object DocumentID, object ModuleID, object Name, object Caption, object Type, object Data, object Date, object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spDocumentUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentID", SqlDbType.Int);
                    cmd.Parameters["@DocumentID"].Value = Utility.ToDBNull(DocumentID);
                    cmd.Parameters["@DocumentID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ModuleID", SqlDbType.Int);
                    cmd.Parameters["@ModuleID"].Value = Utility.ToDBNull(ModuleID);
                    cmd.Parameters["@ModuleID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 255);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Caption", SqlDbType.NVarChar, 255);
                    cmd.Parameters["@Caption"].Value = Utility.ToDBNull(Caption);
                    cmd.Parameters["@Caption"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Type", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Type"].Value = Utility.ToDBNull(Type);
                    cmd.Parameters["@Type"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Data", SqlDbType.VarBinary);
                    cmd.Parameters["@Data"].Value = Utility.ToDBNull(Data);
                    cmd.Parameters["@Data"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

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

        public int Delete(object DocumentID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spDocumentDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentID", SqlDbType.Int);
                    cmd.Parameters["@DocumentID"].Value = DocumentID;
                    cmd.Parameters["@DocumentID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long DocumentID, string Name, string Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spDocumentSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentID", SqlDbType.Int);
                    cmd.Parameters["@DocumentID"].Value = DocumentID;
                    cmd.Parameters["@DocumentID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                    cmd.Parameters["@Name"].Value = Name;
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Status", SqlDbType.VarChar);
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

        public static DataTable selectDashboardPermission(long userID, string Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spDashboardSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserId", SqlDbType.Int);
                    cmd.Parameters["@UserId"].Value = userID;
                    cmd.Parameters["@UserId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UserStatus", SqlDbType.VarChar);
                    cmd.Parameters["@UserStatus"].Value = Status;
                    cmd.Parameters["@UserStatus"].Direction = ParameterDirection.Input;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, "[dbo][tblScreenPermission]");

                    return ds.Tables[0];
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally { cmd.Dispose(); }
            }
            return null;
        }

        public static int AddOrUpdateDashboard(Dashboard dashboard, byte moduleID, string dashboardName, string caption, string Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var type = "XML";
                object data;

                try
                {
                    var dDocument = new DataTable();
                    var doc = new Document(connection);

                    //XDocument xdocument = dashboard.SaveToXDocument();

                    var stream = new MemoryStream();
                    dashboard.SaveToXDocument().Save(stream);
                    stream.Position = 0;
                    data = stream.ToArray();

                    dDocument = Select(0, dashboardName, Status, connection);

                    int result;
                    if (dDocument != null && dDocument.Rows.Count > 0)
                    {
                        result = doc.Update(Utility.ToLong(dDocument.Rows[0]["DocumentID"]), moduleID, dashboardName, caption, type, data, DateTime.Now, Status, Utility.ToGuid(dDocument.Rows[0]["RowGUID"]));
                    }
                    else
                    {
                        //object documentID = 0;
                        //object rowGuid = Guid.Empty;

                        //result = doc.Insert(ref documentID, moduleID, dashboardName, type, caption, data, DateTime.Now, Status, ref rowGuid);
                        result = 0;
                    }

                    return result;
                }
                catch (SqlException exc)
                {
                    throw exc;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return -1;
        }

        public static XDocument LoadDashboard(string Name, string Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText = "SELECT [Data] FROM [dbo].[tblDocument] WHERE [Name] = @Name and Status= @Status";
                    cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
                    cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = Status;

                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    var data = reader.GetValue(0) as byte[];
                    var stream = new MemoryStream(data);
                    return XDocument.Load(stream);
                }
                catch (SqlException exc)
                {
                    throw exc;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }

        public static XDocument LoadDashboard(long DocumentID, string Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();

                try
                {
                    cmd.CommandText = "SELECT [Data] FROM [dbo].[tblDocument] WHERE [DocumentID] = @DocumentID and Status= @Status";
                    cmd.Parameters.Add("DocumentID", SqlDbType.Int).Value = DocumentID;
                    cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = Status;

                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    var data = reader.GetValue(0) as byte[];
                    var stream = new MemoryStream(data);

                    return XDocument.Load(stream);
                }
                catch (SqlException exc)
                {
                    throw exc;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }

        /// <summary>
        ///     Convert an object to a byte array
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ObjectToByteArray(object obj)
        {
            var bf = new BinaryFormatter();

            try
            {
                var ms = new MemoryStream();

                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Convert a byte array to an Object
        /// </summary>
        /// <param name="arrBytes"></param>
        /// <returns></returns>
        public static object ByteArrayToObject(byte[] arrBytes)
        {
            try
            {
                var ms = new MemoryStream();

                var binForm = new BinaryFormatter();
                ms.Write(arrBytes, 0, arrBytes.Length);
                ms.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(ms);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ModuleSelect(long ModuleID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spModuleSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModuleID", SqlDbType.Int);
                    cmd.Parameters["@ModuleID"].Value = ModuleID;
                    cmd.Parameters["@ModuleID"].Direction = ParameterDirection.Input;

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
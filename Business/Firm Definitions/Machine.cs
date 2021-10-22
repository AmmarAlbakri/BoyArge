using Core;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Business
{
    public class Machine
    {
        public Machine(SqlConnection connection)
        {
            Connection = connection;
            Record = new Recording();
        }

        ~Machine()
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

            public long MachineID { get; set; }
            public long MachineGroupID { get; set; }
            public long ProductionTypeID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Model { get; set; }
            public string Specode { get; set; }
            public string ModelYear { get; set; }
            public long NeedleCount { get; set; }
            public long FNeedleCount { get; set; }
            public DateTime Date { get; set; }
            public string Note { get; set; }
            public string Code1 { get; set; }
            public string Code2 { get; set; }
            public decimal Code3 { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                MachineID = MachineGroupID = ProductionTypeID = NeedleCount = FNeedleCount = 0;
                Code3 = 0;
                Status = Status.Active;
                Code = Name = Note = Model = Specode = ModelYear = Code1 = Code2 = "";
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row == null) return;

                MachineID = Utility.ToLong(row["MachineID"]);
                MachineGroupID = Utility.ToLong(row["MachineGroupID"]);
                ProductionTypeID = Utility.ToLong(row["ProductionTypeID"]);
                Code = row["Code"].ToString();
                Name = row["Name"].ToString();
                Model = row["Model"].ToString();
                Specode = row["Specode"].ToString();
                ModelYear = row["ModelYear"].ToString();
                NeedleCount = Utility.ToLong(row["NeedleCount"]);
                FNeedleCount = Utility.ToLong(row["FNeedleCount"]);
                Date = Utility.ToDateTime(row["Date"]);
                Note = row["Note"].ToString();
                Code1 = row["Code1"].ToString();
                Code2 = row["Code2"].ToString();
                Code3 = Utility.ToDecimal(row["Code3"]);
                Status = (Status)Utility.ToByte(row["Status"]);
                RowGUID = Utility.ToGuid(row["RowGUID"]);
            }
        }

        #endregion Row

        #region Definitions

        private readonly SqlConnection Connection;
        private DataTable Table;

        private static DataTable List;

        public Recording Record;

        public const string TableName = "[dbo].[tblMachine]";

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
                List = Select(0, 0, OnlyActive ? 1 : 0, connection);
            else
                List = null;

            return List;
        }

        public int Insert(ref object MachineID, object MachineGroupID, object ProductionTypeID, object Name,
            object Code, object Model, object Specode, object ModelYear, object NeedleCount, object FNeedleCount,
            object Date, object Note, object Code1, object Code2, object Code3, object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spMachineInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = Utility.ToDBNull(MachineID);
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = Utility.ToDBNull(MachineGroupID);
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProductionTypeID", SqlDbType.Int);
                    cmd.Parameters["@ProductionTypeID"].Value = Utility.ToDBNull(ProductionTypeID);
                    cmd.Parameters["@ProductionTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Model", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Model"].Value = Utility.ToDBNull(Model);
                    cmd.Parameters["@Model"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Specode", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Specode"].Value = Utility.ToDBNull(Specode);
                    cmd.Parameters["@Specode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ModelYear", SqlDbType.VarChar, 4);
                    cmd.Parameters["@ModelYear"].Value = Utility.ToDBNull(ModelYear);
                    cmd.Parameters["@ModelYear"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@NeedleCount", SqlDbType.Int);
                    cmd.Parameters["@NeedleCount"].Value = Utility.ToDBNull(NeedleCount);
                    cmd.Parameters["@NeedleCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FNeedleCount", SqlDbType.Int);
                    cmd.Parameters["@FNeedleCount"].Value = Utility.ToDBNull(FNeedleCount);
                    cmd.Parameters["@FNeedleCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.Date);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Note", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Note"].Value = Utility.ToDBNull(Note);
                    cmd.Parameters["@Note"].Direction = ParameterDirection.Input;

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

                    MachineID = cmd.Parameters["@MachineID"].Value;

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

        public int Update(object MachineID, object MachineGroupID, object ProductionTypeID, object Name, object Code,
            object Model, object Specode, object ModelYear, object NeedleCount, object FNeedleCount, object Date,
            object Note, object Code1, object Code2, object Code3, object Status, object RowGUID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spMachineUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = Utility.ToDBNull(MachineID);
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.Int);
                    cmd.Parameters["@MachineGroupID"].Value = Utility.ToDBNull(MachineGroupID);
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ProductionTypeID", SqlDbType.Int);
                    cmd.Parameters["@ProductionTypeID"].Value = Utility.ToDBNull(ProductionTypeID);
                    cmd.Parameters["@ProductionTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Name"].Value = Utility.ToDBNull(Name);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Code"].Value = Utility.ToDBNull(Code);
                    cmd.Parameters["@Code"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Model", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Model"].Value = Utility.ToDBNull(Model);
                    cmd.Parameters["@Model"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Specode", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Specode"].Value = Utility.ToDBNull(Specode);
                    cmd.Parameters["@Specode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ModelYear", SqlDbType.VarChar, 4);
                    cmd.Parameters["@ModelYear"].Value = Utility.ToDBNull(ModelYear);
                    cmd.Parameters["@ModelYear"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@NeedleCount", SqlDbType.Int);
                    cmd.Parameters["@NeedleCount"].Value = Utility.ToDBNull(NeedleCount);
                    cmd.Parameters["@NeedleCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@FNeedleCount", SqlDbType.Int);
                    cmd.Parameters["@FNeedleCount"].Value = Utility.ToDBNull(FNeedleCount);
                    cmd.Parameters["@FNeedleCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Date", SqlDbType.Date);
                    cmd.Parameters["@Date"].Value = Utility.ToDBNull(Date);
                    cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@Note", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Note"].Value = Utility.ToDBNull(Note);
                    cmd.Parameters["@Note"].Direction = ParameterDirection.Input;

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

        public int Delete(object MachineID)
        {
            if (Database.CheckConnection(Connection))
            {
                var cmd = Connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spMachineDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineID", SqlDbType.Int);
                    cmd.Parameters["@MachineID"].Value = MachineID;
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long MachineID, long MachineGroupID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spMachineSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MachineID", SqlDbType.SmallInt);
                    cmd.Parameters["@MachineID"].Value = MachineID;
                    cmd.Parameters["@MachineID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@MachineGroupID", SqlDbType.SmallInt);
                    cmd.Parameters["@MachineGroupID"].Value = MachineGroupID;
                    cmd.Parameters["@MachineGroupID"].Direction = ParameterDirection.Input;

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

        public static DataTable GetBoiler(SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    var sql = new StringBuilder();

                    sql.AppendLine("SELECT [MachineID],");
                    sql.AppendLine("      [MachineGroup],");
                    sql.AppendLine("      [Kodu],");
                    sql.AppendLine("      [Adı],");
                    sql.AppendLine("      [İğ Sayısı],");
                    sql.AppendLine("      [Flotte],");
                    sql.AppendLine("      [Min],");
                    sql.AppendLine("      [Max],");
                    sql.AppendLine("      [Code3],");
                    sql.AppendLine("      [Specode],");
                    sql.AppendLine("      [Note]");
                    sql.AppendLine("FROM [dbo].[vwBoiler]");

                    cmd.CommandText = sql.ToString();
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
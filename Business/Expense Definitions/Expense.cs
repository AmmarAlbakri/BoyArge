﻿using Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class Expense
    {
        public Expense(SqlConnection connection)
        {
            _connection = connection;
            Record = new Recording();
        }

        ~Expense()
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

            public long ExpenseID { get; set; }
            public long ExpenseTypeID { get; set; }
            public long UnitID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public Status Status { get; set; }
            public Guid RowGUID { get; set; }

            public void Reset()
            {
                ExpenseID = ExpenseTypeID = UnitID = 0;
                Status = Status.Active;
                Code = Name = "";
                RowGUID = Guid.Empty;
            }

            public void Change(DataRow row)
            {
                if (row != null)
                {
                    ExpenseID = Utility.ToLong(row["ExpenseID"]);
                    ExpenseTypeID = Utility.ToLong(row["ExpenseTypeID"]);
                    UnitID = Utility.ToLong(row["UnitID"]);
                    Code = row["Code"].ToString();
                    Name = row["Name"].ToString();
                    Status = (Status)Utility.ToByte(row["Status"]);
                    RowGUID = Utility.ToGuid(row["RowGUID"]);
                }
            }
        }

        #endregion Row

        #region Definitions

        private readonly SqlConnection _connection;
        private DataTable Table;

        private static DataTable List;

        public Recording Record;

        public const string TableName = "[dbo].[tblExpense]";

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

        public static DataTable GetList(SqlConnection connection, bool onlyActive = true)
        {
            if (Database.CheckConnection(connection))
                List = Select(0, onlyActive ? 1 : 0, connection);
            else
                List = null;

            return List;
        }

        //public void Refresh(bool OnlyActive, bool Dummy)
        //{
        //    if (!Dummy)
        //    {
        //        StringBuilder sql = new StringBuilder();

        //        sql.AppendLine("SELECT");
        //        sql.AppendLine("    [ExpenseID],");
        //        sql.AppendLine("    [Code],");
        //        sql.AppendLine("    [Name],");
        //        sql.AppendLine("    [Status],");
        //        sql.AppendLine("    [RowGUID]");
        //        sql.AppendLine("FROM [dbo].[tblExpense]");

        //        if (OnlyActive)
        //            sql.AppendLine("WHERE [Status] > 0");
        //        else
        //            sql.AppendLine("WHERE [Status] >= 0");

        //        sql.AppendLine("ORDER BY [Code]");

        //        this.Table = Database.GetList(sql.ToString(), this.Connection, Expense.TableName);
        //    }
        //    else
        //    {
        //        this.Table = new DataTable(Expense.TableName);

        //        this.Table.Columns.Add("ExpenseID", typeof(long));
        //        this.Table.Columns.Add("FirmID", typeof(long));
        //        this.Table.Columns.Add("Code", typeof(string));
        //        this.Table.Columns.Add("Name", typeof(string));
        //        this.Table.Columns.Add("Status", typeof(Int16));
        //        this.Table.Columns.Add("RowGUID", typeof(string));

        //        this.Table.AcceptChanges();
        //    }
        //}

        public int Insert(ref object ExpenseID, object ExpenseTypeID, object UnitID, object Name, object Code,
            object Status, ref object RowGUID)
        {
            if (Database.CheckConnection(_connection))
            {
                var cmd = _connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spExpenseInsert]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseID"].Value = Utility.ToDBNull(ExpenseID);
                    cmd.Parameters["@ExpenseID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@ExpenseTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseTypeID"].Value = Utility.ToDBNull(ExpenseTypeID);
                    cmd.Parameters["@ExpenseTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitID", SqlDbType.Int);
                    cmd.Parameters["@UnitID"].Value = Utility.ToDBNull(UnitID);
                    cmd.Parameters["@UnitID"].Direction = ParameterDirection.Input;

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

                    ExpenseID = cmd.Parameters["@ExpenseID"].Value;

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

        public int Update(object ExpenseID, object ExpenseTypeID, object UnitID, object Name, object Code,
            object Status, object RowGUID)
        {
            if (Database.CheckConnection(_connection))
            {
                var cmd = _connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spExpenseUpdate]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseID"].Value = Utility.ToDBNull(ExpenseID);
                    cmd.Parameters["@ExpenseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ExpenseTypeID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseTypeID"].Value = Utility.ToDBNull(ExpenseTypeID);
                    cmd.Parameters["@ExpenseTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@UnitID", SqlDbType.Int);
                    cmd.Parameters["@UnitID"].Value = Utility.ToDBNull(UnitID);
                    cmd.Parameters["@UnitID"].Direction = ParameterDirection.Input;

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

            return -1;
        }

        public int Delete(object ExpenseID)
        {
            if (Database.CheckConnection(_connection))
            {
                var cmd = _connection.CreateCommand();

                try
                {
                    cmd.CommandText = "[dbo].[spExpenseDelete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
                    cmd.Parameters["@ExpenseID"].Value = ExpenseID;
                    cmd.Parameters["@ExpenseID"].Direction = ParameterDirection.Input;

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

        public static DataTable Select(long ExpenseID, int Status, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spExpenseSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ExpenseID", SqlDbType.SmallInt);
                    cmd.Parameters["@ExpenseID"].Value = ExpenseID;
                    cmd.Parameters["@ExpenseID"].Direction = ParameterDirection.Input;

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
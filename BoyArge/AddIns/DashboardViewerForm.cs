using Business;
using Core;
using DevExpress.DashboardCommon;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BoyArge
{
    public partial class DashboardViewerForm : XtraForm
    {
        #region Definition

        public Dashboard Dashboard { get; set; }
        public int sayac = 0;
        public int sayac_time = 60;

        #endregion Definition

        #region Event

        public DashboardViewerForm()
        {
            InitializeComponent();
        }

        private void DashboardViewerForm_Load(object sender, EventArgs e)
        {
            LoadSource();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select Property from [dbo].[tblParameters] where Definition = 'Refresh_Timer' and Feature='Code'", LoginForm.DataConnection);
                cmd.CommandType = CommandType.Text;

                SqlDataReader sql = cmd.ExecuteReader();
                sql.Read();

                sayac_time = Convert.ToInt32(sql["Property"].ToString());
                sql.Close();
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { throw ex; }

            sayac = 0;
            timer1.Enabled = true;

            if (!this.IsMdiChild)
            {
                RefreshList();
            }
            else
            {
                ((StartForm)this.MdiParent).ribbonControl1.Minimized = true;
                RefreshList();
            }
        }

        #endregion Event

        #region Function

        private void RefreshList()
        {
            if (this.lookReportType.EditValue != null)
            {
                try
                {
                    XDocument doc = Business.Document.LoadDashboard(Utility.ToLong(lookReportType.EditValue), LoginForm.UserStatus, LoginForm.DataConnection);
                    this.dashboardViewer.Dashboard = new Dashboard();
                    this.dashboardViewer.Dashboard.LoadFromXDocument(doc);
                }
                catch (SqlException exc)
                {
                    XtraMessageBox.Show(exc.Message);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadSource()
        {
            if (this.Dashboard != null)
                dashboardViewer.Dashboard = Dashboard;
            using (var dDocument = Document.selectDashboardPermission(LoginForm.UserId, LoginForm.UserStatus, LoginForm.DataConnection))
            {
                //DataTable table = ScreenPermission.GetUserPermissions(LoginForm.UserId, LoginForm.DataConnection);
                //        foreach(DataRow row in dDocument.Rows)
                //        {
                //            foreach (DataRow row2 in table.Rows)
                //            {
                //                if (row["Caption"].Equals(row2["Definition"]))
                //                {
                //                    if (Utility.ToBoolean(row2["Access"])){
                //                        // bişey yapma
                //                    }
                //                    else
                //                    {
                //                        // row değişkenini dDocumnet tablosundan kaldır.
                //                        dDocument.Rows.Remove(row);
                //                    }
                //                }
                //            }
                //        }

                Format.LookUpEdit(this.lookReportType, new[] { "Caption", "Date" }, "Caption", "DocumentID", dDocument);
            }
        }

        #endregion Function

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            if (sayac == sayac_time)
            {
                dashboardViewer.ReloadData();
                sayac = 0;
            }
        }
    }
}
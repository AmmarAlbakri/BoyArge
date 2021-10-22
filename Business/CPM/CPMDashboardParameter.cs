using DevExpress.DashboardCommon;
using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class CPMDashboardParameter
    {
        public CPMDashboardParameter()
        {
            Reset();
        }

        public static DataTable GetTypeList()
        {
            var dt = new DataTable();

            dt.Columns.Add("TypeListID", typeof(int));
            dt.Columns.Add("ReportType", typeof(string));

            dt.Rows.Add(0, "Onay Sistemi");
            dt.Rows.Add(1, "MRP");
            dt.Rows.Add(2, "Siparişler");
            dt.Rows.Add(3, "Sipariş Detayları");
            dt.Rows.Add(4, "Refakat İzleyici");
            dt.Rows.Add(5, "Üretim Reçeteleri");
            dt.Rows.Add(6, "Sevkiyat");
            dt.Rows.Add(7, "Termin");
            dt.Rows.Add(8, "Stock");
            dt.Rows.Add(9, "StockAnalyze");
            dt.Rows.Add(10, "AllOrders");
            dt.Rows.Add(11, "Samples");
            dt.Rows.Add(12, "AllSamples");
            dt.Rows.Add(13, "Termin Analizler");

            return dt;
        }

        private void AddParameter(string _name, Type _type, object _value, object _data = null)
        {
            var param = new DashboardParameter
            {
                Name = _name,
                Type = _type,
                Value = _value
            };

            var settings = new DynamicListLookUpSettings
            {
                DataSource = new DashboardObjectDataSource(_data),
                ValueMember = _name,
                DisplayMember = _name
            };

            param.LookUpSettings = settings;

            foreach (var parameter in parameterList)
                if (parameter.Name == param.Name)
                {
                    parameter.Value = _value;
                    return;
                }

            parameterList.Add(param);
        }

        public List<DashboardParameter> GetListParameter()
        {
            if (parameterList == null)
                return null;

            return parameterList;
        }

        public void Reset()
        {
            Year = null;
            EvrakDurum = null;
            UretimDurum = null;

            parameterList = new List<DashboardParameter>();
        }

        /// <summary>
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="year"></param>
        /// <param name="evrakDurum"></param>
        /// <param name="uretimDurum"></param>
        public void Change(ReportType reportType, object year, object evrakDurum, object uretimDurum)
        {
            try
            {
                Year = year;
                EvrakDurum = evrakDurum;
                UretimDurum = uretimDurum;
                ReportType_ = reportType;

                //if (reportType == ReportType.StockDashboard)
                //    return;

                AddParameter("Year", typeof(object), year);

                var dEvrakDurum = new DataTable();
                dEvrakDurum.Columns.Add("ID", typeof(int));
                dEvrakDurum.Columns.Add("EvrakDurum", typeof(string));
                dEvrakDurum.Rows.Add(0, "Açık");
                dEvrakDurum.Rows.Add(1, "Kapalı");

                AddParameter("EvrakDurum", typeof(object), evrakDurum, dEvrakDurum);

                var dUretimDurum = new DataTable();
                dUretimDurum.Columns.Add("ID", typeof(int));
                dUretimDurum.Columns.Add("UretimDurum", typeof(string));
                dUretimDurum.Rows.Add(0, "Açık");
                dUretimDurum.Rows.Add(1, "Kapalı");

                AddParameter("UretimDurum", typeof(object), uretimDurum, dUretimDurum);
            }
            catch (ArgumentNullException exa)
            {
                throw exa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Definitions

        public object Year { get; set; }
        public object EvrakDurum { get; set; }
        public object UretimDurum { get; set; }

        public const int ModuleID = 2; //Dr CPM

        public enum ReportType
        {
            None = 0,
            ConfirmSystem = 1,
            MRP = 2,
            Orders = 3,
            Preview = 4,
            ProductionOrder = 5,
            ReceiptStatus = 6,
            Shipment = 7,
            Termin = 8,
            Stock = 9,
            StockAnalyze = 10,
            AllOrders = 11,
            Samples = 12,
            AllSamples = 13,
            TerminAnalyze = 14

            //ConfirmSystem =0 ,
            //MRP = 1,
            //Orders = 2,
            //Preview = 3,
            //ProductionOrder = 4,
            //ReceiptStatus = 5,
            //Shipment = 6,
            //Termin = 7
        }

        public ReportType ReportType_ { get; set; }

        public List<DashboardParameter> parameterList = new List<DashboardParameter>();

        #endregion Definitions
    }
}
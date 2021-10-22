using DevExpress.DashboardCommon;
using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class UnitCostParameter
    {
        public enum ReportType
        {
            Static = 0,
            Dynamic = 1
        }

        public enum UnitCostType
        {
            UnitCost,
            ProductUnitCost,
            ProcessUnitCost,
            ZoneExpense,
            Capacity
        }

        public List<DashboardParameter> parameterList = new List<DashboardParameter>();

        public UnitCostParameter()
        {
            Reset();
        }

        public object Date { get; set; }
        public object MainStockCode { get; set; }
        public object StockFeatureTypeID { get; set; }
        public object OrderAmount { get; set; }
        public object CapacityType { get; set; }
        public object RingNo { get; set; }
        public object BukumNo { get; set; }
        public object FinalNo { get; set; }
        public object CalculateType { get; set; }
        public object OrderType { get; set; }
        public object DeliveryType { get; set; }
        public object PaymentDate { get; set; }
        public object PackageType { get; set; }
        public object ProductTreeFicheID { get; set; }

        public static DataTable GetTypeList()
        {
            var dt = new DataTable();

            dt.Columns.Add("TypeListID", typeof(int));
            dt.Columns.Add("UnitCostType", typeof(string));

            dt.Rows.Add(0, "Üretim Maliyet Kalemleri");
            dt.Rows.Add(1, "Proses Maliyeti");
            dt.Rows.Add(2, "Makine ve Operatör Bilgileri");
            dt.Rows.Add(3, "Kapasite Bilgileri");
            dt.Rows.Add(4, "Ürün Maliyeti");

            return dt;
        }

        private void AddParameter(string _name, Type _type, object _value)
        {
            var param = new DashboardParameter
            {
                Name = _name,
                Type = _type,
                Value = _value
            };

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
            Date = null;
            MainStockCode = "";
            OrderAmount = RingNo = BukumNo = FinalNo = 0;
            StockFeatureTypeID = CapacityType = CalculateType =
                OrderType = DeliveryType = PaymentDate = PackageType = ProductTreeFicheID = 0;

            parameterList = new List<DashboardParameter>();
        }

        public void Change(UnitCostType unitCostType, object date, object mainStockCode, object stockFeatureTypeID,
            object orderAmount, object capacityType, object ringNo, object bukumNo, object finalNo,
            object calculateType, object orderType = null, object deliveryType = null, object paymentDate = null,
            object packageType = null, object productTreeFicheID = null)
        {
            Date = date;
            MainStockCode = mainStockCode;
            StockFeatureTypeID = stockFeatureTypeID;
            OrderAmount = orderAmount;
            CapacityType = capacityType;
            RingNo = ringNo;
            BukumNo = bukumNo;
            FinalNo = finalNo;
            CalculateType = calculateType;
            OrderType = orderType;
            DeliveryType = deliveryType;
            PaymentDate = paymentDate;
            PackageType = packageType;
            ProductTreeFicheID = productTreeFicheID;

            AddParameter("ProductTreeFicheID", typeof(int), productTreeFicheID);
            AddParameter("MainStockCode", typeof(string), mainStockCode);
            AddParameter("StockFeatureTypeID", typeof(int), stockFeatureTypeID);
            AddParameter("OrderAmount", typeof(decimal), orderAmount);
            AddParameter("RingBobinNr", typeof(decimal), ringNo);
            AddParameter("BukumNr", typeof(decimal), bukumNo);
            AddParameter("FinalNr", typeof(decimal), finalNo);
            AddParameter("Date", typeof(DateTime), date);
            AddParameter("CapacityType", typeof(decimal), capacityType);
            AddParameter("CalculateType", typeof(bool), calculateType);
            AddParameter("PaymentDate", typeof(int), paymentDate);
            AddParameter("PackageType", typeof(int), packageType);
            AddParameter("OrderType", typeof(int), orderType);
            AddParameter("DeliveryType", typeof(int), deliveryType);
        }
    }
}
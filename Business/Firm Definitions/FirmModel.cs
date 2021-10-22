using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class FirmModel : INotifyPropertyChanged
    {
        public FirmModel(object firmID, object code, object name, object phone, object email, object address,
            object status, object rowguid)
        {
            FirmID = firmID;
            Code = code;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            Status = status;
            RowGUID = rowguid;
        }

        public object FirmID { get; set; }
        public object Code { get; set; }
        public object Name { get; set; }
        public object Phone { get; set; }
        public object Email { get; set; }
        public object Address { get; set; }
        public object Status { get; set; }
        public object RowGUID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        public static CustomObservableCollection<FirmModel> GetFirms(SqlConnection connection)
        {
            var dt = Firm.GetList(connection);

            if (dt == null) return null;

            var firmItems = new CustomObservableCollection<FirmModel>();

            foreach (DataRow row in dt.Rows)
                firmItems.Insert(firmItems.Count,
                    new FirmModel(row["FirmID"], row["Code"], row["Name"], row["Phone"], row["Email"], row["Address"],
                        row["Status"], row["RowGUID"]));

            return firmItems;
        }
    }
}
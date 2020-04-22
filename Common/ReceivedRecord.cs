using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
    public class ReceivedRecord
    {
        [MySqlColName("store_id")]
        public string StoreId { get; set; }
        [MySqlColName("credit_card")]
        public string CreditCard { get; set; }
        [MySqlColName("purchase_date")]
        public DateTime PurchaseDate { get; set; }
        [MySqlColName("total_price")]
        public double TotalPrice { get; set; }
        [MySqlColName("installments")]
        public int Installments { get; set; }
        [MySqlColName("store_type")]
        public char StoreType { get; set; }
        [MySqlColName("activity_days")]
        public char ActivityDays { get; set; }
        [MySqlColName("insertion_date")]
        public DateTime InsertionDate { get; set; }
        [MySqlColName("price_per_installment")]
        public double PricePerInstallment { get; set; }
        [MySqlColName("is_valid")]
        public bool IsValid { get; set; }
        [MySqlColName("why invalid")]
        public string WhyInvalid { get; set; }

        public ReceivedRecord() { }

        public ReceivedRecord(RecordToPublish record)
        {
            StoreId = record.StoreId;
            CreditCard = record.CreditCard;
            PurchaseDate = DateTime.Parse(record.PurchaseDate);
            TotalPrice = double.Parse(String.Format("{0:0.0}", record.TotalPrice));
            Installments = record.Installments is int && record.Installments > 1 ?
                record.Installments : 1;
            StoreType = StoreId[0];
            ActivityDays = StoreId[1];
            InsertionDate = record.InsertionDate;
            PricePerInstallment = TotalPrice / Installments;
            IsValid = record.IsValid;
            WhyInvalid = record.WhyInvalid;
        }

    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class MySqlColName : Attribute
    {
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }

            }

    public MySqlColName(string name)
        {
            _name = name;
        }
    }
}

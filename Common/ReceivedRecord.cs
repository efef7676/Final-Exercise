using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
    public class ReceivedRecord
    {
        public string StoreId { get; set; }
        public string CreditCard { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double TotalPrice { get; set; }
        public int Installments { get; set; }
        public char StoreType { get; set; }
        public char ActivityDays { get; set; }
        public DateTime InsertionDate { get; set; }
        public double PricePerInstallment { get; set; }
        public bool IsValid { get; set; }
        public string WhyInvalid { get; set; }

        public ReceivedRecord() { }

        public ReceivedRecord(RecordToPublish record)
        {
            StoreId = record.StoreId;
            CreditCard = record.CreditCard;
            PurchaseDate = DateTime.Parse(record.PurchaseDate);
            TotalPrice = RoundDouble(record.TotalPrice);
            Installments = record.Installments is int ? record.Installments : 1;
            StoreType = StoreId[0];
            ActivityDays = StoreId[1];
            InsertionDate = record.InsertionDate;
            PricePerInstallment = RoundDouble(record.TotalPrice/record.Installments);
            IsValid = record.IsValid;
            WhyInvalid = record.WhyInvalid;
        }

        private double RoundDouble(double number)
        {
           return double.Parse(String.Format(ConfigorationValues.ExpectedPriceFormat, number));
        }

    }
}

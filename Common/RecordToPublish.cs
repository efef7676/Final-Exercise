using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RecordToPublish
    {
        private static Random _random = new Random();
        public GeneratorForRecords Generator = new GeneratorForRecords();
        public string StoreId { get; set; }
        public string CreditCard { get; set; }
        public dynamic PurchaseDate { get; set; }
        public dynamic TotalPrice { get; set; }
        public dynamic Installments { get; set; }
        public DateTime InsertionDate { get; set; }
        public bool IsValid { get; set; }
        public string WhyInvalid { get; set; }

        public RecordToPublish(bool isOneInstallment = true)
        {

            StoreId = Generator.GenerateValidStoreId();
            CreditCard = Generator.GenerateValidCreditCard();
            PurchaseDate = Generator.GenerateValidDate(StoreId[1]).ToString(ConfigorationValues.ExpectedDateFormat);
            TotalPrice = Generator.GenerateDoublePrice(isOneInstallment);
            Installments = Generator.GenerateInstallmentsByPrice(isOneInstallment, TotalPrice);
            IsValid = true;
            WhyInvalid = null;
            InsertionDate = DateTime.Now.Date;
        }

        public RecordToPublish SetAsImpossibleRecord()
        {
            StoreId = $"{_random.Next()}";
            PurchaseDate = Generator.GenerateValidDate();
            TotalPrice = Generator.GenerateValidStoreId();
            Installments = _random.Next(-100, 0);
            CreditCard = Generator.GenerateValidCreditCard();

            return this;
        }

        public void SetActivityDays(char activityDays = ' ')
        {
            var storeId = new StringBuilder(StoreId);
            storeId[1] = activityDays;
            StoreId = Convert.ToString(storeId);
        }

        public static List<RecordToPublish> CreateNValidRecordsToPublish(int numberOfRecords)
        {
            var records = new List<RecordToPublish>();
            for (int i = 0; i < numberOfRecords; i++)
            {
                records.Add(new RecordToPublish(true));
            }

            return records;
        }
    }
}

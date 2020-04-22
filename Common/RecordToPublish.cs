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
        private GeneratorForRecords Generator = new GeneratorForRecords();
        public string StoreId { get; set; }
        public string CreditCard { get; set; }
        public dynamic PurchaseDate { get; set; }
        public dynamic TotalPrice { get; set; }
        public dynamic Installments { get; set; }
        public DateTime InsertionDate { get; set; }
        public bool IsValid { get; set; }
        public string WhyInvalid { get; set; }

        public RecordToPublish()
        { }

        public RecordToPublish(string storeId, string creditCard, dynamic purchaseDate, double totalPrice, dynamic installments)
        {
            StoreId = storeId;
            CreditCard = creditCard;
            PurchaseDate = purchaseDate;
            TotalPrice = totalPrice;
            Installments = installments;
        }

        public RecordToPublish(bool isValidRecord)
        {
            if (isValidRecord)
            {
                StoreId = Generator.GenerateStoreId();
                CreditCard = Generator.GenerateCreditCard();
                PurchaseDate = Generator.GenerateDate(StoreId[1]).ToString("yyyy-MM-dd");
                TotalPrice = Generator.GeneratePrice();
                Installments = Generator.GenerateInstallmentsByPrice(false, TotalPrice);
                IsValid = true;
                WhyInvalid = null;
            }
            else
            {
                IsValid = false;
                //records that will save in DB as invalid!!
            }

            InsertionDate = DateTime.Now.Date;
        }

        public RecordToPublish SetAsImpossibleRecord()
        {
            StoreId = $"{_random.Next()}";
            PurchaseDate = Generator.GenerateDate();
            TotalPrice = Generator.GenerateStoreId();
            Installments = _random.Next(-100, 0);
            CreditCard = Generator.GenerateCreditCard();

            return this;
        }

    }
}

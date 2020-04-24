using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class ImpossibleRecordExtensions
    {
        private static Random _random = new Random();

        public static void SetInvalidStoreID(this RecordToPublish record) =>
            record.StoreId = record.Generator.GenerateValidCreditCard();

        public static void SetPurchaseDateInUnexpectedFormat(this RecordToPublish record) =>
            record.PurchaseDate = record.Generator.GenerateValidDate().ToString("dd/MM/yyyy");

        public static void SetImpossiblePurchaseDate(this RecordToPublish record) =>
            record.PurchaseDate = record.Generator.GenerateValidStoreId();

        public static void SetImpossibleTotalPrice(this RecordToPublish record) =>
            record.TotalPrice = record.Generator.GenerateValidStoreId();

        public static void SetImpossibleInstallments(this RecordToPublish record)
        {
            var optionsToInvalidInstallments = new dynamic[] { _random.Next(-100, -1), "full", "abcdss" };
            record.Installments = optionsToInvalidInstallments[_random.Next(optionsToInvalidInstallments.Length)];
        }
    }
}

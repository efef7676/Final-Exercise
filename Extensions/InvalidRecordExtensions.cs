using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class InvalidRecordExtensions
    {
        private static Random _random = new Random();

        public static void SetInvalidCreditCard(this RecordToPublish record)
        {
            record.CreditCard = record.Generator.GenerateValidStoreId();
            record.WhyInvalid = ConfigorationValues.CreditCardError;
            record.IsValid = false;
        }

        public static void SetPurchaseDateLaterThanCurrentDate(this RecordToPublish record)
        {
            var start = DateTime.Now.AddMonths(2);
            var end = DateTime.Now.AddMonths(5);
            var range = (end - start).Days;
            record.PurchaseDate = start.AddDays(_random.Next(range)).ConvertByExpectedDateFormat();
            record.IsValid = false;
            record.WhyInvalid = ConfigorationValues.PurchaseDateLaterThanCurrentDateError;
        }

        public static void SetPurchaseDateInSaturday(this RecordToPublish record)
        {
            var start = new DateTime(2000, 1, 1);
            var range = (DateTime.Today - start).Days;
            var date = start.AddDays(_random.Next(range));
            while ((int)date.DayOfWeek != 6)
            {
                date = start.AddDays(_random.Next(range));
            }

            record.PurchaseDate = date.ConvertByExpectedDateFormat();
            record.IsValid = false;
            record.WhyInvalid = ConfigorationValues.PurchaseDateWhenStoreIsCloseError;
        }

        public static void SetInvalidPricePerInstallment(this RecordToPublish record)
        {
            record.TotalPrice = _random.Next(5001, 10000);
            record.Installments = 1;
            record.IsValid = false;
            record.WhyInvalid = ConfigorationValues.PricePerInstallmentError;
        }

        public static void SetInvalidInstallments(this RecordToPublish record)
        {
            record.TotalPrice = _random.Next(5000);
            record.Installments = _random.Next(record.TotalPrice * 10 + 1, int.MaxValue);
            record.IsValid = false;
            record.WhyInvalid = ConfigorationValues.InstallmentsError;
        }

    }
}

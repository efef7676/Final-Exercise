using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Extensions
{
    public static class GeneralRecordExtensions
    {
        public static string ConvertToString(this List<RecordToPublish> records)
        {
            
            var finalString = string.Empty;
            foreach (var record in records)
            {
                var basicRecordInCSV = $"{record.StoreId},{record.CreditCard},{record.PurchaseDate},{record.TotalPrice}";

                if (record.Installments != null)
                {
                    basicRecordInCSV += $",{record.Installments}" + Environment.NewLine;
                }
                else
                {
                    basicRecordInCSV += Environment.NewLine;
                }

                finalString += basicRecordInCSV;
            }
            return finalString;
        }

        public static List<ReceivedRecord> ConvertToReceivedRecords(this List<RecordToPublish> records)
        {
            var receivedRecords = new List<ReceivedRecord>();
            foreach (var recordToPublish in records)
            {
                receivedRecords.Add(new ReceivedRecord(recordToPublish));
            }

            return receivedRecords;
        }

    }
}

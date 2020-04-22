using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class RetrievalFromDB
    {
        private MySqlConnection Connection { get; set; }

        public RetrievalFromDB(MySqlConnection connection)
        {
            Connection = connection;
        }

        public List<ReceivedRecord> GetRows(string storeIdValue = "")
        {
            string query;
            var receivedRecords = new List<ReceivedRecord>();
            Connection.Open();

            if (String.IsNullOrEmpty(storeIdValue))
            {
                query = "SELECT * FROM purchases";
            }
            else
            {
                query = $"SELECT * FROM purchases WHERE store_id='{storeIdValue}'";
            }

            var dataReader = new MySqlCommand(query, Connection).ExecuteReader();

            while (dataReader.Read())
            {
                var receivedRecord = new ReceivedRecord();

                receivedRecord.StoreId = dataReader["store_id"].ToString();
                receivedRecord.StoreType = char.Parse(dataReader["store_type"].ToString());
                receivedRecord.ActivityDays = char.Parse(dataReader["activity_days"].ToString());
                receivedRecord.CreditCard = dataReader["credit_card"].ToString();
                receivedRecord.PurchaseDate = DateTime.Parse(dataReader["purchase_date"].ToString());
                receivedRecord.InsertionDate = DateTime.Parse(dataReader["insertion_date"].ToString());
                receivedRecord.TotalPrice = double.Parse(dataReader["total_price"].ToString());
                receivedRecord.Installments = int.Parse(dataReader["installments"].ToString());
                receivedRecord.PricePerInstallment = double.Parse(dataReader["price_per_installment"].ToString());
                receivedRecord.IsValid = dataReader["is_valid"].ToString() == "1" ? true : false;
                receivedRecord.WhyInvalid = dataReader["why invalid"].ToString();

                receivedRecords.Add(receivedRecord);
            }

            Connection.Close();

            return receivedRecords;
        }
    }

}

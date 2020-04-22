using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Record
    {
        public string StoreId { get; set; }
        public string CreditCard { get; set; }
        public dynamic PurchaseDate { get; set; }
        public double TotalPrice { get; set; }
        public dynamic Installments { get; set; }

        public Record() { }

        public Record(string storeId, string creditCard, dynamic purchaseDate, double totalPrice, dynamic installments)
        {
            StoreId = storeId;
            CreditCard = creditCard;
            PurchaseDate = purchaseDate;
            TotalPrice = totalPrice;
            Installments = installments;
        }
    }
}

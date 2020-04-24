using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    public static class ConfigorationValues
    {
        public static string ConnectionStringDB = ConfigurationManager.AppSettings["CONNECTION_STRING_DB"];
        public static string QueueName = ConfigurationManager.AppSettings["QUEUE_NAME"];

        public static string ExpectedDateFormat = ConfigurationManager.AppSettings["EXPECTED_DATE_FORMAT"];
        public static string ExpectedPriceFormat = ConfigurationManager.AppSettings["EXPECTED_PRICE_FORMAT"];
        
        public static string CreditCardError = ConfigurationManager.AppSettings["CREDIT_CARD_ERROR"];
        public static string InstallmentsError = ConfigurationManager.AppSettings["INSTALLMENTS_ERROR"];
        public static string PurchaseDateWhenStoreIsCloseError = ConfigurationManager.AppSettings["PURCHASE_DATE_CLOSE_STORE_ERROR"];
        public static string PricePerInstallmentError = ConfigurationManager.AppSettings["PRICE_PER_INSTALLMENT_ERROR"];
        public static string PurchaseDateLaterThanCurrentDateError = ConfigurationManager.AppSettings["PURCHASE_DATE_LATER_THAN_NOW_ERROR"];        
    }
}

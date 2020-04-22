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
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Common;

namespace DAL
{
    public class ActionsInDB
    {
        public ManipulationInDB ManipulationInDB { get; set; }
        public RetrievalFromDB RetrievalFromDB { get; set; }

        public ActionsInDB()
        {
            var connection = new MySqlConnection(ConfigorationValues.ConnectionStringDB);
            ManipulationInDB = new ManipulationInDB(connection);
            RetrievalFromDB = new RetrievalFromDB(connection);
        }
    }
}

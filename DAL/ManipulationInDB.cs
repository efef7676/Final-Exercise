using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ManipulationInDB
    {
        private MySqlConnection Connection { get; set; }

        public ManipulationInDB(MySqlConnection connection)
        {
            Connection = connection;
        }

        public void DeleteAllRows()
        {
            Connection.Open();
            var query = "DELETE FROM purchases";
            var cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}

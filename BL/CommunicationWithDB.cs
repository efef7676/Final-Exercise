using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Common;

namespace BL
{
    public class CommunicationWithDB
    {
        private ActionsInDB ActionsInDB { get; set; }
        public bool isEmptyTable() => ActionsInDB.RetrievalFromDB.GetRows().Count == 0;

        public CommunicationWithDB()
        {
            ActionsInDB = new ActionsInDB();
        }

        public void DeleteFromDB()
        {
            ActionsInDB.ManipulationInDB.DeleteAllRows();
        }

        public List<ReceivedRecord> GetFromDB(string storeIdValue = "")
        {
            return ActionsInDB.RetrievalFromDB.GetRows(storeIdValue);
        }

        
    }
}

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
        public void OpenConnection() => ActionsInDB.OpenConnection();
        public void CloseConnection() => ActionsInDB.CloseConnection();
        public void WaitUntilNRowsInDB(int expectedNumberOfRows) => ActionsInDB.WaitUntilAmountOfRowsIsUpdate(expectedNumberOfRows);

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

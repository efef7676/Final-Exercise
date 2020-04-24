using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using System.Collections.Generic;
using Common;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        protected CommunicationWithDB _actionsInDB;
        protected CommunicationWithRabbitMQ _rabbitMq;
        protected List<RecordToPublish> _recordsToPublish;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            _actionsInDB = new CommunicationWithDB();
            _rabbitMq = new CommunicationWithRabbitMQ();
            _recordsToPublish = new List<RecordToPublish>();
            _actionsInDB.OpenConnection();
            _actionsInDB.DeleteFromDB();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _actionsInDB.CloseConnection();
        }
    }
}

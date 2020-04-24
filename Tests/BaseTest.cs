using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using System.Collections.Generic;
using Common;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        private Process _process;
        protected CommunicationWithDB _actionsInDB;
        protected CommunicationWithRabbitMQ _rabbitMq;
        protected List<RecordToPublish> _recordsToPublish;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WorkingDirectory = @"C:\JAR",
                Arguments = "/c java -jar PurchasesPipeline_1.0.1.jar"
            };

            _process = new Process { StartInfo = startInfo };
            _process.Start();

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
            _process.CloseMainWindow();
        }
    }
}

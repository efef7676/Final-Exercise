using System;
using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Extensions;
using Common;
using System.Collections.Generic;
using FluentAssertions;
using System.Threading;
using Assertions;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class SanityTests
    {
        private CommunicationWithDB _actionsInDB;
        private CommunicationWithRabbitMQ _rabbitMq;
        private Random _random = new Random();
        [TestInitialize]
        public void TestInitialize()
        {
            _actionsInDB = new CommunicationWithDB();
            _rabbitMq = new CommunicationWithRabbitMQ();
            _actionsInDB.DeleteFromDB();
        }

        [TestMethod]
        public void SendOneValidRecord_AddedSuccessfullyToDBAsValid()
        {
            var recordsToPublish = new List<RecordToPublish>() { new RecordToPublish(true) };
            _rabbitMq.PublishMessage(recordsToPublish.ConvertToString());

            Thread.Sleep(3000);//think of a way to refresh or wait until change is over

            _actionsInDB.GetFromDB()
                .Should()
                .ExistInDBWithAllDetails(recordsToPublish);
        }

        [TestMethod]
        public void SendFewValidRecords_AddedSuccessfullyToDBAsValid()
        {
            var recordsToPublish = _rabbitMq.CreateNValidRecordsToPublish(3);
            _rabbitMq.PublishMessage(recordsToPublish.ConvertToString());

            Thread.Sleep(5000);//think of a way to refresh or wait until change is over

            _actionsInDB.GetFromDB()
                .Should()
                .ExistInDBWithAllDetails(recordsToPublish);
        }

        [TestMethod]
        public void SendSameValidRecords_AddedSuccessfullyToDBAsValid()
        {
            var recordToPublish = new RecordToPublish(true);
            var recordsToPublish = new List<RecordToPublish>() { recordToPublish, recordToPublish };

            _rabbitMq.PublishMessage(recordsToPublish.ConvertToString());

            Thread.Sleep(5000);//think of a way to refresh or wait until change is over

            _actionsInDB.GetFromDB()
                .Should()
                .ExistInDBWithAllDetails(recordsToPublish);
        }

        [TestMethod]
        public void ValidRecordAndImpossibleRecord_ValidRecordAddedSuccessfullyToDB()
        {
            var validRecord = new List<RecordToPublish>() { new RecordToPublish(true) };
            var impossibleRecord = new List<RecordToPublish>() { new RecordToPublish().SetAsImpossibleRecord() };
            var bothRecords = validRecord.Concat(impossibleRecord).ToList();

            _rabbitMq.PublishMessage(bothRecords.ConvertToString());

            Thread.Sleep(5000);//think of a way to refresh or wait until change is over

            _actionsInDB.GetFromDB()
                .Should()
                .ExistInDBWithAllDetails(validRecord);
        }
    }
}

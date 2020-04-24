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
    public class ValidRecordTests : BaseTest
    {
        [TestMethod]
        public void SendOneValidRecord_MoreThanOneInstallment_AddedSuccessfullyToDBAsValid()
        {
            _recordsToPublish.Add(new RecordToPublish(false));
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(_recordsToPublish.Count);

            _actionsInDB.GetFromDB()
                .Should()
                .BeInDB(_recordsToPublish);
        }

        [TestMethod]
        public void SendOneValidRecord_OneInstallment_AddedSuccessfullyToDBAsValid()
        {
            _recordsToPublish.Add(new RecordToPublish());
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(_recordsToPublish.Count);

            _actionsInDB.GetFromDB()
                .Should()
                .BeInDB(_recordsToPublish);
        }
        [TestMethod]
        public void SendFewValidRecords_AddedSuccessfullyToDBAsValid()
        {
            _recordsToPublish.AddRange(RecordToPublish.CreateNValidRecordsToPublish(3));

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(_recordsToPublish.Count);

            _actionsInDB.GetFromDB()
                .Should()
                .BeInDB(_recordsToPublish);
        }

        [TestMethod]
        public void SendSameValidRecords_AddedSuccessfullyToDBAsValid()
        {
            var recordToPublish = new RecordToPublish();
            _recordsToPublish.AddMany(recordToPublish, recordToPublish);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _actionsInDB.WaitUntilNRowsInDB(_recordsToPublish.Count);

            _actionsInDB.GetFromDB()
                .Should()
                .BeInDB(_recordsToPublish);
        }

        [TestMethod]
        public void ValidRecordAndImpossibleRecord_ValidRecordAddedSuccessfullyToDB()
        {
            var validRecord = new RecordToPublish();
            var impossibleRecord = new RecordToPublish().SetAsImpossibleRecord();
            _recordsToPublish.AddMany(validRecord, impossibleRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _actionsInDB.WaitUntilNRowsInDB(1);

            _actionsInDB.GetFromDB()
                .Should()
                .BeInDB(new List<RecordToPublish>() { validRecord });
        }
    }
}

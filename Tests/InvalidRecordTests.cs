using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System.Collections.Generic;
using Extensions;
using Assertions;

namespace Tests
{
    [TestClass]
    public class InvalidRecordTests : BaseTest
    {
        private RecordToPublish _baseRecord;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _baseRecord = new RecordToPublish();
        }

        [TestMethod]
        public void SendRecord_InvalidCreditCard_AddedsuccessfullyToDBAsInvalid()
        {
            _baseRecord.SetInvalidCreditCard();
            _recordsToPublish.Add(_baseRecord);
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(_recordsToPublish.Count);

            _actionsInDB.GetFromDB()
                .Should()
                .BeInDB(_recordsToPublish);
        }//Dont run this test!! - it will chrash the code

        [TestMethod]
        public void SendRecord_InvalidInstallments_AddedsuccessfullyToDBAsInvalid()
        {
            _baseRecord.SetInvalidInstallments();
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(_recordsToPublish.Count);

            _actionsInDB.GetFromDB()
                .Should()
                .BeInDB(_recordsToPublish);
        }

        [TestMethod]
        public void SendRecord_PurchaseDateIsWhenStoreIsClose_AddedsuccessfullyToDBAsInvalid()
        {
            _baseRecord.SetActivityDays('B');
            _baseRecord.SetPurchaseDateInSaturday();
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(_recordsToPublish.Count);

            _actionsInDB.GetFromDB()
                .Should()
                .BeInDB(_recordsToPublish);
        }

        [TestMethod]
        public void SendRecord_PurchaseDateIsLaterThanTheCurrentDate_AddedsuccessfullyToDBAsInvalid()
        {
            _baseRecord.SetPurchaseDateLaterThanCurrentDate();
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(_recordsToPublish.Count);

            _actionsInDB.GetFromDB()
                .Should()
                .BeInDB(_recordsToPublish);
        }

        [TestMethod]
        public void SendRecord_InvalidPricePerInstallment_AddedsuccessfullyToDBAsInvalid()
        {
            _baseRecord.SetInvalidPricePerInstallment();
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(_recordsToPublish.Count);

            _actionsInDB.GetFromDB()
                .Should()
                .BeInDB(_recordsToPublish);
        }
    }
}

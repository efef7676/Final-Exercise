using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using Extensions;
using Assertions;
using System.Collections.Generic;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class ImpossibleRecordTests : BaseTest
    {
        private RecordToPublish _baseRecord;
        private RecordToPublish _validRecordForReview;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _recordsToPublish.Add(new RecordToPublish());
            _baseRecord = new RecordToPublish();
        }

        [TestMethod]
        public void SendRecord_PurchaseDateInUnexpectedFormat_WillNotAddToDB()
        {
            _baseRecord.SetPurchaseDateInUnexpectedFormat("dd-MM-yyyy");
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(1);

            _actionsInDB.GetFromDB()
                .Should()
                .NotContains(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_ImpossiblePurchaseDate_WillNotAddToDB(string dateFormat)
        {
            _baseRecord.SetImpossiblePurchaseDate();
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(1);

            _actionsInDB.GetFromDB()
                .Should()
                .NotContains(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_ImpossibleStoreId_WillNotAddToDB()
        {
            _baseRecord.SetInvalidStoreID();
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(1);

            _actionsInDB.GetFromDB()
                .Should()
                .NotContains(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_ImpossiblePrice_WillNotAddToDB()
        {
            _baseRecord.SetImpossibleTotalPrice();
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(1);

            _actionsInDB.GetFromDB()
                 .Should()
                 .NotContains(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_ImpossibleInstallments_WillNotAddToDB()
        {
            _baseRecord.SetImpossibleInstallments();
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(1);

            _actionsInDB.GetFromDB()
                 .Should()
                 .NotContains(_baseRecord);
        }
        
    }
}

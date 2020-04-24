using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using Extensions;
using Assertions;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class RequiredFieldIsEmptyTests : BaseTest
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
        public void SendRecord_WithEmptyCreditCard_WontBeInDB()
        {
            _baseRecord.CreditCard = String.Empty;
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(1);

            _actionsInDB.GetFromDB()
               .Should()
               .NotContains(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_WithEmptyStoreId_WontBeInDB()
        {
            _baseRecord.StoreId = String.Empty;
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(1);

            _actionsInDB.GetFromDB()
                .Should()
                .NotContains(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_WithEmptyPurchaseDate_WontBeInDB()
        {
            _baseRecord.PurchaseDate = String.Empty;
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(1);

            _actionsInDB.GetFromDB()
                .Should()
                .NotContains(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_WithEmptyPrice_WontBeInDB()
        {
            _baseRecord.TotalPrice = String.Empty;
            _recordsToPublish.Add(_baseRecord);

            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());

            _actionsInDB.WaitUntilNRowsInDB(1);

            _actionsInDB.GetFromDB()
                .Should()
                .NotContains(_baseRecord);
        }
    }
}

using FluentAssertions;
using FluentAssertions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Extensions;

namespace Assertions
{
    public class ReceivedRecordsAssertions : ObjectAssertions
    {
        private List<ReceivedRecord> ReceivedRecords => Subject as List<ReceivedRecord>;
        protected override string Identifier => "ReceivedRecordsAssertions";

        public ReceivedRecordsAssertions(List<ReceivedRecord> value) : base(value)
        {
        }


        [CustomAssertion]
        public AndConstraint<ReceivedRecordsAssertions> ExistInDBWithAllDetails(List<RecordToPublish> sentRecords)
        {
            ReceivedRecords
                .Should()
                .BeEquivalentTo(sentRecords.ConvertToReceivedRecords());
            return new AndConstraint<ReceivedRecordsAssertions>(this);
        }

    }
}

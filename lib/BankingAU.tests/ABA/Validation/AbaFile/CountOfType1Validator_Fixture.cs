using Banking.AU.ABA.Validation.AbaFile;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.ABA.Validation.AbaFile
{
    [TestFixture]
    public class CountOfType1Validator_Fixture
    {
        [Test]
        public void Zero_records()
        {
            var file = new AU.ABA.AbaFile();
            var errors = new List<Exception>(new CountOfType1Validator().Validate(file));
            Assert.IsNotNull(errors.Find(e => "Must have at least one detail record".Equals(e.Message)));
        }

        [Test]
        public void One_record()
        {
            var file = new AU.ABA.AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord());
            file.FileTotalRecord.CountOfType1 = 1;

            var errors = new List<Exception>(new CountOfType1Validator().Validate(file));
            Assert.AreEqual(0, errors.Count);
        }

        [Test]
        public void One_million_records()
        {
            var file = new AU.ABA.AbaFile();
            for (int i = 0; i < 1000000; i++)
                file.DetailRecords.Add(new AU.ABA.Records.DetailRecord());
            file.FileTotalRecord.CountOfType1 = 1000000;

            var errors = new List<Exception>(new CountOfType1Validator().Validate(file));
            Assert.IsNotNull(errors.Find(e => "Count of detail records cannot exceed 1,000,000".Equals(e.Message)));
        }

        [Test]
        public void FileTotalRecord_mismatch()
        {
            var file = new AU.ABA.AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord());
            file.FileTotalRecord.CountOfType1 = 2;

            var errors = new List<Exception>(new CountOfType1Validator().Validate(file));
            Assert.IsNotNull(errors.Find(e => "CountOfType1 is does not match count of detail records".Equals(e.Message)));
        }

        [Test]
        public void CanAdd_successfully()
        {
            var file = new AU.ABA.AbaFile();
            Assert.AreEqual(true, new CountOfType1Validator().CanAdd(file, new AU.ABA.Records.DetailRecord()));
        }

        [Test]
        public void CanAdd_unsuccessfully()
        {
            var file = new AU.ABA.AbaFile();
            for (int i = 0; i < 999999; i++)
                file.DetailRecords.Add(new AU.ABA.Records.DetailRecord());
            Assert.AreEqual(false, new CountOfType1Validator().CanAdd(file, new AU.ABA.Records.DetailRecord()));
        }
    }
}

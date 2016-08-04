using Banking.AU.ABA.Validation.AbaFile;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using R = Banking.AU.ABA;

namespace Banking.AU.tests.ABA.Validation.AbaFile
{
    [TestFixture]
    public class FileTotalValidator_Fixture
    {
        [Test]
        public void Clean_valid()
        {
            var file = new R.AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 1m, TransactionCode = AU.ABA.Records.TransactionCode.DebitItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 2m, TransactionCode = AU.ABA.Records.TransactionCode.DebitItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 4m, TransactionCode = AU.ABA.Records.TransactionCode.CreditItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 8m, TransactionCode = AU.ABA.Records.TransactionCode.CreditItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 16m, TransactionCode = AU.ABA.Records.TransactionCode.Allotment });
            new FileTotalValidator().Clean(file);
            Assert.AreEqual(3m, file.FileTotalRecord.DebitTotalAmount);
            Assert.AreEqual(12m, file.FileTotalRecord.CreditTotalAmount);
            Assert.AreEqual(9m, file.FileTotalRecord.NetTotalAmount);
            Assert.AreEqual(5, file.FileTotalRecord.CountOfType1);
        }

        [Test]
        public void Validate_no_FileTotalRecord()
        {
            var file = new R.AbaFile();
            file.FileTotalRecord = null;
            var errors = new List<Exception>(new FileTotalValidator().Validate(file));
            Assert.IsNotNull(errors.Find(e => "FileTotalRecord must be provided".Equals(e.Message)));
        }

        [Test]
        public void Validate_FileTotalRecord()
        {
            var file = new R.AbaFile();
            var errors = new List<Exception>(new FileTotalValidator().Validate(file));
            Assert.IsNull(errors.Find(e => "FileTotalRecord must be provided".Equals(e.Message)));
        }
    }
}

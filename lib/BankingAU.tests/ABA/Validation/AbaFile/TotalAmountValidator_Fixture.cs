using Banking.AU.ABA.Validation.AbaFile;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using R = Banking.AU.ABA;

namespace Banking.AU.tests.ABA.Validation.AbaFile
{
    [TestFixture]
    public class TotalAmountValidator_Fixture
    {
        [Test]
        public void Clean_NetTotalAmount()
        {
            var file = new R.AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 20m, TransactionCode = AU.ABA.Records.TransactionCode.DebitItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 50m, TransactionCode = AU.ABA.Records.TransactionCode.CreditItem });
            new NetTotalAmountValidator().Clean(file);
            Assert.AreEqual(30m, file.FileTotalRecord.NetTotalAmount);
        }

        [Test]
        public void Clean_CreditTotalAmount()
        {
            var file = new R.AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 10m, TransactionCode = AU.ABA.Records.TransactionCode.DebitItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 20m, TransactionCode = AU.ABA.Records.TransactionCode.CreditItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 50m, TransactionCode = AU.ABA.Records.TransactionCode.CreditItem });
            new CreditTotalAmountValidator().Clean(file);
            Assert.AreEqual(70m, file.FileTotalRecord.CreditTotalAmount);
        }

        [Test]
        public void Clean_DebitTotalAmount()
        {
            var file = new R.AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 10m, TransactionCode = AU.ABA.Records.TransactionCode.CreditItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 20m, TransactionCode = AU.ABA.Records.TransactionCode.DebitItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 50m, TransactionCode = AU.ABA.Records.TransactionCode.DebitItem });
            new DebitTotalAmountValidator().Clean(file);
            Assert.AreEqual(70m, file.FileTotalRecord.DebitTotalAmount);
        }

        [Test]
        public void FileTotalRecord_match()
        {
            var file = new R.AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 20m, TransactionCode = AU.ABA.Records.TransactionCode.DebitItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 50m, TransactionCode = AU.ABA.Records.TransactionCode.DebitItem });
            file.FileTotalRecord.DebitTotalAmount = 70m;
            var errors = new List<Exception>(new DebitTotalAmountValidator().Validate(file));
            Assert.IsNull(errors.Find(e => "DebitTotalAmount does not match sum of detail records".Equals(e.Message)));
        }

        [Test]
        public void FileTotalRecord_mismatch()
        {
            var file = new R.AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 20m, TransactionCode = AU.ABA.Records.TransactionCode.DebitItem });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { Amount = 50m, TransactionCode = AU.ABA.Records.TransactionCode.DebitItem });
            file.FileTotalRecord.DebitTotalAmount = 10m;
            var errors = new List<Exception>(new DebitTotalAmountValidator().Validate(file));
            Assert.IsNotNull(errors.Find(e => "DebitTotalAmount does not match sum of detail records".Equals(e.Message)));
        }

        [Test]
        public void DebitTotalAmount_bounds_valid()
        {
            // whilst bounds checking for CurrencyValidator is tested, this specific validation subclass upper limit has not been tested
            var file = new R.AbaFile();
            var v = new DebitTotalAmountValidator();
            file.FileTotalRecord.DebitTotalAmount = 99999999.00m;
            var errors = new List<Exception>(v.Validate(file));
            Assert.IsNull(errors.Find(e => "Value must be less than $100,000,000.00".Equals(e.Message)));

            file.FileTotalRecord.DebitTotalAmount = 100000000.00m;
            errors = new List<Exception>(v.Validate(file));
            Assert.IsNotNull(errors.Find(e => "Value must be less than $100,000,000.00".Equals(e.Message)));
        }

        [Test]
        public void CreditTotalAmount_bounds_valid()
        {
            // whilst bounds checking for CurrencyValidator is tested, this specific validation subclass upper limit has not been tested
            var file = new R.AbaFile();
            var v = new CreditTotalAmountValidator();
            file.FileTotalRecord.CreditTotalAmount = 99999999.00m;
            var errors = new List<Exception>(v.Validate(file));
            Assert.IsNull(errors.Find(e => "Value must be less than $100,000,000.00".Equals(e.Message)));

            file.FileTotalRecord.CreditTotalAmount = 100000000.00m;
            errors = new List<Exception>(v.Validate(file));
            Assert.IsNotNull(errors.Find(e => "Value must be less than $100,000,000.00".Equals(e.Message)));
        }

        [Test]
        public void NetTotalAmount_bounds_valid()
        {
            // whilst bounds checking for CurrencyValidator is tested, this specific validation subclass upper limit has not been tested
            var file = new R.AbaFile();
            var v = new NetTotalAmountValidator();
            file.FileTotalRecord.NetTotalAmount = 99999999.00m;
            var errors = new List<Exception>(v.Validate(file));
            Assert.IsNull(errors.Find(e => "Value must be less than $100,000,000.00".Equals(e.Message)));

            file.FileTotalRecord.NetTotalAmount = 100000000.00m;
            errors = new List<Exception>(v.Validate(file));
            Assert.IsNotNull(errors.Find(e => "Value must be less than $100,000,000.00".Equals(e.Message)));
        }
    }
}

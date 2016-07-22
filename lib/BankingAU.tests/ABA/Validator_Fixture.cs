using Banking.AU.ABA;
using Banking.AU.Common.Validation;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.ABA
{
    [TestFixture]
    public class Validator_Fixture
    {
        [Test]
        public void Has_record_type_7()
        {
            // Arrange
            var file = new AbaFile();
            file.FileTotalRecord = null;

            // Act
            var errors = new Validator().Validate(file);

            // Assert
            Assert.IsTrue(errors.Contains(new ValidationError<AbaFile>(file, "FileTotalRecord", string.Empty)));
        }

        [Test]
        public void FileTotalRecord_bsb_valid()
        {
            // Arrange
            var validator = new Validator();
            var file = new AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord());

            // Act
            var errors1 = validator.Validate(file);
            file.FileTotalRecord.Bsb = "123-456";
            var errors2 = validator.Validate(file);

            // Assert
            var bsb = new FormatError<AbaFile>(file, "FileTotalRecord.Bsb", "999-999");
            Assert.IsTrue(!errors1.Contains(bsb));
            Assert.IsTrue(errors2.Contains(bsb));
        }

        [Test]
        public void GenerateTotalRecord_total_is_debit_credit_diff()
        {
            // Arrange
            var validator = new Validator();
            var file = new AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.CreditItem, Amount = 50.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.CreditItem, Amount = 50.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.DebitItem, Amount = 10.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.DebitItem, Amount = 10.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.Pay, Amount = 20.00m });
            file.FileTotalRecord = file.GenerateTotalRecord();

            // Act
            var errors = validator.Validate(file);

            // Assert
            var total = new ValidationError<AbaFile>(file, "FileTotalRecord.NetTotalAmount", string.Empty);
            Assert.IsTrue(!errors.Contains(total));
            Assert.AreEqual(80.00m, file.FileTotalRecord.NetTotalAmount);
            Assert.AreEqual(100.00m, file.FileTotalRecord.CreditTotalAmount);
            Assert.AreEqual(20.00m, file.FileTotalRecord.DebitTotalAmount);
        }

        [Test]
        public void GenerateTotalRecord_total_is_not_truncated()
        {
            // Arrange
            var validator = new Validator();
            var file = new AbaFile();
            file.FileTotalRecord.NetTotalAmount = 999999999.99m;

            // Act
            var errors = validator.Validate(file);

            // Assert
            Assert.IsTrue(errors.Contains(new TruncationError<AbaFile>(file, "FileTotalRecord.NetTotalAmount")));
        }
    }
}

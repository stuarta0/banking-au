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
            Assert.IsTrue(errors.Contains(new ValidationError<AbaFile>(file, "FileTotalRecord", "FileTotalRecord must be provided.")));
        }

        [Test]
        public void FileTotalRecord_bsb_valid()
        {
            // TODO: use validator specifically for FileTotalRecord

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
        public void FileTotalRecord_SumOfCount1_validation()
        {
            // Arrange
            var validator = new Validator();
            var file = new AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord());
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord());
            file.FileTotalRecord = new AU.ABA.Records.FileTotalRecord()
            {
                CountOfType1 = 0
            };

            // Act
            var errors = validator.Validate(file);

            // Assert
            var sum = new ValidationError<AbaFile>(file, "FileTotalRecord", "SumOfCount1 does not equal the total number of DetailRecords.");
            Assert.IsTrue(errors.Contains(sum));
        }

        [Test]
        public void FileTotalRecord_sum_validation()
        {
            // Arrange
            var validator = new Validator();
            var file = new AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.CreditItem, Amount = 50.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.CreditItem, Amount = 50.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.DebitItem, Amount = 10.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.DebitItem, Amount = 10.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.Pay, Amount = 20.00m });
            file.FileTotalRecord = new AU.ABA.Records.FileTotalRecord()
            {
                CreditTotalAmount = 10.00m,
                DebitTotalAmount = 10.00m,
                NetTotalAmount = 50.00m
            };

            // Act
            var errors = validator.Validate(file);
            
            // Assert
            Assert.IsTrue(errors.Contains(new ValidationError<AbaFile>(file, "FileTotalRecord", "DebitTotalAmount does not match sum of all DebitItems.")));
            Assert.IsTrue(errors.Contains(new ValidationError<AbaFile>(file, "FileTotalRecord", "CreditTotalAmount does not match sum of all CreditItems.")));
            Assert.IsTrue(errors.Contains(new ValidationError<AbaFile>(file, "FileTotalRecord", "NetTotalAmount does not match the difference of credit and debit items.")));
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

            // Act
            file.FileTotalRecord = file.GenerateTotalRecord();

            // Assert
            Assert.AreEqual(80.00m, file.FileTotalRecord.NetTotalAmount);
            Assert.AreEqual(100.00m, file.FileTotalRecord.CreditTotalAmount);
            Assert.AreEqual(20.00m, file.FileTotalRecord.DebitTotalAmount);
        }

        [Test]
        public void FileTotalRecord_total_is_not_truncated()
        {
            // TODO: use validator specifically for FileTotalRecord

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

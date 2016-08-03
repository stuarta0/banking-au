using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.ABA.Validation.AbaFile
{
    [TestFixture]
    public class TotalAmountValidator_Fixture
    {
        //[Test]
        //public void FileTotalRecord_sum_validation()
        //{
        //    // Arrange
        //    var validator = new Validator();
        //    var file = new AbaFile();
        //    file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.CreditItem, Amount = 50.00m });
        //    file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.CreditItem, Amount = 50.00m });
        //    file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.DebitItem, Amount = 10.00m });
        //    file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.DebitItem, Amount = 10.00m });
        //    file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.Pay, Amount = 20.00m });
        //    file.FileTotalRecord = new AU.ABA.Records.FileTotalRecord()
        //    {
        //        CreditTotalAmount = 10.00m,
        //        DebitTotalAmount = 10.00m,
        //        NetTotalAmount = 50.00m
        //    };

        //    // Act
        //    var errors = validator.Validate(file);

        //    // Assert
        //    Assert.IsTrue(errors.Contains(new ValidationError<AbaFile>(file, "FileTotalRecord", "DebitTotalAmount does not match sum of all DebitItems.")));
        //    Assert.IsTrue(errors.Contains(new ValidationError<AbaFile>(file, "FileTotalRecord", "CreditTotalAmount does not match sum of all CreditItems.")));
        //    Assert.IsTrue(errors.Contains(new ValidationError<AbaFile>(file, "FileTotalRecord", "NetTotalAmount does not match the difference of credit and debit items.")));
        //}

        //[Test]
        //public void FileTotalRecord_total_is_not_truncated()
        //{
        //    // TODO: use validator specifically for FileTotalRecord

        //    // Arrange
        //    var validator = new Validator();
        //    var file = new AbaFile();
        //    file.FileTotalRecord.NetTotalAmount = 999999999.99m;

        //    // Act
        //    var errors = validator.Validate(file);

        //    // Assert
        //    Assert.IsTrue(errors.Contains(new TruncationError<AbaFile>(file, "FileTotalRecord.NetTotalAmount")));
        //}
    }
}

using Banking.AU.ABA;
using NUnit.Framework;

namespace Banking.AU.tests.ABA
{
    [TestFixture]
    public class AbaFile_Fixture
    {
        [Test]
        public void GenerateTotalRecord_total_is_debit_credit_diff()
        {
            // Arrange
            var file = new AbaFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.CreditItem, Amount = 50.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.CreditItem, Amount = 50.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.DebitItem, Amount = 10.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.DebitItem, Amount = 10.00m });
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord() { TransactionCode = AU.ABA.Records.TransactionCode.Pay, Amount = 20.00m });

            // Act
            file.GenerateTotalRecord();

            // Assert
            Assert.AreEqual(80.00m, file.FileTotalRecord.NetTotalAmount);
            Assert.AreEqual(100.00m, file.FileTotalRecord.CreditTotalAmount);
            Assert.AreEqual(20.00m, file.FileTotalRecord.DebitTotalAmount);
        }
    }
}

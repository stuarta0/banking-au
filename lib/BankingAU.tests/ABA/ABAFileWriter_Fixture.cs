using Banking.AU.ABA;
using Banking.AU.ABA.Records;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Banking.AU.tests.ABA
{
	[TestFixture]
    public class ABAFileWriter_Fixture
    {
		[Test]
		public void Write_vanilla_stream()
        {
			// Arrange
            var io = new ABAFileWriter();
            var file = new ABAFile();
            file.DetailRecords.Add(new AU.ABA.Records.DetailRecord());
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };

			// Act
            io.Write(writer, file);

			// Assert
            Assert.Greater(stream.Length, 0);
            var reader = new StreamReader(stream);
            stream.Position = 0;
            var line = reader.ReadLine();
            Assert.AreEqual(120, line.Length);
            line = reader.ReadLine();
            Assert.AreEqual(120, line.Length);
            line = reader.ReadLine();
            Assert.AreEqual(120, line.Length);
            Assert.IsNull(reader.ReadLine());
            stream.Dispose();
        }

        [Test]
        public void Write_detailed_stream()
        {
            // Arrange
            var io = new ABAFileWriter();
            var file = new ABAFile();
            file.DescriptiveRecord = new DescriptiveRecord()
            {
				ReelSequenceNumber = 1,
				FinancialInstitution = "WBC",
				UserSpecification = "John Citizen",
				UserIdentificationNumber = 1234,
				EntryDescriptor = "PAYROLL",
				ProcessDate = new DateTime(2015, 7, 30)
            };
            file.DetailRecords.Add(new DetailRecord()
            {
				BSB = "000-000",
				AccountNumber = "00-1234",
				Indicator = Indicator.NewOrVaried,
				TransactionCode = TransactionCode.CreditItem,
				Amount = 1234.56m,
				TargetAccountTitle = "Citizen. John Michael",
				LodgementReference = "5550033890123456",
				TraceRecordBSB = "999-999",
				TraceRecordAccountNumber = "43-2100",
				RemitterName = "COMMBANK",
				WithholdingTaxAmount = 123.40m
            });
            file.FileTotalRecord = new FileTotalRecord()
            {
				BSB = "999-999",
				NetTotalAmount = 1234.56m,
				CreditTotalAmount = 1234.56m,
				DebitTotalAmount = 0m,
				CountOfType1 = 1
            };
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };

            // Act
            io.Write(writer, file);

            // Assert
            Assert.Greater(stream.Length, 0);
            var reader = new StreamReader(stream);
            stream.Position = 0;
            var line = reader.ReadLine();
            Assert.AreEqual("0                 01WBC       John Citizen              001234PAYROLL     300715                                        ", line);
            line = reader.ReadLine();
            Assert.AreEqual("1000-000  00-1234N500000123456Citizen. John Michael           5550033890123456  999-999  43-2100COMMBANK        00012340", line);
            line = reader.ReadLine();
            Assert.AreEqual("7999-999            000012345600001234560000000000                        000001                                        ", line);
            Assert.IsNull(reader.ReadLine());
            stream.Dispose();
        }
    }
}

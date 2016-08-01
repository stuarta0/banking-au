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
    public class AbaFileIO_Fixture
    {
		[Test]
		public void Write_vanilla_stream()
        {
			// Arrange
            var io = new AbaFileIO();
            var file = new AbaFile();
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
            var io = new AbaFileIO();
            var file = new AbaFile();
            file.DescriptiveRecord = new DescriptiveRecord()
            {
				ReelSequenceNumber = 1,
				FinancialInstitution = "WBC",
				UserPreferredName = "John Citizen",
				UserIdentificationNumber = 1234,
				EntryDescriptor = "PAYROLL",
				ProcessDate = new DateTime(2015, 7, 30)
            };
            file.DetailRecords.Add(new DetailRecord()
            {
				Bsb = "000-000",
				AccountNumber = "00-1234",
				Indicator = Indicator.NewOrVaried,
				TransactionCode = TransactionCode.CreditItem,
				Amount = 1234.56m,
				TargetAccountTitle = "Citizen. John Michael",
				LodgementReference = "5550033890123456",
				TraceRecordBsb = "999-999",
				TraceRecordAccountNumber = "43-2100",
				RemitterName = "COMMBANK",
				WithholdingTaxAmount = 123.40m
            });
            file.FileTotalRecord = new FileTotalRecord()
            {
				// Bsb = "999-999",
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

		[Test]
		public void Read_detailed_stream()
        {
			// Arrange
            var data = new StringBuilder();
			data.AppendLine("0                 01WBC       John Citizen              001234PAYROLL     300715                                        ");
			data.AppendLine("1000-000  00-1234N500000123456Citizen. John Michael           5550033890123456  999-999  43-2100COMMBANK        00012340");
            data.AppendLine("7999-999            000012345600001234560000000000                        000001                                        ");
            var io = new AbaFileIO();
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };
            writer.Write(data.ToString());
            stream.Position = 0;
            var reader = new StreamReader(stream);

			// Act
            var file = io.Read(reader);

			// Assert
            Assert.IsNotNull(file);
            Assert.IsNotNull(file.DescriptiveRecord);
            Assert.IsNotNull(file.DetailRecords);
            Assert.AreEqual(1, file.DetailRecords.Count);
            Assert.IsNotNull(file.FileTotalRecord);
        }

		[Test]
		public void Read_detailed_file()
		{
			// Arrange
            var io = new AbaFileIO();
            var data = new StringBuilder();
            data.AppendLine("0                 01WBC       John Citizen              001234PAYROLL     300715                                        ");
            data.AppendLine("1000-000  00-1234N500000123456Citizen. John Michael           5550033890123456  999-999  43-2100COMMBANK        00012340");
            data.AppendLine("7999-999            000012345600001234560000000000                        000001                                        ");
			var path = Path.GetTempFileName();
            using (var stream = File.CreateText(path))
                stream.Write(data.ToString());

			// Act
            var file = io.Read(path);
			
            // Assert
            Assert.IsNotNull(file);
            Assert.IsNotNull(file.DescriptiveRecord);
            Assert.IsNotNull(file.DetailRecords);
            Assert.AreEqual(1, file.DetailRecords.Count);
            Assert.IsNotNull(file.FileTotalRecord);
            File.Delete(path);
        }
    }
}

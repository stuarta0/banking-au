using Banking.AU.Westpac.QuickSuper;
using FileHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Banking.AU.tests.Westpac
{
    [TestFixture]
    public class QuickSuperFile_Fixture
    {
        [Test]
        public void Write_stream()
        {
            // Arrange
            var io = new ContributionFileIO();
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };
            var file = new ContributionFile(new[]
            {
                QuickSuperValidator_Fixture.CreateValidRecord(),
                QuickSuperValidator_Fixture.CreateValidRecord(),
                QuickSuperValidator_Fixture.CreateValidRecord()
            });

            // Act
            io.Write(writer, file);

            // Assert
            Assert.IsTrue(writer.BaseStream.Length > 0);
            stream.Dispose();
        }

        [Test]
        public void Write_file()
        {
            // Arrange
            var io = new ContributionFileIO();
            var path = Path.GetTempFileName();
            var file = new ContributionFile(new[]
            {
                QuickSuperValidator_Fixture.CreateValidRecord(),
                QuickSuperValidator_Fixture.CreateValidRecord(),
                QuickSuperValidator_Fixture.CreateValidRecord()
            });

            // Act
            io.Write(path, file);

            // Assert
            Assert.IsTrue(File.Exists(path));
            var fi = new FileInfo(path);
            Assert.IsTrue(fi.Length > 0);
            fi.Delete();
        }

        [Test]
        public void Read_stream()
        {
            // Arrange
            var io = new ContributionFileIO();
            var stream = new MemoryStream();
            new StreamWriter(stream) { AutoFlush = true }.Write(
@"YourFileReference,YourFileDate,ContributionPeriodStartDate,ContributionPeriodEndDate,EmployerID,PayrollID,NameTitle,FamilyName,GivenName,OtherGivenName,NameSuffix,DateOfBirth,Gender,TaxFileNumber,PhoneNumber,MobileNumber,EmailAddress,AddressLine1,AddressLine2,AddressLine3,AddressLine4,Suburb,State,PostCode,Country,EmploymentStartDate,EmploymentEndDate,EmploymentEndReason,FundID,FundName,FundEmployerID,MemberID,EmployerSuperGuaranteeAmount,EmployerAdditionalAmount,MemberSalarySacrificeAmount,MemberAdditionalAmount,OtherContributorType,OtherContributorName,YourContributionReference
,,08-Jul-15,06-Sep-15,,,,Citizen,John,,,07-Aug-85,,,,,,,,,,,,,,,,,ABC123,,,,,,,,,,");
            stream.Position = 0;
            var reader = new StreamReader(stream);
            
            // Act
            var file = io.Read(reader);

            // Assert
            Assert.AreEqual(1, file.Records.Count);
            stream.Dispose();
        }

        [Test]
        public void Read_file()
        {
            // Arrange
            var io = new ContributionFileIO();
            var path = Path.GetTempFileName();
            using (var stream = File.CreateText(path))
                stream.Write(@"YourFileReference,YourFileDate,ContributionPeriodStartDate,ContributionPeriodEndDate,EmployerID,PayrollID,NameTitle,FamilyName,GivenName,OtherGivenName,NameSuffix,DateOfBirth,Gender,TaxFileNumber,PhoneNumber,MobileNumber,EmailAddress,AddressLine1,AddressLine2,AddressLine3,AddressLine4,Suburb,State,PostCode,Country,EmploymentStartDate,EmploymentEndDate,EmploymentEndReason,FundID,FundName,FundEmployerID,MemberID,EmployerSuperGuaranteeAmount,EmployerAdditionalAmount,MemberSalarySacrificeAmount,MemberAdditionalAmount,OtherContributorType,OtherContributorName,YourContributionReference
,,08-Jul-15,06-Sep-15,,,,Citizen,John,,,07-Aug-85,,,,,,,,,,,,,,,,,ABC123,,,,,,,,,,");
                        
            // Act
            var file = io.Read(path);

            // Assert
            Assert.AreEqual(1, file.Records.Count);
        }
    }
}

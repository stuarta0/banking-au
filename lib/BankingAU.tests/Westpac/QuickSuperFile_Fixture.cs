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
        /// <summary>
        /// Returns a record that has the minimum amount of information to pass validation.
        /// </summary>
        /// <returns></returns>
        private ContributionRecord CreateValidRecord()
        {
            return new ContributionRecord()
            {
                ContributionPeriodStartDate = new DateTime(2015, 1, 1),
                ContributionPeriodEndDate = new DateTime(2015, 7, 1),
                FamilyName = "Citizen",
                GivenName = "John",
                DateOfBirth = new DateTime(1990, 1, 1),
                FundID = "ABC123"
            };
        }

        [Test]
        public void Write_stream()
        {
            // Arrange
            var io = new ContributionFileIO();
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };
            var file = new ContributionFile(new[]
            {
                CreateValidRecord(),
                CreateValidRecord(),
                CreateValidRecord()
            });

            // Act
            io.Write(writer, file);

            // Assert
            Assert.IsTrue(writer.BaseStream.Length > 0);
            stream.Position = 0;
            var data = new StreamReader(stream).ReadToEnd();
            stream.Dispose();

            Assert.AreEqual(
@"YourFileReference,YourFileDate,ContributionPeriodStartDate,ContributionPeriodEndDate,EmployerID,PayrollID,NameTitle,FamilyName,GivenName,OtherGivenName,NameSuffix,DateOfBirth,Gender,TaxFileNumber,PhoneNumber,MobileNumber,EmailAddress,AddressLine1,AddressLine2,AddressLine3,AddressLine4,Suburb,State,PostCode,Country,EmploymentStartDate,EmploymentEndDate,EmploymentEndReason,FundID,FundName,FundEmployerID,MemberID,EmployerSuperGuaranteeAmount,EmployerAdditionalAmount,MemberSalarySacrificeAmount,MemberAdditionalAmount,OtherContributorType,OtherContributorName,YourContributionReference
,,01-Jan-15,01-Jul-15,,,,Citizen,John,,,01-Jan-90,,,,,,,,,,,,,,,,,ABC123,,,,,,,,,,
,,01-Jan-15,01-Jul-15,,,,Citizen,John,,,01-Jan-90,,,,,,,,,,,,,,,,,ABC123,,,,,,,,,,
,,01-Jan-15,01-Jul-15,,,,Citizen,John,,,01-Jan-90,,,,,,,,,,,,,,,,,ABC123,,,,,,,,,,
", data);
        }

        [Test]
        public void Write_file()
        {
            // Arrange
            var io = new ContributionFileIO();
            var path = Path.GetTempFileName();
            var file = new ContributionFile(new[]
            {
                CreateValidRecord(),
                CreateValidRecord(),
                CreateValidRecord()
            });

            // Act
            io.Write(path, file);

            // Assert
            Assert.IsTrue(File.Exists(path));
            var fi = new FileInfo(path);
            Assert.IsTrue(fi.Length > 0);
            var data = File.ReadAllText(path);
            fi.Delete();

            Assert.AreEqual(
@"YourFileReference,YourFileDate,ContributionPeriodStartDate,ContributionPeriodEndDate,EmployerID,PayrollID,NameTitle,FamilyName,GivenName,OtherGivenName,NameSuffix,DateOfBirth,Gender,TaxFileNumber,PhoneNumber,MobileNumber,EmailAddress,AddressLine1,AddressLine2,AddressLine3,AddressLine4,Suburb,State,PostCode,Country,EmploymentStartDate,EmploymentEndDate,EmploymentEndReason,FundID,FundName,FundEmployerID,MemberID,EmployerSuperGuaranteeAmount,EmployerAdditionalAmount,MemberSalarySacrificeAmount,MemberAdditionalAmount,OtherContributorType,OtherContributorName,YourContributionReference
,,01-Jan-15,01-Jul-15,,,,Citizen,John,,,01-Jan-90,,,,,,,,,,,,,,,,,ABC123,,,,,,,,,,
,,01-Jan-15,01-Jul-15,,,,Citizen,John,,,01-Jan-90,,,,,,,,,,,,,,,,,ABC123,,,,,,,,,,
,,01-Jan-15,01-Jul-15,,,,Citizen,John,,,01-Jan-90,,,,,,,,,,,,,,,,,ABC123,,,,,,,,,,
", data);
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

        [Test]
        public void Dollar_amounts_two_decimal_limit_write()
        {
            // Arrange
            var io = new ContributionFileIO();
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };
            var file = new ContributionFile(new[] { CreateValidRecord() });
            file[0].EmployerSuperGuaranteeAmount = 7890.1234m;
            file[0].EmployerAdditionalAmount = 1234.5678m;
            file[0].MemberSalarySacrificeAmount = 9012.3456m;
            file[0].MemberAdditionalAmount = 3456.789m;

            // Act
            io.Write(writer, file);

            // Assert
            Assert.IsTrue(writer.BaseStream.Length > 0);
            stream.Position = 0;
            var data = new StreamReader(stream).ReadToEnd();
            stream.Dispose();

            Assert.AreEqual(
@"YourFileReference,YourFileDate,ContributionPeriodStartDate,ContributionPeriodEndDate,EmployerID,PayrollID,NameTitle,FamilyName,GivenName,OtherGivenName,NameSuffix,DateOfBirth,Gender,TaxFileNumber,PhoneNumber,MobileNumber,EmailAddress,AddressLine1,AddressLine2,AddressLine3,AddressLine4,Suburb,State,PostCode,Country,EmploymentStartDate,EmploymentEndDate,EmploymentEndReason,FundID,FundName,FundEmployerID,MemberID,EmployerSuperGuaranteeAmount,EmployerAdditionalAmount,MemberSalarySacrificeAmount,MemberAdditionalAmount,OtherContributorType,OtherContributorName,YourContributionReference
,,01-Jan-15,01-Jul-15,,,,Citizen,John,,,01-Jan-90,,,,,,,,,,,,,,,,,ABC123,,,,7890.12,1234.57,9012.35,3456.79,,,
", data);
        }
    }
}

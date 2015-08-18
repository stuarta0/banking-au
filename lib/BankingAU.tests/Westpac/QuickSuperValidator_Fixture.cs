using Banking.AU.Westpac.QuickSuper;
using FileHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.Westpac
{
    [TestFixture]
    public class QuickSuperValidator_Fixture
    {
        /// <summary>
        /// Returns a record that has the minimum amount of information to pass validation.
        /// </summary>
        /// <returns></returns>
        private ContributionRecord CreateValidRecord()
        {
            return new ContributionRecord()
            {
                ContributionPeriodStartDate = DateTime.Today.AddDays(-30),
                ContributionPeriodEndDate = DateTime.Today.AddDays(+30),
                FamilyName = "Citizen",
                GivenName = "John",
                DateOfBirth = DateTime.Today.AddYears(-30),
                FundID = "ABC123"
            };
        }

        [Test]
        public void Vanilla_invalid()
        {
            // Arrange

            // Act
            var errors = new Validator().Validate(new ContributionRecord());

            // Assert
            Assert.AreEqual(5, errors.Count);
        }

        [Test]
        public void Bare_minimum_valid()
        {
            // Arrange
            // After this, CreateValidRecord() should be used
            var record = new ContributionRecord()
            {
                ContributionPeriodStartDate = DateTime.Today.AddDays(-30),
                ContributionPeriodEndDate = DateTime.Today.AddDays(+30),
                FamilyName = "Citizen",
                GivenName = "John",
                DateOfBirth = DateTime.Today.AddYears(-30),
                FundID = "ABC123"
            };

            // Act
            var errors = new Validator().Validate(record);

            // Assert
            Assert.AreEqual(0, errors.Count);
        }

        [Test]
        public void All_valid()
        {
            // Arrange
            var record = new ContributionRecord()
            {
                AddressLine1 = "Apartment 1",
                AddressLine2 = "Level 2",
                AddressLine3 = "123",
                AddressLine4 = "Street",
                ContributionPeriodStartDate = DateTime.Today.AddDays(-30),
                ContributionPeriodEndDate = DateTime.Today.AddDays(+30),
                Country = "AU",
                DateOfBirth = DateTime.Today.AddYears(-30),
                EmailAddress = "john@example.com",
                EmployerAdditionalAmount = 100,
                EmployerID = "ABC123",
                EmployerSuperGuaranteeAmount = 200,
                EmploymentEndDate = DateTime.Today,
                EmploymentStartDate = DateTime.Today.AddMonths(-6),
                FamilyName = "Citizen",
                FundEmployerID = "ABC123",
                FundID = "ABC123",
                FundName = "Super Fund",
                Gender = ContributionRecord.Sex.Male,
                GivenName = "John",
                MemberAdditionalAmount = 300,
                MemberID = "ABC123",
                MemberSalarySacrificeAmount = 400,
                MobileNumber = "+61400 000 000",
                NameSuffix = NameSuffix.KBE,
                NameTitle = Salutation.MAJGEN,
                OtherContributorName = "Jane Citizen",
                OtherContributorType = "SPOUSE",
                OtherGivenName = "Michael",
                PayrollID = "ABC123",
                PhoneNumber = "(03) 6300 0000",
                PostCode = "1234",
                State = "ACT",
                Suburb = "Canberra",
                TaxFileNumber = "111 222 333",
                YourContributionReference = "ABC123",
                YourFileDate = DateTime.Today,
                YourFileReference = "ABC123"
            };

            // Act
            var errors = new Validator().Validate(record);

            // Assert
            Assert.AreEqual(0, errors.Count);
        }
    }
}

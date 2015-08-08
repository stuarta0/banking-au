using Banking.AU.Common.Converters;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Westpac.QuickSuper
{
    [DelimitedRecord(",")]
    [IgnoreFirst]
    public class ContributionRecord
    {
        /// <summary>
        /// Optional.  
        /// </summary>
        public string YourFileReference;

        /// <summary>
        /// Optional.  
        /// </summary>
        public DateTime? YourFileDate;
        
        /// <summary>
        /// Mandatory.  Restricted formats (section 2.1.1).
        /// </summary>
        public DateTime ContributionPeriodStartDate;
        
        /// <summary>
        /// Mandatory.  Restricted formats (section 2.1.1).
        /// </summary>
        public DateTime ContributionPeriodEndDate;

        /// <summary>
        /// Conditional.  
        /// </summary>
        public string EmployerID;

        /// <summary>
        /// Optional.  
        /// </summary>
        public string PayrollID;

        /// <summary>
        /// Optional.  Salutation.  Restricted values (section 2.3).
        /// </summary>
        [FieldConverter(typeof(EnumConverter), typeof(Salutation))]
        public Salutation? NameTitle;

        /// <summary>
        /// Mandatory.  
        /// </summary>
        public string FamilyName;

        /// <summary>
        /// Mandatory.  
        /// </summary>
        public string GivenName;

        /// <summary>
        /// Optional.  
        /// </summary>
        public string OtherGivenName;

        /// <summary>
        /// Optional.  Restricted values (section 2.4).
        /// </summary>
        [FieldConverter(typeof(EnumConverter), typeof(NameSuffix))]
        public NameSuffix? NameSuffix;

        /// <summary>
        /// Mandatory.
        /// </summary>
        public DateTime DateOfBirth;

        /// <summary>
        /// Optional.  Restricted values:
        /// M = Male
        /// F = Female
        /// I = Intersex/Indeterminate
        /// N = Not stated/Inadequeatly described
        /// </summary>
        public string Gender;

        /// <summary>
        /// Optional.
        /// </summary>
        public string TaxFileNumber;

        /// <summary>
        /// Optional.
        /// </summary>
        public string PhoneNumber;

        /// <summary>
        /// Optional.
        /// </summary>
        public string MobileNumber;

        /// <summary>
        /// Optional.
        /// </summary>
        public string EmailAddress;

        /// <summary>
        /// Conditional.
        /// </summary>
        public string AddressLine1;

        /// <summary>
        /// Optional.
        /// </summary>
        public string AddressLine2;

        /// <summary>
        /// Optional.
        /// </summary>
        public string AddressLine3;

        /// <summary>
        /// Optional.
        /// </summary>
        public string AddressLine4;

        /// <summary>
        /// Conditional.
        /// </summary>
        public string Suburb;

        /// <summary>
        /// Conditional.  Restricted values: AAT, ACT, NSW, NT, QLD, SA, TAS, VIC, WA.
        /// </summary>
        public string State;

        /// <summary>
        /// Conditional.
        /// </summary>
        public string PostCode;

        /// <summary>
        /// Optional.
        /// </summary>
        public string Country;

        /// <summary>
        /// Optional.
        /// </summary>
        public DateTime? EmploymentStartDate;

        /// <summary>
        /// Optional.
        /// </summary>
        public DateTime? EmploymentEndDate;

        /// <summary>
        /// Optional.
        /// </summary>
        public string EmploymentEndReason;

        /// <summary>
        /// Mandatory.
        /// </summary>
        public string FundID;

        /// <summary>
        /// Optional.
        /// </summary>
        public string FundName;

        /// <summary>
        /// Optional.
        /// </summary>
        public string FundEmployerID;

        /// <summary>
        /// Optional.
        /// </summary>
        public string MemberID;

        /// <summary>
        /// Optional.
        /// </summary>
        public decimal? EmployerSuperGuaranteeAmount;

        /// <summary>
        /// Optional.
        /// </summary>
        public decimal? EmployerAdditionalAmount;

        /// <summary>
        /// Optional.
        /// </summary>
        public decimal? MemberSalarySacrificeAmount;

        /// <summary>
        /// Optional.
        /// </summary>
        public decimal? MemberAdditionalAmount;

        /// <summary>
        /// Optional.  Only accepted value is "SPOUSE".
        /// </summary>
        public string OtherContributorType;

        /// <summary>
        /// Optional.
        /// </summary>
        public string OtherContributorName;

        /// <summary>
        /// Optional.
        /// </summary>
        public string YourContributionReference;
    }
}

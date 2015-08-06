using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Westpac.QuickSuper
{
    [IgnoreFirst]
    public class ContributionRecord
    {
        /// <summary>
        /// Optional.  
        /// </summary>
        public string YourFileReference { get; set; }

        /// <summary>
        /// Optional.  
        /// </summary>
        public DateTime? YourFileDate { get; set; }
        
        /// <summary>
        /// Mandatory.  Restricted formats (section 2.1.1).
        /// </summary>
        public DateTime ContributionPeriodStartDate { get; set; }
        
        /// <summary>
        /// Mandatory.  Restricted formats (section 2.1.1).
        /// </summary>
        public DateTime ContributionPeriodEndDate { get; set; }

        /// <summary>
        /// Conditional.  
        /// </summary>
        public string EmployerID { get; set; }

        /// <summary>
        /// Optional.  
        /// </summary>
        public string PayrollID { get; set; }

        /// <summary>
        /// Optional.  Salutation.  Restricted values (section 2.3).
        /// </summary>
        public string NameTitle { get; set; }

        /// <summary>
        /// Mandatory.  
        /// </summary>
        public string FamilyName { get; set; }

        /// <summary>
        /// Mandatory.  
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Optional.  
        /// </summary>
        public string OtherGivenName { get; set; }

        /// <summary>
        /// Optional.  Restricted values (section 2.4).
        /// </summary>
        public string NameSuffix { get; set; }

        /// <summary>
        /// Mandatory.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Optional.  Restricted values:
        /// M = Male
        /// F = Female
        /// I = Intersex/Indeterminate
        /// N = Not stated/Inadequeatly described
        /// </summary>
        public char? Gender { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string TaxFileNumber { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Conditional.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string AddressLine4 { get; set; }

        /// <summary>
        /// Conditional.
        /// </summary>
        public string Suburb { get; set; }

        /// <summary>
        /// Conditional.  Restricted values: AAT, ACT, NSW, NT, QLD, SA, TAS, VIC, WA.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Conditional.
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public DateTime? EmploymentStartDate { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public DateTime? EmploymentEndDate { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string EmploymentEndReason { get; set; }

        /// <summary>
        /// Mandatory.
        /// </summary>
        public string FundID { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string FundName { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string FundEmployerID { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public decimal? EmployerSuperGuaranteeAmount { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public decimal? EmployerAdditionalAmount { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public decimal? MemberSalarySacrificeAmount { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public decimal? MemberAdditionalAmount { get; set; }

        /// <summary>
        /// Optional.  Only accepted value is "SPOUSE".
        /// </summary>
        public string OtherContributorType { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string OtherContributorName { get; set; }

        /// <summary>
        /// Optional.
        /// </summary>
        public string YourContributionReference { get; set; }
    }
}

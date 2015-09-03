using Banking.AU.Common.Attributes;
using Banking.AU.Common.Converters;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Westpac.QuickSuper
{
    /// <summary>
    /// Represents a super contribution for an employee.
    /// Mandatory fields are: ContributionPeriodStartDate, ContributionPeriodEndDate, FamilyName, GivenName, DateOfBirth, FundID.
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst]
    public class ContributionRecord
    {
        public enum Sex
        {
            /// <summary>
            /// Not stated or inadequately described.
            /// </summary>
            [FileRepresentation("N")]
            NotSpecified = 0,

            /// <summary>
            /// Male.
            /// </summary>
            [FileRepresentation("M")]
            Male = 1,

            /// <summary>
            /// Female.
            /// </summary>
            [FileRepresentation("F")]
            Female = 2,

            /// <summary>
            /// Intersex or Indeterminate.
            /// </summary>
            [FileRepresentation("I")]
            Intersex = 3
        }

        /// <summary>
        /// This field is used in duplicate file checking. 
        /// Note: This value must be the same for every contribution detail record in the file.
        /// Optional.
        /// </summary>
        public string YourFileReference;

        /// <summary>
        /// This field is most relevant if you pay for contributions using direct debit.
        /// If a future date is provided, QuickSuper will not process the debit until the specified date. QuickSuper will reject any contribution files dated earlier than the previous banking day or more than 14 days in the future.
        /// If no value is provided, QuickSuper will process the debit on the current day if it is a banking day and before cut-off. Otherwise, the debit will be processed on the next banking day.
        /// Note: This value must be the same for every contribution detail record in the file
        /// Optional.  
        /// </summary>
        public DateTime? YourFileDate;
        
        /// <summary>
        /// The start date of the contribution period. It must be earlier than the Contribution Period End Date value and in a range no earlier than 2 years in the past.
        /// Mandatory.
        /// </summary>
        public DateTime ContributionPeriodStartDate;
        
        /// <summary>
        /// The end date of the contribution period. It must be later than the Contribution Period Start Date value and in a range no later than 6 months in the future. 
        /// Mandatory.
        /// </summary>
        public DateTime ContributionPeriodEndDate;

        /// <summary>
        /// The identifier for the employer, as registered within QuickSuper.
        /// For clients with a Single Employer Facility, you may provide your QuickSuper Client ID in this field or leave blank.
        /// For clients with a Multiple Employer Facility, you must provide the unique identifier for the employer within your facility.
        /// Conditional.
        /// </summary>
        public string EmployerID;

        /// <summary>
        /// The ID representing the employee in your own payroll system. That is, your unique identifier for the employee. 
        /// Optional.  
        /// </summary>
        public string PayrollID;

        /// <summary>
        /// Optional.
        /// </summary>
        [FieldConverter(typeof(EnumConverter), typeof(Salutation))]
        public Salutation? NameTitle;

        /// <summary>
        /// Also known as surname, this field is required to assist funds in allocating contributions. 
        /// Mandatory.
        /// </summary>
        public string FamilyName;

        /// <summary>
        /// Also known as first name, this field is required to assist funds in allocating contributions. 
        /// You should provide the full given name and not just the first initial. 
        /// Mandatory.  
        /// </summary>
        public string GivenName;

        /// <summary>
        /// Also known as middle name, this field can assist funds in allocating contributions. 
        /// It is not mandatory as not all employees will have a second given name; however you should provide this if available. 
        /// If you only have the first initial of the employee’s other given name, then this is acceptable to provide. 
        /// Optional.
        /// </summary>
        public string OtherGivenName;

        /// <summary>
        /// Optional.
        /// </summary>
        [FieldConverter(typeof(EnumConverter), typeof(NameSuffix))]
        public NameSuffix? NameSuffix;

        /// <summary>
        /// Mandatory.
        /// </summary>
        public DateTime DateOfBirth;

        /// <summary>
        /// Optional.
        /// </summary>
        [FieldConverter(typeof(EnumConverter), typeof(Sex))]
        public Sex? Gender;

        /// <summary>
        /// Optional. However you must provide the employee’s TFN if it has been provided to you.
        /// </summary>
        public string TaxFileNumber;

        /// <summary>
        /// Landline or fixed number to use if required to contact the employee. 
        /// Optional.
        /// </summary>
        public string PhoneNumber;

        /// <summary>
        /// Mobile number to use if required to contact the employee. 
        /// Optional.
        /// </summary>
        public string MobileNumber;

        /// <summary>
        /// Email address to use if required to contact the employee. 
        /// Optional.
        /// </summary>
        public string EmailAddress;

        /// <summary>
        /// Applicable for Australian or international addresses. 
        /// Conditional.
        /// </summary>
        public string AddressLine1;

        /// <summary>
        /// Applicable for Australian or international addresses. 
        /// Optional.
        /// </summary>
        public string AddressLine2;

        /// <summary>
        /// Applicable for Australian or international addresses. 
        /// Optional.
        /// </summary>
        public string AddressLine3;

        /// <summary>
        /// Applicable for Australian or international addresses. 
        /// Optional.
        /// </summary>
        public string AddressLine4;

        /// <summary>
        /// Applicable for Australian addresses only. 
        /// Australian suburb aligned with the specified post code. 
        /// Conditional.
        /// </summary>
        public string Suburb;

        /// <summary>
        /// Applicable for Australian addresses only. 
        /// Restricted values: AAT, ACT, NSW, NT, QLD, SA, TAS, VIC, WA.
        /// </summary>
        public string State;

        /// <summary>
        /// Applicable for Australian addresses only. 
        /// Australian post code aligned with the specified suburb.
        /// Conditional.
        /// </summary>
        public string PostCode;

        /// <summary>
        /// Applicable for Australian or international addresses.
        /// Country may be specified using the two character code published under ISO 3166 
        /// e.g. ‘AU’ for Australia or ‘NZ’ for New Zealand. 
        /// Blank indicates an Australia address. 
        /// Optional.
        /// </summary>
        public string Country;

        /// <summary>
        /// The date the employee’s employment started with your company. 
        /// You can provide this if the fund requests you to provide this information to them.
        /// Optional.
        /// </summary>
        public DateTime? EmploymentStartDate;

        /// <summary>
        /// The date the employee’s employment ended with your company. 
        /// You can provide this if the fund requests you to provide this information to them.
        /// Optional.
        /// </summary>
        public DateTime? EmploymentEndDate;

        /// <summary>
        /// The general reason why the employee’s employment ended with your company. 
        /// You can provide this if the fund requests you to provide this information to them. 
        /// You can provide any value as directed by the fund, however a list of suggested values are:
        /// ‘RESIGNED’, ‘RETIREMENT’, ‘DEATH’, ‘DISABLEMENT’, ‘LWOP’ (Leave Without Pay), ‘PARENTAL’ (Parental leave, including maternity and paternity leave), ‘TRANSFER’ (Company transfer to a separate employer within the same parent company), ‘OTHER’ (Other reason not able to be classified using the previous codes).
        /// Optional.
        /// </summary>
        public string EmploymentEndReason;

        /// <summary>
        /// The identifier for the fund being paid. 
        /// This may be a master fund preregistered within QuickSuper for general use; or a fund you have registered for your use.
        /// Valid options (in order of preference) are Full client Fund ID ('QS12345XYZ' or 'QS123477788899901'); Partial client Fund ID without Client ID ('XYZ' or '77788899901'); Unique Superannutaion Identifier (USI, '12345678901001' or 'XXX9999AU'); Historical Fund ID ('SPINXXX9999AU' or 'ABN12345678901'); Superannuation Product Identification Number (SPIN, 'XXX9999AU'); or ABN of SMSF ('12345678901').
        /// Mandatory.
        /// </summary>
        public string FundID;

        /// <summary>
        /// The name of the fund being paid. 
        /// This value is not used by QuickSuper. It is included for readability purposes only. 
        /// Optional.
        /// </summary>
        public string FundName;

        /// <summary>
        /// Funds may allocate an employer ID to an employer and ask that it is provided with employee contributions. 
        /// You may include the allocated value in this field and it will be provided to the fund on the remittance.
        /// Optional.
        /// </summary>
        public string FundEmployerID;

        /// <summary>
        /// The member number allocated by the beneficiary fund to the employee. 
        /// If the employee is a new member to the fund or the fund does not have member numbers (e.g. SMSF), you may leave this field blank.
        /// Optional.
        /// </summary>
        public string MemberID;

        /// <summary>
        /// Optional.
        /// </summary>
        [FieldConverter(typeof(StringFormatConverter), typeof(decimal?), "F2")]
        public decimal? EmployerSuperGuaranteeAmount;

        /// <summary>
        /// Optional.
        /// </summary>
        [FieldConverter(typeof(StringFormatConverter), typeof(decimal?), "F2")]
        public decimal? EmployerAdditionalAmount;

        /// <summary>
        /// Optional.
        /// </summary>
        [FieldConverter(typeof(StringFormatConverter), typeof(decimal?), "F2")]
        public decimal? MemberSalarySacrificeAmount;

        /// <summary>
        /// Optional.
        /// </summary>
        [FieldConverter(typeof(StringFormatConverter), typeof(decimal?), "F2")]
        public decimal? MemberAdditionalAmount;

        /// <summary>
        /// This field may indicate that the contribution has been made on behalf of a spouse. 
        /// Only accepted value is "SPOUSE".
        /// Optional.
        /// </summary>
        public string OtherContributorType;

        /// <summary>
        /// This field indicates the contributing spouse for a spouse contribution. 
        /// Optional.
        /// </summary>
        public string OtherContributorName;

        /// <summary>
        /// If supplied, the value is stored against the employee contribution for support purposes. 
        /// It is not provided on to the fund. 
        /// Optional.
        /// </summary>
        public string YourContributionReference;
    }
}

using Banking.AU.ATO.SuperStream.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO.SuperStream
{
    public class SuperFundMember
    {
        public enum Gender
        {
            NotSpecified = 0, //assumption
            Male = 1,
            Female = 2,
            Intersex = 3 //assumption
        }

        public string TFN { get; set; }
        
        public string PersonNameTitle { get; set; }
        public string PersonNameSuffix { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string OtherGivenName { get; set; }
        public Gender SexCode { get; set; }
        public DateTime BirthDate { get; set; }
        
        public string AddressUsageCode { get; set; }
        public string AddressDetailsLine1 { get; set; }
        public string AddressDetailsLine2 { get; set; }
        public string AddressDetailsLine3 { get; set; }
        public string AddressDetailsLine4 { get; set; }
        public string LocalityName { get; set; }
        public string Postcode { get; set; }
        public string StateTerritoryCode { get; set; }
        public string CountryCode { get; set; }
        
        public string EmailAddress { get; set; }
        public string TelephoneMinimalNumberLandline { get; set; }
        public string TelephoneMinimalNumberMobile { get; set; }
        
        public string MemberClientIdentifier { get; set; }
        public string PayrollNumberIdentifier { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public string EmploymentEndReason { get; set; }

        public Contributions Contributions { get; set; }
        public Registration Registration { get; set; }
    }
}

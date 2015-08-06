using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO.SuperStream.Member
{
    public class Registration
    {
        public DateTime? EmploymentStartDate { get; set; }
        public bool? AtWorkIndicator { get; set; }
        public decimal? AnnualSalaryBenefitsAmount { get; set; }
        public decimal? AnnualSalaryContributionsAmount { get; set; }
        public DateTime? AnnualSalaryContributionsEffectiveStartDate { get; set; }
        public DateTime? AnnualSalaryContributionsEffectiveEndDate { get; set; }
        public decimal? AnnualSalaryInsuranceAmount { get; set; }
        public decimal? WeeklyHoursWorked { get; set; }
        public string OccupationDescription { get; set; }
        public bool? InsuranceOptOutIndicator { get; set; }
        public DateTime? FundRegistrationDate { get; set; }
        public string BenefitCategory { get; set; }
        public string EmploymentStatusCode { get; set; }
        public DateTime? SuperContributionCommenceDate { get; set; }
        public DateTime? SuperContributionCeaseDate { get; set; }
        public string MemberRegistrationAmendmentReason { get; set; }
    }
}

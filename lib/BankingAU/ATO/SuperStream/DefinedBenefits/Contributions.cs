using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO.SuperStream.DefinedBenefits
{
    public class Contributions
    {
        public decimal? MemberPreTaxContribution { get; set; }
        public decimal? MemberPostTaxContribution { get; set; }
        public decimal? EmployerContribution { get; set; }
        public decimal? NotionalMemberPreTaxContribution { get; set; }
        public decimal? NotionalMemberPostTaxContribution { get; set; }
        public decimal? NotionalEmployerContribution { get; set; }
        public decimal? OrdinaryTimeEarnings { get; set; }
        public decimal? ActualPeriodicSalaryWagesEarned { get; set; }
        public decimal? SuperannuableAllowancesPaid { get; set; }
        public decimal? NotionalSuperannuableAllowances { get; set; }
        public decimal? ServiceFraction { get; set; }
        public DateTime? ServiceFractionEffectiveDate { get; set; }
        public decimal? FullTimeHours { get; set; }
        public decimal? ContractedHours { get; set; }
        public decimal? ActualHoursPaid { get; set; }
        public string EmployeeLocationIdentifier { get; set; }
    }
}

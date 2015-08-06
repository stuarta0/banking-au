using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO.SuperStream.DefinedBenefits
{
    public class Registration
    {
        public class Range
        {
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
        }

        public class Rate : Range
        {
            public decimal? Amount { get; set; }
        }

        public class Code : Range
        {
            public string Identifier { get; set; }
        }

        public Rate ServiceFraction { get; set; }
        public Rate DefinedBenefitEmployer { get; set; }
        public Rate DefinedBenefitMember { get; set; }

        public Rate DefinedBenefitAnnualSalary1 { get; set; }
        public Rate DefinedBenefitAnnualSalary2 { get; set; }
        public Rate DefinedBenefitAnnualSalary3 { get; set; }
        public Rate DefinedBenefitAnnualSalary4 { get; set; }
        public Rate DefinedBenefitAnnualSalary5 { get; set; }

        public Code LeaveWithoutPay { get; set; }

        public DateTime? AnnualSalaryInsuranceEffectiveDate { get; set; }
        public DateTime? AnnualSalaryBenefitsEffectiveDate { get; set; }
        public DateTime? EmployeeStatusEffectiveDate { get; set; }
        public DateTime? EmployeeBenefitCategoryEffectiveDate { get; set; }

        public Code EmployeeLocation { get; set; }
    }
}

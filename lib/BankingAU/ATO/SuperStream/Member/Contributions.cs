using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO.SuperStream.Member
{
    public class Contributions
    {
        public DateTime? PayPeriodStartDate { get; set; }
        public DateTime? PayPeriodEndDate { get; set; }
        public decimal? SuperannuationGuaranteeAmount { get; set; }
        public decimal? AwardOrProductivityAmount { get; set; }
        public decimal? PersonalContributionsAmount { get; set; }
        public decimal? SalarySacrificedAmount { get; set; }
        public decimal? VoluntaryAmount { get; set; }
        public decimal? SpouseContributionsAmount { get; set; }
        public decimal? ChildContributionsAmount { get; set; }
        public decimal? OtherThirdPartyContributionsAmount { get; set; }
    }
}

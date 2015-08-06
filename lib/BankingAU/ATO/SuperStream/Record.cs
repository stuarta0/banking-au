using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO.SuperStream
{
    public class Record
    {
        public string ID { get; set; }

        public Header Header { get; set; }
        public Sender Sender { get; set; }
        public Payer Payer { get; set; }
        public Payee Payee { get; set; }
        public Employer Employer { get; set; }
        public SuperFundMember SuperFundMember { get; set; }
        public DefinedBenefit DefinedBenefits { get; set; }
    }
}

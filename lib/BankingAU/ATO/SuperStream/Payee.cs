using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO.SuperStream
{
    public class Payee
    {
        public string ABN { get; set; }
        public string USI { get; set; }
        public string OrganisationalName { get; set; }
        public string TargetElectronicServiceAddress { get; set; }
        public string PaymentMethodCode { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string PaymentCustomerReferenceNumber { get; set; }
        public string BpayBillerCode { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string BsbNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AccountNameText { get; set; }
    }
}

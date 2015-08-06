using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO.SuperStream
{
    public class Payer
    {
        public string ABN { get; set; }
        public string OrganisationalName { get; set; }
        public string BsbNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AccountNameText { get; set; }
    }
}

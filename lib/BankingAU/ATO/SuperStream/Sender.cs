using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO.SuperStream
{
    public class Sender
    {
        public string ABN { get; set; }
        public string OrganisationalNameText { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string OtherGivenName { get; set; }
        public string Email { get; set; }
        public string TelephoneMinimalNumber { get; set; }
    }
}

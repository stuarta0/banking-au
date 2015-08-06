using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO.SuperStream
{
    public class Header
    {
        public string SourceEntityID { get; set; }
        public string SourceEntityIDType { get; set; }
        public string SourceElectronicServiceAddress { get; set; }
        public bool ElectronicErrorMessaging { get; set; }
    }
}

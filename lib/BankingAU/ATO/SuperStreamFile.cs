using Banking.AU.ATO.SuperStream;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ATO
{
    /// <summary>
    /// Representation of the SuperStream Alternative File Format (SAFF).
    /// Version 1.0 - 2014-08-04
    /// </summary>
    public class SuperStreamFile
    {
        public string Version { get; set; }
        public bool NegativesSupported { get; set; }
        public string FileID { get; set; }

        public IList<Record> Records { get; set; }
    }
}

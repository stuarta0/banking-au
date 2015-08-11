using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Westpac.QuickSuper
{
    public class ContributionFile
    {
        public IList<ContributionRecord> Records { get; set; }

        public ContributionFile()
            : this(new List<ContributionRecord>())
        {
        }

        public ContributionFile(IEnumerable<ContributionRecord> records)
        {
            Records = new List<ContributionRecord>(records);
        }
    }
}

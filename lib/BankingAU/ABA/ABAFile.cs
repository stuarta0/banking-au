using Banking.AU.ABA.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA
{
    public class ABAFile
    {
        public DescriptiveRecord DescriptiveRecord { get; set; }

        public IList<DetailRecord> DetailRecords { get; set; }

        public FileTotalRecord FileTotalRecord { get; set; }

        public ABAFile()
        {
            DescriptiveRecord = new DescriptiveRecord();
            DetailRecords = new List<DetailRecord>();
            FileTotalRecord = new FileTotalRecord();
        }
    }
}

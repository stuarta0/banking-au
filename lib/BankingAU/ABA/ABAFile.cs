using Banking.AU.ABA.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA
{
    public class AbaFile
    {
        public DescriptiveRecord DescriptiveRecord { get; set; }

        public IList<DetailRecord> DetailRecords { get; set; }

        /// <summary>
        ///Use <see cref="AbaFile.GenerateTotalRecord"/> to automatically create the required data.
        /// </summary>
        public FileTotalRecord FileTotalRecord { get; set; }

        public AbaFile()
        {
            DescriptiveRecord = new DescriptiveRecord();
            DetailRecords = new List<DetailRecord>();
            FileTotalRecord = new FileTotalRecord();
        }
        
        /// <summary>
        /// Create or update a FileTotalRecord from this object.
        /// Alternatively, use <see cref="Validation.Builtins.FileTotalCleaner"/>.
        /// </summary>
        public void GenerateTotalRecord()
        {
            new Validation.AbaFile.FileTotalValidator().Clean(this);
        }
    }
}

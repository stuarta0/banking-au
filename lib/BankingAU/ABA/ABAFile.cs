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

        public FileTotalRecord GenerateTotalRecord()
        {
            if (DetailRecords == null)
                return null;

            decimal net = 0, credit = 0, debit = 0;
            foreach (var detail in DetailRecords)
            {
                net += detail.Amount;
                if (detail.TransactionCode == TransactionCode.CreditItem)
                    credit += detail.Amount;
                else if (detail.TransactionCode == TransactionCode.DebitItem)
                    debit += detail.Amount;
            }

            return new FileTotalRecord()
            {
                Bsb = "999-999",
                NetTotalAmount = net,
                CreditTotalAmount = credit,
                DebitTotalAmount = debit,
                CountOfType1 = DetailRecords.Count
            };
        }
    }
}

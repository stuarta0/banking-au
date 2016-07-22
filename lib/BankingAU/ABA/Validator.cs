using Banking.AU.Common;
using Banking.AU.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.ABA
{
    /// <summary>
    /// Validates an AbaFile object ensuring all required data exists.
    /// </summary>
    public class Validator : IValidator<AbaFile>
    {
        public IList<IValidationError<AbaFile>> Validate(AbaFile item)
        {
            var result = new List<IValidationError<AbaFile>>();

            if (item.DescriptiveRecord == null)
                result.Add(new ValidationError<AbaFile>(item, "DescriptiveRecord", "DescriptiveRecord must be provided."));
            
            if (item.FileTotalRecord == null)
                result.Add(new ValidationError<AbaFile>(item, "FileTotalRecord", "FileTotalRecord must be provided."));
            
            if (item.DetailRecords == null || item.DetailRecords.Count == 0)
                result.Add(new ValidationError<AbaFile>(item, "DetailRecords", "DetailRecords must be provided."));
            else if (item.FileTotalRecord != null)
            {
                // ensure the detail record totals match the FileTotalRecord
                decimal debit = 0, credit = 0;
                foreach (var detail in item.DetailRecords)
                {
                    if (detail.TransactionCode == Records.TransactionCode.DebitItem)
                        debit += detail.Amount;
                    else if (detail.TransactionCode == Records.TransactionCode.CreditItem)
                        credit += detail.Amount;
                }

                if (item.FileTotalRecord.DebitTotalAmount != debit)
                    result.Add(new ValidationError<AbaFile>(item, "FileTotalRecord", "DebitTotalAmount does not match sum of all DebitItems."));
                if (item.FileTotalRecord.CreditTotalAmount != credit)
                    result.Add(new ValidationError<AbaFile>(item, "FileTotalRecord", "CreditTotalAmount does not match sum of all CreditItems."));
                if (item.FileTotalRecord.NetTotalAmount != Math.Abs(debit - credit))
                    result.Add(new ValidationError<AbaFile>(item, "FileTotalRecord", "NetTotalAmount does not match the difference of credit and debit items."));
                if (item.FileTotalRecord.CountOfType1 != item.DetailRecords.Count)
                    result.Add(new ValidationError<AbaFile>(item, "FileTotalRecord", "SumOfCount1 does not equal the total number of DetailRecords."));
            }

            return result;
        }
    }
}

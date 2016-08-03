using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.AbaFile
{
    /// <summary>
    /// Validator for calculating FileTotalRecord CreditTotalAmount from DetailRecords.
    /// </summary>
    public class CreditTotalAmountValidator : TotalAmountValidator
    {
        public CreditTotalAmountValidator()
            : base(Records.TransactionCode.CreditItem, 10,
                  f => f.FileTotalRecord.CreditTotalAmount,
                  (f, v) => f.FileTotalRecord.CreditTotalAmount = v)
        {
            _fieldName = "CreditTotalAmount";
        }
    }
}

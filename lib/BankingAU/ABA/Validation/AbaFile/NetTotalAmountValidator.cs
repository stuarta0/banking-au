using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.AbaFile
{
    public class NetTotalAmountValidator : TotalAmountValidator
    {
        public NetTotalAmountValidator() : base(10, 
            f => f.FileTotalRecord.NetTotalAmount,
            (f,v) => f.FileTotalRecord.NetTotalAmount = v)
        { }

        public override void Clean(ABA.AbaFile item)
        {
            var debit = CalculateTotal(Records.TransactionCode.DebitItem, item);
            var credit = CalculateTotal(Records.TransactionCode.CreditItem, item);
            item.FileTotalRecord.NetTotalAmount = Math.Abs(debit - credit);

            base.Clean(item);
        }

        public override IEnumerable<Exception> Validate(ABA.AbaFile item)
        {
            var debit = CalculateTotal(Records.TransactionCode.DebitItem, item);
            var credit = CalculateTotal(Records.TransactionCode.CreditItem, item);
            if (item.FileTotalRecord.NetTotalAmount != Math.Abs(debit - credit))
                yield return new Exception("NetTotalAmount does not match difference of debit and credit");

            foreach (var e in base.Validate(item)) yield return e;
        }
    }
}

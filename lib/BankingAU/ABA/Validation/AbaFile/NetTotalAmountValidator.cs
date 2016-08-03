using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.AbaFile
{
    public class NetTotalAmountValidator : CurrencyValidator<ABA.AbaFile>
    {
        public NetTotalAmountValidator() : base(10,
            f => f.FileTotalRecord.NetTotalAmount,
            (f, v) => f.FileTotalRecord.NetTotalAmount = v)
        { }

        protected virtual decimal GetTotal(ABA.AbaFile item)
        {
            decimal debit = 0m, credit = 0m;
            foreach (var r in item.DetailRecords)
            {
                debit += (r.TransactionCode == Records.TransactionCode.DebitItem ? r.Amount : 0m);
                credit += (r.TransactionCode == Records.TransactionCode.CreditItem ? r.Amount : 0m);
            }
            return Math.Abs(debit - credit);
        }

        public override void Clean(ABA.AbaFile item)
        {
            item.FileTotalRecord.NetTotalAmount = GetTotal(item);
            base.Clean(item);
        }

        public override IEnumerable<Exception> Validate(ABA.AbaFile item)
        {
            if (item.FileTotalRecord.NetTotalAmount != GetTotal(item))
                yield return new Exception("NetTotalAmount does not match difference of debit and credit");

            foreach (var e in base.Validate(item)) yield return e;
        }
    }
}

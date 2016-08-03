using System;
using System.Collections.Generic;
using System.Text;
using Banking.AU.ABA.Records;

namespace Banking.AU.ABA.Validation.AbaFile
{
    public class NetTotalAmountValidator : CurrencyValidator<ABA.AbaFile>, ICanAdd
    {
        public NetTotalAmountValidator() : base(10,
            f => f.FileTotalRecord.NetTotalAmount,
            (f, v) => f.FileTotalRecord.NetTotalAmount = v)
        { }

        protected virtual decimal CalculateTotal(IEnumerable<Records.DetailRecord> items)
        {
            decimal debit = 0m, credit = 0m;
            foreach (var r in items)
            {
                debit += (r.TransactionCode == Records.TransactionCode.DebitItem ? r.Amount : 0m);
                credit += (r.TransactionCode == Records.TransactionCode.CreditItem ? r.Amount : 0m);
            }
            return Math.Abs(debit - credit);
        }

        public override void Clean(ABA.AbaFile item)
        {
            item.FileTotalRecord.NetTotalAmount = CalculateTotal(item.DetailRecords);
            base.Clean(item);
        }

        public override IEnumerable<Exception> Validate(ABA.AbaFile item)
        {
            if (item.FileTotalRecord.NetTotalAmount != CalculateTotal(item.DetailRecords))
                yield return new Exception("NetTotalAmount does not match difference of debit and credit");

            foreach (var e in base.Validate(item)) yield return e;
        }

        /// <summary>
        /// A helper function to check whether one or more DetailRecords can be added to an ABA file without exceeding limits for net total.
        /// </summary>
        public bool CanAdd(ABA.AbaFile file, params Records.DetailRecord[] records)
        {
            var list = new List<Records.DetailRecord>(file.DetailRecords);
            list.AddRange(records);
            var total = CalculateTotal(list);
            foreach (var e in base.Validate(total))
                return false;
            return true;
        }
    }
}

using R = Banking.AU.ABA;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.AbaFile
{
    public abstract class TotalAmountValidator : CurrencyValidator<R.AbaFile>
    {
        protected Records.TransactionCode _code;
        protected string _fieldName;
        public TotalAmountValidator(int fieldLength, GetValue<R.AbaFile, decimal> get, SetValue<R.AbaFile, decimal> set)
            : base(fieldLength, get, set)
        {
            _fieldName = "Total";
            _code = Records.TransactionCode.DebitItem;
        }
        public TotalAmountValidator(Records.TransactionCode code, int fieldLength, GetValue<R.AbaFile, decimal> get, SetValue<R.AbaFile, decimal> set)
            : this(fieldLength, get, set)
        {
            _code = code;
        }

        protected decimal CalculateTotal(R.AbaFile item)
        {
            return CalculateTotal(_code, item);
        }

        protected decimal CalculateTotal(Records.TransactionCode code, R.AbaFile item)
        {
            var total = 0m;
            foreach (var r in item.DetailRecords)
                total += (r.TransactionCode == code ? r.Amount : 0);
            return total;
        }

        public override void Clean(R.AbaFile item)
        {
            _set(item, CalculateTotal(item));
            base.Clean(item);
        }

        public override IEnumerable<Exception> Validate(R.AbaFile item)
        {
            if (_get(item) != CalculateTotal(item))
                yield return new Exception(String.Format("{0} does not match sum of detail records", _fieldName));

            foreach (var e in base.Validate(item))
                yield return e;
        }
    }
}

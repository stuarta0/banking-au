using R = Banking.AU.ABA;
using System;
using System.Collections.Generic;
using System.Text;
using Banking.AU.ABA.Records;

namespace Banking.AU.ABA.Validation.AbaFile
{
    /// <summary>
    /// Abstract class for assisting with validating and calculating FileTotalRecord values from DetailRecords.
    /// </summary>
    public abstract class TotalAmountValidator : CurrencyValidator<R.AbaFile>, ICanAdd
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

        protected decimal CalculateTotal(IEnumerable<R.Records.DetailRecord> items)
        {
            return CalculateTotal(_code, items);
        }

        protected decimal CalculateTotal(Records.TransactionCode code, IEnumerable<R.Records.DetailRecord> items)
        {
            var total = 0m;
            foreach (var r in items)
                total += (r.TransactionCode == code ? r.Amount : 0m);
            return total;
        }

        public override void Clean(R.AbaFile item)
        {
            _set(item, CalculateTotal(item.DetailRecords));
            base.Clean(item);
        }

        public override IEnumerable<Exception> Validate(R.AbaFile item)
        {
            if (_get(item) != CalculateTotal(item.DetailRecords))
                yield return new Exception(String.Format("{0} does not match sum of detail records", _fieldName));

            foreach (var e in base.Validate(item))
                yield return e;
        }

        /// <summary>
        /// A helper function to check whether one or more DetailRecords can be added to an ABA file without exceeding limits for totals.
        /// </summary>
        public virtual bool CanAdd(R.AbaFile file, params Records.DetailRecord[] records)
        {
            var list = new List<R.Records.DetailRecord>(file.DetailRecords);
            list.AddRange(records);
            var total = CalculateTotal(list);
            foreach (var e in base.Validate(total))
                return false;
            return true;
        }
    }
}

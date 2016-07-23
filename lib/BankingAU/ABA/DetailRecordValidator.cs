using Banking.AU.ABA.Records;
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
    public class DetailRecordValidator : IValidator<DetailRecord>
    {
        public IList<IValidationError<DetailRecord>> Validate(DetailRecord item)
        {
            var result = new List<IValidationError<DetailRecord>>();

            var bsb     = new Regex(@"^\d{3}\-\d{3}$");
            var account = new Regex(@"^[0-9a-zA-Z\-\s]+$");
            var charset = new Regex(@"^[\s\.\<\>\(\)\+\$\*\{\}\-\?\\/,;:!@#$%&'\x22=~`|_a-zA-Z0-9]+$");
            
            // TODO: extract FileHelpers attributes for field lengths.
            if (!bsb.IsMatch(item.Bsb))
                result.Add(new FormatError<DetailRecord>(item, "Bsb", "000-000"));
            if (!account.IsMatch(item.AccountNumber))
                result.Add(new FormatError<DetailRecord>(item, "AccountNumber", "containing alphanumeric, hyphen and blank characters"));
            if (item.Amount < 0)
                result.Add(new ValidationError<DetailRecord>(item, "Amount", "Amount must not be negative."));
            if (!charset.IsMatch(item.TargetAccountTitle))
                result.Add(new FormatError<DetailRecord>(item, "TargetAccountTitle", "using a subset of printable ASCII characters"));
            if (!String.IsNullOrEmpty(item.TraceRecordBsb) && !bsb.IsMatch(item.TraceRecordBsb))
                result.Add(new FormatError<DetailRecord>(item, "TraceRecordBsb", "000-000"));
            if (!String.IsNullOrEmpty(item.TraceRecordAccountNumber) && !account.IsMatch(item.TraceRecordAccountNumber))
                result.Add(new FormatError<DetailRecord>(item, "TraceRecordAccountNumber", "containing alphanumeric, hyphen and blank characters"));
            if (!charset.IsMatch(item.RemitterName))
                result.Add(new FormatError<DetailRecord>(item, "RemitterName", "using a subset of printable ASCII characters"));
            if (item.WithholdingTaxAmount < 0)
                result.Add(new ValidationError<DetailRecord>(item, "WithholdingTaxAmount", "WithholdingTaxAmount must not be negative."));

            return result;
        }
    }
}

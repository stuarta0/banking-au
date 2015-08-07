using Banking.AU.ABA.Converters;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA
{
    [FixedLengthRecord]
    public class FileTotalRecord
    {
        [FieldFixedLength(1)]
        public int RecordType;

        [FieldFixedLength(7)]
        // TODO: ensure 999-999 format
        public string BSB;

        [FieldFixedLength(12)]
        public string Blank1;

        [FieldFixedLength(10)]
        [FieldConverter(typeof(CurrencyConverter))]
        public decimal NetTotalAmount;

        [FieldFixedLength(10)]
        [FieldConverter(typeof(CurrencyConverter))]
        public decimal CreditTotalAmount;

        [FieldFixedLength(10)]
        [FieldConverter(typeof(CurrencyConverter))]
        public decimal DebitTotalAmount;

        [FieldFixedLength(24)]
        public string Blank2;

        [FieldFixedLength(6)]
        // TODO: right justified, zero padding
        public int CountOfType1;

        [FieldFixedLength(40)]
        public string Blank3;

        public FileTotalRecord()
        {
            RecordType = 7;
        }
    }
}

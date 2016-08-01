using Banking.AU.Common.Converters;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Records
{
    [FixedLengthRecord]
    public class FileTotalRecord
    {
        /// <summary>
        /// Must be 7.
        /// </summary>
        [FieldFixedLength(1)]
        public readonly int RecordType;

        /// <summary>
        /// Must be 999-999.
        /// </summary>
        [FieldFixedLength(7)]
        public readonly string Bsb;

        [FieldFixedLength(12)]
        public readonly string Blank1;

        /// <summary>
        /// Must equal the difference between File Credit & File Debit Total Amounts.
        /// </summary>
        [FieldFixedLength(10)]
        [FieldAlign(AlignMode.Right, '0')]
        [FieldConverter(typeof(UnsignedCurrencyConverter))]
        public decimal NetTotalAmount;

        /// <summary>
        /// Must equal the accumulated total of credit Detail Record amounts. 
        /// </summary>
        [FieldFixedLength(10)]
        [FieldAlign(AlignMode.Right, '0')]
        [FieldConverter(typeof(UnsignedCurrencyConverter))]
        public decimal CreditTotalAmount;

        /// <summary>
        /// Must equal the accumulated total of debit Detail Record amounts. 
        /// </summary>
        [FieldFixedLength(10)]
        [FieldAlign(AlignMode.Right, '0')]
        [FieldConverter(typeof(UnsignedCurrencyConverter))]
        public decimal DebitTotalAmount;

        [FieldFixedLength(24)]
        public readonly string Blank2;

        /// <summary>
        /// Must equal accumulated number of Record Type 1 items on the file.
        /// </summary>
        [FieldFixedLength(6)]
        [FieldAlign(AlignMode.Right, '0')]
        public int CountOfType1;

        [FieldFixedLength(40)]
        public readonly string Blank3;

        public FileTotalRecord()
        {
            RecordType = 7;
            Bsb = "999-999";
        }
    }
}

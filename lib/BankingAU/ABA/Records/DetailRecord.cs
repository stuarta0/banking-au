using Banking.AU.Common.Converters;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Records
{
    [FixedLengthRecord]
    public class DetailRecord
    {
        [FieldFixedLength(1)]
        public int RecordType;

        [FieldFixedLength(7)]
        public string BSB;

        [FieldFixedLength(9)]
        [FieldAlign(AlignMode.Right, ' ')]
        public string AccountNumber;

        [FieldFixedLength(1)]
        [FieldConverter(typeof(EnumConverter), typeof(Indicator))]
        public Indicator Indicator;

        [FieldFixedLength(2)]
        [FieldConverter(typeof(EnumConverter), typeof(TransactionCode))]
        public TransactionCode TransactionCode;

        [FieldFixedLength(10)]
        [FieldAlign(AlignMode.Right, '0')]
        [FieldConverter(typeof(CurrencyConverter))]
        public decimal Amount;

        [FieldFixedLength(32)]
        // TODO: not blank
        public string TargetAccountTitle;

        [FieldFixedLength(18)]
        // TODO: \d{16} card number no hyphens
        public string LodgementReference;

        [FieldFixedLength(7)]
        public string TraceRecordBSB;

        [FieldFixedLength(9)]
        [FieldAlign(AlignMode.Right, ' ')]
        public string TraceRecordAccountNumber;

        [FieldFixedLength(16)]
        // TODO: not blank
        public string RemitterName;

        [FieldFixedLength(8)]
        [FieldAlign(AlignMode.Right, '0')]
        [FieldConverter(typeof(CurrencyConverter))]
        public decimal WithholdingTaxAmount;

        public DetailRecord()
        {
            RecordType = 1;
        }

        public void SetBSB(int bank, Common.BSB.State state, int branch)
        {
            BSB = Common.BSB.Encode(bank, state, branch);
        }

        private void SetTraceBSB(int bank, Common.BSB.State state, int branch)
        {
            TraceRecordBSB = Common.BSB.Encode(bank, state, branch);
        }
    }
}

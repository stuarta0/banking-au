using Banking.AU.ABA.Converters;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Records
{
    [FixedLengthRecord]
    public class DescriptiveRecord
    {
        [FieldFixedLength(1)]
        public int RecordType;

        [FieldFixedLength(17)]
        public string Blank1;

        [FieldFixedLength(2)]
        [FieldAlign(AlignMode.Right, '0')]
        public int ReelSequenceNumber;

        [FieldFixedLength(3)]
        public string FinancialInstitution;

        [FieldFixedLength(7)]
        public string Blank2;

        [FieldFixedLength(26)]
        // TODO: Not null (i.e. blank)
        public string UserSpecification;

        [FieldFixedLength(6)]
        [FieldAlign(AlignMode.Right, '0')]
        public int UserIdentificationNumber;

        [FieldFixedLength(12)]
        // TODO: Not null (i.e. blank)
        public string EntryDescriptor;

        [FieldFixedLength(6)]
        [FieldConverter(ConverterKind.Date, "ddMMyy")]
        public DateTime ProcessDate;

        [FieldFixedLength(40)]
        public string Blank3;

        public DescriptiveRecord()
        {
            RecordType = 0;
            ReelSequenceNumber = 1;
            ProcessDate = DateTime.Today;
        }
    }
}

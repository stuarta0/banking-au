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
        public readonly string Blank1;

        /// <summary>
        /// Identifies multiple files in a single batch. Must start at 1.
        /// Required if number or total of transactions exceed file limits (10 characters or $99,999,999.99, or 99,999 transactions).
        /// </summary>
        [FieldFixedLength(2)]
        [FieldAlign(AlignMode.Right, '0')]
        public int ReelSequenceNumber;

        /// <summary>
        /// Must be approved Financial Institution abbreviation. Bank of Queensland's abbreviation is BQL, Westpac's abbreviation is "WBC". Consult your Bank for correct abbreviation.
        /// </summary>
        [FieldFixedLength(3)]
        public string FinancialInstitution;

        [FieldFixedLength(7)]
        public readonly string Blank2;

        /// <summary>
        /// Must be User Preferred Specification as advised by User's FI. All coded character set valid. Must not be all blanks.
        /// </summary>
        [FieldFixedLength(26)]
        public string UserPreferredName;

        /// <summary>
        /// Must be User Identification Number which is allocated by APCA.
        /// Contrary to its description, this number identifies the financial institution, not the user. Each FI has its own number (or possibly several, depending on the size of the bank) which is issued by APCA. This number does not change between batches; it’s tied to the bank and, potentially, the account. Most banks document this number somewhere in their internet banking portal instructions.
        /// </summary>
        [FieldFixedLength(6)]
        [FieldAlign(AlignMode.Right, '0')]
        public int UserIdentificationNumber;

        /// <summary>
        /// Description of entries on file e.g. "PAYROLL". All coded character set valid. Must not be all blanks.
        /// </summary>
        [FieldFixedLength(12)]
        public string EntryDescriptor;

        [FieldFixedLength(6)]
        [FieldConverter(ConverterKind.Date, "ddMMyy")]
        public DateTime ProcessDate;

        [FieldFixedLength(40)]
        public readonly string Blank3;

        public DescriptiveRecord()
        {
            RecordType = 0;
            ReelSequenceNumber = 1;
            ProcessDate = DateTime.Today;
        }
    }
}

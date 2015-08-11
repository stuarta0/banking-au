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

        /// <summary>
        /// Use <see cref="Banking.AU.Common.BSB"/> for correct format. 
        /// For credits to Employee Benefits Card accounts, field must always contain BSB 032-898.
        /// </summary>
        [FieldFixedLength(7)]
        public string BSB;

        /// <summary>
        /// Account number to be credited/debited. Numeric, hyphens and blanks only are valid. Must not contain all blanks (unless a credit card transaction) or zeros. Leading zeros which are part of a valid account number must be shown, e.g. 00-1234. 
        /// Where account number exceeds nine characters, edit out hyphens.
        /// For credits to Employee Benefits Card accounts, Account Number field must always be 999999.
        /// </summary>
        [FieldFixedLength(9)]
        [FieldAlign(AlignMode.Right, ' ')]
        public string AccountNumber;

        /// <summary>
        /// Can be used to indicate that a particular record represents a change to a prior record in the batch, or to existing details held on file for the payee. It’s also clear that not every financial institution pays attention to this field. Unless you are dealing with thousands of payments at a time, you should leave this field blank to make it clear that each record represents a separate payment.
        /// Default None.
        /// </summary>
        [FieldFixedLength(1)]
        [FieldConverter(typeof(EnumConverter), typeof(Indicator))]
        public Indicator Indicator;

        /// <summary>
        /// In most cases, you should use CreditItem (50), which represents a non-specific credit to the bank account. For payroll transactions, use Pay (53). The other transaction codes appear to be of relevance to the ATO and superannuation funds only.
        /// Default CreditItem.
        /// </summary>
        [FieldFixedLength(2)]
        [FieldConverter(typeof(EnumConverter), typeof(TransactionCode))]
        public TransactionCode TransactionCode;

        /// <summary>
        /// Amount of transaction in dollars. Must be greater than zero.
        /// </summary>
        [FieldFixedLength(10)]
        [FieldAlign(AlignMode.Right, '0')]
        [FieldConverter(typeof(CurrencyConverter))]
        public decimal Amount;

        /// <summary>
        /// Title of Account to be credited/debited. All coded character set valid. Must not be all blanks.
        /// Desirable Format for Transaction Account credits:
        /// -  Surname (period)
        ///    Blank
        /// -  given name with blanks between each name
        /// </summary>
        [FieldFixedLength(32)]
        public string TargetAccountTitle;

        /// <summary>
        /// This is the text that appears on the payee’s bank statement.
        /// All coded character set valid. Field must contain only the 16 character Employee Benefits Card number; for example 5550033890123456.
        /// No leading spaces, zeroes, hyphens or other characters can be included.
        /// </summary>
        [FieldFixedLength(18)]
        public string LodgementReference;

        /// <summary>
        /// BSB of User to enable retracing of the entry to its source if necessary.
        /// Use <see cref="Banking.AU.Common.BSB"/> for correct format. 
        /// This is the BSB of your bank account.
        /// </summary>
        [FieldFixedLength(7)]
        public string TraceRecordBSB;

        /// <summary>
        /// Account number of User to enable retracing of the entry to its source if necessary.
        /// This is the Account Number of your bank account.
        /// </summary>
        [FieldFixedLength(9)]
        [FieldAlign(AlignMode.Right, ' ')]
        public string TraceRecordAccountNumber;

        /// <summary>
        /// Name of originator of the entry. This may vary from Name of the User. All coded character set valid. Must not contain all blanks.
        /// If your bank supports it, this lets you track the name of the person in your organisation who authorised the payment.
        /// </summary>
        [FieldFixedLength(16)]
        public string RemitterName;

        /// <summary>
        /// Amount of withholding tax in dollars. Must be greater than zero.
        /// </summary>
        [FieldFixedLength(8)]
        [FieldAlign(AlignMode.Right, '0')]
        [FieldConverter(typeof(CurrencyConverter))]
        public decimal WithholdingTaxAmount;

        public DetailRecord()
        {
            RecordType = 1;
            Indicator = Records.Indicator.None;
            TransactionCode = Records.TransactionCode.CreditItem;
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

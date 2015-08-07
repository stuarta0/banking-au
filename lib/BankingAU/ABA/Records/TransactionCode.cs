using Banking.AU.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Records
{
    public enum TransactionCode
    {
        /// <summary>
        /// Externally initiated debit items.
        /// </summary>
        [FileRepresentation("13")]
        DebitItem = 13,

        /// <summary>
        /// Externally initiated credit items with the exception of those bearing Transaction Codes.
        /// </summary>
        [FileRepresentation("50")]
        CreditItem = 50,

        /// <summary>
        /// Australian Government Security Interest.
        /// </summary>
        [FileRepresentation("51")]
        SecurityInterest = 51,

        /// <summary>
        /// Family Allowance.
        /// </summary>
        [FileRepresentation("52")]
        FamilyAllowance = 52,

        /// <summary>
        /// Pay.
        /// </summary>
        [FileRepresentation("53")]
        Pay = 53,

        /// <summary>
        /// Pension.
        /// </summary>
        [FileRepresentation("54")]
        Pension = 54,

        /// <summary>
        /// Allotment.
        /// </summary>
        [FileRepresentation("55")]
        Allotment = 55,

        /// <summary>
        /// Dividend.
        /// </summary>
        [FileRepresentation("56")]
        Dividend = 56,

        /// <summary>
        /// Debenture/Note Interest.
        /// </summary>
        [FileRepresentation("57")]
        DebentureInterest = 57
    }
}

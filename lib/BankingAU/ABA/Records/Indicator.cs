using Banking.AU.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Records
{
    public enum Indicator
    {
        [FileRepresentation(" ")]
        None,

        /// <summary>
        /// For new or varied Bank/State/Branch number or name details (N).
        /// </summary>
        [FileRepresentation("N")]
        NewOrVaried,
        
        /// <summary>
        /// Dividend paid to a resident of a country where a double tax agreement is in force (W).
        /// </summary>
        [FileRepresentation("W")]
        DividendPaidDoubleTax,

        /// <summary>
        /// Dividend paid to a resident of any other country (X).
        /// </summary>
        [FileRepresentation("X")]
        DividendPaid,

        /// <summary>
        /// Interest paid to all non-residents (Y).
        /// </summary>
        [FileRepresentation("Y")]
        InterestPaid
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Common
{
    public static class Bsb
    {
        /// <summary>
        /// Value represents Australian BSB state code.
        /// </summary>
        public enum State
        {
            ACT_NSW = 2,
            VIC = 3,
            QLD = 4,
            SA_NT = 5,
            WA = 6,
            TAS = 7
        }

        /// <summary>
        /// Encodes a BSB number in the format "000-000"
        /// </summary>
        /// <param name="bank">Two digit bank code.</param>
        /// <param name="state">State of branch.</param>
        /// <param name="branch">Three digit branch code.</param>
        /// <returns></returns>
        public static string Encode(int bank, State state, int branch)
        {
            return Encode(bank, (int)state, branch);
        }

        /// <summary>
        /// Encodes a BSB number in the format "000-000"
        /// </summary>
        /// <param name="bank">Two digit bank code.</param>
        /// <param name="state">Single digit state code.</param>
        /// <param name="branch">Three digit branch code.</param>
        /// <returns></returns>
        public static string Encode(int bank, int state, int branch)
        {
            if (bank < 0 || bank > 99)
                throw new ArgumentException("Bank must be a number between 0 and 99.");
            if (state < 0 || state > 9)
                throw new ArgumentException("State must be a number between 0 and 9.");
            if (branch < 0 || branch > 999)
                throw new ArgumentException("Branch must be a number between 0 and 999.");
            return String.Format("{0:D2}{1}-{2:D3}", bank, state, branch);
        }
    }
}

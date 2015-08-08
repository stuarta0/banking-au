using Banking.AU.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Westpac.QuickSuper
{
    public enum Salutation
    {
        /// <summary>
        /// Abbot.
        /// </summary>
        ABBOT,

        /// <summary>
        /// Doctor.
        /// </summary>
        DR,

        /// <summary>
        /// Ms.
        /// </summary>
        MS,

        /// <summary>
        /// Able Seaman.
        /// </summary>
        AB,

        /// <summary>
        /// Earl.
        /// </summary>
        EARL,

        /// <summary>
        /// Nurse.
        /// </summary>
        NURSE,

        /// <summary>
        /// Admiral.
        /// </summary>
        ADML,

        /// <summary>
        /// Engineer.
        /// </summary>
        ENGR,

        /// <summary>
        /// Officer Cadet.
        /// </summary>
        OCDT,

        /// <summary>
        /// Air Chief Marshal.
        /// </summary>
        ACM,

        /// <summary>
        /// Father.
        /// </summary>
        FR,

        /// <summary>
        /// Pastor.
        /// </summary>
        PASTOR,

        /// <summary>
        /// Air Commodore.
        /// </summary>
        AIRCDRE,

        /// <summary>
        /// Flight Lieutenant.
        /// </summary>
        FLTLT,

        /// <summary>
        /// Petty Officer.
        /// </summary>
        PO,

        /// <summary>
        /// Air Marshal.
        /// </summary>
        AM,

        /// <summary>
        /// Flight Sergeant.
        /// </summary>
        FSGT,

        /// <summary>
        /// Pilot Officer.
        /// </summary>
        PLTOFF,

        /// <summary>
        /// Air Vice Marshal.
        /// </summary>
        AVM,

        /// <summary>
        /// Flying Officer.
        /// </summary>
        FLGOFF,

        /// <summary>
        /// Private.
        /// </summary>
        PTE,

        /// <summary>
        /// Aircraftman.
        /// </summary>
        AC,

        /// <summary>
        /// General.
        /// </summary>
        GEN,

        /// <summary>
        /// Professor.
        /// </summary>
        PROF,

        /// <summary>
        /// Aircraftwoman.
        /// </summary>
        ACW,

        /// <summary>
        /// Governor.
        /// </summary>
        GOV,

        /// <summary>
        /// Rabbi.
        /// </summary>
        RABBI,

        /// <summary>
        /// Alderman.
        /// </summary>
        ALD,

        /// <summary>
        /// Group Captain.
        /// </summary>
        GP_CAPT,

        /// <summary>
        /// Rear Admiral.
        /// </summary>
        RADM,

        /// <summary>
        /// Ambassador.
        /// </summary>
        AMBSR,

        /// <summary>
        /// Honourable.
        /// </summary>
        HON,

        /// <summary>
        /// Rector.
        /// </summary>
        RECTOR,

        /// <summary>
        /// Archbishop.
        /// </summary>
        ARCHBISHOP,

        /// <summary>
        /// Judge.
        /// </summary>
        JUDGE,

        /// <summary>
        /// Regimental Sergeant Major.
        /// </summary>
        RSM,

        /// <summary>
        /// Archdeacon.
        /// </summary>
        ARCHDEACON,

        /// <summary>
        /// Justice RSM-A Regimental Sergeant Major Of The Army.
        /// </summary>
        JUSTICE,

        /// <summary>
        /// Associate Professor.
        /// </summary>
        ASSOC_PROF,

        /// <summary>
        /// Lady.
        /// </summary>
        LADY,

        /// <summary>
        /// Reverend.
        /// </summary>
        REV,

        /// <summary>
        /// Baron.
        /// </summary>
        BARON,

        /// <summary>
        /// Lance Bombardier.
        /// </summary>
        LBDR,

        /// <summary>
        /// Right Honourable.
        /// </summary>
        RTHON,

        /// <summary>
        /// Baroness.
        /// </summary>
        BARONESS,

        /// <summary>
        /// Lance Corporal.
        /// </summary>
        LCPL,

        /// <summary>
        /// Right Reverend.
        /// </summary>
        RT_REV,

        /// <summary>
        /// Bishop.
        /// </summary>
        BISHOP,

        /// <summary>
        /// Leading Aircraftman.
        /// </summary>
        LAC,

        /// <summary>
        /// Seaman.
        /// </summary>
        SMN,

        /// <summary>
        /// Bombardier.
        /// </summary>
        BDR,

        /// <summary>
        /// Leading Aircraftwoman.
        /// </summary>
        LACW,

        /// <summary>
        /// Second Lieutenant.
        /// </summary>
        [FileRepresentation("2LT")]
        SECOND_LT,

        /// <summary>
        /// Brigadier.
        /// </summary>
        BRIG,

        /// <summary>
        /// Leading Seaman.
        /// </summary>
        LS,

        /// <summary>
        /// Senator.
        /// </summary>
        SEN,

        /// <summary>
        /// Brother.
        /// </summary>
        BR,

        /// <summary>
        /// Lieutenant (Army).
        /// </summary>
        LT,

        /// <summary>
        /// Senior.
        /// </summary>
        SNR,

        /// <summary>
        /// Cadet.
        /// </summary>
        CDT,

        /// <summary>
        /// Lieutenant (Navy).
        /// </summary>
        LEUT,

        /// <summary>
        /// Sergeant.
        /// </summary>
        SGT,

        /// <summary>
        /// Canon.
        /// </summary>
        CANON,

        /// <summary>
        /// Lieutenant Colonel.
        /// </summary>
        LTCOL,

        /// <summary>
        /// Sir.
        /// </summary>
        SIR,

        /// <summary>
        /// Captain (Army).
        /// </summary>
        CAPT,

        /// <summary>
        /// Lieutenant Commander.
        /// </summary>
        LCDR,

        /// <summary>
        /// Sister.
        /// </summary>
        SR,

        /// <summary>
        /// Captain (Navy).
        /// </summary>
        CAPT_RAN,

        /// <summary>
        /// Lieutenant General.
        /// </summary>
        LTGEN,

        /// <summary>
        /// Sister Superior.
        /// </summary>
        SISTER_SUP,

        /// <summary>
        /// Cardinal.
        /// </summary>
        CARDNL,

        /// <summary>
        /// Lieutenant Governor.
        /// </summary>
        LTGOV,

        /// <summary>
        /// Squadron Leader.
        /// </summary>
        SQNLDR,

        /// <summary>
        /// Chaplain.
        /// </summary>
        CHAP,

        /// <summary>
        /// Lord.
        /// </summary>
        LORD,

        /// <summary>
        /// Staff Cadet.
        /// </summary>
        SCDT,

        /// <summary>
        /// Chief Petty Officer.
        /// </summary>
        CPO,

        /// <summary>
        /// Madam.
        /// </summary>
        MADAM,

        /// <summary>
        /// Staff Sergeant.
        /// </summary>
        SSGT,

        /// <summary>
        /// Colonel.
        /// </summary>
        COL,

        /// <summary>
        /// Madame.
        /// </summary>
        MADAME,

        /// <summary>
        /// Station Master.
        /// </summary>
        SM,

        /// <summary>
        /// Commander.
        /// </summary>
        CMDR,

        /// <summary>
        /// Major.
        /// </summary>
        MAJ,

        /// <summary>
        /// Sub Lieutenant.
        /// </summary>
        SBLT,

        /// <summary>
        /// Commissioner.
        /// </summary>
        CMM,

        /// <summary>
        /// Major General.
        /// </summary>
        MAJGEN,

        /// <summary>
        /// Superintendent.
        /// </summary>
        SUPT,

        /// <summary>
        /// Commodore.
        /// </summary>
        CDRE,

        /// <summary>
        /// Manager.
        /// </summary>
        MGR,

        /// <summary>
        /// Swami.
        /// </summary>
        SWAMI,

        /// <summary>
        /// Constable.
        /// </summary>
        CONST,

        /// <summary>
        /// Master.
        /// </summary>
        MSTR,

        /// <summary>
        /// Vice Admiral.
        /// </summary>
        VADM,

        /// <summary>
        /// Consul.
        /// </summary>
        CONSUL,

        /// <summary>
        /// Mayor.
        /// </summary>
        MAYOR,

        /// <summary>
        /// Vice Commander.
        /// </summary>
        VCE_CMNDR,

        /// <summary>
        /// Corporal.
        /// </summary>
        CPL,

        /// <summary>
        /// Mayoress.
        /// </summary>
        MAYORESS,

        /// <summary>
        /// Viscount.
        /// </summary>
        VISCOUNT,

        /// <summary>
        /// Count.
        /// </summary>
        COUNT,

        /// <summary>
        /// Midshipman.
        /// </summary>
        MIDN,

        /// <summary>
        /// Warrant Officer (Air Force).
        /// </summary>
        WOFF,

        /// <summary>
        /// Countess.
        /// </summary>
        COUNTESS,

        /// <summary>
        /// Miss.
        /// </summary>
        MISS,

        /// <summary>
        /// Warrant Officer (Navy).
        /// </summary>
        WO,

        /// <summary>
        /// Dame.
        /// </summary>
        DAME,

        /// <summary>
        /// Mister WO1 Warrant Officer Class 1.
        /// </summary>
        MR,

        /// <summary>
        /// Deacon.
        /// </summary>
        DEACON,

        /// <summary>
        /// Monsignor WO2 Warrant Officer Class 2.
        /// </summary>
        MON,

        /// <summary>
        /// Deaconess.
        /// </summary>
        DEACONESS,

        /// <summary>
        /// Most Reverend.
        /// </summary>
        MOST_REV,

        /// <summary>
        /// Warrant Officer Of The Air Force.
        /// </summary>
        WOFF_AF,

        /// <summary>
        /// Dean.
        /// </summary>
        DEAN,

        /// <summary>
        /// Mother.
        /// </summary>
        MTHR,

        /// <summary>
        ///  Warrant Officer Of The Navy.
        /// </summary>
        WO_N,

        /// <summary>
        /// Deputy Superintendent.
        /// </summary>
        DEPUTY_SUPT,

        /// <summary>
        /// Mrs.
        /// </summary>
        MRS,

        /// <summary>
        /// Wing Commander.
        /// </summary>
        WCDR,

        /// <summary>
        /// Director.
        /// </summary>
        DIRECTOR
    }
}

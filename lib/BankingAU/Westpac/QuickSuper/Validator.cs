using Banking.AU.Common;
using Banking.AU.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.Westpac.QuickSuper
{
    public class Validator : IValidator<ContributionRecord>
    {
        static Validator()
        {
            SALUTATIONS = new Dictionary<string,string>();


//"ABBOT","Abbot"
//"DR","Doctor"
//"MS","Ms"
//"AB","Able Seaman"
//"EARL","Earl"
//"NURSE","Nurse"
//"ADML","Admiral"
//"ENGR","Engineer"
//"OCDT","Officer Cadet"
//"ACM","Air Chief Marshal"
//"FR","Father"
//"PASTOR","Pastor"
//"AIRCDRE","Air Commodore"
//"FLTLT","Flight Lieutenant"
//"PO","Petty Officer"
//"AM","Air Marshal"
//"FSGT","Flight Sergeant"
//"PLTOFF","Pilot Officer"
//"AVM","Air Vice Marshal"
//"FLGOFF","Flying Officer"
//"PTE","Private"
//"AC","Aircraftman"
//"GEN","General"
//"PROF","Professor"
//"ACW","Aircraftwoman"
//"GOV","Governor"
//"RABBI","Rabbi"
//"ALD","Alderman"
//"GP CAPT","Group Captain"
//"RADM","Rear Admiral"
//"AMBSR","Ambassador"
//"HON","Honourable"
//"RECTOR","Rector"
//"ARCHBISHOP","Archbishop"
//"JUDGE","Judge"
//"RSM","Regimental Sergeant Major"
//"ARCHDEACON","Archdeacon"
//"JUSTICE","Justice RSM-A Regimental Sergeant Major Of The Army"
//"ASSOC PROF","Associate Professor"
//"LADY","Lady"
//"REV","Reverend"
//"BARON","Baron"
//"LBDR","Lance Bombardier"
//"RTHON","Right Honourable"
//"BARONESS","Baroness"
//"LCPL","Lance Corporal"
//"RT REV","Right Reverend"
//"BISHOP","Bishop"
//"LAC","Leading Aircraftman"
//"SMN","Seaman"
//"BDR","Bombardier"
//"LACW","Leading Aircraftwoman"
//"2LT","Second Lieutenant"
//"BRIG","Brigadier"
//"LS","Leading Seaman"
//"SEN","Senator"
//"BR","Brother"
//"LT","Lieutenant (Army)"
//"SNR","Senior"
//"CDT","Cadet"
//"LEUT","Lieutenant (Navy)"
//"SGT","Sergeant"
//"CANON","Canon"
//"LTCOL","Lieutenant Colonel"
//"SIR","Sir"
//"CAPT","Captain (Army)"
//"LCDR","Lieutenant Commander"
//"SR","Sister"
//"CAPT, RAN","Captain (Navy)"
//"LTGEN","Lieutenant General"
//"SISTER SUP","Sister Superior"
//"CARDNL","Cardinal"
//"LTGOV","Lieutenant Governor"
//"SQNLDR","Squadron Leader"
//"CHAP","Chaplain"
//"LORD","Lord"
//"SCDT","Staff Cadet"
//"CPO","Chief Petty Officer"
//"MADAM","Madam"
//"SSGT","Staff Sergeant"
//"COL","Colonel"
//"MADAME","Madame"
//"SM","Station Master"
//"CMDR","Commander"
//"MAJ","Major"
//"SBLT","Sub Lieutenant"
//"CMM","Commissioner"
//"MAJGEN","Major General"
//"SUPT","Superintendent"
//"CDRE","Commodore"
//"MGR","Manager"
//"SWAMI","Swami"
//"CONST","Constable"
//"MSTR","Master"
//"VADM","Vice Admiral"
//"CONSUL","Consul"
//"MAYOR","Mayor"
//"VCE CMNDR","Vice Commander"
//"CPL","Corporal"
//"MAYORESS","Mayoress"
//"VISCOUNT","Viscount"
//"COUNT","Count"
//"MIDN","Midshipman"
//"WOFF","Warrant Officer (Air Force)"
//"COUNTESS","Countess"
//"MISS","Miss"
//"WO","Warrant Officer (Navy)"
//"DAME","Dame"
//"MR","Mister WO1 Warrant Officer Class 1"
//"DEACON","Deacon"
//"MON","Monsignor WO2 Warrant Officer Class 2"
//"DEACONESS","Deaconess"
//"MOST REV","Most Reverend"
//"WOFF-AF","Warrant Officer Of The Air Force"
//"DEAN","Dean"
//"MTHR","Mother"
//"WO-N"," Warrant Officer Of The Navy"
//"DEPUTY SUPT","Deputy Superintendent"
//"MRS","Mrs"
//"WCDR","Wing Commander"
//"DIRECTOR","Director"



//"BM","Bravery Medal"
//"KCVO","Knight Commander of the Royal Victorian Order"
//"BEM","British Empire Medal"
//"KG","Knight of the Garter"
//"COMDC","Commissioner of Declarations"
//"AK","Knight of the Order of Australia"
//"CH","Companion of Honour"
//"KT","Knight of the Thistle"
//"AC","Companion of the Order of Australia"
//"OAM","Medal of the Order of Australia - Order of St John"
//"CV","Cross of Valour"
//"MP","Member of Parliament"
//"DCMG","Dame Commander of the Order of Saint Michael and Saint George"
//"MHA","Member of the House of Assembly"
//"DCB","Dame Commander of the Order of the Bath"
//"MHR","Member of the House of Representatives"
//"DBE","Dame Commander of the Order of the British Empire"
//"MLA","Member of the Legislative Assembly"
//"DCVO","Dame Commander of the Royal Victorian Order"
//"MLC","Member of the Legislative Council"
//"AD","Dame of the Order of Australia"
//"AM","Member of the Order of Australia"
//"DFM","Distinguished Flying Medal"
//"MBE","Member of the Order of the British Empire"
//"DSC","Distinguished Service Cross"
//"MC","Military Cross"
//"DSM","Distinguished Service Medal"
//"OC","Officer Commanding"
//"ESQ","Esquire"
//"AO","Officer of the Order of Australia"
//"GC","George Cross"
//"OBE","Officer of the Order of the British Empire"
//"JNR","Junior"
//"OM","Order of Merit"
//"JP","Justice of the Peace"
//"QC","Queens Counsel"
//"KB","Knight Bachelor"
//"SNR","Senior"
//"KCMG","Knight Commander of the Order of Saint Michael and Saint George"
//"SC","Star of Courage"
//"KCB","Knight Commander of the Order of the Bath"
//"VC","Victoria Cross"
//"KBE","Knight Commander of the Order of the British Empire"
        }

        public IList<IValidationError<ContributionRecord>> Validate(ContributionRecord item)
        {
            var reference = new Regex(@"^[A-Za-z0-9_\-\.]{0,20}$");
            var alphanumeric = new Regex(@"[A-Za-z0-9]");
            var name = new Regex(@"^[A-Za-z'\-\s\.\(\)]{0,40}$");
            var gender = new Regex(@"^[MFIN]$");
            var phone = new Regex(@"");
            var email = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$");

            var result = new List<IValidationError<ContributionRecord>>();
            if (!reference.IsMatch(item.YourFileReference))
                result.Add(new ValidationError<ContributionRecord>(item, "YourFileReference does not match the requirements."));
            if (!alphanumeric.IsMatch(item.FamilyName))
                result.Add(new ValidationError<ContributionRecord>(item, "FamilyName does not match the requirements."));

            return result;
        }


        private static Dictionary<string, string> SALUTATIONS;
    }
}

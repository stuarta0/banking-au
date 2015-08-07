using Banking.AU.Common;
using Banking.AU.Common.Validation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.Westpac.QuickSuper
{
    public class Validator : IValidator<ContributionRecord>
    {
        static Validator()
        {
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
            var reference       = new Regex(@"^[A-Za-z0-9_\-\.]*$");
            var alphanumeric    = new Regex(@"^[A-Za-z0-9]*$");
            var name            = new Regex(@"^[A-Za-z'\-\s\.\(\)]*$");
            var gender          = new Regex(@"^[MFIN]$");
            var phone           = new Regex(@"^[0-9\-\s+\(\)]*$");
            var email           = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$");
            var state           = new Regex(@"^(AAT|ACT|NSW|NT|QLD|SA|TAS|VIC|WA)$");
            var postcode        = new Regex(@"^\d{4}$");
            var country         = new Regex(@"^[A-Za-z]{2}$");
            var memberId        = new Regex(@"^[A-Za-z0-9\-/]*$");
            var contribType     = new Regex(@"^SPOUSE$");

            var rules = new List<PropertyChecker>()
            {
                new PropertyChecker("YourFileReference") { Rule = reference },
                new PropertyChecker<DateTime?>("YourFileDate") { Func = (c, i, v) => {
                    if (v.HasValue)
                    {
                        if (v.Value < DateTime.Today.AddDays(-1) || v.Value > DateTime.Today.AddDays(14))
                            return String.Concat(c.Name, " must be between the previous banking day and less than 14 days in the future.");
                    }
                    return null;
                }},
                new PropertyChecker<DateTime>("ContributionPeriodStartDate") { IsMandatory = true, Func = (c, i, v) => {
                    if (v < DateTime.Today.AddYears(-2))
                        return String.Concat(c.Name, " must be no earlier than 2 years in the past.");
                    if (v > i.ContributionPeriodEndDate)
                        return String.Concat(c.Name, " must be before ContributionPeriodEndDate.");
                    return null;
                }},
                new PropertyChecker<DateTime>("ContributionPeriodEndDate") { IsMandatory = true, Func = (c, i, v) => {
                    if (v < i.ContributionPeriodStartDate)
                        return String.Concat(c.Name, " must be after ContributionPeriodStartDate.");
                    if (v > DateTime.Today.AddMonths(6))
                        return String.Concat(c.Name, " must be no later than 6 months in the future.");
                    return null;
                }},
                new PropertyChecker("EmployerID") { Rule = alphanumeric },
                new PropertyChecker("PayrollID") { MaxLength = 20 },
                new PropertyChecker("NameTitle"), // Limited to list of values
                new PropertyChecker("FamilyName") { IsMandatory = true, Rule = name, MaxLength = 40 },
                new PropertyChecker("GivenName") { IsMandatory = true, Rule = name, MaxLength = 40 },
                new PropertyChecker("OtherGivenName") { Rule = name, MaxLength = 40 },
                new PropertyChecker("NameSuffix"), // Limited to list of values
                new PropertyChecker<DateTime>("DateOfBirth") { IsMandatory = true, Func = (c, i, v) => {
                    if (v < DateTime.Today.AddYears(-100) || v > DateTime.Today)
                        return String.Concat(c.Name, " must be before today and greater than 100 years ago.");
                    return null;
                }},
                new PropertyChecker("Gender") { Rule = gender },
                new PropertyChecker("TaxFileNumber"),
                new PropertyChecker("PhoneNumber") { Rule = phone, MaxLength = 15 },
                new PropertyChecker("MobileNumber") { Rule = phone, MaxLength = 15 },
                new PropertyChecker("EmailAddress") { Rule = email, MaxLength = 60 },
                new PropertyChecker("AddressLine1") { MaxLength = 50 },
                new PropertyChecker("AddressLine2") { MaxLength = 50 },
                new PropertyChecker("AddressLine3") { MaxLength = 50 },
                new PropertyChecker("AddressLine4") { MaxLength = 50 },
                new PropertyChecker("Suburb") { MaxLength = 50 },
                new PropertyChecker("State") { Rule = state },
                new PropertyChecker("PostCode") { Rule = postcode },
                new PropertyChecker("Country") { Rule = country }, // limited to www.iso.org/iso/country_codes
                new PropertyChecker<DateTime?>("EmploymentStartDate") { Func = (c, i, v) => {
                    if (v.HasValue)
                    {
                        if (v < DateTime.Today.AddYears(-100) || v > DateTime.Today.AddMonths(6))
                            return String.Concat(c.Name, " must not be older than 100 years ago or after 6 months in the future.");
                        if (v > i.EmploymentEndDate)
                            return String.Concat(c.Name, " must be earlier than EmploymentEndDate.");
                    }
                    return null;
                }},
                new PropertyChecker<DateTime?>("EmploymentEndDate") { Func = (c,i,v) => {
                    if (v.HasValue)
                    {
                        if (v < DateTime.Today.AddYears(-100) || v > DateTime.Today.AddMonths(6))
                            return String.Concat(c.Name, " must not be older than 100 years ago or after 6 months in the future.");
                        if (v < i.EmploymentStartDate)
                            return String.Concat(c.Name, " must be earlier than EmploymentStartDate.");
                    }
                    return null;
                }},
                new PropertyChecker("EmploymentEndReason") { MaxLength = 80 },
                new PropertyChecker("FundID") { IsMandatory = true, Rule = alphanumeric },
                new PropertyChecker("FundName") { MaxLength = 60 },
                new PropertyChecker("FundEmployerID") { MaxLength = 20 },
                new PropertyChecker("MemberID") { Rule = memberId, MaxLength = 20 },
                new PropertyChecker("EmployerSuperGuaranteeAmount"),
                new PropertyChecker("EmployerAdditionalAmount"),
                new PropertyChecker("MemberSalarySacrificeAmount"),
                new PropertyChecker("MemberAdditionalAmount"),
                new PropertyChecker("OtherContributorType") { Rule = contribType },
                new PropertyChecker("OtherContributorName") { Rule = name, MaxLength = 80 },
                new PropertyChecker("YourContributionReference") { Rule = reference, MaxLength = 20 }
            };

            var result = new List<IValidationError<ContributionRecord>>();
            foreach (var r in rules)
            {
                var errors = r.Validate(item);
                if (errors.Count > 0)
                    result.AddRange(errors);
            }

            return result;
        }

        #region Helper Classes

        private class PropertyChecker : IValidator<ContributionRecord>
        {
            public string Name { get; private set; }
            public bool IsMandatory { get; set; }
            public int? MaxLength { get; set; }
            public Regex Rule { get; set; }
            protected PropertyInfo _prop;

            public PropertyChecker(string name)
            {
                Name = name;
                MaxLength = null;
                _prop = typeof(ContributionRecord).GetProperty(Name);
            }

            public virtual IList<IValidationError<ContributionRecord>> Validate(ContributionRecord item)
            {
                var result = new List<IValidationError<ContributionRecord>>();
                var value = _prop.GetValue(item, null);
                if (IsMandatory && value == null)
                    result.Add(new RecordError(item, Name, String.Concat(Name, " is mandatory but has been provided with no value.")));
                if (value != null)
                {
                    if (Rule != null && !Rule.IsMatch((string)value))
                        result.Add(new RecordError(item, Name, String.Concat(Name, " does not match required validation rules.")));
                    if (MaxLength.HasValue && ((string)value).Length > MaxLength)
                        result.Add(new RecordError(item, Name, String.Concat(Name, " must be less than ", MaxLength, ".")));
                }
                return result;
            }
        }

        private delegate string ValidateFunc<T>(PropertyChecker<T> checker, ContributionRecord item, T value);
        private class PropertyChecker<T> : PropertyChecker
        {
            public ValidateFunc<T> Func { get; set; }

            public PropertyChecker(string name)
                : base(name)
            { }

            public override IList<IValidationError<ContributionRecord>> Validate(ContributionRecord item)
            {
                var result = base.Validate(item);
                if (Func != null)
                {
                    var value = _prop.GetValue(item, null);
                    if (value != null && !(value is T))
                    {
                        try { value = Convert.ChangeType(value, typeof(T)); }
                        catch { }
                        if (!(value is T))
                            result.Add(new RecordError(item, Name, String.Concat(Name, " must of type ", typeof(T).Name, ".")));
                        return result;
                    }

                    var message = Func(this, item, (T)value);
                    if (message != null)
                        result.Add(new RecordError(item, Name, message));
                }

                return result;
            }
        }

        private class RecordError : ValidationError<ContributionRecord>
        {
            public RecordError(ContributionRecord item, string member, string message)
                : base(item, member, message)
            { }
        }

        #endregion
    }
}

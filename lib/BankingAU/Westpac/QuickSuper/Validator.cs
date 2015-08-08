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

            var rules = new List<Checker>()
            {
                new Checker("YourFileReference") { Rule = reference },
                new Checker<DateTime?>("YourFileDate") { Func = (c, i, v) => {
                    if (v.HasValue)
                    {
                        if (v.Value < DateTime.Today.AddDays(-1) || v.Value > DateTime.Today.AddDays(14))
                            return String.Concat(c.Name, " must be between the previous banking day and less than 14 days in the future.");
                    }
                    return null;
                }},
                new Checker<DateTime>("ContributionPeriodStartDate") { IsMandatory = true, Func = (c, i, v) => {
                    if (v < DateTime.Today.AddYears(-2))
                        return String.Concat(c.Name, " must be no earlier than 2 years in the past.");
                    if (v > i.ContributionPeriodEndDate)
                        return String.Concat(c.Name, " must be before ContributionPeriodEndDate.");
                    return null;
                }},
                new Checker<DateTime>("ContributionPeriodEndDate") { IsMandatory = true, Func = (c, i, v) => {
                    if (v < i.ContributionPeriodStartDate)
                        return String.Concat(c.Name, " must be after ContributionPeriodStartDate.");
                    if (v > DateTime.Today.AddMonths(6))
                        return String.Concat(c.Name, " must be no later than 6 months in the future.");
                    return null;
                }},
                new Checker("EmployerID") { Rule = alphanumeric },
                new Checker("PayrollID") { MaxLength = 20 },
                new Checker("NameTitle"), // Limited to list of values
                new Checker("FamilyName") { IsMandatory = true, Rule = name, MaxLength = 40 },
                new Checker("GivenName") { IsMandatory = true, Rule = name, MaxLength = 40 },
                new Checker("OtherGivenName") { Rule = name, MaxLength = 40 },
                new Checker("NameSuffix"), // Limited to list of values
                new Checker<DateTime>("DateOfBirth") { IsMandatory = true, Func = (c, i, v) => {
                    if (v < DateTime.Today.AddYears(-100) || v > DateTime.Today)
                        return String.Concat(c.Name, " must be before today and greater than 100 years ago.");
                    return null;
                }},
                new Checker("Gender") { Rule = gender },
                new Checker("TaxFileNumber"),
                new Checker("PhoneNumber") { Rule = phone, MaxLength = 15 },
                new Checker("MobileNumber") { Rule = phone, MaxLength = 15 },
                new Checker("EmailAddress") { Rule = email, MaxLength = 60 },
                new Checker("AddressLine1") { MaxLength = 50 },
                new Checker("AddressLine2") { MaxLength = 50 },
                new Checker("AddressLine3") { MaxLength = 50 },
                new Checker("AddressLine4") { MaxLength = 50 },
                new Checker("Suburb") { MaxLength = 50 },
                new Checker("State") { Rule = state },
                new Checker("PostCode") { Rule = postcode },
                new Checker("Country") { Rule = country }, // limited to www.iso.org/iso/country_codes
                new Checker<DateTime?>("EmploymentStartDate") { Func = (c, i, v) => {
                    if (v.HasValue)
                    {
                        if (v < DateTime.Today.AddYears(-100) || v > DateTime.Today.AddMonths(6))
                            return String.Concat(c.Name, " must not be older than 100 years ago or after 6 months in the future.");
                        if (v > i.EmploymentEndDate)
                            return String.Concat(c.Name, " must be earlier than EmploymentEndDate.");
                    }
                    return null;
                }},
                new Checker<DateTime?>("EmploymentEndDate") { Func = (c,i,v) => {
                    if (v.HasValue)
                    {
                        if (v < DateTime.Today.AddYears(-100) || v > DateTime.Today.AddMonths(6))
                            return String.Concat(c.Name, " must not be older than 100 years ago or after 6 months in the future.");
                        if (v < i.EmploymentStartDate)
                            return String.Concat(c.Name, " must be earlier than EmploymentStartDate.");
                    }
                    return null;
                }},
                new Checker("EmploymentEndReason") { MaxLength = 80 },
                new Checker("FundID") { IsMandatory = true, Rule = alphanumeric },
                new Checker("FundName") { MaxLength = 60 },
                new Checker("FundEmployerID") { MaxLength = 20 },
                new Checker("MemberID") { Rule = memberId, MaxLength = 20 },
                new Checker("EmployerSuperGuaranteeAmount"),
                new Checker("EmployerAdditionalAmount"),
                new Checker("MemberSalarySacrificeAmount"),
                new Checker("MemberAdditionalAmount"),
                new Checker("OtherContributorType") { Rule = contribType },
                new Checker("OtherContributorName") { Rule = name, MaxLength = 80 },
                new Checker("YourContributionReference") { Rule = reference, MaxLength = 20 }
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

        private class Checker : IValidator<ContributionRecord>
        {
            public string Name { get; private set; }
            public bool IsMandatory { get; set; }
            public int? MaxLength { get; set; }
            public Regex Rule { get; set; }
            protected FieldInfo _field;

            public Checker(string name)
            {
                Name = name;
                MaxLength = null;
                _field = typeof(ContributionRecord).GetField(Name);
            }

            public virtual IList<IValidationError<ContributionRecord>> Validate(ContributionRecord item)
            {
                var result = new List<IValidationError<ContributionRecord>>();
                var value = _field.GetValue(item);
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

        private delegate string ValidateFunc<T>(Checker<T> checker, ContributionRecord item, T value);
        private class Checker<T> : Checker
        {
            public ValidateFunc<T> Func { get; set; }

            public Checker(string name)
                : base(name)
            { }

            public override IList<IValidationError<ContributionRecord>> Validate(ContributionRecord item)
            {
                var result = base.Validate(item);
                if (Func != null)
                {
                    var value = _field.GetValue(item);
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

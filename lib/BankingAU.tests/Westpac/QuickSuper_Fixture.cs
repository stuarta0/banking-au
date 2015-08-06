using Banking.AU.Westpac.QuickSuper;
using FileHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.Westpac
{
    [TestFixture]
    public class QuickSuper_Fixture
    {
        [Test]
        public void Instantiation()
        {
            var reader = new ContributionRecord();
        }

        [Test]
        public void Write_test()
        {
            var engine = new DelimitedFileEngine<ContributionRecord>();
            foreach (var field in engine.Options.Fields)
            {
                if (field.FieldType == typeof(DateTime))
                {
                    //field.Converter = new DateConvertor();
                }
            }
        }
    }
}

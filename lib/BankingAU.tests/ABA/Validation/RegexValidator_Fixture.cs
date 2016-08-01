using Banking.AU.ABA.Validation;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.tests.ABA.Validation.DetailRecord
{
    [TestFixture]
    public class RegexValidator_Fixture
    {
        private class FakeItem
        {
            public string Value;
            public FakeItem() { }
            public FakeItem(string value)
            {
                Value = value;
            }
        }

        private RegexValidator<FakeItem> GetValidator()
        {
            return new RegexValidator<FakeItem>(
                new Regex("^[0-9]{4}$"), new Regex("[^0-9]"),
                i => i.Value, (i, v) => i.Value = v);
        }

        [Test]
        public void Validate_correct()
        {
            var errors = new List<Exception>(GetValidator().Validate(new FakeItem("1234")));
            Assert.AreEqual(0, errors.Count);
        }

        [Test]
        public void Validate_null()
        {
            var errors = new List<Exception>(GetValidator().Validate(new FakeItem(null)));
            Assert.IsNotNull(errors.Find(e => "Value cannot be null".Equals(e.Message)));
        }

        [Test]
        public void Validate_incorrect()
        {
            var errors = new List<Exception>(GetValidator().Validate(new FakeItem("1234abc")));
            Assert.IsNotNull(errors.Find(e => "Value '1234abc' does not match pattern: ^[0-9]{4}$".Equals(e.Message)));
        }

        [Test]
        public void Clean_correct()
        {
            var f = new FakeItem("1234");
            GetValidator().Clean(f);
            Assert.AreEqual("1234", f.Value);
        }

        [Test]
        public void Clean_incorrect_but_valid()
        {
            var f = new FakeItem("1234abc");
            GetValidator().Clean(f);
            Assert.AreEqual("1234", f.Value);
        }

        [Test]
        public void Clean_incorrect_invalid()
        {
            var f = new FakeItem("abc");
            Assert.Throws<FormatException>(() =>
            {
                GetValidator().Clean(f);
            });
        }

        [Test]
        public void Clean_null()
        {
            var f = new FakeItem(null);
            Assert.Throws<ArgumentNullException>(() =>
            {
                GetValidator().Clean(f);
            });
        }
    }
}

using Banking.AU.ABA.Validation;
using Banking.AU.Common.Validation;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.ABA.Validation.DetailRecord
{
    [TestFixture]
    public class CurrencyValidator_Fixture
    {
        private class FakeItem
        {
            public decimal Value;
            public FakeItem() { }
            public FakeItem(decimal value)
            {
                Value = value;
            }
        }

        private CurrencyValidator<FakeItem> GetValidator(int length)
        {
            return new CurrencyValidator<FakeItem>(length, i => i.Value, (i, v) => i.Value = v);
        }

        [Test]
        public void Zero_valid()
        {
            var errors = new List<Exception>(GetValidator(10).Validate(new FakeItem()));
            Assert.IsTrue(errors.Count == 0);
        }

        [Test]
        public void Negative_invalid()
        {
            var errors = new List<Exception>(GetValidator(10).Validate(new FakeItem(-10.00m)));
            Assert.IsNotNull(errors.Find(e => "Value must be greater than zero.".Equals(e.Message)));
        }

        [Test]
        public void Max_exceeded()
        {
            // 5 chars = 000.00 therefore < $1,000.00 (up to $999.99)
            var errors = new List<Exception>(GetValidator(5).Validate(new FakeItem(1000.00m)));
            Assert.IsNotNull(errors.Find(e => "Value must be less than $1,000.00".Equals(e.Message)));
        }

        [Test]
        public void Clean_max_exceeded()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                GetValidator(5).Clean(new FakeItem(1000.00m));
            });
        }

        [Test]
        public void Clean_zero()
        {
            var item = new FakeItem(0m);
            GetValidator(10).Clean(item);
            Assert.AreEqual(0m, item.Value);
        }

        [Test]
        public void Clean_negative()
        {
            var item = new FakeItem(-1m);
            GetValidator(10).Clean(item);
            Assert.AreEqual(1m, item.Value);
        }

        [Test]
        public void Instantiate_invalid_length()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                GetValidator(0);
            });
        }
    }
}

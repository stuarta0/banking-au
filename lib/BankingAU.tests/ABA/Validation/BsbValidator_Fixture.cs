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
    public class BsbValidator_Fixture
    {
        private class FakeItem
        {
            public string Bsb;
            public FakeItem() { }
            public FakeItem(string bsb)
            {
                Bsb = bsb;
            }
        }

        private BsbValidator<FakeItem> GetValidator()
        {
            return new BsbValidator<FakeItem>(i => i.Bsb, (i, v) => i.Bsb = v);
        }

        [Test]
        public void Is_empty()
        {
            var errors = new List<IError>(GetValidator().Validate(new FakeItem()));
            Assert.IsNotNull(errors.Find(e => "BSB cannot be empty".Equals(e.Message)));
        }

        [Test]
        public void Format_valid()
        {
            var errors = new List<IError>(GetValidator().Validate(new FakeItem("123-456")));
            Assert.IsNull(errors.Find(e => "BSB must be in the format \"000-000\"".Equals(e.Message)));
        }

        [Test]
        public void Format_invalid()
        {
            var errors = new List<IError>(GetValidator().Validate(new FakeItem("123456")));
            Assert.IsNotNull(errors.Find(e => "BSB must be in the format \"000-000\"".Equals(e.Message)));
        }

        [Test]
        public void Clean_empty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                GetValidator().Clean(new FakeItem());
            });
        }

        [Test]
        public void Clean_valid()
        {
            var item = new FakeItem("123-456");
            GetValidator().Clean(item);
            Assert.AreEqual("123-456", item.Bsb);
        }

        [Test]
        public void Clean_valid_bad_formatting()
        {
            var item = new FakeItem(" 12.3- 456_");
            GetValidator().Clean(item);
            Assert.AreEqual("123-456", item.Bsb);
        }

        [Test]
        public void Clean_invalid()
        {
            Assert.Throws<FormatException>(() =>
            {
                GetValidator().Clean(new FakeItem("123-bad"));
            });
        }
    }
}

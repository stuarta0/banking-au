using System;
using System.Collections.Generic;
using NUnit.Framework;
using V = Banking.AU.ABA.Validation.DetailRecord;

namespace Banking.AU.tests.ABA.Validation.DetailRecord
{
    [TestFixture]
    public class CharsetValidator_Fixture
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

        private V.CharsetValidator<FakeItem> GetValidator()
        {
            return new V.CharsetValidator<FakeItem>(64,
                i => i.Value, (i, v) => i.Value = v);
        }

        [Test]
        public void Valid_charset()
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ- .<>()+$*{}-?\\/,;:!@#$%&'\"=~`|_";
            string pattern = @"\s\.\<\>\(\)\+\$\*\{\}\-\?\\/,;:!@#$%&'\x22=~`|_a-zA-Z0-9";
            string message = String.Format(@"Value '{0}' does not match pattern: ^[{1}]+$", chars, pattern);
            var item = new FakeItem()
            {
                Value = new string(chars.ToCharArray())
            };
            var errors = new List<Exception>(GetValidator().Validate(item));
            Assert.IsNull(errors.Find(e => message.Equals(e.Message)));
        }

        [Test]
        public void Invalid_charset()
        {
            string chars = @"^[]";
            string pattern = @"\s\.\<\>\(\)\+\$\*\{\}\-\?\\/,;:!@#$%&'\x22=~`|_a-zA-Z0-9";
            string message = String.Format(@"Value '{0}' does not match pattern: ^[{1}]+$", chars, pattern);
            var item = new FakeItem()
            {
                Value = new string(chars.ToCharArray())
            };
            var errors = new List<Exception>(GetValidator().Validate(item));
            Assert.IsNotNull(errors.Find(e => message.Equals(e.Message)));
        }
    }
}

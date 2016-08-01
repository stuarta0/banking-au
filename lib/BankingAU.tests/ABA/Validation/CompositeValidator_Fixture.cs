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
    public class CompositeValidator_Fixture
    {
        private class FakeItem
        {
            public int VisitedCount;
        }

        private class FakeValidator : IValidator<FakeItem>
        {
            public void Clean(FakeItem item) { item.VisitedCount++; }
            public IEnumerable<IError> Validate(FakeItem item) { item.VisitedCount++; yield break; }
        }

        private IValidator<FakeItem> GetValidator()
        {
            return new CompositeValidator<FakeItem>(new List<IValidator<FakeItem>>()
            {
                new FakeValidator(),
                new FakeValidator()
            });
        }

        [Test]
        public void All_validated()
        {
            var f = new FakeItem();
            // Note: without iterating the error list, Validation will not be performed
            var errors = new List<IError>(GetValidator().Validate(f));
            Assert.AreEqual(2, f.VisitedCount);
        }

        [Test]
        public void All_cleaned()
        {
            var f = new FakeItem();
            GetValidator().Clean(f);
            Assert.AreEqual(2, f.VisitedCount);
        }
    }
}

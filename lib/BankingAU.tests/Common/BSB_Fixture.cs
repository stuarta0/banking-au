using Banking.AU.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.Common
{
    [TestFixture]
    public class Bsb_Fixture
    {
        [Test]
        public void Encode_bsb()
        {
            // Arrange

            // Act
            var bsb = Bsb.Encode(73, Bsb.State.TAS, 123);

            // Assert
            Assert.AreEqual("737-123", bsb);
        }

        [Test]
        public void Encode_empty_bsb()
        {
            // Arrange

            // Act
            var bsb = Bsb.Encode(0, 0, 0);

            // Assert
            Assert.AreEqual("000-000", bsb);
        }
    }
}

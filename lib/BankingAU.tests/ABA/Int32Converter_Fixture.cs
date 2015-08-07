using Banking.AU.ABA.Converters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.ABA
{
    [TestFixture]
    public class Int32Converter_Fixture
    {
        [Test]
        public void From_int()
        {
            // Arrange
            var c = new Int32Converter(6);

            // Act
            var result = c.FieldToString(1234);

            // Assert
            Assert.AreEqual("001234", result);
        }

        [Test]
        public void To_int()
        {
            // Arrange
            var c = new Int32Converter(6);

            // Act
            var result = c.StringToField("001234");

            // Assert
            Assert.AreEqual(1234, result);
        }
    }
}

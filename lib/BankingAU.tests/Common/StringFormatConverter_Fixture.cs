using Banking.AU.Common.Converters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.Common
{
    [TestFixture]
    public class StringFormatConverter_Fixture
    {
        [Test]
        public void From_decimal()
        {
            // Arrange
            var c = new StringFormatConverter(typeof(decimal), "F2");

            // Act
            var result = c.FieldToString(1234.5678m);

            // Assert
            Assert.AreEqual("1234.57", result);
        }

        [Test]
        public void To_decimal()
        {
            // Arrange
            var c = new StringFormatConverter(typeof(decimal), "F2");

            // Act
            var result = c.StringToField("1234.57");

            // Assert
            Assert.AreEqual(1234.57m, result);
        }
        [Test]
        public void From_decimal_to_integer()
        {
            // Arrange
            var c = new StringFormatConverter(typeof(int), "F0");

            // Act
            var result = c.FieldToString(1234.5678m);

            // Assert
            Assert.AreEqual("1235", result);
        }

        [Test]
        public void To_integer_from_decimal()
        {
            // Arrange
            var c = new StringFormatConverter(typeof(int), "F0");

            // Act
            var result = c.StringToField("1235");

            // Assert
            Assert.AreEqual(1235.0m, result);
        }
    }
}

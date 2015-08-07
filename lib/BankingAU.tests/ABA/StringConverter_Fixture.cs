using Banking.AU.ABA.Converters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.ABA
{
    [TestFixture]
    public class StringConverter_Fixture
    {
        [Test]
        public void From_string()
        {
            // Arrange
            var c = new StringConverter(10);

            // Act
            var result = c.FieldToString("hello");

            // Assert
            Assert.AreEqual("     hello", result);
        }

        [Test]
        public void To_string()
        {
            // Arrange
            var c = new StringConverter(10);

            // Act
            var result = c.StringToField("     hello");

            // Assert
            Assert.AreEqual("hello", result);
        }
    }
}

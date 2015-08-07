using Banking.AU.ABA.Converters;
using Banking.AU.ABA.Records;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.ABA
{
    [TestFixture]
    public class EnumConverter_Fixture
    {
        [Test]
        public void From_indicator()
        {
            // Arrange
            var c = new EnumConverter(typeof(Indicator));

            // Act
            var result = c.FieldToString(Indicator.NewOrVaried);

            // Assert
            Assert.AreEqual("N", result);
        }

        [Test]
        public void To_indicator()
        {
            // Arrange
            var c = new EnumConverter(typeof(Indicator));

            // Act
            var result = c.StringToField("X");

            // Assert
            Assert.AreEqual(Indicator.DividendPaid, result);
        }

        [Test]
        public void From_transaction_code()
        {
            // Arrange
            var c = new EnumConverter(typeof(TransactionCode));

            // Act
            var result = c.FieldToString(TransactionCode.CreditItem);

            // Assert
            Assert.AreEqual("50", result);
        }

        [Test]
        public void To_transaction_code()
        {
            // Arrange
            var c = new EnumConverter(typeof(TransactionCode));

            // Act
            var result = c.StringToField("50");

            // Assert
            Assert.AreEqual(TransactionCode.CreditItem, result);
        }
    }
}

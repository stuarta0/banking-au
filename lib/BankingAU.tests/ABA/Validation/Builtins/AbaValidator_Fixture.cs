using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.tests.ABA.Validation.Builtins
{
    [TestFixture]
    public class AbaValidator_Fixture
    {
        //[Test]
        //public void FileTotalRecord_SumOfCount1_validation()
        //{
        //    // Arrange
        //    var validator = new Validator();
        //    var file = new AbaFile();
        //    file.DetailRecords.Add(new AU.ABA.Records.DetailRecord());
        //    file.DetailRecords.Add(new AU.ABA.Records.DetailRecord());
        //    file.FileTotalRecord = new AU.ABA.Records.FileTotalRecord()
        //    {
        //        CountOfType1 = 0
        //    };

        //    // Act
        //    var errors = validator.Validate(file);

        //    // Assert
        //    var sum = new ValidationError<AbaFile>(file, "FileTotalRecord", "SumOfCount1 does not equal the total number of DetailRecords.");
        //    Assert.IsTrue(errors.Contains(sum));
        //}
    }
}

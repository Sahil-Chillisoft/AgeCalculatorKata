using System;
using NUnit.Framework;

namespace AgeCalculator.Tests
{
    [TestFixture]
    public class AgeCalculatorTests
    {
        private AgeCalculator CreateAgeCalculator()
        {
            return new AgeCalculator();
        }

        [Test]
        public void CalculateAge_GivenDateOfBirthIsInFuture_ThrowException()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2021, 1, 1);
            var targetDate = new DateTime(2020, 1, 1);
            const string expectedOutput = "Unborn, date of birth is in the future.";

            //Act             
            var output = Assert.Throws<Exception>(() => CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate));

            //Assert
            Assert.AreEqual(expectedOutput, output.Message);
        }

        [Test]
        public void CalculateAge_GivenDateOfBirthIsToday_Return0()
        {
            //Arrange 
            var dateOfBirth = DateTime.Now.Date;
            var targetDate = DateTime.Now.Date;
            const int expectedOutput = 0;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenDateOfBirthIsSameMonthAsTargetDateButDifferentDay_ReturnAgeInDays()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2020,6,1);
            var targetDate = new DateTime(2020, 6, 15);
            const int expectedOutput = 14;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenDateOfBirthIsSameYearAsTargetDate_ReturnAgeInMonths()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2020, 06, 01);
            var targetDate = new DateTime(2020, 12, 01);
            const int expectedOutput = 6;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenBirthdayIsOneDayBeforeInDifferentMonth_ReturnAge()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2010, 12, 1);
            var targetDate = new DateTime(2020, 11, 30);
            const int expectedOutput = 9;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenBirthdayIsOneDayBeforeInSameMonth_ReturnAge()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2010, 12, 2);
            var targetDate = new DateTime(2020, 12, 1);
            const int expectedOutput = 9;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenBirthdayIsOneMonthAway_ReturnAge()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2010, 12, 1);
            var targetDate = new DateTime(2020, 11, 1);
            const int expectedOutput = 9;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenBirthdayIsOnTheDayOfTargetDate_ReturnAge()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2010, 12, 1);
            var targetDate = new DateTime(2020, 12, 1);
            const int expectedOutput = 10;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenOneDayAfterBirthday_ReturnAge()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2010, 12, 1);
            var targetDate = new DateTime(2020, 12, 2);
            const int expectedOutput = 10;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenDateOfBirthIsLeapYearAndTargetDateIsLeapYear_ReturnAge()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2008, 2, 29);
            var targetDate = new DateTime(2020, 2, 29);
            const int expectedOutput = 12;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenDateOfBirthIsLeapYearAndTargetDateIsNotLeapYearButSameMonth_ReturnAge()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2008, 2, 29);
            var targetDate = new DateTime(2019, 2, 28);
            const int expectedOutput = 10;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenDateOfBirthIsLeapYearAndTargetDateIsNotLeapYearAndOneMonthAfterBirthday_ReturnAge()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2008, 2, 29);
            var targetDate = new DateTime(2019, 3, 1);
            const int expectedOutput = 11;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void CalculateAge_GivenDateOfBirthIsLeapYearAndTargetDateIsNotLeapYearAndOneMonthBeforeBirthday_ReturnAge()
        {
            //Arrange 
            var dateOfBirth = new DateTime(2008, 2, 29);
            var targetDate = new DateTime(2019, 1, 15);
            const int expectedOutput = 10;

            //Act             
            var output = CreateAgeCalculator().CalculateAge(dateOfBirth, targetDate);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }
    }
}

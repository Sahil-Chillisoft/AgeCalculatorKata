using System;

namespace AgeCalculator
{
    public class AgeCalculator
    {
        public int CalculateAge(DateTime dateOfBirth, DateTime targetDate)
        {
            if (dateOfBirth > targetDate)
                throw new Exception("Unborn, date of birth is in the future.");

            if (IsSameYearMonthDay(dateOfBirth, targetDate))
                return 0;

            if (IsSameYearAndMonth(dateOfBirth, targetDate))
                return GetDifferenceInDays(dateOfBirth, targetDate);

            if (IsSameYear(dateOfBirth, targetDate))
                return GetDifferenceInMonths(dateOfBirth, targetDate);

            return CalculateExactAge(dateOfBirth, targetDate);
        }

        private int CalculateExactAge(DateTime dateOfBirth, DateTime targetDate)
        {
            var age = GetDifferenceInYears(dateOfBirth, targetDate);
            var differenceInMonths = GetDifferenceInMonths(dateOfBirth, targetDate);

            if (DateTime.IsLeapYear(dateOfBirth.Year))
            {
                if (differenceInMonths <= 0 && dateOfBirth.Day > targetDate.Day)
                    age--;
                return age;
            }

            if (differenceInMonths != 0 || GetDifferenceInDays(dateOfBirth, targetDate) != 0)
                age--;

            if (dateOfBirth.Month == targetDate.Month && targetDate.Day > dateOfBirth.Day)
                age++;

            return age;
        }

        private bool IsSameYearMonthDay(DateTime dateOfBirth, DateTime targetDate)
        {
            return dateOfBirth == targetDate;
        }

        private bool IsSameYearAndMonth(DateTime dateOfBirth, DateTime targetDate)
        {
            return (dateOfBirth.Year == targetDate.Year && dateOfBirth.Month == targetDate.Month);
        }

        private bool IsSameYear(DateTime dateOfBirth, DateTime targetDate)
        {
            return (dateOfBirth.Year == targetDate.Year);
        }

        private int GetDifferenceInDays(in DateTime dateOfBirth, in DateTime targetDate)
        {
            var days = targetDate.Day - dateOfBirth.Day;
            return days;
        }

        private int GetDifferenceInMonths(in DateTime dateOfBirth, in DateTime targetDate)
        {
            var months = targetDate.Month - dateOfBirth.Month;
            return months;
        }

        private int GetDifferenceInYears(DateTime dateOfBirth, DateTime targetDate)
        {
            var years = targetDate.Year - dateOfBirth.Year;
            return years;
        }
    }
}

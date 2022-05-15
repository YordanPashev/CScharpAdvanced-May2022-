using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class DateModifier
    {
        public static int CalculateDayDifference(string firstInput, string secondInput)
        {
            DateTime firstDate = DateTime.Parse(firstInput);
            DateTime secondDate = DateTime.Parse(secondInput);

            return Math.Abs((int)(firstDate - secondDate).TotalDays);
        }
    }
}

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public class DateModifier
    {
        public int DifferenceInTheDaysBetweenTwoDates(string firstDate, string secondDate)
        {
            string[] first = firstDate.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int year1 = int.Parse(first[0]);
            int month1 = int.Parse(first[1]);
            int day1 = int.Parse(first[2]);
            string[] second = secondDate.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int year2 = int.Parse(second[0]);
            int month2 = int.Parse(second[1]);
            int day2 = int.Parse(second[2]);
            DateTime start = new DateTime(year1, month1, day1);
            DateTime end = new DateTime(year2, month2, day2);

            TimeSpan timeSpan = (end - start);

            return Math.Abs(timeSpan.Days);
        }
    }
}
//two string parameters, representing dates as strings and calculates the difference in the days between them. 
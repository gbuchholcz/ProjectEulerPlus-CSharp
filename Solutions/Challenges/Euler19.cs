using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler19
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
        [System.Diagnostics.DebuggerDisplay("{_year}/{_month}/{_day}")]
        struct MyDateTime : IComparable<MyDateTime>
        {
            long _year;
            long _month;
            long _day;
            long daysSinceEpoch;

            private static long[] dayCountPerMonthNotLeapYear = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            private static long[] dayCountPerMonthLeapYear = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            private static long leapYearDayCount = 366;
            private static long noLeapYearDayCount = 365;

            public static MyDateTime Parse(string line)
            {
                string[] parts = line.Split();
                return new MyDateTime(long.Parse(parts[0]), long.Parse(parts[1]), long.Parse(parts[2]));
            }

            public MyDateTime(long year, long month, long day)
            {
                this._year = year;
                this._month = month;
                this._day = day;

                this.daysSinceEpoch = 0;

                long yearsSinceEpoch = year - 1900;
                long leap4 = (yearsSinceEpoch + 3) / 4;
                long noLeap100 = (yearsSinceEpoch + 99) / 100;
                long leap400 = (yearsSinceEpoch + 299) / 400;
                long leapTotal = leap4 - noLeap100 + leap400;
                this.daysSinceEpoch += leapTotal * leapYearDayCount + (yearsSinceEpoch - leapTotal) * noLeapYearDayCount;

                bool isYearLeap = _year % 4 == 0 && !(_year % 400 == 0 ^ _year % 100 == 0);

                for (int i = 1; i < _month; ++i)
                {
                    if (isYearLeap)
                    {
                        daysSinceEpoch += dayCountPerMonthLeapYear[i];
                    }
                    else
                    {
                        daysSinceEpoch += dayCountPerMonthNotLeapYear[i];
                    }
                }

                daysSinceEpoch += _day - 1;
            }

            public DayOfWeek GetDayOfWeek()
            {
                return (DayOfWeek)((daysSinceEpoch + 1) % 7);
            }

            public MyDateTime GetFirstDayOfNextMonth()
            {
                if (_month == 12)
                {
                    return new MyDateTime(_year + 1, 1, 1);
                }
                return new MyDateTime(_year, _month + 1, 1);
            }

            public MyDateTime GetActualFirstDayOfMonth()
            {
                if (_day > 1)
                {
                    if (_month == 12)
                    {
                        return new MyDateTime(_year + 1, 1, 1);
                    }
                    else
                    {
                        return new MyDateTime(_year, _month + 1, 1);
                    }
                }
                return new MyDateTime(_year, _month, 1);
            }


            public int CompareTo(MyDateTime other)
            {
                if (_year < other._year)
                {
                    return -1;
                }
                else if (_year > other._year)
                {
                    return 1;
                }
                else if (_month < other._month)
                {
                    return -1;
                }
                else if (_month > other._month)
                {
                    return 1;
                }
                else if (_day < other._day)
                {
                    return -1;
                }
                else if (_day > other._day)
                {
                    return 1;
                }
                else return 0;
            }
        }

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {

                var startDate = MyDateTime.Parse(input.ReadLine());
                var endDate = MyDateTime.Parse(input.ReadLine());
                startDate = startDate.GetActualFirstDayOfMonth();

                int result = 0;
                while (startDate.CompareTo(endDate) <= 0)
                {
                    if (startDate.GetDayOfWeek() == DayOfWeek.Sunday)
                    {
                        ++result;
                    }
                    startDate = startDate.GetFirstDayOfNextMonth();
                }
                output.WriteLine(result);
            }
        }


        public static void Test()
        {
            string inputData = @"2
1900 1 1
1910 1 1
2000 1 1
2020 1 1";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}

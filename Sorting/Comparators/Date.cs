using System;

namespace Sorting.Comparators
{
    public class Date:IComparable<Date>
    {
        private int month, day, year;

        public Date(int month, int day, int year)
        {
            this.month = month;
            this.day = day;
            this.year = year;
        }

        public int CompareTo(Date other)
        {
            if (this.year < other.year) return -1;
            if (this.year > other.year) return +1;
            if (this.month < other.month) return -1;
            if (this.month > other.month) return +1;
            if (this.day < other.day) return -1;
            if (this.day > other.day) return +1;
            return 0;


        }
    }
}
using System;
using System.Globalization;

namespace VeduBoxUnitTest.Utils{
    class Dates{
        public static int GetCurrentYear(){
            return Int32.Parse(DateTime.Now.ToString("yyyy"));
        }
        public static string GetCurrentMonth(){
            return DateTime.Now.ToString("MMMM");
        }
        public static string GetCurrentDay(){
            return DateTime.Now.ToString("dd");
        }
        public static string GetCurrentHour(){
            return DateTime.Now.ToString("HH");
        }
        public static string GetCurrentMinute(){
            return DateTime.Now.ToString("mm");
        }
        public static string GetMonthNameByNumber(int number){
            return DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(number);
        }
        public static int GetNextYear(int year = 1){
            return GetCurrentYear() + year;
        }
        public static string GetNextMonth(Months months = Months.December){
            return months.ToString();
        }
        public static string GetNextDay(int day = 22){
            return day.ToString();
        }
    }
    enum Months{
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}

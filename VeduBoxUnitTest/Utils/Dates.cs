using System;
using System.Globalization;

namespace VeduBoxUnitTest.Utils{
    class Dates{
        public static int getCurrentYear(){
            return Int32.Parse(DateTime.Now.ToString("yyyy"));
        }
        public static string getCurrentMonth(){
            return DateTime.Now.ToString("MMMM");
        }
        public static string getCurrentDay(){
            return DateTime.Now.ToString("dd");
        }
        public static string getCurrentHour(){
            return DateTime.Now.ToString("HH");
        }
        public static string getCurrentMinute(){
            return DateTime.Now.ToString("mm");
        }
        public static string getMonthNameByNumber(int number){
            return DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(number);
        }
        public static int getNextYear(int year = 1){
            return getCurrentYear() + year;
        }
        public static string getNextMonth(Months months = Months.December){
            return months.ToString();
        }
        public static string getNextDay(int day = 22){
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

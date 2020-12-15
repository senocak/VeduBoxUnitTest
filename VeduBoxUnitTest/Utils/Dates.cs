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
    }
}

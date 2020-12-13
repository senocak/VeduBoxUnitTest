using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeduBoxUnitTest.Utils
{
    class Dates
    {
        public static int getCurrentYear()
        {
            int yearCurrent = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return yearCurrent;
        }
        public static string getCurrentMonth()
        {
            string monthCurrent = DateTime.Now.ToString("MMMM");
            return monthCurrent;
        }
        public static string getCurrentDay()
        {
            string dayCurrent = DateTime.Now.ToString("dd");
            return dayCurrent;
        }
        public static string getCurrentHour()
        {
            string hourCurrent = DateTime.Now.ToString("HH");
            return hourCurrent;
        }
        public static string getCurrentMinute()
        {
            string minuteCurrent = DateTime.Now.ToString("mm");
            return minuteCurrent;
        }


        



    }
}

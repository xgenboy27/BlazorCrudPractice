using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTools
{
    public static class Folder
    {
        public static string Account(string rootName, string newFolderName)
        {
            //string rootFolder = rootName + "/";

            string newFolder = rootName + newFolderName;
            Directory.CreateDirectory(newFolder);

            return newFolder + "\\"; ;
        }



        public static string WorkWeek(string rootName, string newFolder)
        {

            DateTime dt = DateTime.Today;

            string YearMonthWeek = rootName + "/" +
                                   dt.Year.ToString() + "/" +
                                   dt.ToString("MMMM") + "/WW" +
                                   CultureInfo.
                                   CurrentCulture.
                                   Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString() + "/";

            newFolder += YearMonthWeek.Replace("/", "\\");
            Directory.CreateDirectory(newFolder);


            return newFolder + "\\";
        }

        public static (string newFolder, string urlPath) URLWorkWeek(string rootName, string newFolder, string urlPath)
        {

            DateTime dt = DateTime.Today;

            string YearMonthWeek = rootName + "/" +
                                   dt.Year.ToString() + "/" +
                                   dt.ToString("MMMM") + "/WW" +
                                   CultureInfo.
                                   CurrentCulture.
                                   Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString() + "/";

            urlPath += YearMonthWeek;
            newFolder += YearMonthWeek.Replace("/", "\\");
            Directory.CreateDirectory(newFolder);

            return (newFolder, urlPath);
        }
    }
}

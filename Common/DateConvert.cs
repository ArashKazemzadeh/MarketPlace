using System.Globalization;
namespace Common;


public static class DateConvert
{


    public static DateTime ConvertPersianToGregorian(string persianDateTime)
    {
        string[] dateTimeParts = persianDateTime.Split(' ');
        string persianDate = dateTimeParts[0];
        string persianTime = dateTimeParts[1];

        string[] dateParts = persianDate.Split('/');
        int month = int.Parse(dateParts[0]);
        int day = int.Parse(dateParts[1]);
        int year = int.Parse(dateParts[2]);

        string[] timeParts = persianTime.Split(':');
        int hour = int.Parse(timeParts[0]);
        int minute = int.Parse(timeParts[1]);

        PersianCalendar persianCalendar = new PersianCalendar();
        DateTime gregorianDate = persianCalendar.ToDateTime(year, month, day, hour, minute, 0, 0);

        return gregorianDate;
    }

    public static string ConvertGregorianToPersian(DateTime miladiDate)
    {
        PersianCalendar persianCalendar = new PersianCalendar();
        int year = persianCalendar.GetYear(miladiDate);
        int month = persianCalendar.GetMonth(miladiDate);
        int day = persianCalendar.GetDayOfMonth(miladiDate);
        int hour = persianCalendar.GetHour(miladiDate);
        int minute = persianCalendar.GetMinute(miladiDate);
        int second = persianCalendar.GetSecond(miladiDate);
        string amPmDesignator = persianCalendar.GetHour(miladiDate) < 12 ? "AM" : "PM";

        string persianDateTime = string.Format("{0}/{1}/{2} {3}:{4}:{5} {6}", year, month, day, hour, minute, second, amPmDesignator);

        return persianDateTime;
    }


    public static int GetPersianMonthNumber(string monthName)
    {
        var persianCulture = new CultureInfo("fa-IR");
        var monthNumber = persianCulture.DateTimeFormat.MonthNames.ToList().FindIndex(m => m == monthName) + 1;
        return monthNumber;
    }
}



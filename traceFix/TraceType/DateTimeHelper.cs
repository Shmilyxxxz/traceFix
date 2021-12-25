using System;
using System.Globalization;

namespace ASM.TraceabilityProxy.Service
{
	public static class DateTimeHelper
	{
		private static bool s_bUseUTCTime = false;

		public static DateTime Now
		{
			get
			{
				DateTime result;
				if (DateTimeHelper.s_bUseUTCTime)
				{
					result = DateTime.UtcNow;
				}
				else
				{
					result = DateTime.Now;
				}
				return result;
			}
		}

		public static DateTime CorrectTimeZone(DateTime time)
		{
			DateTime result = time;
			if (result.Kind == DateTimeKind.Unspecified)
			{
				result = DateTime.SpecifyKind(time, DateTimeKind.Local);
			}
			if (DateTimeHelper.s_bUseUTCTime && result.Kind != DateTimeKind.Utc)
			{
				result = time.ToUniversalTime();
			}
			else if (!DateTimeHelper.s_bUseUTCTime && result.Kind == DateTimeKind.Utc)
			{
				result = time.ToLocalTime();
			}
			return result;
		}

		public static string DateToTraceHostOldFormat(DateTime time)
		{
			return time.ToString("yyyyMMddHHmmssff");
		}

		public static string DateToXMLString(DateTime time)
		{
			DateTime dateTime = DateTimeHelper.CorrectTimeZone(time);
			string result;
			if (dateTime.Kind == DateTimeKind.Utc)
			{
				result = dateTime.ToString("yyy-MM-ddTHH:mm:ss.fffZ");
			}
			else
			{
				result = dateTime.ToString("yyy-MM-ddTHH:mm:ss.fffzzz");
			}
			return result;
		}

		public static DateTime XMLStringToDateWithoutTimeZone(string xmlString)
		{
			DateTime time = DateTime.ParseExact(xmlString, "yyyyMMddHHmmssff", CultureInfo.InvariantCulture);
			return DateTimeHelper.CorrectTimeZone(time);
		}

		public static DateTime XMLStringToDate(string xmlString)
		{
			DateTime time = DateTime.Parse(xmlString);
			return DateTimeHelper.CorrectTimeZone(time);
		}

		public static bool IsDateTimeValid(DateTime time)
		{
			return time.Year > 1900 && time.Year < 3000;
		}

		public static bool CompareDateTimes(DateTime dt1, DateTime dt2)
		{
			DateTime t = (dt1 != DateTime.MinValue && dt1 != DateTime.MaxValue) ? dt1.AddMilliseconds(-10.0) : dt1;
			DateTime t2 = (dt1 != DateTime.MinValue && dt1 != DateTime.MaxValue) ? dt1.AddMilliseconds(10.0) : dt1;
			return t <= dt2 && dt2 <= t2;
		}

		public static bool CompareDateTimesNullable(DateTime? dt1, DateTime? dt2)
		{
			return DateTimeHelper.CompareDateTimes(dt1 ?? DateTime.MinValue, dt2 ?? DateTime.MinValue);
		}
	}
}

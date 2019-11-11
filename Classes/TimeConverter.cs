using BerlinClock.Classes;
using System;
using System.Linq;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private static int fourLampsInRow = 4;

        private static int elevenLampsInRow = 11;

        private static char red = 'R';

        private static char yellow = 'Y';

        private static char off = 'O';

        public string convertTime(string aTime)
        {
            string[] tmp = SeparateTimeByUnits(aTime);
            int hours, minutes, seconds;

            try
            {
                hours = int.Parse(tmp[0]);
                minutes = int.Parse(tmp[1]);
                seconds = tmp.Count() == 3 ? int.Parse(tmp[2]) : 0;
            }
            catch
            {
                return $"{aTime} - invalid time format";
            }

            this.ValidateTime(seconds, minutes, hours);

            ClockModel clockModel = new ClockModel
            {
                SecondsLine = (seconds % 2 == 0 ? yellow : off).ToString(),
                HoursFirstLine = GenerateRow(fourLampsInRow, (int)(hours/5), red),
                HoursSecondLine = GenerateRow(fourLampsInRow, hours % 5, red),
                MinutesFirstLine = GenerateRow(elevenLampsInRow, (int)(minutes/5), yellow).Replace("YYY", "YYR"),
                MinutesSecondLine = GenerateRow(fourLampsInRow, minutes % 5, yellow) 
            };


            return clockModel.ToString();
        }

        private string[] SeparateTimeByUnits(string aTime)
        {
            string[] separatedTimes = aTime.Split(':');

            return separatedTimes;
        }

        private string GenerateRow(int lampsInRow, int switchedLamps, char lampColour)
        {
            int offLampsCount = lampsInRow - switchedLamps;

            string switched = new String(lampColour, switchedLamps);
            string offed = new String(off, offLampsCount);

            return switched + offed;
        }

        private void ValidateTime(int seconds, int minutes, int hours)
        {
            if ((seconds < 0 || seconds > 59) ||
               (minutes < 0 || minutes > 59) ||
               (hours < 0 || hours > 24) ||
               (hours == 24 && (minutes > 0 || seconds > 0)))
            {
                throw new Exception($"Time values are out of range");   
            }
        }
    }
}

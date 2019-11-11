namespace BerlinClock.Classes
{
    public class ClockModel
    {
        public string SecondsLine { get; set; }

        public string HoursFirstLine { get; set; }

        public string HoursSecondLine { get; set; }

        public string MinutesFirstLine { get; set; }

        public string MinutesSecondLine { get; set; }

        public override string ToString()
        {
            return $"{SecondsLine}\r\n"
                + $"{HoursFirstLine}\r\n"
                + $"{HoursSecondLine}\r\n"
                + $"{MinutesFirstLine}\r\n"
                + $"{MinutesSecondLine}";
        }
    }
}

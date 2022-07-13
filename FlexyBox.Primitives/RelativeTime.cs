using System;

namespace Primitives
{
    public class RelativeTime : IEquatable<RelativeTime>
    {
        public DateOnly Date { get; }
        public TimeOnly Time { get; }

        public RelativeTime(DateOnly date, TimeOnly time)
        {
            Date = date;
            Time = time;
        }

        public bool Equals(RelativeTime other)
        {
            if (Date.ToString() == other.ToString() && Date.ToString() == other.ToString())
                return true;
            return false;
        }

        public static bool operator >(RelativeTime a, RelativeTime b)
        {
            if (a.Date.CompareTo(b.Date) == 0 && a.Time.CompareTo(b.Time) > 0)
                return true;

            if (a.Date.CompareTo(b.Date) > 0)
                return true;
            return false;
        }

        public static bool operator !=(RelativeTime a, RelativeTime b)
        {
            return !a.Equals(b);
        }

        public static bool operator ==(RelativeTime a, RelativeTime b)
        {
            return a.Equals(b);
        }

        public static bool operator >=(RelativeTime a, RelativeTime b)
        {
            if (a > b || a == b)
                return true;
            return false;
        }

        public static bool operator <=(RelativeTime a, RelativeTime b)
        {
            if (a < b || a == b)
                return true;
            return false;
        }

        public static bool operator <(RelativeTime a, RelativeTime b)
        {
            if (a.Date.CompareTo(b.Date) == 0 && a.Time.CompareTo(b.Time) < 0)
                return true;

            if (a.Date.CompareTo(b.Date) < 0)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals((RelativeTime)obj);
        }

        public override int GetHashCode()
        {
            return (Date.ToString() + Time.ToString()).GetHashCode();
        }

        public override string ToString()
        {
            return Date.ToString() + " " + Time.ToString();
        }
    }
}


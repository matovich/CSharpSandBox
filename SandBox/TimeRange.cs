using System;
using System.Globalization;

namespace SandBox
{
    class TimeRange
    {
        public TimeRange(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }

        public TimeRange(DateTimeOffset start, TimeSpan span)
            : this(start, start.Add(span.Ticks >= 0 ? span : TimeSpan.Zero))
        {
        }

        public TimeRange(TimeSpan span, DateTimeOffset end)
        {
            Start = (end.Ticks - span.Ticks) > 0 ? end.Subtract(span) : DateTimeOffset.MinValue;
            End = end;
        }

        public TimeRange(TimeRange source)
            : this(source.Start, source.End)
        {
        }

        public DateTimeOffset Start { get; private set; }

        public DateTimeOffset End { get; private set; }

        public TimeSpan Span
        {
            get { return End.Subtract(Start); }
        }

        public int CompareTo(TimeRange other)
        {
            if (other == null)
                return 1;

            return Start.CompareTo(other.Start);
        }

        public bool Equals(TimeRange other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            return (Start == other.Start) && (End == other.End);
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode() ^ End.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var temp = obj as TimeRange;
            if (!ReferenceEquals(temp, null))
            {
                return Equals(temp);
            }
            return false;
        }

        public static bool operator ==(TimeRange left, TimeRange right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TimeRange left, TimeRange right)
        {
            return !(left == right);
        }

        public static bool operator >(TimeRange left, TimeRange right)
        {
            if (left == null)
                return false;

            return left.CompareTo(right) > 0;
        }

        public static bool operator <(TimeRange left, TimeRange right)
        {
            if (left == null)
                return false;

            return left.CompareTo(right) < 0;
        }

        public override string ToString()
        {
            return String.Format(CultureInfo.CurrentCulture,"{0} - {1}", Start, End);
        }

        public bool OverLaps(TimeRange other)
        {
            return (StartIsInRangeOf(other) || EndIsInRangeOf(other) || Consumes(other));
        }

        public bool Consumes(TimeRange other)
        {
            return ((other.Start >= Start) && (other.End <= End));
        }

        public TimeRange GetIntersection(TimeRange other)
        {
            TimeRange retVal;

            //    |-this-|
            // |----other----|
            if (EndIsInRangeOf(other) && StartIsInRangeOf(other))
                retVal = new TimeRange(Start, End);

            // |---this---|
            //       |--other--|
            else if (EndIsInRangeOf(other))
                retVal = new TimeRange(other.Start, End);

            //      |---this---|
            // |--other--|
            else if (StartIsInRangeOf(other))
                retVal = new TimeRange(Start, other.End);


            // |-----this-----|
            //    |--other--|
            else if (OverLaps(other))
                retVal = new TimeRange(other.Start, other.End);

            // |-- this --|
            //            |-- other --|
            else
                throw new ArgumentException("Time ranges in question do no overlap and therefore an intersection cannot be derived");

            return retVal;
        }

        public bool TimeIsInRange(DateTimeOffset time)
        {
            return (Start <= time && End >= time);
        }

        private bool EndIsInRangeOf(TimeRange other)
        {
            return (End >= other.Start && End <= other.End);
        }

        private bool StartIsInRangeOf(TimeRange other)
        {
            return (Start >= other.Start && Start <= other.End);
        }
    }
}

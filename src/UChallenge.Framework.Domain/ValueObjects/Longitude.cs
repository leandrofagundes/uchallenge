using System;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Domain.Properties;

namespace UChallenge.Framework.Domain.ValueObjects
{
    public readonly struct Longitude :
          IEquatableValueObject<Longitude>
    {
        private readonly double _value;
        private const double MINVALUE = -180;
        private const double MAXVALUE = 180;

        public Longitude(double value)
        {
            if (IsInvalidValue(value))
                throw new DomainFieldInvalidNumberOutOfRangeException(Resources.Longitude, MINVALUE, MAXVALUE);

            _value = value;
        }

        private static bool IsInvalidValue(double value)
        {
            if (value < MINVALUE || value > MAXVALUE)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public double ToDouble()
        {
            return _value;
        }

        public bool Equals(Longitude other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            else if (obj is Longitude other)
                return _value == other._value;
            else
                return false;
        }

        public static bool operator ==(Longitude left, Longitude right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Longitude left, Longitude right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}

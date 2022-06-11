using System;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Domain.Properties;

namespace UChallenge.Framework.Domain.ValueObjects
{
    public readonly struct Latitude :
         IEquatableValueObject<Latitude>
    {
        private readonly double _value;
        private const double MINVALUE = -90;
        private const double MAXVALUE = 90;

        public Latitude(double value)
        {
            if (value < MINVALUE || value > MAXVALUE)
                throw new DomainFieldInvalidNumberOutOfRangeException(Resources.Longitude, MINVALUE, MAXVALUE);

            _value = value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public double ToDouble()
        {
            return _value;
        }

        public bool Equals(Latitude other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            else if (obj is Latitude other)
                return _value == other._value;
            else
                return false;
        }

        public static bool operator ==(Latitude left, Latitude right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Latitude left, Latitude right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}

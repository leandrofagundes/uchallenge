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
            _value = value;
        }

        private static bool IsValidValue(double value)
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

        public static bool TryParse(string value, out Latitude? latitude)
        {
            latitude = null;

            if (!double.TryParse(value, out double valueAsDouble))
                return false;

            if (!IsValidValue(valueAsDouble))
                return false;

            latitude = new Latitude(valueAsDouble);
            return true;
        }
    }
}

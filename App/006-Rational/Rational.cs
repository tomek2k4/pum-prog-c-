using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public struct Rational : IEquatable<Rational>, IComparable<Rational>
    {
        public Rational(int numerator, int denominator)
        {
            throw new NotImplementedException();
        }

        public static readonly Rational Zero = new Rational(0, 1);
        public static readonly Rational NaN = new Rational();

        public int Numerator
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Denominator
        {
            get
            {
                throw new NotImplementedException();
            }
        }
       
        public bool Equals(Rational other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Rational other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();

        }

        public string ToString(bool normalize)
        {
            throw new NotImplementedException();

        }

        public Rational Normalize()
        {
            throw new NotImplementedException();

        }

        public Rational Inverse()
        {
            throw new NotImplementedException();

        }

        public Rational Negate()
        {
            throw new NotImplementedException();

        }

        public Rational Add(Rational other)
        {
            throw new NotImplementedException();

        }

        public Rational Substract(Rational other)
        {
            throw new NotImplementedException();

        }

        public Rational Multiplicate(Rational other)
        {
            throw new NotImplementedException();

        }

        public Rational Divide(Rational other)
        {
            throw new NotImplementedException();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Shared
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if( obj is not ValueObject other)
            {
                return false;
            }
            if (GetType() != other.GetType())
            {
                return false;
            }

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode() => GetEqualityComponents().Aggregate(1, (hash, obj) => HashCode.Combine(hash, obj?.GetHashCode()??0));
    }
}

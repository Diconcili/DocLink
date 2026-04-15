using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Shared
{
    public abstract class Entity
    {
        public abstract object GetId();

        public override bool Equals(object? obj)
        {
            if(obj is not Entity other)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            if (GetType() != other.GetType())
            {
                return false;
            }

            return GetId().Equals(other.GetId());
        }

        public override int GetHashCode() => GetId().GetHashCode();
    }
}

using DocLink.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Record
{
    public sealed class RecordId : ValueObject
    {
        public Guid Value { get; }

        public RecordId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("RecordId cannot be empty.");
            }
            Value = value;
        }

        public static RecordId NewId() => new (Guid.NewGuid()); 
        public static RecordId From(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value.ToString();
    }
}

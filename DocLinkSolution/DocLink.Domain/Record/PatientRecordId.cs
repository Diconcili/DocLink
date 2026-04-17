using DocLink.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Record
{
    public sealed class PatientRecordId : ValueObject
    {
        public Guid Value { get; }

        public PatientRecordId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("RecordId cannot be empty.");
            }
            Value = value;
        }

        public static PatientRecordId NewId() => new (Guid.NewGuid()); 
        public static PatientRecordId From(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value.ToString();
    }
}

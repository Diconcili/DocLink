using DocLink.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Patient
{
    public sealed class PatientId : ValueObject
    {
        public Guid Value { get; }

        public PatientId(Guid value)
        {
            if (value == Guid.Empty)
                throw new Exception("Patient ID cannot be empty.");
            Value = value;
        }

        public static PatientId New() => new(Guid.NewGuid());
        public static PatientId From(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }
}

using DocLink.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Record
{
    public sealed class DocumentId : ValueObject
    {
        public Guid Value { get; }

        public DocumentId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("DocumentId cannot be empty.");
            }

            Value = value;
        }

        public static DocumentId NewId() => new (Guid.NewGuid());

        public static DocumentId From(Guid value) => new(value);
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value.ToString();
    }
}

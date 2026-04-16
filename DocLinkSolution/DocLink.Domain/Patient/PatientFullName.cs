using DocLink.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Patient
{
    public sealed class PatientFullName : ValueObject
    {
        public string First { get; }
        public string Last { get; }

        public PatientFullName(string first, string last)
        {
            if (string.IsNullOrWhiteSpace(first))
                throw new Exception("First name is required.");
            if (string.IsNullOrWhiteSpace(last))
                throw new Exception("Last name is required.");

            First = first.Trim();
            Last = last.Trim();
        }

        public string Full => $"{First} {Last}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return First;
            yield return Last;
        }
    }
}
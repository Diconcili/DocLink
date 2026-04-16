using System;
using System.Collections.Generic;
using System.Text;
using DocLink.Domain.Shared;

namespace DocLink.Domain.Patient
{
    public sealed class Patient : Entity
    {
        public PatientId Id { get; }
        public PatientFullName PatientName { get; private set; }

        public Patient(PatientId id, PatientFullName patientName)
        {
            Id = id;
            PatientName = patientName;
        }

        public void UpdateName(PatientFullName newName)
        {
            if (newName is null)
            {
                throw new ArgumentException("Patient name cannot be null.");
            }

            PatientName = newName;
        }

        public override object GetId() => Id;
    }
}

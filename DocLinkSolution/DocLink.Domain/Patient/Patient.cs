using System;
using System.Collections.Generic;
using System.Text;
using DocLink.Domain.Shared;

namespace DocLink.Domain.Patient
{
    internal class Patient : Entity
    {
        public PatientId Id { get; }
        public PatientFullName PatientName { get; private set; }

        public Patient(PatientId id, PatientFullName patientName)
        {
            Id = id;
            PatientName = patientName;
        }

        public override object GetId() => Id;
    }
}

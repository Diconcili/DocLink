using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Patient.DTOs
{
    public sealed class PatientDto
    {
        public Guid Id { get; init; }
        public string FullName { get; init; }

    }
}

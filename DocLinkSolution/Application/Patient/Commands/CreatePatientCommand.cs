using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Patient.Commands
{
    public sealed class CreatePatientCommand
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}

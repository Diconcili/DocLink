using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Record.Commands
{
    public sealed class CreatePatientRecordCommand
    {
        public Guid PatientId { get; init; }
    }
}

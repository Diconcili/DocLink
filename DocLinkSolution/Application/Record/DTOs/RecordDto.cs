using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Record.DTOs
{
    internal class RecordDto
    {
        public Guid Id { get; init; }
        public Guid PatientId { get; init; }

        public IEnumerable<DocumentDto> Documents { get; init; } = Enumerable.Empty<DocumentDto>();
    }
}

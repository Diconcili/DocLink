using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Record.DTOs
{
    internal class DocumentDto
    {
        public Guid Id { get; init; }
        public string FileName { get; init; }
        public DateTime AddedAt { get; init; }
    }
}

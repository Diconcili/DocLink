using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Record.Commands
{
    public sealed class ProcessPdfCommand
    {
        public Guid RecordId { get; init; }
        public string FilePath { get; init; }
    }
}

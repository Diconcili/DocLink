using DocLink.Domain.Record;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPdfParser
    {
        PdfMetadata Parse(string filePath);
    }
}

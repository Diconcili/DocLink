using DocLink.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Record
{
    public sealed class PdfMetadata : ValueObject
    {
        public string RawText { get; }
        public string FileName { get; }
        public DateTime ExtractedAt {  get; }
        // I'll add more metadata properties if needed, such as page count, author, etc.

        public PdfMetadata(string rawText, string fileName)
        {
            if (string.IsNullOrWhiteSpace(rawText))
            {
                throw new ArgumentException("Raw text cannot be empty.", nameof(rawText));
            }
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name cannot be empty.", nameof(fileName));
            }            


            RawText = rawText;
            FileName = fileName;
            ExtractedAt = DateTime.UtcNow;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RawText;
            yield return FileName;
        }
    }
}

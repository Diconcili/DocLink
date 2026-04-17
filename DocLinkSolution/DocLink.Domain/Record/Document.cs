using DocLink.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Record
{
    public sealed class Document : Entity
    {
        public DocumentId Id { get; }
        public PatientRecordId RecordId { get; }
        public PdfMetadata Metadata { get; private set; }
        public DateTime AddedAt { get; }


        public Document(DocumentId id, PatientRecordId recordId, PdfMetadata metadata)
        {
            if (id is null)
                throw new Exception("DocumentId is required.");
            if (recordId is null)
                throw new Exception("RecordId is required.");
            if (metadata is null)
                throw new Exception("Document metadata is required.");

            Id = id;
            RecordId = recordId;
            Metadata = metadata;
            AddedAt = DateTime.UtcNow;
        }

        public override object GetId() => Id;
    }
}
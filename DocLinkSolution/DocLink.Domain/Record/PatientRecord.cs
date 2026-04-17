using DocLink.Domain.Patient;
using DocLink.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Record
{
    public sealed class PatientRecord : Entity
    {
        public RecordId Id { get; }
        public PatientId PatientId { get; }

        private readonly List<Document> documentList = new();
        public IReadOnlyCollection<Document> Documents => documentList.AsReadOnly();

        public PatientRecord(RecordId id, PatientId patientId)
        {
            if (id is null)
                throw new Exception("RecordId is required.");
            if (patientId is null)
                throw new Exception("PatientId is required.");

            Id = id;
            PatientId = patientId;
        }

        public void AddDocument(PdfMetadata metadata)
        {
            var document = new Document(
                DocumentId.NewId(),
                Id,
                metadata
                );

            documentList.Add(document);
        }

        public void RemoveDocument(DocumentId documentId) 
        {
            var document = documentList.FirstOrDefault(d => d.Id.Equals(documentId));

            if (document is null)
            {
                throw new Exception("Document not found in the record.");
            }

            documentList.Remove(document);
        }

        public override object GetId() => Id;
    }
}

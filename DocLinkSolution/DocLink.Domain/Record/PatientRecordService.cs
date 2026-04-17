using DocLink.Domain.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Record
{
    public sealed class PatientRecordService
    {
        private readonly IPatientRecordRepository _recordRepository;

        public PatientRecordService(IPatientRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public async Task<PatientRecord?> GetByIdAsync(PatientRecordId id)
        {
            return await _recordRepository.GetByIdAsync(id);
        }

        public async Task<PatientRecord> CreateAsync(PatientId patientId)
        {
            var existing = await _recordRepository.GetByPatientIdAsync(patientId);

            if (existing != null)
            {
                throw new Exception("Patient already has a record.");
            }

            var record = new PatientRecord(PatientRecordId.NewId(), patientId);

            await _recordRepository.AddAsync(record);

            return record;
        }

        public async Task AddDocumentAsync(PatientRecordId recordId, PdfMetadata metadata)
        {
            var record = await _recordRepository.GetByIdAsync(recordId);

            if (record is null)
            {
                throw new Exception($"Record {recordId} not found.");
            }

            record.AddDocument(metadata);

            await _recordRepository.UpdateAsync(record);
        }

        public async Task RemoveDocumentAsync(PatientRecordId recordId, DocumentId documentId)
        {
            var record = await _recordRepository.GetByIdAsync(recordId);

            if (record is null)
            {
                throw new Exception($"Record {recordId} not found.");
            }

            record.RemoveDocument(documentId);

            await _recordRepository.UpdateAsync(record);
        }
    }
}
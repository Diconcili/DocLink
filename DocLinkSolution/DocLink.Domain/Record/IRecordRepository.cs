using DocLink.Domain.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Record
{
    public interface IRecordRepository
    {
        Task<Record?> GetByIdAsync(RecordId id);
        Task<Record?> GetByPatientIdAsync(PatientId patientId);
        Task AddAsync(Record record);
        Task UpdateAsync(Record record);
        Task DeleteAsync(RecordId id);
    }
}

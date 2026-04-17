using DocLink.Domain.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Record
{
    public interface IPatientRecordRepository
    {
        Task<PatientRecord?> GetByIdAsync(PatientRecordId id);
        Task<PatientRecord?> GetByPatientIdAsync(PatientId patientId);
        Task AddAsync(PatientRecord record);
        Task UpdateAsync(PatientRecord record);
        Task DeleteAsync(PatientRecordId id);
    }
}

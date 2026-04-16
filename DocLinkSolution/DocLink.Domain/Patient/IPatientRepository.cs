using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Patient
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByIdAsync(PatientId id);
        Task<IEnumerable<Patient>> GetAllAsync();
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(PatientId id);
    }
}

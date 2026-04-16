using System;
using System.Collections.Generic;
using System.Text;

namespace DocLink.Domain.Patient
{
    public sealed class PatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> CreateAsync(PatientFullName name)
        {
            var patient = new Patient(PatientId.New(), name);
            
            await _patientRepository.AddAsync(patient);

            return patient;
        }

        public async Task UpdateNameAsync(PatientId id, PatientFullName newName)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            if (patient is null)
            {
                throw new Exception($"Patient {id} not found.");
            }

            patient.UpdateName(newName);

            await _patientRepository.UpdateAsync(patient);
        }
    }
}
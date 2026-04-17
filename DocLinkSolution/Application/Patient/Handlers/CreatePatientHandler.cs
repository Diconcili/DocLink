using Application.Patient.Commands;
using Application.Patient.DTOs;
using DocLink.Domain.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Patient.Handlers
{
    public sealed class CreatePatientHandler
    {
        private readonly PatientService _patientService;

        public CreatePatientHandler (PatientService patientService)
        {
            _patientService = patientService;
        }
        
        public async Task<PatientDto> HandleAsync(CreatePatientCommand command)
        {
            var fullName = new PatientFullName(command.FirstName, command.LastName);

            var patient = await _patientService.CreateAsync(fullName);

            return new PatientDto
            {
                Id = patient.Id.Value,
                FullName = patient.PatientName.Full
            };
        }
    }
}

using Application.Record.Commands;
using Application.Record.DTOs;
using DocLink.Domain.Patient;
using DocLink.Domain.Record;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Record.Handlers
{
    public sealed class CreatePatientRecordHandler
    {
        private readonly PatientRecordService _recordService;

        public CreatePatientRecordHandler(PatientRecordService recordService)
        {
            _recordService = recordService;
        }

        public async Task<PatientRecordDto> HandleAsync(CreatePatientRecordCommand command)
        {
            var patientId = PatientId.From(command.PatientId);

            var record = await _recordService.CreateAsync(patientId);

            return new PatientRecordDto
            {
                Id = record.Id.Value,
                PatientId = record.PatientId.Value,
                Documents = Enumerable.Empty<DocumentDto>()
            };

        }
    }
}

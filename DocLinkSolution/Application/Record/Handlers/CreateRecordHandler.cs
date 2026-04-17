using Application.Record.Commands;
using Application.Record.DTOs;
using DocLink.Domain.Patient;
using DocLink.Domain.Record;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Record.Handlers
{
    public sealed class CreateRecordHandler
    {
        private readonly RecordService _recordService;

        public CreateRecordHandler(RecordService recordService)
        {
            _recordService = recordService;
        }

        public async Task<RecordDto> HandleAsync(CreateRecordCommand command)
        {
            var patientId = PatientId.From(command.PatientId);

            var record = await _recordService.CreateAsync(patientId);

            return new RecordDto
            {
                Id = record.Id.Value,
                PatientId = record.PatientId.Value,
                Documents = Enumerable.Empty<DocumentDto>()
            };

        }
    }
}

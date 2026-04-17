using Application.Interfaces;
using Application.Record.Commands;
using Application.Record.DTOs;
using DocLink.Domain.Record;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Record.Handlers
{
    public sealed class ProcessPdfHandler
    {
        private readonly RecordService _recordService;
        private readonly IPdfParser _pdfParser;

        public ProcessPdfHandler(RecordService recordService, IPdfParser pdfParser)
        {
            _recordService = recordService;
            _pdfParser = pdfParser;
        }

        public async Task<RecordDto> HandleAsync(ProcessPdfCommand command)
        {
            var recordId = RecordId.From(command.RecordId);

            var metadata = _pdfParser.Parse(command.FilePath);

            await _recordService.AddDocumentAsync(recordId, metadata);

            var record = await _recordService.GetByIdAsync(recordId) ?? throw new Exception($"Record with ID {recordId} not found.");

            return MapToDto(record);
        }

        private static RecordDto MapToDto(Record record) => new()
        {
            Id = record.Id.Value,
            PatientId = record.PatientId.Value,
            Documents = record.Documents.Select(d => new DocumentDto
            {
                Id = d.Id.Value,
                FileName = d.Metadata.FileName,
                AddedAt = d.Metadata.AddedAt
            })
        };

    }
}

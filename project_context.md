# Project context

## Stack
- C# / .NET 10
- DDD architecture
- PostgreSQL + EF Core 10 (Npgsql 9.0.4)
- PdfPig 0.1.14

## Architecture decisions
- Solution split: Domain, Application, Infrastructure, Api, Tests
- Entity base class uses abstract GetId() — non-generic, verbose implementation
- ValueObject base class uses GetEqualityComponents()
- Constructors use verbose null checks (not ?? throw shorthand)
- No sealed on entities — kept only on Value Objects and IDs
- PatientRecord renamed from Record (C# keyword collision)

## Domain layer ✅
### Shared
- Entity.cs — abstract GetId(), Equals, GetHashCode
- ValueObject.cs — abstract GetEqualityComponents(), Equals, GetHashCode

### Patient
- Patient.cs — Entity, has PatientId and FullName
- PatientId.cs — ValueObject, wraps Guid, has New() and From()
- FullName.cs — ValueObject, First + Last + Full property
- IPatientRepository.cs — GetByIdAsync, GetAllAsync, AddAsync, UpdateAsync, DeleteAsync
- PatientService.cs — CreateAsync, UpdateNameAsync

### PatientRecord
- PatientRecord.cs — aggregate root Entity, owns List<Document>
- PatientRecordId.cs — ValueObject, wraps Guid
- Document.cs — Entity inside aggregate, has DocumentId + PatientRecordId + PdfMetadata + AddedAt
- DocumentId.cs — ValueObject, wraps Guid
- PdfMetadata.cs — ValueObject, has RawText + FileName + ExtractedAt
- IPatientRecordRepository.cs — GetByIdAsync, GetByPatientIdAsync, AddAsync, UpdateAsync, DeleteAsync
- PatientRecordService.cs — CreateAsync, AddDocumentAsync, RemoveDocumentAsync, GetByIdAsync

## Application layer ✅
### Interfaces
- IPdfParser.cs — Parse(filePath) returns PdfMetadata

### Patient
- PatientDto.cs — Id (Guid), FullName (string), uses init
- CreatePatientCommand.cs — FirstName, LastName
- CreatePatientHandler.cs — builds FullName VO, calls PatientService, returns PatientDto

### PatientRecord
- PatientRecordDto.cs — Id, PatientId (Guids), Documents (IEnumerable<DocumentDto>)
- DocumentDto.cs — Id (Guid), FileName, AddedAt
- CreatePatientRecordCommand.cs — PatientId (Guid)
- CreatePatientRecordHandler.cs — calls PatientRecordService, returns PatientRecordDto
- ProcessPdfCommand.cs — PatientRecordId (Guid), FilePath
- ProcessPdfHandler.cs — calls IPdfParser + PatientRecordService, returns PatientRecordDto

## Infrastructure layer 🔄 (next)
- AppDbContext.cs — pending
- Owned Entities for all Value Objects
- PatientRepository.cs — pending
- PatientRecordRepository.cs — pending
- PdfParser.cs — pending (implements IPdfParser using PdfPig)
- DiretorioMonitor.cs — pending
- DiretorioConfig.cs — pending

## Pending
- Queries (when DB is connected)
- API layer
- Unit tests (final step)

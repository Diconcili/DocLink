# Contexto do projeto

## Pilha de tecnologias
- C# / .NET 10
- Arquitetura DDD
- PostgreSQL + EF Core 10 (Npgsql 9.0.4)
- PdfPig 0.1.14

## Decisões de arquitetura
- Divisão da solução: Domínio, Aplicação, Infraestrutura, API, Testes
- A classe base Entity usa GetId() abstrato — implementação não genérica e detalhada
- A classe base ValueObject usa GetEqualityComponents()
- Os construtores usam verificações de null detalhadas (não a sintaxe abreviada ?? throw)
- Sem sealed nas entidades — mantido apenas em Value Objects e IDs
- PatientRecord renomeado de Record (conflito de palavras-chave em C#)

## Camada de domínio ✅
### Compartilhado
- Entity.cs — GetId() abstrato, Equals, GetHashCode
- ValueObject.cs — GetEqualityComponents() abstrato, Equals, GetHashCode

### Paciente
- Patient.cs — Entidade, possui PatientId e FullName
- PatientId.cs — Objeto de Valor, encapsula Guid, possui New() e From()
- FullName.cs — Objeto de Valor, propriedade First + Last + Full
- IPatientRepository.cs — GetByIdAsync, GetAllAsync, AddAsync, UpdateAsync, DeleteAsync
- PatientService.cs — CreateAsync, UpdateNameAsync

### PatientRecord
- PatientRecord.cs — Entidade raiz agregada, possui List<Document>
- PatientRecordId.cs — ValueObject, encapsula Guid
- Document.cs — Entidade dentro do agregado, possui DocumentId + PatientRecordId + PdfMetadata + AddedAt
- DocumentId.cs — ValueObject, encapsula Guid
- PdfMetadata.cs — ValueObject, possui RawText + FileName + ExtractedAt
- IPatientRecordRepository.cs — GetByIdAsync, GetByPatientIdAsync, AddAsync, UpdateAsync, DeleteAsync
- PatientRecordService.cs — CreateAsync, AddDocumen

- ## Camada de infraestrutura 🔄 (próximo)
- AppDbContext.cs — pendente
- Entidades associadas para todos os objetos de valor
- PatientRepository.cs — pendente
- PatientRecordRepository.cs — pendente
- PdfParser.cs — pendente (implementa IPdfParser usando PdfPig)
- DiretorioMonitor.cs — pendente
- DiretorioConfig.cs — pendente

## Pendente
- Consultas (quando o banco de dados estiver conectado)
- Camada de API
- Testes unitários (etapa final)

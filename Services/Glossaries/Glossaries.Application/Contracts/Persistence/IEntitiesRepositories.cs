using Glossaries.Domain.Entities;

namespace Glossaries.Application.Contracts.Persistence
{
    public interface IGlossaryRepository : IAsyncRepository<Glossary> { }
}

using Glossaries.Application.Features.Glossaries.Queries.GetGlossariesList;
using MediatR;

namespace Glossaries.Application.Features.Glossaries.Queries.GetGlossaryById
{
    public class GetGlossaryByIdQuery : IRequest<GlossaryDto>
    {
        public int Id { get; set; }

        public GetGlossaryByIdQuery(int id)
        {
            Id = id;
        }
    }
}

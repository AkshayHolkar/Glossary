using AutoMapper;
using Glossaries.Application.Contracts.Persistence;
using Glossaries.Application.Features.Glossaries.Queries.GetGlossariesList;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Glossaries.Application.Features.Glossaries.Queries.GetGlossaryById
{
    public class GetGlossaryByIdQueryHandler : IRequestHandler<GetGlossaryByIdQuery, GlossaryDto>
    {
        private readonly IGlossaryRepository _glossaryRepository;
        private readonly IMapper _mapper;

        public GetGlossaryByIdQueryHandler(IGlossaryRepository glossaryRepository, IMapper mapper)
        {
            _glossaryRepository = glossaryRepository ?? throw new ArgumentNullException(nameof(glossaryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GlossaryDto> Handle(GetGlossaryByIdQuery request, CancellationToken cancellationToken)
        {
            var glossary = await _glossaryRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GlossaryDto>(glossary);
        }
    }
}

using AutoMapper;
using Glossaries.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Glossaries.Application.Features.Glossaries.Queries.GetGlossariesList
{
    public class GetGlossariesListQueryHandler : IRequestHandler<GetGlossariesListQuery, List<GlossaryDto>>
    {
        private readonly IGlossaryRepository _glossaryRepository;
        private readonly IMapper _mapper;

        public GetGlossariesListQueryHandler(IGlossaryRepository glossaryRepository, IMapper mapper)
        {
            _glossaryRepository = glossaryRepository ?? throw new ArgumentNullException(nameof(glossaryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GlossaryDto>> Handle(GetGlossariesListQuery request, CancellationToken cancellationToken)
        {
            var glossaryList = await _glossaryRepository.GetAllAsync();
            return _mapper.Map<List<GlossaryDto>>(glossaryList);
        }
    }
}

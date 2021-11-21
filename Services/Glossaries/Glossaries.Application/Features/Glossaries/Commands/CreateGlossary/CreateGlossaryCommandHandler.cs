using AutoMapper;
using Glossaries.Application.Contracts.Persistence;
using Glossaries.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Glossaries.Application.Features.Glossaries.Commands.CreateGlossary
{
    public class CreateGlossaryCommandHandler : IRequestHandler<CreateGlossaryCommand, int>
    {
        private readonly IGlossaryRepository _glossaryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateGlossaryCommandHandler> _logger;

        public CreateGlossaryCommandHandler(IGlossaryRepository glossaryRepository, IMapper mapper, ILogger<CreateGlossaryCommandHandler> logger)
        {
            _glossaryRepository = glossaryRepository ?? throw new ArgumentNullException(nameof(glossaryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateGlossaryCommand request, CancellationToken cancellationToken)
        {
            var glossary = _mapper.Map<Glossary>(request);
            var newGlossary = await _glossaryRepository.CreateAsync(glossary);

            _logger.LogInformation($"Glossary is successfully created.");

            return newGlossary.Id;
        }
    }
}

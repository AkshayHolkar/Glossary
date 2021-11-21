using AutoMapper;
using Glossaries.Application.Contracts.Persistence;
using Glossaries.Application.Exceptions;
using Glossaries.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Glossaries.Application.Features.Glossaries.Commands.UpdateGlossary
{
    public class UpdateGlossaryCommandHandler : IRequestHandler<UpdateGlossaryCommand>
    {
        private readonly IGlossaryRepository _glossaryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateGlossaryCommandHandler> _logger;

        public UpdateGlossaryCommandHandler(IGlossaryRepository glossaryRepository, IMapper mapper, ILogger<UpdateGlossaryCommandHandler> logger)
        {
            _glossaryRepository = glossaryRepository ?? throw new ArgumentNullException(nameof(glossaryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateGlossaryCommand request, CancellationToken cancellationToken)
        {
            var glossaryToUpdate = await _glossaryRepository.GetByIdAsync(request.Id);
            if (glossaryToUpdate == null)
            {
                throw new NotFoundException(nameof(Glossary), request.Id);
            }

            _mapper.Map(request, glossaryToUpdate, typeof(UpdateGlossaryCommand), typeof(Glossary));
            await _glossaryRepository.UpdateAsync(glossaryToUpdate);

            _logger.LogInformation("Glossary updated successfully.");

            return Unit.Value;
        }
    }
}

using AutoMapper;
using Glossaries.Application.Contracts.Persistence;
using Glossaries.Application.Exceptions;
using Glossaries.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Glossaries.Application.Features.Glossaries.Commands.DeleteGlossary
{
    public class DeleteGlossaryCommandHandler : IRequestHandler<DeleteGlossaryCommand>
    {
        private readonly IGlossaryRepository _glossaryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteGlossaryCommandHandler> _logger;

        public DeleteGlossaryCommandHandler(IGlossaryRepository glossaryRepository, IMapper mapper, ILogger<DeleteGlossaryCommandHandler> logger)
        {
            _glossaryRepository = glossaryRepository ?? throw new ArgumentNullException(nameof(glossaryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteGlossaryCommand request, CancellationToken cancellationToken)
        {
            var glossaryToDelete = await _glossaryRepository.GetByIdAsync(request.Id);

            if (glossaryToDelete == null)
            {
                throw new NotFoundException(nameof(Glossary), request.Id);
            }

            await _glossaryRepository.DeleteAsync(request.Id);
            _logger.LogInformation("Glossary deleted successfully.");

            return Unit.Value;
        }
    }
}

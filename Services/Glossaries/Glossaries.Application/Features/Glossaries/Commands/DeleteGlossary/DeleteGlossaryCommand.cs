using MediatR;

namespace Glossaries.Application.Features.Glossaries.Commands.DeleteGlossary
{
    public class DeleteGlossaryCommand : IRequest
    {
        public int Id { get; set; }
    }
}

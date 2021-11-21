using MediatR;

namespace Glossaries.Application.Features.Glossaries.Commands.CreateGlossary
{
    public class CreateGlossaryCommand : IRequest<int>
    {
        public string Term { get; set; }
        public string Definition { get; set; }
    }
}

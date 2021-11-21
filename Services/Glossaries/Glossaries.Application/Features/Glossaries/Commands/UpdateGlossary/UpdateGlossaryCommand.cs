using MediatR;

namespace Glossaries.Application.Features.Glossaries.Commands.UpdateGlossary
{
    public class UpdateGlossaryCommand : IRequest
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
    }
}
